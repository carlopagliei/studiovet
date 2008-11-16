using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StudioVet.Localization;

namespace StudioVet.Core {
  public partial class CaptureFiles : Form {

    //Carlop.Configuration.RegistryCfgStorage stor = new Carlop.Configuration.RegistryCfgStorage();
    
    public CaptureFiles() {
      InitializeComponent();
      textBox1.Text = AppData.Doma.AutoCapturePath;
      fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(fileSystemWatcher1_Created);
      btnStart.Enabled = true;
      btnStop.Enabled = false;
      button1.Enabled = true;
      Text = translation.btn_captureFolder;
    }

    void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e) {
      listBox1.Items.Insert(0, e.FullPath);
      try {
        System.Threading.Thread.Sleep(100);
        pictureBox1.Load(e.FullPath);
      }
      catch {
      }
      if (FileCaptured != null) 
        FileCaptured(this, e);
    }

    public event EventHandler<System.IO.FileSystemEventArgs> FileCaptured;

    private void _startWatch() {
      fileSystemWatcher1.Path = AppData.Doma.AutoCapturePath;
      fileSystemWatcher1.IncludeSubdirectories = false;
      fileSystemWatcher1.EnableRaisingEvents = true;
    }

    private void _stopWatch() {
      fileSystemWatcher1.EnableRaisingEvents = false;
    }

    private void button1_Click(object sender, EventArgs e) {
      folderBrowserDialog1.SelectedPath = AppData.Doma.AutoCapturePath;
      if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
        textBox1.Text = folderBrowserDialog1.SelectedPath;
        AppData.Doma.AutoCapturePath = textBox1.Text;
      }
    }

    private void btnStart_Click(object sender, EventArgs e) {
      _startWatch();
      btnStart.Enabled = false;
      btnStop.Enabled = true;
      button1.Enabled = false;
    }

    private void btnStop_Click(object sender, EventArgs e) {
      _stopWatch();
      btnStart.Enabled = true;
      btnStop.Enabled = false;
      button1.Enabled = true;
      listBox1.Items.Clear();
    }

    private void CaptureFiles_FormClosing(object sender, FormClosingEventArgs e) {
      btnStop_Click(null, null);
      AppData.Registry.SetValue("AutoCapture", "Top", this.Top);
      AppData.Registry.SetValue("AutoCapture", "Left", this.Left);
    }

    private void CaptureFiles_Load(object sender, EventArgs e) {
      this.Top = AppData.Registry.GetValue("AutoCapture", "Top", this.Top);
      this.Left = AppData.Registry.GetValue("AutoCapture", "Left", this.Left);
    }
  }
}