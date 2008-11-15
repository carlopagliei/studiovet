using System;
using System.Threading;

namespace Carlop.ClassLib.Threading {


  /// <summary>
  /// Used to notify that a wait handle has been signaled/set
  /// </summary>
  /// <param name="sender">The MultiSignalThread object that owns the thread</param>
  /// <param name="arrayIndex">The index in the WaitHandles property</param>
  public delegate void ThreadSignalDelegate(object sender, int arrayIndex);

  /// <summary>
  /// Used to notify that an event occurred
  /// </summary>
  /// <param name="sender">The MultiSignalThread object that owns the thread</param>
  public delegate void ThreadEventDelegate(object sender);


  
  /// <summary>
  /// A class that encapsulate basic thread management: Start/Stop methods, multiple
  /// object waiting, peridic timeout and callbacks
  /// </summary>
  public class MultiSignalThread {

    private WaitHandle[] _eventsToWaitFor;
    private WaitHandle[] _waitHandles;
    private AutoResetEvent _exitSignal;
    private Thread _threadObj;
    private bool _running = false;
    private string _name = null;
    private ThreadPriority _priority = ThreadPriority.Normal;
    private int _waitTimeout = Timeout.Infinite;
    private bool _terminateAsap = false;

    private void _run() {
      if (BeforeStart != null) { 
        BeforeStart(this); 
      }
      ThreadInit();
      try {
        ThreadExecute();
      }
      finally {
        ThreadShutdown();
      }
      if (AfterStop != null) { 
        AfterStop(this); 
      }
    }



    //---(protected)---

    /// <summary>
    /// called at the very beginning of the thread proc
    /// </summary>
    protected virtual void ThreadInit() {
      if (WaitHandles != null) {
        _eventsToWaitFor = new WaitHandle[1 + WaitHandles.Length];
        for (int i = 0; i < WaitHandles.Length; i++) {
          _eventsToWaitFor[i + 1] = WaitHandles[i];
        }
      }
      else {
        _eventsToWaitFor = new WaitHandle[1];
      }
      _eventsToWaitFor[0] = _exitSignal;
      //int i = 0;
      //foreach(WaitHandle w in WaitHandles) { _eventsToWaitFor[i++] = w; }
    }
    /// <summary>
    /// called just before the thread termnates
    /// </summary>
    protected virtual void ThreadShutdown() {
    }
    /// <summary>
    /// manages thread lifetime and execution
    /// </summary>
    protected virtual void ThreadExecute() {
      int elapsedEvent = 0;
      do {
        try {
          elapsedEvent = WaitHandle.WaitAny(_eventsToWaitFor, WaitTimeout, false);
          if (elapsedEvent == WaitHandle.WaitTimeout) {
            TimeoutElapsed(this);
          }
          else
            if (elapsedEvent > 0) {
              if (SignalElapsed != null) {
                SignalElapsed(this, elapsedEvent - 1);
              }
            }
        }
        catch (AbandonedMutexException) {
          //
        }
      } while ((elapsedEvent != 0) && (!_terminateAsap));
    }



    //---(public)---

    /// <summary>
    /// Constructor
    /// </summary>
    public MultiSignalThread() {
      _exitSignal = new AutoResetEvent(false);
    }

    /// <summary>
    /// Gets or sets the name of the thread
    /// </summary>
    public string Name {
      get { 
        if (string.IsNullOrEmpty(_name)) return this.GetType().Name; 
        else return _name; 
      }
      set { _name = value; }
    }
    /// <summary>
    /// If different than Timeout.Infinite (default) the thread calls the 
    /// TimeoutElapsed event each time a new interval (millisec) elapses
    /// </summary>
    public int WaitTimeout {
      get { return _waitTimeout; }
      set { _waitTimeout = value; }
    }
    /// <summary>
    /// Gets or sets a value indicating the scheduling priority of a thread
    /// </summary>
    public ThreadPriority Priority {
      get { return _priority; }
      set { _priority = value; }
    }
    /// <summary>
    /// Sets the Handles array that the thread has to wait for. Changes to this
    /// property while thread is running has no effect
    /// </summary>
    public WaitHandle[] WaitHandles {
      get { return _waitHandles; }
      set { _waitHandles = value; }
    }
    /// <summary>
    /// True if the thread is running
    /// </summary>
    public bool Running {
      get { return _running; }
    }


    /// <summary>
    /// Starts the thread
    /// </summary>
    public void Start() {
      if (!_running) {
        _terminateAsap = false;
        _threadObj = new Thread(new ThreadStart(_run));
        _threadObj.IsBackground = true;
        _threadObj.Priority = this.Priority;
        _threadObj.Name = this.Name;
        _threadObj.Start();
        _running = true;
      }
    }
    /// <summary>
    /// Stops the thread and exits immediatly
    /// </summary>
    public void Stop() {
      this.Stop(false, -1);
    }
    /// <summary>
    /// Stops the thread and block until terminates
    /// </summary>
    /// <param name="waitTermination">if true the methods blocks else it exits immediately</param>
    /// <param name="timeout">if waitTermination==true, this is the wait interval in msec (-1 = infinite)</param>
    public void Stop(bool waitTermination, int timeout) {
      if (_running) {
        _terminateAsap = true;
        _exitSignal.Set(); // signal to exit
        if (waitTermination) _threadObj.Join(timeout);
        _running = false;
      }
    }


    /// <summary>
    /// launched when a wait handle (see WaitHandles property) is set.
    /// This event is launched from inside the thread
    /// </summary>
    public event ThreadSignalDelegate SignalElapsed;
    /// <summary>
    /// Lauched periodically if no handles is set during the wait period.
    /// This event is launched from inside the thread
    /// </summary>
    public event ThreadEventDelegate TimeoutElapsed;
    /// <summary>
    /// Launched at the very beginning of the thread proc. This event is launched from inside the thread
    /// </summary>
    public event ThreadEventDelegate BeforeStart;
    /// <summary>
    /// Launched just before the thread terminates. This event is launched from inside the thread
    /// </summary>
    public event ThreadEventDelegate AfterStop;


  }


}