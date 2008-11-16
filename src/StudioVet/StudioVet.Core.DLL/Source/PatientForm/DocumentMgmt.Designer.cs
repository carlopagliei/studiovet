namespace StudioVet.Core {
  partial class DocumentMgmt {
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentMgmt));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.labPath = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.grid = new System.Windows.Forms.DataGridView();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.webBrowser = new System.Windows.Forms.WebBrowser();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.btnSave = new System.Windows.Forms.ToolStripButton();
      this.btnUndo = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.btnAddFile = new System.Windows.Forms.ToolStripButton();
      this.btnCapture = new System.Windows.Forms.ToolStripButton();
      this.btnAcquire = new System.Windows.Forms.ToolStripButton();
      this.btnDeleteFile = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.btnPrint = new System.Windows.Forms.ToolStripButton();
      this.btnShellExec = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.btnNavigateFiles = new System.Windows.Forms.ToolStripButton();
      this.btnOpenPath = new System.Windows.Forms.ToolStripButton();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer1.IsSplitterFixed = true;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.labPath);
      this.splitContainer1.Panel1.Controls.Add(this.label1);
      this.splitContainer1.Panel1MinSize = 10;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
      this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
      this.splitContainer1.Size = new System.Drawing.Size(842, 528);
      this.splitContainer1.SplitterDistance = 28;
      this.splitContainer1.TabIndex = 1;
      // 
      // labPath
      // 
      this.labPath.AutoSize = true;
      this.labPath.Dock = System.Windows.Forms.DockStyle.Right;
      this.labPath.Location = new System.Drawing.Point(807, 0);
      this.labPath.Name = "labPath";
      this.labPath.Size = new System.Drawing.Size(35, 13);
      this.labPath.TabIndex = 1;
      this.labPath.Text = "label2";
      // 
      // label1
      // 
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(842, 28);
      this.label1.TabIndex = 0;
      this.label1.Text = "label1";
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 25);
      this.splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.grid);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.panel1);
      this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(2);
      this.splitContainer2.Size = new System.Drawing.Size(842, 471);
      this.splitContainer2.SplitterDistance = 337;
      this.splitContainer2.TabIndex = 1;
      // 
      // grid
      // 
      this.grid.BackgroundColor = System.Drawing.Color.Gold;
      this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grid.Location = new System.Drawing.Point(15, 14);
      this.grid.Name = "grid";
      this.grid.Size = new System.Drawing.Size(240, 150);
      this.grid.TabIndex = 0;
      this.grid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellLeave);
      this.grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grid_DataBindingComplete);
      this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(2, 2);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(1);
      this.panel1.Size = new System.Drawing.Size(497, 467);
      this.panel1.TabIndex = 0;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.pictureBox);
      this.panel2.Controls.Add(this.webBrowser);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(1, 1);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(495, 465);
      this.panel2.TabIndex = 1;
      // 
      // pictureBox
      // 
      this.pictureBox.Location = new System.Drawing.Point(15, 11);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(84, 84);
      this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox.TabIndex = 1;
      this.pictureBox.TabStop = false;
      this.pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
      // 
      // webBrowser
      // 
      this.webBrowser.Location = new System.Drawing.Point(111, 11);
      this.webBrowser.Margin = new System.Windows.Forms.Padding(0);
      this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
      this.webBrowser.Name = "webBrowser";
      this.webBrowser.ScrollBarsEnabled = false;
      this.webBrowser.Size = new System.Drawing.Size(89, 84);
      this.webBrowser.TabIndex = 0;
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnUndo,
            this.toolStripSeparator3,
            this.btnAddFile,
            this.btnCapture,
            this.btnAcquire,
            this.btnDeleteFile,
            this.toolStripSeparator1,
            this.btnPrint,
            this.btnShellExec,
            this.toolStripSeparator2,
            this.btnNavigateFiles,
            this.btnOpenPath});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(842, 25);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // btnSave
      // 
      this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
      this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(51, 22);
      this.btnSave.Text = "Save";
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnUndo
      // 
      this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
      this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnUndo.Name = "btnUndo";
      this.btnUndo.Size = new System.Drawing.Size(52, 22);
      this.btnUndo.Text = "Undo";
      this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // btnAddFile
      // 
      this.btnAddFile.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFile.Image")));
      this.btnAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnAddFile.Name = "btnAddFile";
      this.btnAddFile.Size = new System.Drawing.Size(63, 22);
      this.btnAddFile.Text = "Add file";
      this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
      // 
      // btnCapture
      // 
      this.btnCapture.Image = ((System.Drawing.Image)(resources.GetObject("btnCapture.Image")));
      this.btnCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnCapture.Name = "btnCapture";
      this.btnCapture.Size = new System.Drawing.Size(88, 22);
      this.btnCapture.Text = "Capture files";
      this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
      // 
      // btnAcquire
      // 
      this.btnAcquire.Image = ((System.Drawing.Image)(resources.GetObject("btnAcquire.Image")));
      this.btnAcquire.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnAcquire.Name = "btnAcquire";
      this.btnAcquire.Size = new System.Drawing.Size(119, 22);
      this.btnAcquire.Text = "Acquire by scanner";
      this.btnAcquire.Click += new System.EventHandler(this.btnAcquire_Click);
      // 
      // btnDeleteFile
      // 
      this.btnDeleteFile.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFile.Image")));
      this.btnDeleteFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnDeleteFile.Name = "btnDeleteFile";
      this.btnDeleteFile.Size = new System.Drawing.Size(83, 22);
      this.btnDeleteFile.Text = "Remove file";
      this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // btnPrint
      // 
      this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
      this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnPrint.Name = "btnPrint";
      this.btnPrint.Size = new System.Drawing.Size(49, 22);
      this.btnPrint.Text = "Print";
      this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
      // 
      // btnShellExec
      // 
      this.btnShellExec.Image = ((System.Drawing.Image)(resources.GetObject("btnShellExec.Image")));
      this.btnShellExec.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnShellExec.Name = "btnShellExec";
      this.btnShellExec.Size = new System.Drawing.Size(91, 22);
      this.btnShellExec.Text = "Shell Execute";
      this.btnShellExec.Click += new System.EventHandler(this.btnShellExec_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // btnNavigateFiles
      // 
      this.btnNavigateFiles.Image = ((System.Drawing.Image)(resources.GetObject("btnNavigateFiles.Image")));
      this.btnNavigateFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnNavigateFiles.Name = "btnNavigateFiles";
      this.btnNavigateFiles.Size = new System.Drawing.Size(63, 22);
      this.btnNavigateFiles.Text = "Explore";
      this.btnNavigateFiles.Click += new System.EventHandler(this.btnExplore_Click);
      // 
      // btnOpenPath
      // 
      this.btnOpenPath.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenPath.Image")));
      this.btnOpenPath.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnOpenPath.Name = "btnOpenPath";
      this.btnOpenPath.Size = new System.Drawing.Size(78, 22);
      this.btnOpenPath.Text = "Open path";
      this.btnOpenPath.Click += new System.EventHandler(this.btnNavigate_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.FileName = "openFileDialog";
      this.openFileDialog.Multiselect = true;
      // 
      // DocumentMgmt
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer1);
      this.Name = "DocumentMgmt";
      this.Size = new System.Drawing.Size(842, 528);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton btnAddFile;
    private System.Windows.Forms.ToolStripButton btnDeleteFile;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.ToolStripButton btnAcquire;
    private System.Windows.Forms.ToolStripButton btnCapture;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton btnPrint;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.WebBrowser webBrowser;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.Label labPath;
    private System.Windows.Forms.ToolStripButton btnNavigateFiles;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.DataGridView grid;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.ToolStripButton btnOpenPath;
    private System.Windows.Forms.ToolStripButton btnSave;
    private System.Windows.Forms.ToolStripButton btnUndo;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripButton btnShellExec;
  }
}
