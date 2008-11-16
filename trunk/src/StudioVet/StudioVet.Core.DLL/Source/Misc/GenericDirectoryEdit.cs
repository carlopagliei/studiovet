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


  public partial class GenericDirecoryEdit : UserControl {

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

      this.VisibleChanged += new EventHandler(delegate { if (!Visible) _checkOut(); });
      Application.ApplicationExit += new EventHandler(delegate { _checkOut(); });
    }

    private void _commitChanges() {
      int pos = bnd.Position;
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
      bnd.Position = pos;
      selRow = grid.Rows[pos];
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

      //grid.RowsRemoved -= new DataGridViewRowsRemovedEventHandler(grid_RowsRemoved);

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

      if ((_preview) && (pkOrdinal >= 0)) {
        long seed;
        using (SqlConnection conn = new SqlConnection(AppData.ConnectionString)) {
          conn.Open();
          SqlCommand cmd = new SqlCommand("SELECT IDENT_SEED(" + Db.QuoteStr(identityTable) + ") + IDENT_CURRENT(" + Db.QuoteStr(identityTable) + ")", conn);
          seed = (long)((System.Decimal)cmd.ExecuteScalar());
        }
        ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[pkOrdinal] };
        ds.Tables[0].Columns[pkOrdinal].AllowDBNull = true;
        ds.Tables[0].Columns[pkOrdinal].AutoIncrement = true;
        ds.Tables[0].Columns[pkOrdinal].AutoIncrementSeed = seed;
      }

      SqlCommandBuilder b = new SqlCommandBuilder(da);

      btnEdit.Checked = !readOnly;
      _updateEditMode();

      this.grid.AutoGenerateColumns = true;


      this.grid.DefaultCellStyle.BackColor = AppData.Colors.Control;
      this.grid.DefaultCellStyle.ForeColor = AppData.Colors.ControlText;
      this.grid.DefaultCellStyle.SelectionBackColor = AppData.Colors.Selection;
      this.grid.DefaultCellStyle.SelectionForeColor = AppData.Colors.SelectionText;

      bnd = new BindingSource(ds, "Table");
      bnd.DataSource = ds;
      grid.DataSource = bnd;

      this.grid.BorderStyle = BorderStyle.None;
      this.grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      this.grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      if (pkOrdinal >= 0) this.grid.Columns[pkOrdinal].ReadOnly = true;

      foreach (DataGridViewColumn col in grid.Columns) {
        string rs = "dbcol_" + _identityTableC + "_" + col.HeaderText.ToLower();
        if (col.HeaderText.ToUpper() == "DESCRIPTION") col.MinimumWidth = 500;
        if (col.HeaderText.ToUpper() == "LABEL") col.MinimumWidth = 200;
        if (_identityTableC == "zipcode") {
          if (col.HeaderText.ToUpper() == "PROVINCE") col.Width = 60;
          else
            if (col.HeaderText.ToUpper() == "ZIPCODE") col.Width = 75;
            else
              col.Width = 150;
        }
        col.HeaderText = translation.ResourceManager.GetString(rs);
        if (readOnly) col.ReadOnly = true;
      }

      grid.Dock = DockStyle.Fill;

      //grid.RowsRemoved += new DataGridViewRowsRemovedEventHandler(grid_RowsRemoved);

      btnApply.Enabled = false;
      btnUndo.Enabled = false;

    }

    private void _updateEditMode() {
      btnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;

      if (btnEdit.Checked) {
        this.grid.ReadOnly = false;
        this.grid.AllowUserToDeleteRows = true;
        btnEdit.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("edit_yes_16", 16, 16).ToBitmap();
        btnEdit.ToolTipText = translation.str_Edit;
        this.grid.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        if (this.Tag != null) {
          this.grid.DoubleClick -= new System.EventHandler(this.dataGridView1_DoubleClick);
          this.Tag = null;
        }
      }
      else {
        this.grid.ReadOnly = true;
        this.grid.AllowUserToDeleteRows = false;
        btnEdit.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("edit_no_16", 16, 16).ToBitmap();
        btnEdit.ToolTipText = translation.str_ReadOnly;
        this.grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        if (this.Tag == null) {
          this.grid.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
          this.Tag = grid;
        }
      }

    }

    public void HideTitle() {
      splitContainer1.Panel1Collapsed = true;
    }

    public void ShowTitle() {
      splitContainer1.Panel1Collapsed = false;
    }

    public void TitleH3() {
      splitContainer1.SplitterDistance = 36;
      titleImage.Hide();
      splitContainer1.Panel1.BackColor = AppData.Colors.H3Background;
      label1.ForeColor = AppData.Colors.H3Foreground;
      label1.Font = AppData.Fonts.H3;
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

    public GenericDirecoryEdit() {
      InitializeComponent();
      _objInit();
    }

    private void btnEdit_Click(object sender, EventArgs e) {
      btnEdit.Checked = !btnEdit.Checked;
      _updateEditMode();
    }

    private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
      if ((e.ColumnIndex < 0)||(e.RowIndex<0)) return;
      if (grid.Columns[e.ColumnIndex].ReadOnly) {
        e.CellStyle.BackColor = AppData.Colors.GridCellBkReadOnly;
      }
    }





  }



}
