using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Carlop.Data;
using StudioVet.Localization;


namespace StudioVet.Core {




  public partial class AnimalDataEdit : UserControl {


    public DbPatient Patient = new DbPatient();

    public void _translateComponent(){
      labPatientID.Text = translation.dbcol_patient_patientid;
      labBirthDate.Text = translation.dbcol_patient_birthdate;
      labFirstName.Text = translation.dbcol_patient_firstname;
      labIdNumber.Text = translation.dbcol_patient_identification;
      labRace.Text = translation.dbcol_animal_species + "/"  + translation.dbcol_animal_race;
      eAnimalLabel.Enabled = false;
    }


    public int PatientID {
      get { return Patient.PersonID; }
    }

    public void Execute(ExecuteMode mode, int viewId){
      switch (mode) { 
        case ExecuteMode.Insert:
          this.Clear();
          ePatientID.Enabled = false;
          break;
        //case ExecuteMode.Search:
        //  this.Clear();
        //  ePatientID.Enabled = true;
        //  break;
        default:
          this.LoadID(viewId);
          ePatientID.Enabled = false;
          break;
      }
    }

    public AnimalDataEdit() {
      InitializeComponent();
      _translateComponent();
    }
    

    public void SyncUI() {
      if (Patient.PersonID > 0) {
        ePatientID.Text = Patient.PatientID.ToString();
        eBirthDate.Text = Patient.BirthDate.ToShortDateString();
        eFirstName.Text = Patient.FirstName;
        eIdNumber.Text = Patient.Identification;
        eNotes.Text = Patient.Notes;
        eAnimalLabel.Text = Patient.Animal_Label;
        eAnimalLabel.Tag = Patient.AnimalID;
      }
      else {
        ePatientID.Text = "";
        eBirthDate.Text = "";
        eFirstName.Text = "";
        eIdNumber.Text = "";
        eAnimalLabel.Text = "";
        eAnimalLabel.Tag = null;
        eNotes.Text = "";
      }
    }


    public void SyncObj() {
      Patient.Identification = eIdNumber.Text;
      Patient.BirthDate = eBirthDate.Value.Date;
      Patient.FirstName = eFirstName.Text;
      Patient.Notes = eNotes.Text;
      Patient.AnimalID = (int)eAnimalLabel.Tag;
    }


    public void Clear() {

      Patient = new DbPatient();
      SyncUI();

    }

    public void LoadID(int personID) {

      Patient.FetchFromDb(personID);
      SyncUI();

    }

    public void SaveToDb() {

      SyncObj();
      Patient.SaveToDb();

    }

    private void _process(string text, string fieldName, StringBuilder sb) {
      if (!string.IsNullOrEmpty(text)) {
        if (sb.Length > 0) sb.Append("and");
        sb.Append("([");
        sb.Append(fieldName);
        sb.Append("] LIKE ");
        sb.Append(Db.QuoteStr("%" + text + '%'));
        sb.Append(")");
      }

    }

    public event EventHandler DataChanged;

    private void textChanged(object sender, EventArgs e) {
      if (DataChanged != null) DataChanged(this, null);
    }

    GenericDirecoryEdit dv;
    DialogHostForm df;

    private void btnNewAnimal_Click(object sender, EventArgs e) {
      dv = new GenericDirecoryEdit();
      dv.HideTitle();
      dv.Width = 550;
      dv.Height = 300;
      dv.Execute(
        "Select [AnimalID], [Label], [Species], [Race] from [dbo].[Animal]", 
        0, 
        "animal", 
        AppData.PreviewCodesWhenEditing, 
        true);
      df = new DialogHostForm();
      df.Text = translation.str_Animals;
      dv.DblClicked += new EventHandler(dv_DblClicked);
      if (df.ShowComponent(dv) == DialogResult.OK) {
        dv.Commit();
        eAnimalLabel.Text = (string)dv.selRow.Cells[1].Value;
        eAnimalLabel.Tag = dv.selRow.Cells[0].Value;
      }
    }

    void dv_DblClicked(object sender, EventArgs e) {
      df.DialogResult = DialogResult.OK; 
      dv.DblClicked -= new EventHandler(dv_DblClicked);
      dv.CheckOut();
      df.Close();
    }


  }
}
