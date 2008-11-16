using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

using Carlop.Data;
using System.Resources;
using StudioVet.Localization;


namespace StudioVet.Core {


  public partial class PatientListEdit : UserControl {

    // ---( PRIVATE FIELDS )---

    DataSet ds;
    SqlDataAdapter da;
    BindingSource bnd;
    AnimalDataEdit pEdit;
    DialogHostForm dlgEdit; 
    string _query;
    int _fkPerson;
    string _msgCap;

    int rebindPos = -1;

    bool _preview = true;

    // ---( PRIVATE HELPERS )---

    private void _objInit() {
      this.splitContainer1.Panel1.BackColor = AppData.Colors.H1Background;
      this.splitContainer1.Panel1.ForeColor = AppData.Colors.H1Foreground;
      this.label1.Font = AppData.Fonts.H1;
      titleImage.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("Amora_Script", 32, 32).ToBitmap();

      btnAddAnimal.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("edit_new_16", 16, 16).ToBitmap();
      btnAddAnimal.Enabled = true;
      btnAddAnimal.Text = translation.btn_AddAnimal;

      btnEdit.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("edit_yes_16", 16, 16).ToBitmap();
      btnEdit.Enabled = false;
      btnEdit.Text = translation.btn_EditAnimal;

      btnVisits.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("visit_folder_16", 16, 16).ToBitmap();
      btnVisits.Enabled = false;
      btnVisits.Text = translation.str_Patient_Form;

      btnDelete.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("delete_16", 16, 16).ToBitmap();
      btnDelete.Enabled = false;
      btnDelete.Text = translation.btn_DelAnimal;

      this.toolStrip1.RenderMode = AppData.MenuRenderMode;
      this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;

      btnExit.BackColor = AppData.Colors.H3Background;
      btnExit.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("Close16x16_shadow", 16, 16).ToBitmap();

    }


    public void MiniTitle() {
      titleImage.Hide();
      btnExit.Hide();
      panel1.Hide();
      splitContainer1.Panel1.BackColor = AppData.Colors.H3Background;
      label1.ForeColor = AppData.Colors.H3Foreground;
      label1.Font = AppData.Fonts.H3;
      label1.Left = 2;
      label1.Top = 2;
      splitContainer1.Panel1MinSize = 24;
      splitContainer1.SplitterDistance = 24;

    }

    // ---( EVENTS )---


    private void btnAddAnimal_Click(object sender, EventArgs e) {
      if (pEdit == null) {
        pEdit = new AnimalDataEdit();
        dlgEdit = new DialogHostForm();
        dlgEdit.ShowInTaskbar = false;
      }
      dlgEdit.Text = btnAddAnimal.Text;
      pEdit.Execute(ExecuteMode.Insert, 0);
      if (dlgEdit.ShowComponent(pEdit) == DialogResult.OK) {
        pEdit.Patient.PersonID = _fkPerson;
        pEdit.SaveToDb();
        rebindPos = bnd.Position;
        this.Execute(_fkPerson, _preview);
      }
    }

    private void btnEditAnimal_Click(object sender, EventArgs e) {
      if (pEdit == null) {
        pEdit = new AnimalDataEdit();
        dlgEdit = new DialogHostForm();
        dlgEdit.ShowInTaskbar = false;
      }
      dlgEdit.Text = btnEdit.Text;
      pEdit.Execute(ExecuteMode.ViewExisting, (int)grid.SelectedRows[0].Cells[0].Value);
      if (dlgEdit.ShowComponent(pEdit) == DialogResult.OK) {
        pEdit.Patient.PersonID = _fkPerson;
        pEdit.SaveToDb();
        rebindPos = bnd.Position;
        this.Execute(_fkPerson, _preview);
      }
    }

    private void btnDelete_Click(object sender, EventArgs e) {
      MessageBox.Show("Not Yet Implemented !");

    }


    private void btnExit_Click(object sender, EventArgs e) {
      if (UserActionExit != null) UserActionExit(this, null);
    }

    // ---( PUBLIC )---

    public void Execute(int fkPerson, bool previewCodes) {


      this.grid.DataSource = null;
      if (da != null) da.Dispose();
      if (ds != null) ds.Dispose();


      _query = AppData.SqlScripts.ExecSP("loadPatientFromPerson01", fkPerson);
      _fkPerson = fkPerson;
      _msgCap = label1.Text;


      this.grid.BackColor = AppData.Colors.Control;
      this.grid.ForeColor = AppData.Colors.ControlText;
      this.grid.DefaultCellStyle.BackColor = AppData.Colors.Control;
      this.grid.DefaultCellStyle.ForeColor = AppData.Colors.ControlText;
      this.grid.DefaultCellStyle.SelectionBackColor = AppData.Colors.Selection;
      this.grid.DefaultCellStyle.SelectionForeColor = AppData.Colors.SelectionText;
      //this.toolStrip1.BackColor = AppData.Colors.H3Background;
      //this.toolStrip1.ForeColor = AppData.Colors.H3Foreground;
      

      ds = new DataSet();
      da = new SqlDataAdapter(_query, AppData.ConnectionString);
      da.Fill(ds);

      this.grid.AutoGenerateColumns = true;

      bnd = new BindingSource(ds, "Table");
      bnd.DataSource = ds;
      grid.DataSource = bnd;

      //this.grid.DataSource = ds;//.Tables[0];
      //this.grid.DataMember = "Table";
      this.grid.BorderStyle = BorderStyle.None;
      this.grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      this.grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grid.Columns[0].ReadOnly = true;
      this.grid.AllowUserToAddRows = false;
      this.grid.AllowUserToDeleteRows = false;
      this.grid.ReadOnly = true;
      this.grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

      foreach (DataGridViewColumn col in grid.Columns) {
        string rs = "dbcol_patient_" + col.HeaderText.ToLower();
        if (col.HeaderText.ToUpper() == "LABEL") {
          col.MinimumWidth = 150;
          col.HeaderText = translation.dbcol_animal_species + "/" + translation.dbcol_animal_race;
        }
        else {
          col.HeaderText = translation.ResourceManager.GetString(rs);
        }
      }

      grid.Dock = DockStyle.Fill;

      btnEdit.Enabled = false;
      btnVisits.Enabled = false;
      btnDelete.Enabled = false;

      if (rebindPos >= 0) {
        bnd.Position = rebindPos;
        grid.Rows[rebindPos].Selected = true;
      }
      rebindPos = -1;

    }


    public event EventHandler UserActionExit;

    public PatientListEdit() {
      InitializeComponent();
      _objInit();
    }

    private void grid_SelectionChanged(object sender, EventArgs e) {
      btnEdit.Enabled = true;
      btnVisits.Enabled = true;
      btnDelete.Enabled = true;
    }

    private void btnVisits_Click(object sender, EventArgs e) {
      PatientForm p = new PatientForm();
      p.Execute((int)grid.SelectedRows[0].Cells[0].Value);
      p.Show();
    }

    private void grid_DoubleClick(object sender, EventArgs e) {
      btnVisits_Click(sender, e);
    }


  }



}
