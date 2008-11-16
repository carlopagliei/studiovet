namespace StudioVet.Core {

  partial class DialogHostForm {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogHostForm));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.AccessibleDescription = null;
      this.splitContainer1.AccessibleName = null;
      resources.ApplyResources(this.splitContainer1, "splitContainer1");
      this.splitContainer1.BackgroundImage = null;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer1.Font = null;
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.AccessibleDescription = null;
      this.splitContainer1.Panel1.AccessibleName = null;
      resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
      this.splitContainer1.Panel1.BackgroundImage = null;
      this.splitContainer1.Panel1.Font = null;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.AccessibleDescription = null;
      this.splitContainer1.Panel2.AccessibleName = null;
      resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
      this.splitContainer1.Panel2.BackgroundImage = null;
      this.splitContainer1.Panel2.Controls.Add(this.button2);
      this.splitContainer1.Panel2.Controls.Add(this.button1);
      this.splitContainer1.Panel2.Font = null;
      // 
      // button2
      // 
      this.button2.AccessibleDescription = null;
      this.button2.AccessibleName = null;
      resources.ApplyResources(this.button2, "button2");
      this.button2.BackgroundImage = null;
      this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.button2.Font = null;
      this.button2.Name = "button2";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // button1
      // 
      this.button1.AccessibleDescription = null;
      this.button1.AccessibleName = null;
      resources.ApplyResources(this.button1, "button1");
      this.button1.BackgroundImage = null;
      this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.button1.Font = null;
      this.button1.Name = "button1";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // DialogForm
      // 
      this.AccessibleDescription = null;
      this.AccessibleName = null;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = null;
      this.Controls.Add(this.splitContainer1);
      this.Font = null;
      this.Icon = null;
      this.Name = "DialogForm";
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
  }
}