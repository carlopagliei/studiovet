namespace StudioVet.Core
{
    partial class AnimalDataEdit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.panel2 = new System.Windows.Forms.Panel();
          this.btnNewAnimal = new System.Windows.Forms.Button();
          this.labRace = new System.Windows.Forms.Label();
          this.eAnimalLabel = new System.Windows.Forms.TextBox();
          this.labBirthDate = new System.Windows.Forms.Label();
          this.eBirthDate = new System.Windows.Forms.DateTimePicker();
          this.labPatientID = new System.Windows.Forms.Label();
          this.ePatientID = new System.Windows.Forms.TextBox();
          this.labIdNumber = new System.Windows.Forms.Label();
          this.eIdNumber = new System.Windows.Forms.TextBox();
          this.labFirstName = new System.Windows.Forms.Label();
          this.eFirstName = new System.Windows.Forms.TextBox();
          this.eNotes = new System.Windows.Forms.TextBox();
          this.labNotes = new System.Windows.Forms.Label();
          this.panel2.SuspendLayout();
          this.SuspendLayout();
          // 
          // panel2
          // 
          this.panel2.Controls.Add(this.labNotes);
          this.panel2.Controls.Add(this.eNotes);
          this.panel2.Controls.Add(this.btnNewAnimal);
          this.panel2.Controls.Add(this.labRace);
          this.panel2.Controls.Add(this.eAnimalLabel);
          this.panel2.Controls.Add(this.labBirthDate);
          this.panel2.Controls.Add(this.eBirthDate);
          this.panel2.Controls.Add(this.labPatientID);
          this.panel2.Controls.Add(this.ePatientID);
          this.panel2.Controls.Add(this.labIdNumber);
          this.panel2.Controls.Add(this.eIdNumber);
          this.panel2.Controls.Add(this.labFirstName);
          this.panel2.Controls.Add(this.eFirstName);
          this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panel2.Location = new System.Drawing.Point(4, 4);
          this.panel2.Name = "panel2";
          this.panel2.Size = new System.Drawing.Size(374, 209);
          this.panel2.TabIndex = 47;
          // 
          // btnNewAnimal
          // 
          this.btnNewAnimal.Location = new System.Drawing.Point(349, 92);
          this.btnNewAnimal.Name = "btnNewAnimal";
          this.btnNewAnimal.Size = new System.Drawing.Size(21, 20);
          this.btnNewAnimal.TabIndex = 5;
          this.btnNewAnimal.Text = "...";
          this.btnNewAnimal.UseVisualStyleBackColor = true;
          this.btnNewAnimal.Click += new System.EventHandler(this.btnNewAnimal_Click);
          // 
          // labRace
          // 
          this.labRace.AutoSize = true;
          this.labRace.Location = new System.Drawing.Point(187, 78);
          this.labRace.Name = "labRace";
          this.labRace.Size = new System.Drawing.Size(76, 13);
          this.labRace.TabIndex = 77;
          this.labRace.Text = "Race/Species";
          // 
          // eRace
          // 
          this.eAnimalLabel.Location = new System.Drawing.Point(190, 92);
          this.eAnimalLabel.Name = "eRace";
          this.eAnimalLabel.Size = new System.Drawing.Size(153, 20);
          this.eAnimalLabel.TabIndex = 4;
          // 
          // labBirthDate
          // 
          this.labBirthDate.AutoSize = true;
          this.labBirthDate.Location = new System.Drawing.Point(187, 39);
          this.labBirthDate.Name = "labBirthDate";
          this.labBirthDate.Size = new System.Drawing.Size(49, 13);
          this.labBirthDate.TabIndex = 76;
          this.labBirthDate.Text = "Birthdate";
          // 
          // eBirthDate
          // 
          this.eBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
          this.eBirthDate.Location = new System.Drawing.Point(190, 55);
          this.eBirthDate.Name = "eBirthDate";
          this.eBirthDate.Size = new System.Drawing.Size(181, 20);
          this.eBirthDate.TabIndex = 2;
          // 
          // labPatientID
          // 
          this.labPatientID.AutoSize = true;
          this.labPatientID.Location = new System.Drawing.Point(0, 0);
          this.labPatientID.Name = "labPatientID";
          this.labPatientID.Size = new System.Drawing.Size(32, 13);
          this.labPatientID.TabIndex = 1;
          this.labPatientID.Text = "Code";
          // 
          // ePatientID
          // 
          this.ePatientID.Location = new System.Drawing.Point(0, 16);
          this.ePatientID.Name = "ePatientID";
          this.ePatientID.Size = new System.Drawing.Size(181, 20);
          this.ePatientID.TabIndex = 0;
          this.ePatientID.TextChanged += new System.EventHandler(this.textChanged);
          // 
          // labIdNumber
          // 
          this.labIdNumber.AutoSize = true;
          this.labIdNumber.Location = new System.Drawing.Point(0, 78);
          this.labIdNumber.Name = "labIdNumber";
          this.labIdNumber.Size = new System.Drawing.Size(67, 13);
          this.labIdNumber.TabIndex = 73;
          this.labIdNumber.Text = "Identification";
          // 
          // eIdNumber
          // 
          this.eIdNumber.Location = new System.Drawing.Point(0, 92);
          this.eIdNumber.Name = "eIdNumber";
          this.eIdNumber.Size = new System.Drawing.Size(181, 20);
          this.eIdNumber.TabIndex = 3;
          this.eIdNumber.TextChanged += new System.EventHandler(this.textChanged);
          // 
          // labFirstName
          // 
          this.labFirstName.AutoSize = true;
          this.labFirstName.Location = new System.Drawing.Point(0, 39);
          this.labFirstName.Name = "labFirstName";
          this.labFirstName.Size = new System.Drawing.Size(35, 13);
          this.labFirstName.TabIndex = 48;
          this.labFirstName.Text = "Name";
          // 
          // eFirstName
          // 
          this.eFirstName.Location = new System.Drawing.Point(0, 55);
          this.eFirstName.Name = "eFirstName";
          this.eFirstName.Size = new System.Drawing.Size(181, 20);
          this.eFirstName.TabIndex = 1;
          this.eFirstName.TextChanged += new System.EventHandler(this.textChanged);
          // 
          // eNotes
          // 
          this.eNotes.Location = new System.Drawing.Point(0, 131);
          this.eNotes.Multiline = true;
          this.eNotes.Name = "eNotes";
          this.eNotes.Size = new System.Drawing.Size(367, 72);
          this.eNotes.TabIndex = 78;
          // 
          // labNotes
          // 
          this.labNotes.AutoSize = true;
          this.labNotes.Location = new System.Drawing.Point(0, 115);
          this.labNotes.Name = "labNotes";
          this.labNotes.Size = new System.Drawing.Size(35, 13);
          this.labNotes.TabIndex = 79;
          this.labNotes.Text = "Notes";
          // 
          // PatientEdit
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.panel2);
          this.Name = "PatientEdit";
          this.Padding = new System.Windows.Forms.Padding(4);
          this.Size = new System.Drawing.Size(382, 217);
          this.panel2.ResumeLayout(false);
          this.panel2.PerformLayout();
          this.ResumeLayout(false);

        }

        #endregion

      private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labIdNumber;
      private System.Windows.Forms.TextBox eIdNumber;
        private System.Windows.Forms.Label labFirstName;
      private System.Windows.Forms.TextBox eFirstName;
      private System.Windows.Forms.Label labPatientID;
      private System.Windows.Forms.TextBox ePatientID;
      private System.Windows.Forms.Label labBirthDate;
      private System.Windows.Forms.TextBox eAnimalLabel;
      private System.Windows.Forms.DateTimePicker eBirthDate;
      private System.Windows.Forms.Label labRace;
      private System.Windows.Forms.Button btnNewAnimal;
      private System.Windows.Forms.Label labNotes;
      private System.Windows.Forms.TextBox eNotes;
    }
}
