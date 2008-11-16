using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace StudioVet.Core {


  public partial class GenericDirectoryView : UserControl {
    
    
    public GenericDirectoryView() {
      InitializeComponent();
      _objInit();
    }

    private void _objInit() {
      this.splitContainer1.Panel1.BackColor = AppData.Colors.H1Background;
      this.splitContainer1.Panel1.ForeColor = AppData.Colors.H1Foreground;
      this.label1.Font = AppData.Fonts.H1;
      titleImage.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("Amora_Script", 32, 32).ToBitmap();
    }

    public void Execute(string query, int[] hiddenCols, string[] colHeaders) {


      using (SqlConnection conn = new SqlConnection(AppData.ConnectionString)) {

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(query, conn);
        da.Fill(ds);

        this.grid.AutoGenerateColumns = true;
        this.grid.DataSource = ds;
        this.grid.DataMember = "Table";
        this.grid.AllowUserToAddRows = false;
        this.grid.AllowUserToDeleteRows = false;
        this.grid.AllowUserToResizeColumns = false;
        this.grid.AllowUserToResizeRows = false;
        this.grid.BorderStyle = BorderStyle.None;
        this.grid.MultiSelect = false;
        this.grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.grid.ReadOnly = true;


        this.grid.DefaultCellStyle.BackColor = AppData.Colors.Control;
        this.grid.DefaultCellStyle.ForeColor = AppData.Colors.ControlText;
        this.grid.DefaultCellStyle.SelectionBackColor = AppData.Colors.Selection;
        this.grid.DefaultCellStyle.SelectionForeColor = AppData.Colors.SelectionText;

        if (hiddenCols != null) {
          foreach (int i in hiddenCols) {
            grid.Columns[i].Visible = false;
          }
        }

        foreach (DataGridViewColumn col in grid.Columns) {
          if (col.HeaderText.ToUpper() == "ADDRESS") col.MinimumWidth = 200;
          if (colHeaders != null) col.HeaderText = colHeaders[col.Index];
        }

        grid.Dock = DockStyle.Fill;

      }


    }

    public void Execute(DataSet _ds, int[] hiddenCols, string[] colHeaders) {


      using (SqlConnection conn = new SqlConnection(AppData.ConnectionString)) {


        this.grid.AutoGenerateColumns = true;
        this.grid.DataSource = _ds;
        this.grid.DataMember = "Table";
        this.grid.AllowUserToAddRows = false;
        this.grid.AllowUserToDeleteRows = false;
        this.grid.AllowUserToResizeColumns = false;
        this.grid.AllowUserToResizeRows = false;
        this.grid.BorderStyle = BorderStyle.None;
        this.grid.MultiSelect = false;
        this.grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.grid.ReadOnly = true;


        this.grid.DefaultCellStyle.BackColor = AppData.Colors.Control;
        this.grid.DefaultCellStyle.ForeColor = AppData.Colors.ControlText;
        this.grid.DefaultCellStyle.SelectionBackColor = AppData.Colors.Selection;
        this.grid.DefaultCellStyle.SelectionForeColor = AppData.Colors.SelectionText;

        if (hiddenCols != null) {
          foreach (int i in hiddenCols) {
            grid.Columns[i].Visible = false;
          }
        }

        foreach (DataGridViewColumn col in grid.Columns) {
          if (col.HeaderText.ToUpper() == "ADDRESS") col.MinimumWidth = 200;
          if (colHeaders != null) col.HeaderText = colHeaders[col.Index];
        }

        grid.Dock = DockStyle.Fill;

      }


    }

    private void dataGridView1_DoubleClick(object sender, EventArgs e) {
      if (DblClicked != null) {
        DblClicked(this, null);
      };
    }

    public event EventHandler DblClicked;

    public DataGridViewRow selRow;

    public void HideTitle() {
      this.splitContainer1.Panel1Collapsed = true;
    }

    private void grid_SelectionChanged(object sender, EventArgs e) {
      if (grid.SelectedRows.Count > 0) {
        selRow = grid.SelectedRows[0];
      }
    }

    private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
      //if ((e.ColumnIndex < 0) || (e.RowIndex < 0)) return;
      //if (grid.Columns[e.ColumnIndex].ReadOnly) {
      //  e.CellStyle.BackColor = AppData.Colors.GridCellBkReadOnly;
      //  e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
      //}

    }


  }



}
