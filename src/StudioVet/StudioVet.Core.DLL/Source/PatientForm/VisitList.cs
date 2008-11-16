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


  public partial class VisitListEdit : UserControl {

    // ---( PRIVATE FIELDS )---

    DataSet ds;
    SqlDataAdapter da;
    BindingSource bnd;

    // ---( PRIVATE HELPERS )---

    private void _objInit() {
      label1.Font = AppData.Fonts.Hyperlink;
      this.splitContainer1.Panel1.BackColor = AppData.Colors.H1Background;
      this.splitContainer1.Panel1.ForeColor = AppData.Colors.H1Foreground;
      this.label1.Font = AppData.Fonts.H1;
    }

    private void dataGridView1_DoubleClick(object sender, EventArgs e) {
      if (DblClicked != null) {
        DblClicked(this, null);
      };
    }

    private void grid_SelectionChanged(object sender, EventArgs e) {
      try {
        SelectedVisitID = (int)grid.CurrentRow.Cells[0].Value;
      }
      catch {
        SelectedVisitID = 0;
      }
    }


    // ---( PUBLIC )---

    public int SelectedVisitID;
    public bool VaccinesOnly;

    public event EventHandler DblClicked;

    public void Execute(int patientID, bool vaccinesOnly) {

      VaccinesOnly = vaccinesOnly;

      this.grid.DataSource = null;
      if (da != null) da.Dispose();
      if (ds != null) ds.Dispose();

      string query = (vaccinesOnly ? AppData.SqlScripts.ExecSP("vaccinesFromPatient01", patientID) :
                                     AppData.SqlScripts.ExecSP("visitsFromPatient01", patientID));

      ds = new DataSet();
      da = new SqlDataAdapter(query, AppData.ConnectionString);
      da.Fill(ds);

      this.grid.AutoGenerateColumns = true;


      bnd = new BindingSource(ds, "Table");
      bnd.DataSource = ds;
      grid.DataSource = bnd;
      grid.Cursor = Cursors.Default;
      grid.BackgroundColor = AppData.Colors.H2Background;// SystemColors.Control;
      grid.SelectionChanged +=new EventHandler(grid_SelectionChanged);

      this.grid.BorderStyle = BorderStyle.None;
      this.grid.ColumnHeadersVisible = false;
      this.grid.RowHeadersVisible = false;
      this.grid.ReadOnly = true;
      this.grid.AllowUserToResizeRows = false;
      this.grid.ScrollBars = ScrollBars.Vertical;

      this.grid.DefaultCellStyle.BackColor = AppData.Colors.Control;
      this.grid.DefaultCellStyle.ForeColor = AppData.Colors.ControlText;
      this.grid.DefaultCellStyle.SelectionBackColor = AppData.Colors.Selection;
      this.grid.DefaultCellStyle.SelectionForeColor = AppData.Colors.SelectionText;

      grid.Dock = DockStyle.Fill;

    }

    private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
      Rectangle newRect = new Rectangle(e.CellBounds.X + 1,
           e.CellBounds.Y + 1, e.CellBounds.Width - 4,
           e.CellBounds.Height - 4);

      // ----------
      string textline1, textline2, textline3;
      Color clGrid;
      Color clBack;
      Color clFont;
      if (e.Value != null) {
        try {
          textline1 = ((System.DateTime)grid.Rows[e.RowIndex].Cells[3].Value).ToString("d") + "  -  " + grid.Rows[e.RowIndex].Cells[1].Value.ToString();
          textline2 = grid.Rows[e.RowIndex].Cells[4].Value.ToString();
          try {
            textline3 = ((System.DateTime)grid.Rows[e.RowIndex].Cells[5].Value).ToString("d");
            if (!string.IsNullOrEmpty(textline3))
              textline3 =
                translation.dbcol_reminder_duedate + "/" +
                translation.dbcol_pharmaceutical_booster + ": " + 
                textline3;
          } 
          catch {
            textline3 = "";
          }
          if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected) {
            clGrid = this.grid.GridColor;
            clBack = e.CellStyle.SelectionBackColor;
            clFont = e.CellStyle.SelectionForeColor;
          }
          else {
            clGrid = this.grid.GridColor;
            clBack = e.CellStyle.BackColor;
            clFont = e.CellStyle.ForeColor;
          }
        }
        catch {
          textline1 = "";
          textline2 = "";
          textline3 = "";
          clGrid = grid.BackgroundColor;
          clBack = grid.BackgroundColor;
          clFont = grid.BackgroundColor;
        }
      }
      else {
        textline1 = "";
        textline2 = "";
        textline3 = "";
        clGrid = grid.BackgroundColor;
        clBack = grid.BackgroundColor;
        clFont = grid.BackgroundColor;
      }

      // ----------
      using ( 
        Brush gridBrush = new SolidBrush(clGrid),
          backColorBrush = new SolidBrush(clBack),
          fontColorBrush = new SolidBrush(clFont)) {
        using (Pen gridLinePen = new Pen(gridBrush)) {
          // Erase the cell.
          e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

          // Draw the grid lines (only the right and bottom lines;
          // DataGridView takes care of the others).
          e.Graphics.DrawLine(
              gridLinePen, 
              e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
          if (e.RowIndex == 0) {
            e.Graphics.DrawLine(
                gridLinePen,
                e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
          }
          e.Graphics.DrawLine(
            gridLinePen, 
            e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Left, e.CellBounds.Top);
          e.Graphics.DrawLine(
            gridLinePen,
            e.CellBounds.Right, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Top);

          // Draw the text content of the cell, ignoring alignment.
          e.Graphics.DrawString(
            textline1, e.CellStyle.Font, fontColorBrush,  
            e.CellBounds.X + 2, e.CellBounds.Y + 2, StringFormat.GenericDefault);
          e.Graphics.DrawString(
            textline2, e.CellStyle.Font, fontColorBrush,
            e.CellBounds.X + 2, e.CellBounds.Y + 4 + e.CellStyle.Font.Height, StringFormat.GenericDefault);
          if (!string.IsNullOrEmpty(textline3)) 
            e.Graphics.DrawString(
              textline3, e.CellStyle.Font, fontColorBrush,
              e.CellBounds.X + 2, e.CellBounds.Y + 4 + 2 * e.CellStyle.Font.Height, StringFormat.GenericDefault);

          e.Handled = true;
        }
      }
    }


    public VisitListEdit() {
      InitializeComponent();
      _objInit();
    }

    private void grid_SizeChanged(object sender, EventArgs e) {
      resizeColumn0();
    }

    private void resizeColumn0() {
      grid.Columns[0].Width = grid.ClientSize.Width - 2;
      if ((grid.Rows.Count * grid.Rows[0].MinimumHeight) > grid.Width) {
        grid.Columns[0].Width -= SystemInformation.VerticalScrollBarWidth;
      }
    }

    private void grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
      foreach (DataGridViewRow row in grid.Rows) {
        row.MinimumHeight = 12 + 3 * grid.Font.Height;
      }
      foreach (DataGridViewColumn col in grid.Columns) {
        if (col.Index > 0) col.Visible = false;
      }
      resizeColumn0();

    }







  }



}
