using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Resources;

using Carlop.Data;
using StudioVet.Localization;


namespace StudioVet.Core {


  public partial class PersonEdit : UserControl {

    // ---( PRIVATE FIELDS )---
    ExecuteMode _executeMode;
    int _executeID;
    PatientListEdit patients;
    PersonDataEdit personEdit1;

    // ---( PRIVATE HELPERS )---

    private void _objInit() {
      this.splitContainer1.Panel1.BackColor = AppData.Colors.H1Background;
      this.splitContainer1.Panel1.ForeColor = AppData.Colors.H1Foreground;
      this.label1.Font = AppData.Fonts.H1;
      titleImage.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("Amora_Script", 32, 32).ToBitmap();

      btnApply.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("floppy_16", 16, 16).ToBitmap();
      btnApply.Enabled = false;
      btnApply.Text = translation.btnSave;

      btnUndo.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("undo_16", 16, 16).ToBitmap();
      btnUndo.Enabled = false;
      btnUndo.Text = translation.btn_undo_changes;

      btnSearch.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("view_16", 16, 16).ToBitmap();
      btnSearch.Enabled = false;
      btnSearch.Text = translation.btnSearch;

      btnExit.BackColor = AppData.Colors.H3Background;
      btnExit.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("Close16x16_shadow", 16, 16).ToBitmap();

      this.VisibleChanged += new EventHandler(delegate { if (!Visible) _checkOut(); });
      Application.ApplicationExit += new EventHandler(delegate { _checkOut(); });

      this.personEdit1 = new StudioVet.Core.PersonDataEdit();
      this.splitContainer2.Panel2.Controls.Add(this.personEdit1);
      this.personEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.personEdit1.Location = new System.Drawing.Point(0, 0);
      this.personEdit1.Name = "personEdit1";
      this.personEdit1.Padding = new System.Windows.Forms.Padding(4);
      this.personEdit1.Size = new System.Drawing.Size(724, 303);
      this.personEdit1.TabIndex = 0;

      this.toolStrip1.RenderMode = AppData.MenuRenderMode;
      this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;

      personEdit1.DataChanged += new EventHandler(delegate { btnApply.Enabled = true; btnUndo.Enabled = true; });

    }

    private void _showPatients() {
      if (patients == null) {
        patients = new PatientListEdit();
        patients.Dock = DockStyle.Fill;
        patients.MiniTitle();
        patients.label1.Text = translation.str_Animals;
        splitContainer3.Panel2.Controls.Add(patients);
      }
      patients.Show();
      patients.Execute(this._executeID, AppData.PreviewCodesWhenEditing);
    }

    private void _hidePatients() {
      if (patients != null) {
        patients.Hide();
      }
    }

    private void _commitChanges() {
      personEdit1.SaveToDb();
      this.Execute(ExecuteMode.ViewExisting, personEdit1.PersonID);
    }

    private void _undoChanges() {
      this.Execute(_executeMode, _executeID);
      personEdit1.SaveToDb();
      btnApply.Enabled = false;
      btnUndo.Enabled = false;
    }

    private bool _thereAreChanges() {
      return (btnApply.Enabled);
    }

    private void _checkOut() {
      if (_thereAreChanges()) {
        DialogResult r = MessageBox.Show(translation.dlg_save_changes, translation.str_Customer_Form, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (r == DialogResult.Yes) {
          _commitChanges();
        }
      }
    }

    // ---( EVENTS )---

    private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e) {
      MessageBox.Show(e.Exception.Message, translation.dlg_error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
    }


    private void btnApply_Click(object sender, EventArgs e) {
      try {
        _commitChanges();
      }
      catch (Exception ex) {
        MessageBox.Show(ex.Message, translation.dlg_error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }
    }

    private void btnUndo_Click(object sender, EventArgs e) {
      try {
        _undoChanges();
      }
      catch (Exception ex) {
        MessageBox.Show(ex.Message, translation.dlg_error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }
    }

    private void btnExit_Click(object sender, EventArgs e) {
      if (UserActionExit != null) UserActionExit(this, null);
    }

    // ---( PUBLIC )---

    public void Execute(ExecuteMode mode, int viewId) {
      _executeMode = mode;
      _executeID = viewId;
      personEdit1.Execute(mode, viewId);
      switch (mode) {
        case ExecuteMode.Insert:
          btnSearch.Visible = false;
          btnApply.Visible = true;
          btnUndo.Visible = false;
          personEdit1.Clear();
          _hidePatients();
          break;
        case ExecuteMode.Search:
          btnSearch.Visible = true;
          btnApply.Visible = false;
          btnUndo.Visible = false;
          personEdit1.Clear();
          _hidePatients();
          break;
        default:
          btnSearch.Visible = false;
          btnApply.Visible = true;
          btnUndo.Visible = true;
          personEdit1.LoadID(viewId);
          _showPatients();
          break;
      }
      btnApply.Enabled = false;
      btnUndo.Enabled = false;
      btnSearch.Enabled = false;
      personEdit1.Focus();
    }
    
    public event EventHandler UserActionExit;
    
    public PersonEdit() {
      InitializeComponent();
      _objInit();
    }



  }



}
