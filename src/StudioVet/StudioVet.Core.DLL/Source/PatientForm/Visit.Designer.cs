namespace StudioVet.Core {
  partial class VisitEdit {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisitEdit));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitContainer3 = new System.Windows.Forms.SplitContainer();
      this.titleImage = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.btnSave = new System.Windows.Forms.ToolStripButton();
      this.btnCreateInvoice = new System.Windows.Forms.ToolStripButton();
      this.btnPrintInvoice = new System.Windows.Forms.ToolStripButton();
      this.btnPrintReport = new System.Windows.Forms.ToolStripButton();
      this.btnPageSetup = new System.Windows.Forms.ToolStripButton();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.panel2 = new System.Windows.Forms.Panel();
      this.labReport = new System.Windows.Forms.Label();
      this.eReport = new System.Windows.Forms.TextBox();
      this.labNotes = new System.Windows.Forms.Label();
      this.eNotes = new System.Windows.Forms.TextBox();
      this.labDoctor = new System.Windows.Forms.Label();
      this.labVisitType = new System.Windows.Forms.Label();
      this.eDoctor = new System.Windows.Forms.TextBox();
      this.dtVisitDatetime = new System.Windows.Forms.DateTimePicker();
      this.labDescription = new System.Windows.Forms.Label();
      this.eDescription = new System.Windows.Forms.TextBox();
      this.cbVisitType = new System.Windows.Forms.ComboBox();
      this.labVisitDatetime = new System.Windows.Forms.Label();
      this.panel5 = new System.Windows.Forms.Panel();
      this.panel6 = new System.Windows.Forms.Panel();
      this.splitContainer4 = new System.Windows.Forms.SplitContainer();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.splitContainer3.Panel1.SuspendLayout();
      this.splitContainer3.Panel2.SuspendLayout();
      this.splitContainer3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.titleImage)).BeginInit();
      this.toolStrip1.SuspendLayout();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel6.SuspendLayout();
      this.splitContainer4.Panel1.SuspendLayout();
      this.splitContainer4.SuspendLayout();
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
      this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
      this.splitContainer1.Panel1MinSize = 37;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
      this.splitContainer1.Size = new System.Drawing.Size(846, 676);
      this.splitContainer1.SplitterDistance = 66;
      this.splitContainer1.TabIndex = 3;
      // 
      // splitContainer3
      // 
      this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer3.IsSplitterFixed = true;
      this.splitContainer3.Location = new System.Drawing.Point(0, 0);
      this.splitContainer3.Name = "splitContainer3";
      this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer3.Panel1
      // 
      this.splitContainer3.Panel1.Controls.Add(this.titleImage);
      this.splitContainer3.Panel1.Controls.Add(this.label1);
      this.splitContainer3.Panel1MinSize = 37;
      // 
      // splitContainer3.Panel2
      // 
      this.splitContainer3.Panel2.Controls.Add(this.toolStrip1);
      this.splitContainer3.Size = new System.Drawing.Size(846, 66);
      this.splitContainer3.SplitterDistance = 37;
      this.splitContainer3.TabIndex = 0;
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
      this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
      this.label1.Location = new System.Drawing.Point(41, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(56, 23);
      this.label1.TabIndex = 1;
      this.label1.Text = "Title";
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnCreateInvoice,
            this.btnPrintInvoice,
            this.btnPrintReport,
            this.btnPageSetup});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(846, 25);
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
      // btnCreateInvoice
      // 
      this.btnCreateInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateInvoice.Image")));
      this.btnCreateInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnCreateInvoice.Name = "btnCreateInvoice";
      this.btnCreateInvoice.Size = new System.Drawing.Size(96, 22);
      this.btnCreateInvoice.Text = "Create invoice";
      this.btnCreateInvoice.Click += new System.EventHandler(this.btnCreateInvoice_Click);
      // 
      // btnPrintInvoice
      // 
      this.btnPrintInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintInvoice.Image")));
      this.btnPrintInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnPrintInvoice.Name = "btnPrintInvoice";
      this.btnPrintInvoice.Size = new System.Drawing.Size(85, 22);
      this.btnPrintInvoice.Text = "Print invoice";
      this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
      // 
      // btnPrintReport
      // 
      this.btnPrintReport.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintReport.Image")));
      this.btnPrintReport.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnPrintReport.Name = "btnPrintReport";
      this.btnPrintReport.Size = new System.Drawing.Size(82, 22);
      this.btnPrintReport.Text = "Print report";
      this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
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
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.panel2);
      this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(2);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.panel5);
      this.splitContainer2.Size = new System.Drawing.Size(846, 606);
      this.splitContainer2.SplitterDistance = 134;
      this.splitContainer2.TabIndex = 7;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.labReport);
      this.panel2.Controls.Add(this.eReport);
      this.panel2.Controls.Add(this.labNotes);
      this.panel2.Controls.Add(this.eNotes);
      this.panel2.Controls.Add(this.labDoctor);
      this.panel2.Controls.Add(this.labVisitType);
      this.panel2.Controls.Add(this.eDoctor);
      this.panel2.Controls.Add(this.dtVisitDatetime);
      this.panel2.Controls.Add(this.labDescription);
      this.panel2.Controls.Add(this.eDescription);
      this.panel2.Controls.Add(this.cbVisitType);
      this.panel2.Controls.Add(this.labVisitDatetime);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(2, 2);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(842, 130);
      this.panel2.TabIndex = 0;
      this.panel2.Resize += new System.EventHandler(this.panel2_Resize);
      // 
      // labReport
      // 
      this.labReport.AutoSize = true;
      this.labReport.Location = new System.Drawing.Point(3, 39);
      this.labReport.Name = "labReport";
      this.labReport.Size = new System.Drawing.Size(39, 13);
      this.labReport.TabIndex = 11;
      this.labReport.Text = "Report";
      // 
      // eReport
      // 
      this.eReport.Location = new System.Drawing.Point(3, 55);
      this.eReport.Multiline = true;
      this.eReport.Name = "eReport";
      this.eReport.Size = new System.Drawing.Size(479, 72);
      this.eReport.TabIndex = 4;
      this.eReport.TextChanged += new System.EventHandler(this.eReport_TextChanged);
      // 
      // labNotes
      // 
      this.labNotes.AutoSize = true;
      this.labNotes.Location = new System.Drawing.Point(488, 39);
      this.labNotes.Name = "labNotes";
      this.labNotes.Size = new System.Drawing.Size(35, 13);
      this.labNotes.TabIndex = 9;
      this.labNotes.Text = "Notes";
      // 
      // eNotes
      // 
      this.eNotes.Location = new System.Drawing.Point(488, 55);
      this.eNotes.Multiline = true;
      this.eNotes.Name = "eNotes";
      this.eNotes.Size = new System.Drawing.Size(351, 72);
      this.eNotes.TabIndex = 5;
      this.eNotes.TextChanged += new System.EventHandler(this.eReport_TextChanged);
      // 
      // labDoctor
      // 
      this.labDoctor.AutoSize = true;
      this.labDoctor.Location = new System.Drawing.Point(313, 0);
      this.labDoctor.Name = "labDoctor";
      this.labDoctor.Size = new System.Drawing.Size(39, 13);
      this.labDoctor.TabIndex = 7;
      this.labDoctor.Text = "Doctor";
      // 
      // labVisitType
      // 
      this.labVisitType.AutoSize = true;
      this.labVisitType.Location = new System.Drawing.Point(137, 0);
      this.labVisitType.Name = "labVisitType";
      this.labVisitType.Size = new System.Drawing.Size(53, 13);
      this.labVisitType.TabIndex = 6;
      this.labVisitType.Text = "Visit Type";
      // 
      // eDoctor
      // 
      this.eDoctor.Location = new System.Drawing.Point(316, 16);
      this.eDoctor.Name = "eDoctor";
      this.eDoctor.Size = new System.Drawing.Size(166, 20);
      this.eDoctor.TabIndex = 2;
      this.eDoctor.TextChanged += new System.EventHandler(this.eReport_TextChanged);
      // 
      // dtVisitDatetime
      // 
      this.dtVisitDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtVisitDatetime.Location = new System.Drawing.Point(3, 16);
      this.dtVisitDatetime.Name = "dtVisitDatetime";
      this.dtVisitDatetime.Size = new System.Drawing.Size(131, 20);
      this.dtVisitDatetime.TabIndex = 0;
      this.dtVisitDatetime.ValueChanged += new System.EventHandler(this.dtVisitDatetime_ValueChanged);
      // 
      // labDescription
      // 
      this.labDescription.AutoSize = true;
      this.labDescription.Location = new System.Drawing.Point(485, 0);
      this.labDescription.Name = "labDescription";
      this.labDescription.Size = new System.Drawing.Size(60, 13);
      this.labDescription.TabIndex = 3;
      this.labDescription.Text = "Description";
      // 
      // eDescription
      // 
      this.eDescription.Location = new System.Drawing.Point(488, 16);
      this.eDescription.Name = "eDescription";
      this.eDescription.Size = new System.Drawing.Size(351, 20);
      this.eDescription.TabIndex = 3;
      this.eDescription.TextChanged += new System.EventHandler(this.eReport_TextChanged);
      // 
      // cbVisitType
      // 
      this.cbVisitType.FormattingEnabled = true;
      this.cbVisitType.Location = new System.Drawing.Point(140, 16);
      this.cbVisitType.Name = "cbVisitType";
      this.cbVisitType.Size = new System.Drawing.Size(170, 21);
      this.cbVisitType.TabIndex = 1;
      this.cbVisitType.VisibleChanged += new System.EventHandler(this.cbVisitType_VisibleChanged);
      this.cbVisitType.TextChanged += new System.EventHandler(this.eReport_TextChanged);
      // 
      // labVisitDatetime
      // 
      this.labVisitDatetime.AutoSize = true;
      this.labVisitDatetime.Location = new System.Drawing.Point(0, 0);
      this.labVisitDatetime.Name = "labVisitDatetime";
      this.labVisitDatetime.Size = new System.Drawing.Size(30, 13);
      this.labVisitDatetime.TabIndex = 0;
      this.labVisitDatetime.Text = "Date";
      // 
      // panel5
      // 
      this.panel5.Controls.Add(this.panel6);
      this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel5.Location = new System.Drawing.Point(0, 0);
      this.panel5.Name = "panel5";
      this.panel5.Padding = new System.Windows.Forms.Padding(1);
      this.panel5.Size = new System.Drawing.Size(846, 468);
      this.panel5.TabIndex = 1;
      // 
      // panel6
      // 
      this.panel6.Controls.Add(this.splitContainer4);
      this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel6.Location = new System.Drawing.Point(1, 1);
      this.panel6.Name = "panel6";
      this.panel6.Size = new System.Drawing.Size(844, 466);
      this.panel6.TabIndex = 0;
      this.panel6.Resize += new System.EventHandler(this.panel6_Resize);
      // 
      // splitContainer4
      // 
      this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer4.Location = new System.Drawing.Point(0, 0);
      this.splitContainer4.Name = "splitContainer4";
      this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer4.Panel1
      // 
      this.splitContainer4.Panel1.Controls.Add(this.tableLayoutPanel1);
      this.splitContainer4.Panel1MinSize = 100;
      this.splitContainer4.Size = new System.Drawing.Size(844, 466);
      this.splitContainer4.SplitterDistance = 152;
      this.splitContainer4.TabIndex = 1;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(844, 152);
      this.tableLayoutPanel1.TabIndex = 3;
      // 
      // VisitEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer1);
      this.Name = "VisitEdit";
      this.Padding = new System.Windows.Forms.Padding(2);
      this.Size = new System.Drawing.Size(850, 680);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer3.Panel1.ResumeLayout(false);
      this.splitContainer3.Panel1.PerformLayout();
      this.splitContainer3.Panel2.ResumeLayout(false);
      this.splitContainer3.Panel2.PerformLayout();
      this.splitContainer3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.titleImage)).EndInit();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel5.ResumeLayout(false);
      this.panel6.ResumeLayout(false);
      this.splitContainer4.Panel1.ResumeLayout(false);
      this.splitContainer4.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.PictureBox titleImage;
    public System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label labVisitType;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label labDoctor;
    private System.Windows.Forms.TextBox eDoctor;
    private System.Windows.Forms.DateTimePicker dtVisitDatetime;
    private System.Windows.Forms.Label labDescription;
    private System.Windows.Forms.TextBox eDescription;
    private System.Windows.Forms.ComboBox cbVisitType;
    private System.Windows.Forms.Label labVisitDatetime;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.Panel panel6;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.SplitContainer splitContainer4;
    private System.Windows.Forms.Label labNotes;
    private System.Windows.Forms.TextBox eNotes;
    private System.Windows.Forms.Label labReport;
    private System.Windows.Forms.TextBox eReport;
    private System.Windows.Forms.SplitContainer splitContainer3;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton btnSave;
    private System.Windows.Forms.ToolStripButton btnPrintInvoice;
    private System.Windows.Forms.ToolStripButton btnCreateInvoice;
    private System.Windows.Forms.ToolStripButton btnPageSetup;
    private System.Windows.Forms.ToolStripButton btnPrintReport;
  }
}
