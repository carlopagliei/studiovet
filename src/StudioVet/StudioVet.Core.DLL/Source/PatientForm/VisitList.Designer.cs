namespace StudioVet.Core {
  partial class VisitListEdit {
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
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.label1 = new System.Windows.Forms.Label();
      this.grid = new System.Windows.Forms.DataGridView();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
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
      this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
      this.splitContainer1.Panel1.Controls.Add(this.label1);
      this.splitContainer1.Panel1.ForeColor = System.Drawing.SystemColors.Info;
      this.splitContainer1.Panel1MinSize = 0;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.grid);
      this.splitContainer1.Size = new System.Drawing.Size(507, 277);
      this.splitContainer1.SplitterDistance = 25;
      this.splitContainer1.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(56, 23);
      this.label1.TabIndex = 1;
      this.label1.Text = "Title";
      // 
      // grid
      // 
      this.grid.BackgroundColor = System.Drawing.Color.Lavender;
      this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grid.Cursor = System.Windows.Forms.Cursors.AppStarting;
      this.grid.Location = new System.Drawing.Point(21, 18);
      this.grid.MultiSelect = false;
      this.grid.Name = "grid";
      this.grid.Size = new System.Drawing.Size(356, 209);
      this.grid.TabIndex = 0;
      this.grid.SizeChanged += new System.EventHandler(this.grid_SizeChanged);
      this.grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grid_DataBindingComplete);
      this.grid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grid_CellPainting);
      this.grid.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
      this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
      // 
      // VisitListEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer1);
      this.Name = "VisitListEdit";
      this.Size = new System.Drawing.Size(507, 277);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    public System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridView grid;

  }
}
