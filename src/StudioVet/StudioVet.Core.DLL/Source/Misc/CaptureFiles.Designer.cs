namespace StudioVet.Core {
  partial class CaptureFiles {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureFiles));
      this.label1 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.btnStart = new System.Windows.Forms.Button();
      this.btnStop = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AccessibleDescription = null;
      this.label1.AccessibleName = null;
      resources.ApplyResources(this.label1, "label1");
      this.label1.Font = null;
      this.label1.Name = "label1";
      // 
      // textBox1
      // 
      this.textBox1.AccessibleDescription = null;
      this.textBox1.AccessibleName = null;
      resources.ApplyResources(this.textBox1, "textBox1");
      this.textBox1.BackgroundImage = null;
      this.textBox1.Font = null;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      // 
      // button1
      // 
      this.button1.AccessibleDescription = null;
      this.button1.AccessibleName = null;
      resources.ApplyResources(this.button1, "button1");
      this.button1.BackgroundImage = null;
      this.button1.Font = null;
      this.button1.Name = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // folderBrowserDialog1
      // 
      resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
      // 
      // fileSystemWatcher1
      // 
      this.fileSystemWatcher1.EnableRaisingEvents = true;
      this.fileSystemWatcher1.SynchronizingObject = this;
      // 
      // pictureBox1
      // 
      this.pictureBox1.AccessibleDescription = null;
      this.pictureBox1.AccessibleName = null;
      resources.ApplyResources(this.pictureBox1, "pictureBox1");
      this.pictureBox1.BackgroundImage = null;
      this.pictureBox1.Font = null;
      this.pictureBox1.ImageLocation = null;
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.TabStop = false;
      // 
      // listBox1
      // 
      this.listBox1.AccessibleDescription = null;
      this.listBox1.AccessibleName = null;
      resources.ApplyResources(this.listBox1, "listBox1");
      this.listBox1.BackColor = System.Drawing.SystemColors.Control;
      this.listBox1.BackgroundImage = null;
      this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.listBox1.Font = null;
      this.listBox1.ForeColor = System.Drawing.SystemColors.GrayText;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Name = "listBox1";
      // 
      // btnStart
      // 
      this.btnStart.AccessibleDescription = null;
      this.btnStart.AccessibleName = null;
      resources.ApplyResources(this.btnStart, "btnStart");
      this.btnStart.BackgroundImage = null;
      this.btnStart.Font = null;
      this.btnStart.Name = "btnStart";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // btnStop
      // 
      this.btnStop.AccessibleDescription = null;
      this.btnStop.AccessibleName = null;
      resources.ApplyResources(this.btnStop, "btnStop");
      this.btnStop.BackgroundImage = null;
      this.btnStop.Font = null;
      this.btnStop.Name = "btnStop";
      this.btnStop.UseVisualStyleBackColor = true;
      this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
      // 
      // CaptureFiles
      // 
      this.AccessibleDescription = null;
      this.AccessibleName = null;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = null;
      this.Controls.Add(this.btnStop);
      this.Controls.Add(this.btnStart);
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.label1);
      this.Font = null;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = null;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CaptureFiles";
      this.TopMost = true;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CaptureFiles_FormClosing);
      this.Load += new System.EventHandler(this.CaptureFiles_Load);
      ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.IO.FileSystemWatcher fileSystemWatcher1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Button btnStop;
    private System.Windows.Forms.Button btnStart;
  }
}