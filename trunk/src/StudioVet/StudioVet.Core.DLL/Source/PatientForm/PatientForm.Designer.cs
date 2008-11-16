namespace StudioVet.Core {
  partial class PatientForm {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientForm));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.btnShowVisits = new System.Windows.Forms.ToolStripButton();
      this.btnShowVaccines = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.btnNewVisit = new System.Windows.Forms.ToolStripButton();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.lpanBorder = new System.Windows.Forms.Panel();
      this.lpanContainer = new System.Windows.Forms.Panel();
      this.splitContainer3 = new System.Windows.Forms.SplitContainer();
      this.cpanBorder = new System.Windows.Forms.Panel();
      this.cpanContainer = new System.Windows.Forms.Panel();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.lpanBorder.SuspendLayout();
      this.lpanContainer.SuspendLayout();
      this.splitContainer3.SuspendLayout();
      this.cpanBorder.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      resources.ApplyResources(this.splitContainer1, "splitContainer1");
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowVisits,
            this.toolStripLabel1,
            this.btnShowVaccines,
            this.toolStripSeparator1,
            this.btnNewVisit});
      resources.ApplyResources(this.toolStrip1, "toolStrip1");
      this.toolStrip1.Name = "toolStrip1";
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.toolStripLabel1.Name = "toolStripLabel1";
      resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
      // 
      // btnShowVisits
      // 
      resources.ApplyResources(this.btnShowVisits, "btnShowVisits");
      this.btnShowVisits.Name = "btnShowVisits";
      this.btnShowVisits.Click += new System.EventHandler(this.btnShowVisits_Click);
      // 
      // btnShowVaccines
      // 
      resources.ApplyResources(this.btnShowVaccines, "btnShowVaccines");
      this.btnShowVaccines.Name = "btnShowVaccines";
      this.btnShowVaccines.Click += new System.EventHandler(this.btnShowVaccines_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      // 
      // btnNewVisit
      // 
      resources.ApplyResources(this.btnNewVisit, "btnNewVisit");
      this.btnNewVisit.Name = "btnNewVisit";
      this.btnNewVisit.Click += new System.EventHandler(this.btnNewVisit_Click);
      // 
      // splitContainer2
      // 
      resources.ApplyResources(this.splitContainer2, "splitContainer2");
      this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.lpanBorder);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.cpanBorder);
      // 
      // lpanBorder
      // 
      this.lpanBorder.Controls.Add(this.lpanContainer);
      resources.ApplyResources(this.lpanBorder, "lpanBorder");
      this.lpanBorder.Name = "lpanBorder";
      // 
      // lpanContainer
      // 
      this.lpanContainer.Controls.Add(this.splitContainer3);
      resources.ApplyResources(this.lpanContainer, "lpanContainer");
      this.lpanContainer.Name = "lpanContainer";
      // 
      // splitContainer3
      // 
      resources.ApplyResources(this.splitContainer3, "splitContainer3");
      this.splitContainer3.Name = "splitContainer3";
      // 
      // cpanBorder
      // 
      this.cpanBorder.Controls.Add(this.cpanContainer);
      resources.ApplyResources(this.cpanBorder, "cpanBorder");
      this.cpanBorder.Name = "cpanBorder";
      // 
      // cpanContainer
      // 
      resources.ApplyResources(this.cpanContainer, "cpanContainer");
      this.cpanContainer.Name = "cpanContainer";
      // 
      // PatientForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer1);
      this.Name = "PatientForm";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.ResumeLayout(false);
      this.lpanBorder.ResumeLayout(false);
      this.lpanContainer.ResumeLayout(false);
      this.splitContainer3.ResumeLayout(false);
      this.cpanBorder.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton btnNewVisit;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.Panel lpanContainer;
    private System.Windows.Forms.Panel cpanBorder;
    private System.Windows.Forms.Panel lpanBorder;
    private System.Windows.Forms.Panel cpanContainer;
    private System.Windows.Forms.ToolStripButton btnShowVisits;
    private System.Windows.Forms.ToolStripButton btnShowVaccines;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.SplitContainer splitContainer3;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;

  }
}