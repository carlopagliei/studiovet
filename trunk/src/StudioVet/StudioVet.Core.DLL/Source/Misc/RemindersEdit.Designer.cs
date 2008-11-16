namespace StudioVet.Core {
  partial class RemindersEdit {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemindersEdit));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnExit = new System.Windows.Forms.Button();
      this.titleImage = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.btnApply = new System.Windows.Forms.ToolStripButton();
      this.btnUndo = new System.Windows.Forms.ToolStripButton();
      this.grid = new System.Windows.Forms.DataGridView();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.btnHTML = new System.Windows.Forms.ToolStripButton();
      this.btnPrint = new System.Windows.Forms.ToolStripButton();
      this.btnPageSetup = new System.Windows.Forms.ToolStripButton();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.titleImage)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer1.IsSplitterFixed = true;
      this.splitContainer1.Location = new System.Drawing.Point(2, 2);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
      this.splitContainer1.Panel1.Controls.Add(this.panel1);
      this.splitContainer1.Panel1.Controls.Add(this.titleImage);
      this.splitContainer1.Panel1.Controls.Add(this.label1);
      this.splitContainer1.Panel1.ForeColor = System.Drawing.SystemColors.Info;
      this.splitContainer1.Panel1MinSize = 37;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
      this.splitContainer1.Size = new System.Drawing.Size(503, 273);
      this.splitContainer1.SplitterDistance = 37;
      this.splitContainer1.TabIndex = 2;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnExit);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel1.Location = new System.Drawing.Point(466, 0);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(8);
      this.panel1.Size = new System.Drawing.Size(37, 37);
      this.panel1.TabIndex = 5;
      // 
      // btnExit
      // 
      this.btnExit.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnExit.Location = new System.Drawing.Point(8, 8);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(21, 21);
      this.btnExit.TabIndex = 4;
      this.btnExit.UseVisualStyleBackColor = true;
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
      // 
      // titleImage
      // 
      this.titleImage.Location = new System.Drawing.Point(3, 3);
      this.titleImage.Name = "titleImage";
      this.titleImage.Size = new System.Drawing.Size(32, 32);
      this.titleImage.TabIndex = 3;
      this.titleImage.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(41, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(56, 23);
      this.label1.TabIndex = 1;
      this.label1.Text = "Title";
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer2.IsSplitterFixed = true;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.toolStrip1);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.grid);
      this.splitContainer2.Size = new System.Drawing.Size(503, 232);
      this.splitContainer2.SplitterDistance = 26;
      this.splitContainer2.TabIndex = 1;
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnApply,
            this.btnUndo,
            this.toolStripSeparator1,
            this.btnHTML,
            this.btnPrint,
            this.btnPageSetup});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(503, 25);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // btnApply
      // 
      this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
      this.btnApply.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnApply.Name = "btnApply";
      this.btnApply.Size = new System.Drawing.Size(99, 22);
      this.btnApply.Text = "Apply Changes";
      this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
      // 
      // btnUndo
      // 
      this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
      this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnUndo.Name = "btnUndo";
      this.btnUndo.Size = new System.Drawing.Size(97, 22);
      this.btnUndo.Text = "Undo Changes";
      this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
      // 
      // grid
      // 
      this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
      this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grid.Location = new System.Drawing.Point(19, 17);
      this.grid.Name = "grid";
      this.grid.Size = new System.Drawing.Size(240, 150);
      this.grid.TabIndex = 0;
      this.grid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellLeave);
      this.grid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grid_UserDeletedRow);
      this.grid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grid_CellPainting);
      this.grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
      this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // btnHTML
      // 
      this.btnHTML.Image = ((System.Drawing.Image)(resources.GetObject("btnHTML.Image")));
      this.btnHTML.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnHTML.Name = "btnHTML";
      this.btnHTML.Size = new System.Drawing.Size(48, 22);
      this.btnHTML.Text = "Html";
      this.btnHTML.Click += new System.EventHandler(this.btnHTML_Click);
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
      // btnPageSetup
      // 
      this.btnPageSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnPageSetup.Image")));
      this.btnPageSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnPageSetup.Name = "btnPageSetup";
      this.btnPageSetup.Size = new System.Drawing.Size(81, 22);
      this.btnPageSetup.Text = "Page setup";
      this.btnPageSetup.Click += new System.EventHandler(this.btnPageSetup_Click);
      // 
      // RemindersEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer1);
      this.Name = "RemindersEdit";
      this.Padding = new System.Windows.Forms.Padding(2);
      this.Size = new System.Drawing.Size(507, 277);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.titleImage)).EndInit();
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel1.PerformLayout();
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.ResumeLayout(false);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    public System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox titleImage;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton btnApply;
    private System.Windows.Forms.ToolStripButton btnUndo;
    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.DataGridView grid;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton btnHTML;
    private System.Windows.Forms.ToolStripButton btnPrint;
    private System.Windows.Forms.ToolStripButton btnPageSetup;

  }
}
