using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using StudioVet.Localization;

namespace StudioVet.Core {


  public partial class ServiceDispenseBoosterEdit : UserControl {
    
    public ServiceDispenseBoosterEdit() {
      InitializeComponent();
      _obj_init();
    }

    public string Title {
      get { return label1.Text; }
      set { label1.Text = value; }
    }

    private void _obj_init() {
      label1.Font = AppData.Fonts.H3;
      label1.BackColor = AppData.Colors.H3Background;
      label1.ForeColor = AppData.Colors.H3Foreground;
      splitContainer1.SplitterDistance = label1.Font.Height + 2;
      label1.Top = 0;
      this.toolStrip1.RenderMode = AppData.MenuRenderMode;
      this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;

      btnSave.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("floppy_16", 16, 16).ToBitmap();
      btnSave.Enabled = false;
      btnSave.Text = translation.btnSave;

      btnUndo.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("undo_16", 16, 16).ToBitmap();
      btnUndo.Enabled = false;
      btnUndo.Text = translation.btn_undo_changes; 
      
      this.grid.AutoGenerateColumns = true;
      this.grid.DefaultCellStyle.BackColor = AppData.Colors.Control;
      this.grid.DefaultCellStyle.ForeColor = AppData.Colors.ControlText;
      this.grid.DefaultCellStyle.SelectionBackColor = AppData.Colors.Selection;
      this.grid.DefaultCellStyle.SelectionForeColor = AppData.Colors.SelectionText;

    }

    private void _initDataBindings() {

    }

    int VisitID;

    DataSet ds;
    SqlDataAdapter da;
    BindingSource bnd;

    DataSet ds2;
    SqlDataAdapter da2;

    private enum EditMode { 
      services,
      dispenses,
      reminders

    }

    EditMode _mode;
    int visitIdCellIndex;
    int chargeCellIndex;

    private void _load_data(string query1, string query2) {
      ds = new DataSet();
      da = new SqlDataAdapter(query1, AppData.ConnectionString);
      da.Fill(ds);
      SqlCommandBuilder b = new SqlCommandBuilder(da);
      bnd = new BindingSource(ds, "Table");
      bnd.DataSource = ds;
      grid.DataSource = bnd;
      //
      if (!string.IsNullOrEmpty(query2)) {
        ds2 = new DataSet();
        da2 = new SqlDataAdapter(query2, AppData.ConnectionString);
        da2.Fill(ds2);
      }
      //
      boosters.Clear();
    }



    public void ExecuteServices(int visitId) {

      VisitID = visitId;
      _mode = EditMode.services;
      visitIdCellIndex = 3;
      chargeCellIndex = 1;

      _load_data(
        AppData.SqlScripts.ExecSP("loadServicesFromVisit", VisitID),
        AppData.SqlScripts.ExecSP("selectAllServiceTypes")
        );

      DataGridViewComboBoxColumn cbc = new DataGridViewComboBoxColumn();
      cbc.HeaderText = grid.Columns[0].HeaderText;
      cbc.DataSource = ds2.Tables[0].DefaultView;
      cbc.DisplayMember = "Label";
      cbc.ValueMember = "ServiceTypeID";
      cbc.DataPropertyName = "ServiceTypeID";
      grid.Columns.Insert(0, cbc);
      grid.Columns.RemoveAt(1);
      grid.Columns[0].Width = 150;
      grid.Columns[0].HeaderText = translation.dbcol_service_servicetypeid;
      grid.Columns[1].Width = 50;
      grid.Columns[1].HeaderText = translation.dbcol_service_charge;
      grid.Columns[2].Width = 190;
      grid.Columns[2].HeaderText = translation.dbcol_service_notes;
      grid.Columns[3].Visible = false;
      grid.Columns[4].Visible = false;

      btnSave.Enabled = false;
      btnUndo.Enabled = false;

    }

    public void ExecuteDispenses(int visitId) {

      VisitID = visitId;
      _mode = EditMode.dispenses;
      visitIdCellIndex = 4;
      chargeCellIndex = 1;

      _load_data(
        AppData.SqlScripts.ExecSP("loadDispensesFromVisit", VisitID),
        AppData.SqlScripts.ExecSP("selectAllPharmaceutical")
        );

      DataGridViewComboBoxColumn cbc = new DataGridViewComboBoxColumn();
      cbc.HeaderText = grid.Columns[0].HeaderText;
      cbc.DataSource = ds2.Tables[0].DefaultView;
      cbc.DisplayMember = "Label";
      cbc.ValueMember = "PharmaceuticalID";
      cbc.DataPropertyName = "PharmaceuticalID";
      grid.Columns.Insert(0, cbc);
      grid.Columns.RemoveAt(1);
      grid.Columns[0].Width = 150;
      grid.Columns[0].HeaderText = translation.dbcol_dispense_dispenseid;
      grid.Columns[1].Width = 50;
      grid.Columns[1].HeaderText = translation.dbcol_dispense_charge;
      grid.Columns[2].Width = 20;
      grid.Columns[2].HeaderText = translation.dbcol_dispense_quantity_abb;
      grid.Columns[3].Width = 190;
      grid.Columns[3].HeaderText = translation.dbcol_dispense_notes;
      grid.Columns[4].Visible = false;
      grid.Columns[5].Visible = false;

      btnSave.Enabled = false;
      btnUndo.Enabled = false;

    }

    public void ExecuteReminders(int visitId) {

      VisitID = visitId;
      _mode = EditMode.reminders;
      visitIdCellIndex = 4;
      chargeCellIndex = 1;

      _load_data(
        AppData.SqlScripts.ExecSP("loadRemindersFromVisit", VisitID),
        null
        );

      grid.Columns[0].Width = 75;
      grid.Columns[0].HeaderText = translation.dbcol_reminder_duedate;
      grid.Columns[1].Width = 50;
      grid.Columns[1].HeaderText = translation.dbcol_reminder_warning;
      grid.Columns[2].Width = 100;
      grid.Columns[2].HeaderText = translation.dbcol_reminder_description;
      grid.Columns[3].Width = 100;
      grid.Columns[3].HeaderText = translation.dbcol_reminder_notes;
      grid.Columns[4].Visible = false;
      grid.Columns[5].Visible = false;

      btnSave.Enabled = false;
      btnUndo.Enabled = false;

    }

    public void Requery() {
      if (_mode == EditMode.dispenses) {
        this.ExecuteDispenses(VisitID);
      }
      else if (_mode == EditMode.reminders) {
        this.ExecuteReminders(VisitID);
      }
      else {
        this.ExecuteServices(VisitID);
      }
    }

    
    private void btnSave_Click(object sender, EventArgs e) {
      grid.EndEdit();
      bnd.EndEdit();
      try {
        da.Update(ds.Tables[0]);
      }
      catch (SqlException ex) {
        if (!ex.Message.ToLower().Contains("cannot insert the value null")) throw;
      }
      //if (boosters.Count > 0) {
      //  using (SqlConnection conn = new SqlConnection(AppData.ConnectionString)) {
      //    conn.Open();
      //    SqlCommand cmd = new SqlCommand("", conn);
      //    foreach (string q in boosters) {
      //      cmd.CommandText = q;
      //      cmd.ExecuteNonQuery();
      //    }
      //  }
      //  if (BoosterAdded != null) BoosterAdded(this, null);
      //}
      if (BoosterAdded != null) BoosterAdded(this, null);
      if (ChangesSaved != null) ChangesSaved(this, null);
      Requery();
    }

    private void btnUndo_Click(object sender, EventArgs e) {
      Requery();
    }

    private void grid_UserAddedRow(object sender, DataGridViewRowEventArgs e) {
      for (int i = 0; i < grid.Rows.Count - 1; i++) {
        grid.Rows[i].Cells[visitIdCellIndex].Value = VisitID;
      }
    }

    private void grid_CellLeave(object sender, DataGridViewCellEventArgs e) {
      if (grid.IsCurrentCellInEditMode) {
        btnSave.Enabled = true;
        btnUndo.Enabled = true;
      }

    }

    public event EventHandler BoosterAdded;
    List<string> boosters = new List<string>();

    public event EventHandler ChangesSaved;

    private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e) {

      try {
        if ((e.ColumnIndex == 0) && (_mode == EditMode.services)) {
          using (SqlConnection conn = new SqlConnection(AppData.ConnectionString)) {
            conn.Open();
            string q = "select rate from ServiceType where serviceTypeID = " + grid.Rows[e.RowIndex].Cells[0].Value.ToString();
            SqlCommand cmd = new SqlCommand(q, conn);
            grid.Rows[e.RowIndex].Cells[chargeCellIndex].Value = cmd.ExecuteScalar();
          }
        }
        else
          if ((e.ColumnIndex == 0) && (_mode == EditMode.dispenses)) {
            using (SqlConnection conn = new SqlConnection(AppData.ConnectionString)) {
              conn.Open();
              string q;
              SqlCommand cmd;
              q = "select rate from Pharmaceutical where PharmaceuticalID = " + grid.Rows[e.RowIndex].Cells[0].Value.ToString();
              cmd = new SqlCommand(q, conn);
              grid.Rows[e.RowIndex].Cells[chargeCellIndex].Value = cmd.ExecuteScalar();
              grid.Rows[e.RowIndex].Cells[chargeCellIndex + 1].Value = 1;
              //q = "select booster from Pharmaceutical where PharmaceuticalID = " + grid.Rows[e.RowIndex].Cells[0].Value.ToString();
              //cmd = new SqlCommand(q, conn);
              //object o = cmd.ExecuteScalar();
              //if (o.GetType() != typeof(System.DBNull)) {
              //  string addbooster = AppData.SqlScripts.ExecSP(
              //    "insertDefaultBooster",
              //    VisitID,
              //    o,
              //    30,
              //    Carlop.Data.Db.QuoteStr(((DataGridViewComboBoxCell)grid.Rows[e.RowIndex].Cells[0]).FormattedValue.ToString()),
              //    Carlop.Data.Db.QuoteStr(((DataGridViewComboBoxCell)grid.Rows[e.RowIndex].Cells[0]).FormattedValue.ToString()));
              //  boosters.Add(addbooster);
              //}
            }
          }
      }
      catch {
        // well... probably the user has began edit without completing
        // nothing interesting to do...
      }

    }

    private void grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
      btnSave.Enabled = true;
      btnUndo.Enabled = true;
    }


  }

}
