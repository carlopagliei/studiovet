namespace StudioVet.Core {
  partial class SelectPaymentTerm {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectPaymentTerm));
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
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
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // label1
      // 
      this.label1.AccessibleDescription = null;
      this.label1.AccessibleName = null;
      resources.ApplyResources(this.label1, "label1");
      this.label1.Font = null;
      this.label1.Name = "label1";
      this.label1.Click += new System.EventHandler(this.label1_Click);
      // 
      // comboBox1
      // 
      this.comboBox1.AccessibleDescription = null;
      this.comboBox1.AccessibleName = null;
      resources.ApplyResources(this.comboBox1, "comboBox1");
      this.comboBox1.BackgroundImage = null;
      this.comboBox1.Font = null;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
      // 
      // SelectPaymentTerm
      // 
      this.AcceptButton = this.button1;
      this.AccessibleDescription = null;
      this.AccessibleName = null;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = null;
      this.CancelButton = this.button2;
      this.Controls.Add(this.comboBox1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Font = null;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = null;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SelectPaymentTerm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBox1;
  }
}