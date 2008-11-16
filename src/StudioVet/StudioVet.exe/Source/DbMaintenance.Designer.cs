namespace StudioVet {
  partial class DbMaintenance {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbMaintenance));
      this.label1 = new System.Windows.Forms.Label();
      this.eServer = new System.Windows.Forms.TextBox();
      this.eDatabase = new System.Windows.Forms.TextBox();
      this.rbWin = new System.Windows.Forms.RadioButton();
      this.rbSQL = new System.Windows.Forms.RadioButton();
      this.eUser = new System.Windows.Forms.TextBox();
      this.ePassword = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.panel4 = new System.Windows.Forms.Panel();
      this.label9 = new System.Windows.Forms.Label();
      this.button3 = new System.Windows.Forms.Button();
      this.label8 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel4.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // eServer
      // 
      resources.ApplyResources(this.eServer, "eServer");
      this.eServer.Name = "eServer";
      // 
      // eDatabase
      // 
      resources.ApplyResources(this.eDatabase, "eDatabase");
      this.eDatabase.Name = "eDatabase";
      // 
      // rbWin
      // 
      resources.ApplyResources(this.rbWin, "rbWin");
      this.rbWin.Checked = true;
      this.rbWin.Name = "rbWin";
      this.rbWin.TabStop = true;
      this.rbWin.UseVisualStyleBackColor = true;
      this.rbWin.Click += new System.EventHandler(this.rbSQL_Click);
      // 
      // rbSQL
      // 
      resources.ApplyResources(this.rbSQL, "rbSQL");
      this.rbSQL.Name = "rbSQL";
      this.rbSQL.UseVisualStyleBackColor = true;
      this.rbSQL.Click += new System.EventHandler(this.rbSQL_Click);
      // 
      // eUser
      // 
      resources.ApplyResources(this.eUser, "eUser");
      this.eUser.Name = "eUser";
      // 
      // ePassword
      // 
      resources.ApplyResources(this.ePassword, "ePassword");
      this.ePassword.Name = "ePassword";
      // 
      // label2
      // 
      resources.ApplyResources(this.label2, "label2");
      this.label2.Name = "label2";
      // 
      // label3
      // 
      resources.ApplyResources(this.label3, "label3");
      this.label3.Name = "label3";
      // 
      // label4
      // 
      resources.ApplyResources(this.label4, "label4");
      this.label4.Name = "label4";
      // 
      // label5
      // 
      resources.ApplyResources(this.label5, "label5");
      this.label5.Name = "label5";
      // 
      // button1
      // 
      resources.ApplyResources(this.button1, "button1");
      this.button1.Name = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // btnOk
      // 
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      resources.ApplyResources(this.btnOk, "btnOk");
      this.btnOk.Name = "btnOk";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      resources.ApplyResources(this.btnCancel, "btnCancel");
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.eServer);
      this.panel1.Controls.Add(this.eDatabase);
      this.panel1.Controls.Add(this.rbWin);
      this.panel1.Controls.Add(this.rbSQL);
      this.panel1.Controls.Add(this.button1);
      this.panel1.Controls.Add(this.eUser);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.ePassword);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label3);
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Name = "panel1";
      // 
      // panel2
      // 
      resources.ApplyResources(this.panel2, "panel2");
      this.panel2.Name = "panel2";
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.btnOk);
      this.panel3.Controls.Add(this.btnCancel);
      resources.ApplyResources(this.panel3, "panel3");
      this.panel3.Name = "panel3";
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.label9);
      this.panel4.Controls.Add(this.button3);
      this.panel4.Controls.Add(this.label8);
      resources.ApplyResources(this.panel4, "panel4");
      this.panel4.Name = "panel4";
      // 
      // label9
      // 
      resources.ApplyResources(this.label9, "label9");
      this.label9.BackColor = System.Drawing.Color.Pink;
      this.label9.ForeColor = System.Drawing.Color.Maroon;
      this.label9.Name = "label9";
      // 
      // button3
      // 
      resources.ApplyResources(this.button3, "button3");
      this.button3.Name = "button3";
      this.button3.UseVisualStyleBackColor = true;
      // 
      // label8
      // 
      resources.ApplyResources(this.label8, "label8");
      this.label8.Name = "label8";
      // 
      // DbMaintenance
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel4);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "DbMaintenance";
      this.ShowInTaskbar = false;
      this.Load += new System.EventHandler(this.DbMaintenance_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox eServer;
    private System.Windows.Forms.TextBox eDatabase;
    private System.Windows.Forms.RadioButton rbWin;
    private System.Windows.Forms.RadioButton rbSQL;
    private System.Windows.Forms.TextBox eUser;
    private System.Windows.Forms.TextBox ePassword;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
  }
}