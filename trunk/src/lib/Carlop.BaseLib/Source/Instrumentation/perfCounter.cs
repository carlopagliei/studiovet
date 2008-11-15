using System;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using Carlop.Utils;


namespace Carlop.Instrumentation {




  /// <summary>
  /// This class has been adapted from the original Ryan Seghers HighResClock class
  /// Here we have the original disclaimer
  /// ==================================================================================
  /// HighResClock.cs
  /// Copyright (C) 2003-2004 Ryan Seghers
  /// This software is provided AS IS. No warranty is granted, 
  /// neither expressed nor implied. USE THIS SOFTWARE AT YOUR OWN RISK.
  /// NO REPRESENTATION OF MERCHANTABILITY or FITNESS FOR ANY 
  /// PURPOSE is given.
  /// License to use this software is limited by the following terms:
  /// 1) This code may be used in any program, including programs developed
  ///    for commercial purposes, provided that this notice is included verbatim.
  /// Also, in return for using this code, please attempt to make your fixes and
  /// updates available in some way, such as by sending your updates to the
  /// author.
  /// ==================================================================================
  /// </summary>
  public sealed class PerfCounter {

    // ------------------------------------------------------------------------------
    // private

    // DllImports
    [DllImport("kernel32", EntryPoint = "QueryPerformanceCounter")]
    private static extern uint win32_QueryPerformanceCounter(ref Int64 t);
    [DllImport("kernel32", EntryPoint = "QueryPerformanceFrequency")]
    private static extern uint win32_QueryPerformanceFrequency(ref Int64 t);

    private static Int64 _perfFreq = 0;
    private static Int64 _overheadTicks;
    private static Int64 _k32TicksOffset;
    private static Int64 _counter1;
    // ------------------------------------------------------------------------------
    // public


    // contructor
    static PerfCounter() { Calibrate(); }

    /// <summary>
    /// This represents the number of ticks it takes to make a duration measurement, and 
    /// is therefore the effective resolution that can be measured
    /// </summary>
    public static Int64 Resolution {
      get { return (_overheadTicks); }
    }
    /// <summary>
    /// returns the hires counter frequency
    /// </summary>
    public static Int64 Frequency {
      get { return (_perfFreq); }
    }

    /// <summary>
    /// Measure overhead for interop calls and clock resolution.
    /// </summary>
    public static void Calibrate() {
      win32_QueryPerformanceFrequency(ref _perfFreq);

      // boost process and thread priority temporarily
      ThreadPriority oldThreadPriority = Thread.CurrentThread.Priority;
      Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;

      Process proc = Process.GetCurrentProcess();
      ProcessPriorityClass oldProcPriorityClass = proc.PriorityClass;
      proc.PriorityClass = ProcessPriorityClass.RealTime;

      try {
        // calc offset between our ticks and DateTime
        _k32TicksOffset = NowTicks - DateTime.Now.Ticks;

        // calculate measurement overhead by taking a set of measurements
        long start, stop = 0;
        _overheadTicks = Int64.MaxValue;

        for (int i = 0; i < 10; i++) {
          start = NowTicks;
          stop = NowTicks;
          long ticks = stop - start;
          if (ticks > 0 && ticks < _overheadTicks) _overheadTicks = ticks;
        }

        // handle case where no measurement gave us a difference
        // in case the overhead is under the perf counter resolution
        if (_overheadTicks == Int64.MaxValue) _overheadTicks = 0;

        //Console.WriteLine("perfFreq = {0}, overheadTicks = {1}, overheadMs = {2}", 
        //	perfFreq, overheadTicks, TicksToMs(overheadTicks));
      }
      finally {
        Thread.CurrentThread.Priority = oldThreadPriority;
        proc.PriorityClass = oldProcPriorityClass;
      }
    }
    /// <summary>
    /// A simple self test. true means all ok
    /// </summary>
    /// <param name="param">not used</param>
    public static void SelfTest(String param) {
      Console.WriteLine("=======================================================");
      Console.WriteLine("PerformanceCounter.SelfTest\r\n");
      Console.WriteLine("param='{0}'", param);

      Calibrate();
      Console.WriteLine("\n");
      Console.WriteLine("Measurement overhead: {0} ticks", PerfCounter.Resolution);
      Console.WriteLine("Frequency: {0} cpuTicks/sec", PerfCounter.Frequency);

      double realFreq = 1.4 * 1024 * 1024 * 1024;
      Console.WriteLine("1.4 GHz CPU clock freq / perf counter freq = {0:f3}",
         realFreq / PerfCounter.Frequency);

      // figure out how often high perf counter wraps
      double rangeSeconds = (double)long.MaxValue / PerfCounter.Frequency;
      double rangeDays = rangeSeconds / (3600 * 24);
      double rangeYears = rangeDays / 365;
      Console.WriteLine("Span of clock is {0:e3} s, {1:e3} d, {2:e3} years",
        rangeSeconds, rangeDays, rangeYears);

      long start = PerfCounter.NowTicks;
      long stop = PerfCounter.NowTicks;
      long stop1 = PerfCounter.NowTicks;

      Console.WriteLine("duration: {0} ms", PerfCounter.CalcTimeSpan(start, stop).TotalMilliseconds);
      Console.WriteLine("duration1: {0} ms", PerfCounter.CalcTimeSpan(start, stop1).TotalMilliseconds);
      Console.WriteLine("duration: {0} ms", PerfCounter.CalcTimeSpan(start).TotalMilliseconds);

      // check against sleep
      start = PerfCounter.NowTicks;
      int sleepTime = 100;
      Thread.Sleep(sleepTime);
      stop = PerfCounter.NowTicks;
      double d = PerfCounter.CalcTimeSpan(start, stop).TotalMilliseconds;
      Console.WriteLine("Slept {0} ms and that gave measured {1:f2} ms",
        sleepTime, d);
      Console.WriteLine("    (This is typically a little off (5ms?), probably due to "
        + "thread scheduling latencies.)");

      // try TimeSpan
      TimeSpan span = PerfCounter.CalcTimeSpan(start, stop);
      Console.WriteLine("The same duration as a time span is {0} ms", span.TotalMilliseconds);

      // try DateTime
      Console.WriteLine("My DateTime: {0},   .Net's DateTime: {1}",
        PerfCounter.Now, DateTime.Now);

      // time something with DateTime
      DateTime startDateTime = DateTime.Now;
      DateTime startHrc = PerfCounter.Now;

      // kill some time
      double res = 0.0;
      for (int i = 0; i < 50000; i++) {
        res += Math.Sin(Math.Cos(Math.Acos(1.0)));
      }

      span = DateTime.Now - startDateTime;
      TimeSpan spanHrc = PerfCounter.Now - startHrc;
      Console.WriteLine("DateTime's timing: {0} ms", span.TotalMilliseconds);
      Console.WriteLine("HighResClock's timing: {0} ms", spanHrc.TotalMilliseconds);

      // check DateTime's resolution
      startDateTime = DateTime.Now;
      double maxMsGap = 100000;
      for (int i = 0; i < 100; i++) {
        double msGap = ((TimeSpan)(DateTime.Now - startDateTime)).TotalMilliseconds;
        Thread.Sleep(1);
        if ((msGap > 0) && (msGap < maxMsGap)) maxMsGap = msGap;
      }
      Console.WriteLine("DateTime's resolution is {0:f2} ms", maxMsGap);

      // check HighResClock's DateTime resolution
      startDateTime = PerfCounter.Now;
      maxMsGap = 100000;
      for (int i = 0; i < 100; i++) {
        double msGap = ((TimeSpan)(PerfCounter.Now - startDateTime)).TotalMilliseconds;
        Thread.Sleep(1);
        if ((msGap > 0) && (msGap < maxMsGap)) maxMsGap = msGap;
      }
      Console.WriteLine("HighResClock's DateTime resolution is {0} ms", maxMsGap);

    }


    /// <summary>
    /// Gets the tick count from the clock. No adjustment is made 
    /// to this due to OverheadTicks
    /// </summary>
    static void FetchCounter() {
      if (_perfFreq == 0) {
        throw new NotSupportedException("This system does not have a high performance counter.");
      }
      win32_QueryPerformanceCounter(ref _counter1);
    }
    /// <summary>
    /// Returns the current counter value in system ticks
    /// </summary>
    public static Int64 NowTicks {
      get {
        FetchCounter();
        // convert to .Net ticks
        return ((Int64)(_counter1 / ((float)_perfFreq / 1e7)));
      }
    }
    /// <summary>
    /// converts the current counter value to string. Dots
    /// are added so that string is in the following format: Seconds.Millisec.Microsec
    /// </summary>
    /// <returns></returns>
    public new static String ToString() {
      Int64 us = NowTicks / 10;
      // convert to .Net ticks
      System.Text.StringBuilder s = new System.Text.StringBuilder();
      s.Append(us.ToString());
      s.Insert(s.Length - 6, ".");
      s.Insert(s.Length - 3, ".");
      return (s.ToString());
    }


    /// <summary>
    /// returns datetime with the maximun available resolution
    /// </summary>
    public static DateTime Now {
      get {
        return (new DateTime(NowTicks - _k32TicksOffset));
      }
    }


    /// <summary>
    /// Convert ticks to milliseconds. (A tick is 100 nanoseconds.)
    /// No adjustment is made to this due to OverheadTicks 
    /// </summary>
    /// <param name="ticks"></param>
    /// <returns></returns>
    public static float ConvertTicksToMs(Int64 ticks) {
      return ((float)ticks / 10000);
    }
    /// <summary>
    /// Calculate the duration (to NowTicks) as a TimeSpan. subtracts OverheadTicks from the measured ticks
    /// </summary>
    /// <param name="startTicks"></param>
    /// <param name="stopTicks"></param>
    /// <returns></returns>
    public static TimeSpan CalcTimeSpan(Int64 startTicks, Int64 stopTicks) {
      long ticks = stopTicks - startTicks;
      ticks -= _overheadTicks;
      ticks = Math.Max(0, ticks);
      return (new TimeSpan(ticks));
    }
    /// <summary>
    /// Calculate the duration (to NowTicks) as a TimeSpan. subtracts OverheadTicks from the measured ticks
    /// </summary>
    /// <param name="startTicks"></param>
    /// <returns></returns>
    public static TimeSpan CalcTimeSpan(Int64 startTicks) {
      return (CalcTimeSpan(startTicks, NowTicks));
    }
    /// <summary>
    /// Calculate the duration (to NowTicks) as a TimeSpan. subtracts OverheadTicks from the measured ticks
    /// </summary>
    /// <param name="startTime"></param>
    /// <returns></returns>
    public static TimeSpan CalcTimeSpan(DateTime startTime) {
      return (CalcTimeSpan(startTime.Ticks, NowTicks));
    }
    /// <summary>
    /// Calculate the duration (to NowTicks) as a TimeSpan. subtracts OverheadTicks from the measured ticks
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="stopTime"></param>
    /// <returns></returns>
    public static TimeSpan CalcTimeSpan(DateTime startTime, DateTime stopTime) {
      return (CalcTimeSpan(startTime.Ticks, stopTime.Ticks));
    }

  }

  /// <summary>
  /// This class can be used to measure time intervals with the maximum
  /// possible accuracy (see PerfCounter.Resolution)
  /// </summary>
  public class PerfStopwatch {
    private Int64 _counterI;
    public PerfStopwatch() {
      Reset();
    }
    /// <summary>
    /// Resets the stopwatch
    /// </summary>
    public void Reset() {
      _counterI = PerfCounter.NowTicks;
    }
    /// <summary>
    /// returns how many ticks has been elapsed since last reset 
    /// (10000000 ticks per second)
    /// </summary>
    public Int64 Ticks {
      get { return PerfCounter.NowTicks - _counterI; }
    }
    /// <summary>
    /// writes the actual tick value
    /// </summary>
    /// <returns>the actual stopwatch value as string</returns>
    public string ElapsedTicks() {
      return this.Ticks.ToString();
    }
    /// <summary>
    /// writes the actual tick value in microseconds (ticks/10)
    /// </summary>
    /// <returns>the actual stopwatch value as microseconds string</returns>
    public string ElapsedMicrosec() {
      //System.Text.StringBuilder s = new System.Text.StringBuilder();
      //s.Append((this.Ticks / 10).ToString());
      //if (s.Length > 6) s.Insert(s.Length - 6, ".");
      //if (s.Length > 3) s.Insert(s.Length - 3, ",");
      //return s.ToString();
      return (this.Ticks / 10).ToString();
    }
    /// <summary>
    /// writes the actual tick value in a time fashion HH:MM:SS.millisec,microsec
    /// </summary>
    /// <returns>the actual stopwatch value in a time fashion</returns>
    public string ElapsedTime() {
      Int64 t = this.Ticks;
      DateTime d = new DateTime(t);
      System.Text.StringBuilder s = new System.Text.StringBuilder();
      s.Append((t / 10).ToString());
      if (s.Length > 3) s.Insert(s.Length - 3, ",");
      return (d.ToString(@"HH\:mm\:ss\.") + StrUtils.RightSubstring(s.ToString(), 7));
    }


  }


}
