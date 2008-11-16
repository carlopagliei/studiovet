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
using System.IO;

namespace StudioVet.Core {


  public partial class InvoiceMgmt : UserControl {

    // ---( PRIVATE FIELDS )---

    DataSet ds;
    SqlDataAdapter da;
    BindingSource bnd;
    string _query;
    bool _preview = true;

    // ---( PRIVATE HELPERS )---

    private void _objInit() {
      this.splitContainer1.Panel1.BackColor = AppData.Colors.H1Background;
      this.splitContainer1.Panel1.ForeColor = AppData.Colors.H1Foreground;
      this.label1.Font = AppData.Fonts.H1;
      titleImage.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("Amora_Script", 32, 32).ToBitmap();

      btnUndoLastInvoce.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("undoinvoice_16", 16, 16).ToBitmap();
      btnUndoLastInvoce.Text = translation.str_delLastInvoice;

      btnTotal.Checked = true;
      btnTotal.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("ShowTotalY_16", 16, 16).ToBitmap();

      DateTime month = new DateTime(2000, 1, 1);
      cbMonth.Items.Add("----");
      for (int i = 1; i <= 12; i++) {
        cbMonth.Items.Add(month.ToString("MMMM"));
        month = month.AddMonths(1);
      }
      cbMonth.SelectedIndex = 0;

      cbYear.Items.Add("----");
      SqlConnection conn = new SqlConnection(AppData.ConnectionString);
      conn.Open();
      SqlCommand cmd = new SqlCommand("select distinct [Year] from [InvoiceNum] order by [Year]", conn);
      SqlDataReader r = cmd.ExecuteReader();
      while (r.Read()) {
        cbYear.Items.Add(((int)Carlop.Data.Db.Get(r, 0, 0)).ToString());
      }
      cbYear.SelectedIndex = cbYear.Items.Count - 1;

      btnRefresh.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("reload_16", 16, 16).ToBitmap();
      btnRefresh.Text = translation.str_refresh;
      
      btnExit.BackColor = AppData.Colors.H3Background;
      btnExit.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("Close16x16_shadow", 16, 16).ToBitmap();

      btnPrint.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("print_16", 16, 16).ToBitmap();
      btnPrint.Enabled = true;
      btnPrint.Text = translation.btn_print;

      btnPageSetup.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("pagesetup_16", 16, 16).ToBitmap();
      btnPageSetup.Enabled = true;
      btnPageSetup.Text = translation.btn_pageSetup;

      btnHTML.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("document_16", 16, 16).ToBitmap();
      btnHTML.Enabled = true;
      btnHTML.Text = translation.str_html;

      this.toolStrip1.RenderMode = AppData.MenuRenderMode;
      this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;

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
    }




    // ---( EVENTS )---

    private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e) {
      MessageBox.Show(e.Exception.Message, translation.dlg_error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

    // ---( PUBLIC )---

    public event EventHandler DblClicked;

    public event EventHandler UserActionExit;

    public DataGridViewRow selRow;

    public void Execute() {//string query, int pkOrdinal, string identityTable, bool previewCodes, bool readOnly) {

      //AppData.SqlScripts.ExecSP("showInvoicesOfCurrentYear"), 0, "", false, false
      _query = "EXEC showInvoicesOfCurrentYear ";
      _query += (btnTotal.Checked ? "1" : "0");
      if (cbYear.SelectedIndex > 0) {
        _query += "," + cbYear.Text;
      }
      if (cbMonth.SelectedIndex > 0) {
        _query += "," + cbMonth.SelectedIndex.ToString();
      }

      this.grid.DataSource = null;
      if (da != null) da.Dispose();
      if (ds != null) ds.Dispose();

      ds = new DataSet();
      da = new SqlDataAdapter(_query, AppData.ConnectionString);
      da.Fill(ds);

      this.grid.AutoGenerateColumns = true;
      this.grid.DefaultCellStyle.BackColor = AppData.Colors.Control;
      this.grid.DefaultCellStyle.ForeColor = AppData.Colors.ControlText;
      this.grid.DefaultCellStyle.SelectionBackColor = AppData.Colors.Selection;
      this.grid.DefaultCellStyle.SelectionForeColor = AppData.Colors.SelectionText;
      this.grid.AllowUserToAddRows = false;
      this.grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      grid.Dock = DockStyle.Fill;

      bnd = new BindingSource(ds, "Table");
      bnd.DataSource = ds;
      grid.DataSource = bnd;

      this.grid.BorderStyle = BorderStyle.None;
      this.grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      this.grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

      grid.Columns[0].Visible = false;
      grid.Columns[1].Visible = false;
      grid.Columns[2].Visible = false;
      grid.Columns[3].ReadOnly = true;
      grid.Columns[3].HeaderText = translation.str_invoiceNum;
      grid.Columns[4].Visible = false;
      grid.Columns[5].ReadOnly = true;
      grid.Columns[5].HeaderText = translation.str_Month;
      grid.Columns[6].MinimumWidth = 100;
      grid.Columns[6].HeaderText = translation.str_Year;
      grid.Columns[6].MinimumWidth = 50;
      grid.Columns[7].Visible = false;
      grid.Columns[8].HeaderText = translation.str_invoiceGrandTotal;
      grid.Columns[9].MinimumWidth = 100;
      grid.Columns[9].ReadOnly = true;
      grid.Columns[9].HeaderText = translation.dbcol_document_description;
      grid.Columns[9].MinimumWidth = 500;


    }


    public InvoiceMgmt() {
      InitializeComponent();
      _objInit();
    }

    private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
      if (e.ColumnIndex < 0) return;
      if (e.RowIndex < 0) return;

      if (grid.Rows[e.RowIndex].DefaultCellStyle.BackColor == AppData.Colors.GridCellBkAzz) {
        e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, grid.Font.SizeInPoints + 4, FontStyle.Bold);
      }
      else
        if (grid.Rows[e.RowIndex].DefaultCellStyle.BackColor == AppData.Colors.GridCellBkWarn) {
        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
      } else
      if (grid.Rows[e.RowIndex].DefaultCellStyle.BackColor == AppData.Colors.GridCellBkOops) {
        e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, grid.Font.SizeInPoints + 2,FontStyle.Bold);
      }


    }

    private void grid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
      if (e.RowIndex < 0) return;
      if ((int)grid.Rows[e.RowIndex].Cells[2].Value == -3) {
        grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = AppData.Colors.GridCellBkAzz;
      }
      else
      if ((int)grid.Rows[e.RowIndex].Cells[2].Value == -2) {
        grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = AppData.Colors.GridCellBkOops;
      }
      else
        if ((int)grid.Rows[e.RowIndex].Cells[2].Value == -1)  {
        grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = AppData.Colors.GridCellBkWarn;
      }
  }

    private void grid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
      if (e.ColumnIndex < 0) return;
      if (e.RowIndex < 0) return;

      if (e.ColumnIndex == 2) {
        if ((int)e.Value < 0) {
          e.Value = "";
        }
      }
    }

    private void btnTotal_Click(object sender, EventArgs e) {
      if (btnTotal.Checked) btnTotal.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("ShowTotalY_16", 16, 16).ToBitmap();
      else btnTotal.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("ShowTotalN_16", 16, 16).ToBitmap();
      if (!string.IsNullOrEmpty(_query)) this.Execute();

    }

    private void toolStripButton1_Click(object sender, EventArgs e) {

      string subt = "";
      if (cbYear.SelectedIndex > 0) {
        subt += translation.str_Year + ": " + cbYear.Text;
      }
      if (cbMonth.SelectedIndex > 0) {
        if (!string.IsNullOrEmpty(subt)) subt += ", "; 
        subt += translation.str_Month + ": " + cbMonth.Text;
      }
      if (!string.IsNullOrEmpty(subt)) subt = translation.str_period + ": " + subt;

      TabularReport.Print(label1.Text, subt, grid);


    }



    private void btnUndoLastInvoce_Click(object sender, EventArgs e) {

      if (MessageBox.Show(
            translation.str_sureToDelInvoice, 
            translation.str_delLastInvoice, 
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Warning) == DialogResult.Yes) {

        SqlDataReader rdr = Db.Sql.ExecQuery(AppData.ConnectionString,
                                              AppData.SqlScripts.ExecSP("RemoveLastInvoice"));
        int visitId = 0;
        while (rdr.Read()) {
          visitId = Db.Get(rdr, 0, 0);
          break;
        }

        if (visitId > 0) {
          DbVisit visit = new DbVisit();
          visit.FetchFromDb(visitId);
          File.Delete(System.IO.Path.Combine(visit.DocumentPath, "invoice.htm"));
          Db.Sql.ExecNonQuery(
            AppData.ConnectionString,
            string.Format("delete from document where visitid = {0} and [filename]='invoice.htm'", visitId));
        }

        this.Execute();
      }


    }

    private void btnRefresh_Click(object sender, EventArgs e) {
      this.Execute();
    }

    private void btnPageSetup_Click(object sender, EventArgs e) {
      string subt = "";
      if (cbYear.SelectedIndex > 0) {
        subt += translation.str_Year + ": " + cbYear.Text;
      }
      if (cbMonth.SelectedIndex > 0) {
        if (!string.IsNullOrEmpty(subt)) subt += ", ";
        subt += translation.str_Month + ": " + cbMonth.Text;
      }
      if (!string.IsNullOrEmpty(subt)) subt = translation.str_period + ": " + subt;
      TabularReport.SetupAndPrint(label1.Text, subt, grid);
    }

    private void btnHTML_Click(object sender, EventArgs e) {
      string subt = "";
      if (cbYear.SelectedIndex > 0) {
        subt += translation.str_Year + ": " + cbYear.Text;
      }
      if (cbMonth.SelectedIndex > 0) {
        if (!string.IsNullOrEmpty(subt)) subt += ", ";
        subt += translation.str_Month + ": " + cbMonth.Text;
      }
      if (!string.IsNullOrEmpty(subt)) subt = translation.str_period + ": " + subt;
      TabularReport.HtmlView(label1.Text, subt, grid);
    }




  }



}
