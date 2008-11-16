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


  public partial class RemindersEdit : UserControl {

    // ---( PRIVATE FIELDS )---

    DataSet ds;
    SqlDataAdapter da;
    BindingSource bnd;
    string _query;
    int _pkOrdinal;
    string _identityTable;
    string _identityTableC;
    string _msgCap;
    bool _readonly;
    bool _preview = true;

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

      btnExit.BackColor = AppData.Colors.H3Background;
      btnExit.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("Close16x16_shadow", 16, 16).ToBitmap();

      this.toolStrip1.RenderMode = AppData.MenuRenderMode;
      this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;

      btnPrint.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("print_16", 16, 16).ToBitmap();
      btnPrint.Enabled = true;
      btnPrint.Text = translation.btn_print;

      btnPageSetup.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("pagesetup_16", 16, 16).ToBitmap();
      btnPageSetup.Enabled = true;
      btnPageSetup.Text = translation.btn_pageSetup;

      btnHTML.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("document_16", 16, 16).ToBitmap();
      btnHTML.Enabled = true;
      btnHTML.Text = translation.str_html;

      this.VisibleChanged += new EventHandler(delegate { if (!Visible) _checkOut(); });
      Application.ApplicationExit += new EventHandler(delegate { _checkOut(); });
    }

    private void _commitChanges() {
      try {
        grid.EndEdit();
        bnd.EndEdit();
        da.Update(ds.Tables[0]);
      }
      catch (Exception e) {
        MessageBox.Show(e.Message, translation.dlg_error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }
      if (!_preview) ds.Clear();
      da.Fill(ds);
      btnApply.Enabled = false;
      btnUndo.Enabled = false;
    }

    private void _undoChanges() {
      Execute(_query, _pkOrdinal, _identityTable, _preview, _readonly);
      btnApply.Enabled = false;
      btnUndo.Enabled = false;
    }

    private bool _thereAreChanges() {
      return (btnApply.Enabled);
    }

    private void _checkOut() {
      if (_thereAreChanges()) {
        DialogResult r = MessageBox.Show(translation.dlg_save_changes, _msgCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (r == DialogResult.Yes) {
          _commitChanges();
        }
      }
    }

    // ---( EVENTS )---

    private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e) {
      MessageBox.Show(e.Exception.Message, translation.dlg_error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
    }

    private void grid_CellLeave(object sender, DataGridViewCellEventArgs e) {
      if (grid.IsCurrentCellInEditMode) {
        btnApply.Enabled = true;
        btnUndo.Enabled = true;
      }
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

    private void dataGridView1_DoubleClick(object sender, EventArgs e) {
      if (DblClicked != null) {
        DblClicked(this, null);
      };
    }

    private void grid_SelectionChanged(object sender, EventArgs e) {
      if (grid.SelectedRows.Count > 0) {
        selRow = grid.SelectedRows[0];
      }
    }

    private void grid_UserDeletedRow(object sender, DataGridViewRowEventArgs e) {
      if (!grid.ReadOnly) {
        btnApply.Enabled = true;
        btnUndo.Enabled = true;
      }

    }

    // ---( PUBLIC )---

    public event EventHandler DblClicked;

    public event EventHandler UserActionExit;

    public DataGridViewRow selRow;

    public void Execute(string query, int pkOrdinal, string identityTable, bool previewCodes, bool readOnly) {

      this.grid.DataSource = null;
      if (da != null) da.Dispose();
      if (ds != null) ds.Dispose();

      _preview = previewCodes;
      _query = query;
      _pkOrdinal = pkOrdinal;
      _identityTable = identityTable;
      _identityTableC = identityTable.Replace("[", "").Replace("]", "").Replace("dbo.", "").ToLower();
      _msgCap = label1.Text;
      _readonly = readOnly;

      ds = new DataSet();
      da = new SqlDataAdapter(query, AppData.ConnectionString);
      da.Fill(ds);
      SqlCommand updCmd = new SqlCommand(
        @"update dbo.reminder set completed = @p2, description = @p3, duedate = @p4, warning = @p5, notes = @p6 " +
         "where reminderid = @p1",
        new SqlConnection(AppData.ConnectionString));
      updCmd.Parameters.Add("@p1", SqlDbType.Int, 0, "r_id");
      updCmd.Parameters.Add("@p2", SqlDbType.Bit, 0, "r_done");
      updCmd.Parameters.Add("@p3", SqlDbType.NVarChar, 255, "r_descr");
      updCmd.Parameters.Add("@p4", SqlDbType.DateTime, 0, "r_due");
      updCmd.Parameters.Add("@p5", SqlDbType.Int, 0, "r_warn");
      updCmd.Parameters.Add("@p6", SqlDbType.NVarChar, 4000, "r_notes");
      da.UpdateCommand = updCmd;

      this.grid.AutoGenerateColumns = true;
      this.grid.DefaultCellStyle.BackColor = AppData.Colors.Control;
      this.grid.DefaultCellStyle.ForeColor = AppData.Colors.ControlText;
      this.grid.DefaultCellStyle.SelectionBackColor = AppData.Colors.Selection;
      this.grid.DefaultCellStyle.SelectionForeColor = AppData.Colors.SelectionText;
      this.grid.AllowUserToAddRows = false;
      grid.Dock = DockStyle.Fill;

      bnd = new BindingSource(ds, "Table");
      bnd.DataSource = ds;
      grid.DataSource = bnd;

      this.grid.BorderStyle = BorderStyle.None;
      this.grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      this.grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

      grid.Columns[0].Visible = false;
      grid.Columns[1].ReadOnly = true;
      grid.Columns[1].HeaderText = translation.str_nameAndSurname;
      grid.Columns[2].ReadOnly = true;
      grid.Columns[2].HeaderText = translation.str_Patient;
      grid.Columns[3].Width = 35;
      grid.Columns[3].HeaderText = translation.dbcol_reminder_completed;
      grid.Columns[4].HeaderText = translation.dbcol_reminder_description;
      grid.Columns[4].MinimumWidth = 100;
      grid.Columns[5].ReadOnly = true;
      grid.Columns[5].HeaderText = translation.str_reminderCdown;
      grid.Columns[6].HeaderText = translation.dbcol_reminder_duedate;
      grid.Columns[7].HeaderText = translation.dbcol_reminder_warning;
      grid.Columns[8].HeaderText = translation.dbcol_reminder_notes;
      grid.Columns[8].MinimumWidth = 250;

      btnApply.Enabled = false;
      btnUndo.Enabled = false;

    }

    public void CheckOut() {
      _checkOut();
    }

    public void Commit() {
      if (_thereAreChanges()) {
        _commitChanges();
      }
    }

    public void Undo() {
      _undoChanges();
    }

    public void Apply() {
      _commitChanges();
    }

    public RemindersEdit() {
      InitializeComponent();
      _objInit();
    }

    private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
      if (e.ColumnIndex < 0) return;
      if (e.RowIndex < 0) return;

      if (e.ColumnIndex == 5) {
        if ((int)e.Value <= 0) e.CellStyle.BackColor = AppData.Colors.GridCellBkOops;
        else e.CellStyle.BackColor = AppData.Colors.GridCellBkWarn;
      }
      else
        if (grid.Columns[e.ColumnIndex].ReadOnly) {
          e.CellStyle.BackColor = AppData.Colors.GridCellBkReadOnly;
        }
    }

    private void btnPrint_Click(object sender, EventArgs e) {
      TabularReport.Print(label1.Text, DateTime.Now.ToString("d"), grid);
    }

    private void btnPageSetup_Click(object sender, EventArgs e) {
      TabularReport.SetupAndPrint(label1.Text, DateTime.Now.ToString("d"), grid);
    }

    private void btnHTML_Click(object sender, EventArgs e) {
      TabularReport.HtmlView(label1.Text, DateTime.Now.ToString("d"), grid);
    }



  }



}
