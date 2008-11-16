namespace StudioVet
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.components = new System.ComponentModel.Container();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
          this.splitContainer1 = new System.Windows.Forms.SplitContainer();
          this.borderPanel = new System.Windows.Forms.Panel();
          this.adPanel = new System.Windows.Forms.Panel();
          this.adLink5 = new System.Windows.Forms.LinkLabel();
          this.adTitlePanel = new System.Windows.Forms.Panel();
          this.adTitleImage = new System.Windows.Forms.PictureBox();
          this.adTitleLabel = new System.Windows.Forms.Label();
          this.adLink1 = new System.Windows.Forms.LinkLabel();
          this.adLink2 = new System.Windows.Forms.LinkLabel();
          this.adLink3 = new System.Windows.Forms.LinkLabel();
          this.adLink4 = new System.Windows.Forms.LinkLabel();
          this.rmPanel = new System.Windows.Forms.Panel();
          this.rmLink2 = new System.Windows.Forms.LinkLabel();
          this.rmTitlePanel = new System.Windows.Forms.Panel();
          this.rmTitleImage = new System.Windows.Forms.PictureBox();
          this.rmTitleLabel = new System.Windows.Forms.Label();
          this.rmLink1 = new System.Windows.Forms.LinkLabel();
          this.cpPanel = new System.Windows.Forms.Panel();
          this.cpLink3 = new System.Windows.Forms.LinkLabel();
          this.labPatient = new System.Windows.Forms.Label();
          this.labCustomer = new System.Windows.Forms.Label();
          this.ePatient = new System.Windows.Forms.TextBox();
          this.eCustomer = new System.Windows.Forms.TextBox();
          this.cpTitlePanel = new System.Windows.Forms.Panel();
          this.cpTitleImage = new System.Windows.Forms.PictureBox();
          this.cpTitleLabel = new System.Windows.Forms.Label();
          this.cpLink1 = new System.Windows.Forms.LinkLabel();
          this.cpLink2 = new System.Windows.Forms.LinkLabel();
          this.pClientBorder = new System.Windows.Forms.Panel();
          this.pClient = new System.Windows.Forms.Panel();
          this.pictureBox1 = new System.Windows.Forms.PictureBox();
          this.splitContainer2 = new System.Windows.Forms.SplitContainer();
          this.statusStrip1 = new System.Windows.Forms.StatusStrip();
          this.menuStrip1 = new System.Windows.Forms.MenuStrip();
          this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.selectLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.italianoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.databaseSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
          this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.aboutStudioVetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.timer1 = new System.Windows.Forms.Timer(this.components);
          this.splitContainer1.Panel1.SuspendLayout();
          this.splitContainer1.Panel2.SuspendLayout();
          this.splitContainer1.SuspendLayout();
          this.borderPanel.SuspendLayout();
          this.adPanel.SuspendLayout();
          this.adTitlePanel.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.adTitleImage)).BeginInit();
          this.rmPanel.SuspendLayout();
          this.rmTitlePanel.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.rmTitleImage)).BeginInit();
          this.cpPanel.SuspendLayout();
          this.cpTitlePanel.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.cpTitleImage)).BeginInit();
          this.pClientBorder.SuspendLayout();
          this.pClient.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
          this.splitContainer2.Panel1.SuspendLayout();
          this.splitContainer2.Panel2.SuspendLayout();
          this.splitContainer2.SuspendLayout();
          this.menuStrip1.SuspendLayout();
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
          this.splitContainer1.Panel1.Controls.Add(this.borderPanel);
          resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
          // 
          // splitContainer1.Panel2
          // 
          this.splitContainer1.Panel2.Controls.Add(this.pClientBorder);
          resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
          // 
          // borderPanel
          // 
          this.borderPanel.BackColor = System.Drawing.SystemColors.ControlDark;
          this.borderPanel.Controls.Add(this.adPanel);
          this.borderPanel.Controls.Add(this.rmPanel);
          this.borderPanel.Controls.Add(this.cpPanel);
          resources.ApplyResources(this.borderPanel, "borderPanel");
          this.borderPanel.Name = "borderPanel";
          // 
          // adPanel
          // 
          this.adPanel.BackColor = System.Drawing.SystemColors.Control;
          this.adPanel.Controls.Add(this.adLink5);
          this.adPanel.Controls.Add(this.adTitlePanel);
          this.adPanel.Controls.Add(this.adLink1);
          this.adPanel.Controls.Add(this.adLink2);
          this.adPanel.Controls.Add(this.adLink3);
          this.adPanel.Controls.Add(this.adLink4);
          resources.ApplyResources(this.adPanel, "adPanel");
          this.adPanel.ForeColor = System.Drawing.Color.LightCoral;
          this.adPanel.Name = "adPanel";
          // 
          // adLink5
          // 
          resources.ApplyResources(this.adLink5, "adLink5");
          this.adLink5.LinkColor = System.Drawing.SystemColors.WindowText;
          this.adLink5.Name = "adLink5";
          this.adLink5.TabStop = true;
          this.adLink5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.adLink5_LinkClicked);
          // 
          // adTitlePanel
          // 
          this.adTitlePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
          this.adTitlePanel.Controls.Add(this.adTitleImage);
          this.adTitlePanel.Controls.Add(this.adTitleLabel);
          resources.ApplyResources(this.adTitlePanel, "adTitlePanel");
          this.adTitlePanel.ForeColor = System.Drawing.Color.White;
          this.adTitlePanel.Name = "adTitlePanel";
          // 
          // adTitleImage
          // 
          resources.ApplyResources(this.adTitleImage, "adTitleImage");
          this.adTitleImage.Name = "adTitleImage";
          this.adTitleImage.TabStop = false;
          // 
          // adTitleLabel
          // 
          resources.ApplyResources(this.adTitleLabel, "adTitleLabel");
          this.adTitleLabel.ForeColor = System.Drawing.SystemColors.Window;
          this.adTitleLabel.Name = "adTitleLabel";
          // 
          // adLink1
          // 
          resources.ApplyResources(this.adLink1, "adLink1");
          this.adLink1.LinkColor = System.Drawing.SystemColors.WindowText;
          this.adLink1.Name = "adLink1";
          this.adLink1.TabStop = true;
          this.adLink1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.adLink4_LinkClicked);
          // 
          // adLink2
          // 
          resources.ApplyResources(this.adLink2, "adLink2");
          this.adLink2.LinkColor = System.Drawing.SystemColors.WindowText;
          this.adLink2.Name = "adLink2";
          this.adLink2.TabStop = true;
          this.adLink2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.adLink3_LinkClicked);
          // 
          // adLink3
          // 
          resources.ApplyResources(this.adLink3, "adLink3");
          this.adLink3.LinkColor = System.Drawing.SystemColors.WindowText;
          this.adLink3.Name = "adLink3";
          this.adLink3.TabStop = true;
          this.adLink3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
          // 
          // adLink4
          // 
          resources.ApplyResources(this.adLink4, "adLink4");
          this.adLink4.LinkColor = System.Drawing.SystemColors.WindowText;
          this.adLink4.Name = "adLink4";
          this.adLink4.TabStop = true;
          this.adLink4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.adLink2_LinkClicked);
          // 
          // rmPanel
          // 
          this.rmPanel.BackColor = System.Drawing.SystemColors.Control;
          this.rmPanel.Controls.Add(this.rmLink2);
          this.rmPanel.Controls.Add(this.rmTitlePanel);
          this.rmPanel.Controls.Add(this.rmLink1);
          resources.ApplyResources(this.rmPanel, "rmPanel");
          this.rmPanel.ForeColor = System.Drawing.Color.LightCoral;
          this.rmPanel.Name = "rmPanel";
          // 
          // rmLink2
          // 
          resources.ApplyResources(this.rmLink2, "rmLink2");
          this.rmLink2.LinkColor = System.Drawing.SystemColors.WindowText;
          this.rmLink2.Name = "rmLink2";
          this.rmLink2.TabStop = true;
          this.rmLink2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.rmLink2_LinkClicked);
          // 
          // rmTitlePanel
          // 
          this.rmTitlePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
          this.rmTitlePanel.Controls.Add(this.rmTitleImage);
          this.rmTitlePanel.Controls.Add(this.rmTitleLabel);
          resources.ApplyResources(this.rmTitlePanel, "rmTitlePanel");
          this.rmTitlePanel.ForeColor = System.Drawing.Color.White;
          this.rmTitlePanel.Name = "rmTitlePanel";
          // 
          // rmTitleImage
          // 
          resources.ApplyResources(this.rmTitleImage, "rmTitleImage");
          this.rmTitleImage.Name = "rmTitleImage";
          this.rmTitleImage.TabStop = false;
          // 
          // rmTitleLabel
          // 
          resources.ApplyResources(this.rmTitleLabel, "rmTitleLabel");
          this.rmTitleLabel.ForeColor = System.Drawing.SystemColors.Window;
          this.rmTitleLabel.Name = "rmTitleLabel";
          // 
          // rmLink1
          // 
          resources.ApplyResources(this.rmLink1, "rmLink1");
          this.rmLink1.LinkColor = System.Drawing.SystemColors.WindowText;
          this.rmLink1.Name = "rmLink1";
          this.rmLink1.TabStop = true;
          this.rmLink1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.rmLink1_LinkClicked);
          // 
          // cpPanel
          // 
          this.cpPanel.BackColor = System.Drawing.SystemColors.Control;
          this.cpPanel.Controls.Add(this.cpLink3);
          this.cpPanel.Controls.Add(this.labPatient);
          this.cpPanel.Controls.Add(this.labCustomer);
          this.cpPanel.Controls.Add(this.ePatient);
          this.cpPanel.Controls.Add(this.eCustomer);
          this.cpPanel.Controls.Add(this.cpTitlePanel);
          this.cpPanel.Controls.Add(this.cpLink1);
          this.cpPanel.Controls.Add(this.cpLink2);
          resources.ApplyResources(this.cpPanel, "cpPanel");
          this.cpPanel.ForeColor = System.Drawing.Color.LightCoral;
          this.cpPanel.Name = "cpPanel";
          // 
          // cpLink3
          // 
          resources.ApplyResources(this.cpLink3, "cpLink3");
          this.cpLink3.LinkColor = System.Drawing.SystemColors.WindowText;
          this.cpLink3.Name = "cpLink3";
          this.cpLink3.TabStop = true;
          this.cpLink3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cpLink3_LinkClicked);
          // 
          // labPatient
          // 
          resources.ApplyResources(this.labPatient, "labPatient");
          this.labPatient.ForeColor = System.Drawing.SystemColors.WindowText;
          this.labPatient.Name = "labPatient";
          // 
          // labCustomer
          // 
          resources.ApplyResources(this.labCustomer, "labCustomer");
          this.labCustomer.ForeColor = System.Drawing.SystemColors.WindowText;
          this.labCustomer.Name = "labCustomer";
          // 
          // ePatient
          // 
          this.ePatient.BorderStyle = System.Windows.Forms.BorderStyle.None;
          resources.ApplyResources(this.ePatient, "ePatient");
          this.ePatient.Name = "ePatient";
          this.ePatient.KeyUp += new System.Windows.Forms.KeyEventHandler(this.eCustomer_KeyUp);
          // 
          // eCustomer
          // 
          this.eCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
          resources.ApplyResources(this.eCustomer, "eCustomer");
          this.eCustomer.Name = "eCustomer";
          this.eCustomer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.eCustomer_KeyUp);
          // 
          // cpTitlePanel
          // 
          this.cpTitlePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
          this.cpTitlePanel.Controls.Add(this.cpTitleImage);
          this.cpTitlePanel.Controls.Add(this.cpTitleLabel);
          resources.ApplyResources(this.cpTitlePanel, "cpTitlePanel");
          this.cpTitlePanel.ForeColor = System.Drawing.Color.White;
          this.cpTitlePanel.Name = "cpTitlePanel";
          // 
          // cpTitleImage
          // 
          resources.ApplyResources(this.cpTitleImage, "cpTitleImage");
          this.cpTitleImage.Name = "cpTitleImage";
          this.cpTitleImage.TabStop = false;
          // 
          // cpTitleLabel
          // 
          resources.ApplyResources(this.cpTitleLabel, "cpTitleLabel");
          this.cpTitleLabel.ForeColor = System.Drawing.SystemColors.Window;
          this.cpTitleLabel.Name = "cpTitleLabel";
          // 
          // cpLink1
          // 
          resources.ApplyResources(this.cpLink1, "cpLink1");
          this.cpLink1.LinkColor = System.Drawing.SystemColors.WindowText;
          this.cpLink1.Name = "cpLink1";
          this.cpLink1.TabStop = true;
          this.cpLink1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cpLink1_LinkClicked);
          // 
          // cpLink2
          // 
          resources.ApplyResources(this.cpLink2, "cpLink2");
          this.cpLink2.LinkColor = System.Drawing.SystemColors.WindowText;
          this.cpLink2.Name = "cpLink2";
          this.cpLink2.TabStop = true;
          this.cpLink2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cpLink2_LinkClicked);
          // 
          // pClientBorder
          // 
          this.pClientBorder.Controls.Add(this.pClient);
          resources.ApplyResources(this.pClientBorder, "pClientBorder");
          this.pClientBorder.Name = "pClientBorder";
          // 
          // pClient
          // 
          this.pClient.Controls.Add(this.pictureBox1);
          resources.ApplyResources(this.pClient, "pClient");
          this.pClient.Name = "pClient";
          // 
          // pictureBox1
          // 
          resources.ApplyResources(this.pictureBox1, "pictureBox1");
          this.pictureBox1.Name = "pictureBox1";
          this.pictureBox1.TabStop = false;
          this.pictureBox1.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox1_LoadCompleted);
          // 
          // splitContainer2
          // 
          resources.ApplyResources(this.splitContainer2, "splitContainer2");
          this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
          this.splitContainer2.Name = "splitContainer2";
          // 
          // splitContainer2.Panel1
          // 
          this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
          // 
          // splitContainer2.Panel2
          // 
          this.splitContainer2.Panel2.Controls.Add(this.statusStrip1);
          // 
          // statusStrip1
          // 
          resources.ApplyResources(this.statusStrip1, "statusStrip1");
          this.statusStrip1.Name = "statusStrip1";
          // 
          // menuStrip1
          // 
          this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
          resources.ApplyResources(this.menuStrip1, "menuStrip1");
          this.menuStrip1.Name = "menuStrip1";
          // 
          // fileToolStripMenuItem
          // 
          this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
          this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
          resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
          // 
          // exitToolStripMenuItem
          // 
          this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
          resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
          this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
          // 
          // optionsToolStripMenuItem
          // 
          this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectLanguageToolStripMenuItem,
            this.databaseSetupToolStripMenuItem,
            this.optionsToolStripMenuItem1});
          this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
          resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
          // 
          // selectLanguageToolStripMenuItem
          // 
          this.selectLanguageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.italianoToolStripMenuItem});
          this.selectLanguageToolStripMenuItem.Name = "selectLanguageToolStripMenuItem";
          resources.ApplyResources(this.selectLanguageToolStripMenuItem, "selectLanguageToolStripMenuItem");
          // 
          // englishToolStripMenuItem
          // 
          this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
          resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
          this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
          // 
          // italianoToolStripMenuItem
          // 
          this.italianoToolStripMenuItem.Name = "italianoToolStripMenuItem";
          resources.ApplyResources(this.italianoToolStripMenuItem, "italianoToolStripMenuItem");
          this.italianoToolStripMenuItem.Click += new System.EventHandler(this.italianoToolStripMenuItem_Click);
          // 
          // databaseSetupToolStripMenuItem
          // 
          this.databaseSetupToolStripMenuItem.Name = "databaseSetupToolStripMenuItem";
          resources.ApplyResources(this.databaseSetupToolStripMenuItem, "databaseSetupToolStripMenuItem");
          this.databaseSetupToolStripMenuItem.Click += new System.EventHandler(this.databaseSetupToolStripMenuItem_Click);
          // 
          // optionsToolStripMenuItem1
          // 
          this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
          resources.ApplyResources(this.optionsToolStripMenuItem1, "optionsToolStripMenuItem1");
          this.optionsToolStripMenuItem1.Click += new System.EventHandler(this.optionsToolStripMenuItem1_Click);
          // 
          // helpToolStripMenuItem
          // 
          this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutStudioVetToolStripMenuItem});
          this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
          resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
          // 
          // aboutStudioVetToolStripMenuItem
          // 
          this.aboutStudioVetToolStripMenuItem.Name = "aboutStudioVetToolStripMenuItem";
          resources.ApplyResources(this.aboutStudioVetToolStripMenuItem, "aboutStudioVetToolStripMenuItem");
          this.aboutStudioVetToolStripMenuItem.Click += new System.EventHandler(this.aboutStudioVetToolStripMenuItem_Click);
          // 
          // timer1
          // 
          this.timer1.Enabled = true;
          this.timer1.Interval = 2000;
          this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
          // 
          // MainForm
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.splitContainer2);
          this.Controls.Add(this.menuStrip1);
          this.MainMenuStrip = this.menuStrip1;
          this.Name = "MainForm";
          this.splitContainer1.Panel1.ResumeLayout(false);
          this.splitContainer1.Panel2.ResumeLayout(false);
          this.splitContainer1.ResumeLayout(false);
          this.borderPanel.ResumeLayout(false);
          this.adPanel.ResumeLayout(false);
          this.adPanel.PerformLayout();
          this.adTitlePanel.ResumeLayout(false);
          this.adTitlePanel.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.adTitleImage)).EndInit();
          this.rmPanel.ResumeLayout(false);
          this.rmPanel.PerformLayout();
          this.rmTitlePanel.ResumeLayout(false);
          this.rmTitlePanel.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.rmTitleImage)).EndInit();
          this.cpPanel.ResumeLayout(false);
          this.cpPanel.PerformLayout();
          this.cpTitlePanel.ResumeLayout(false);
          this.cpTitlePanel.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.cpTitleImage)).EndInit();
          this.pClientBorder.ResumeLayout(false);
          this.pClient.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
          this.splitContainer2.Panel1.ResumeLayout(false);
          this.splitContainer2.Panel2.ResumeLayout(false);
          this.splitContainer2.Panel2.PerformLayout();
          this.splitContainer2.ResumeLayout(false);
          this.menuStrip1.ResumeLayout(false);
          this.menuStrip1.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.SplitContainer splitContainer2;
      private System.Windows.Forms.Panel cpPanel;
      private System.Windows.Forms.LinkLabel cpLink1;
      private System.Windows.Forms.LinkLabel cpLink2;
      private System.Windows.Forms.Panel cpTitlePanel;
      private System.Windows.Forms.Label cpTitleLabel;
      private System.Windows.Forms.Panel borderPanel;
      private System.Windows.Forms.Panel rmPanel;
      private System.Windows.Forms.LinkLabel rmLink1;
      private System.Windows.Forms.Panel rmTitlePanel;
      private System.Windows.Forms.Label rmTitleLabel;
      private System.Windows.Forms.Panel adPanel;
      private System.Windows.Forms.LinkLabel adLink1;
      private System.Windows.Forms.LinkLabel adLink2;
      private System.Windows.Forms.LinkLabel adLink3;
      private System.Windows.Forms.Panel adTitlePanel;
      private System.Windows.Forms.Label adTitleLabel;
      private System.Windows.Forms.LinkLabel adLink4;
      private System.Windows.Forms.PictureBox rmTitleImage;
      private System.Windows.Forms.PictureBox adTitleImage;
      private System.Windows.Forms.PictureBox cpTitleImage;
      private System.Windows.Forms.Panel pClientBorder;
      private System.Windows.Forms.Panel pClient;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Timer timer1;
      private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem selectLanguageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem italianoToolStripMenuItem;
      private System.Windows.Forms.Label labPatient;
      private System.Windows.Forms.Label labCustomer;
      private System.Windows.Forms.TextBox ePatient;
      private System.Windows.Forms.TextBox eCustomer;
      private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem aboutStudioVetToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem databaseSetupToolStripMenuItem;
      private System.Windows.Forms.LinkLabel adLink5;
      private System.Windows.Forms.LinkLabel cpLink3;
      private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
      private System.Windows.Forms.LinkLabel rmLink2;
    }
}

