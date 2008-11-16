namespace StudioVet.Core {
  partial class ServiceDispenseBoosterEdit {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceDispenseBoosterEdit));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.label1 = new System.Windows.Forms.Label();
      this.grid = new System.Windows.Forms.DataGridView();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.btnSave = new System.Windows.Forms.ToolStripButton();
      this.btnUndo = new System.Windows.Forms.ToolStripButton();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
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
      this.splitContainer1.Panel1.Controls.Add(this.label1);
      this.splitContainer1.Panel1MinSize = 10;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
      this.splitContainer1.Panel2.Controls.Add(this.grid);
      this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
      this.splitContainer1.Size = new System.Drawing.Size(305, 271);
      this.splitContainer1.SplitterDistance = 28;
      this.splitContainer1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(305, 28);
      this.label1.TabIndex = 0;
      this.label1.Text = "label1";
      // 
      // grid
      // 
      this.grid.AllowUserToResizeRows = false;
      this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
      this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grid.Location = new System.Drawing.Point(0, 25);
      this.grid.Name = "grid";
      this.grid.RowHeadersWidth = 20;
      this.grid.Size = new System.Drawing.Size(305, 214);
      this.grid.TabIndex = 1;
      this.grid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grid_UserAddedRow);
      this.grid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_UserDeletingRow);
      this.grid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellLeave);
      this.grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnUndo});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(305, 25);
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
      // ServiceDispenseBoosterEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer1);
      this.Name = "ServiceDispenseBoosterEdit";
      this.Size = new System.Drawing.Size(305, 271);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton btnSave;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridView grid;
    private System.Windows.Forms.ToolStripButton btnUndo;
  }
}
