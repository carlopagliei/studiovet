using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using StudioVet.Localization;
using System.Data.SqlClient;
using System.IO;
using Carlop.Data;
using StudioVet.WIA;

namespace StudioVet.Core {


  public partial class DocumentMgmt : UserControl {


    public DocumentMgmt() {
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
      labPath.BackColor = AppData.Colors.H3Background;
      labPath.ForeColor = AppData.Colors.H3Foreground;

      btnSave.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("floppy_16", 16, 16).ToBitmap();
      btnSave.Enabled = false;
      btnSave.Text = translation.btnSave;

      btnUndo.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("undo_16", 16, 16).ToBitmap();
      btnUndo.Enabled = false;
      btnUndo.Text = translation.btn_undo_changes;

      btnAddFile.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("document2_16", 16, 16).ToBitmap();
      btnAddFile.Enabled = true;
      btnAddFile.Text = translation.btn_addFile;

      btnAcquire.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("scanner_16", 16, 16).ToBitmap();
      btnAcquire.Enabled = true;
      btnAcquire.Text = translation.btn_acquire;

      btnCapture.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("document2auto_16", 16, 16).ToBitmap();
      btnCapture.Enabled = true;
      btnCapture.Text = translation.btn_captureFolder;

      btnDeleteFile.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("delete_16", 16, 16).ToBitmap();
      btnDeleteFile.Enabled = false;
      btnDeleteFile.Text = translation.btn_delete;

      btnPrint.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("print_16", 16, 16).ToBitmap();
      btnPrint.Enabled = true;
      btnPrint.Text = translation.btn_print;

      btnShellExec.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("run_16", 16, 16).ToBitmap();
      btnShellExec.Enabled = true;
      btnShellExec.Text = translation.btn_shellexec;

      btnNavigateFiles.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("thumbs_16", 16, 16).ToBitmap();
      btnNavigateFiles.Enabled = true;
      btnNavigateFiles.Text = translation.btn_navigateFiles;

      btnOpenPath.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("explore_path_16", 16, 16).ToBitmap();
      btnOpenPath.Enabled = true;
      btnOpenPath.Text = translation.btn_explorePath;

      panel1.BackColor = SystemColors.InactiveBorder;// AppData.Colors.StandardBorderColor;
      //splitContainer2.Panel2.b

      pictureBox.Dock = DockStyle.Fill;
      webBrowser.Dock = DockStyle.Fill;
      pictureBox.Hide();
      webBrowser.Hide();

      autocap = new CaptureFiles();
      autocap.FileCaptured += new EventHandler<FileSystemEventArgs>(autocap_FileCaptured);

      this.grid.Dock = DockStyle.Fill;
      this.grid.BorderStyle = BorderStyle.None;
      //this.grid.RowHeadersVisible = false;
      this.grid.AutoGenerateColumns = true;
      this.grid.BackgroundColor = SystemColors.Control;
      this.grid.DefaultCellStyle.BackColor = AppData.Colors.Control;
      this.grid.DefaultCellStyle.ForeColor = AppData.Colors.ControlText;
      this.grid.DefaultCellStyle.SelectionBackColor = AppData.Colors.Selection;
      this.grid.DefaultCellStyle.SelectionForeColor = AppData.Colors.SelectionText;


    }

    DbVisit visit;
    CaptureFiles autocap;

    DataSet ds;
    SqlDataAdapter da;
    BindingSource bnd;


    public void BindToVisit(DbVisit aVisit) {
      visit = aVisit;
      labPath.Text = visit.DocumentPath;
      System.IO.Directory.CreateDirectory(visit.DocumentPath);
      Requery();

    }

    public void Requery() {
      _load_data(AppData.SqlScripts.ExecSP("loadDocuments", visit.VisitID));
      //_load_data("select filename, printflag, notes from document where visitid = " + visit.VisitID.ToString());
      grid.Columns[0].Visible = false;
      grid.Columns[1].ReadOnly = true;
      grid.Columns[1].HeaderText = translation.dbcol_document_filename;
      grid.Columns[2].HeaderText = translation.dbcol_document_printflag;
      grid.Columns[3].HeaderText = translation.dbcol_document_notes;
      pictureBox.Hide();
      webBrowser.Hide();
      btnSave.Enabled = false;
      btnUndo.Enabled = false;
    }


    private void _load_data(string query1) {
      ds = new DataSet();
      da = new SqlDataAdapter(query1, AppData.ConnectionString);
      da.Fill(ds);
      SqlCommandBuilder b = new SqlCommandBuilder(da);
      bnd = new BindingSource(ds, "Table");
      bnd.DataSource = ds;
      grid.DataSource = bnd;
    }

    public void AddFile(string filename, string comment) {
      string d = System.IO.Path.GetFileName(filename);
      Carlop.Data.Db.Sql.ExecNonQuery(
        AppData.ConnectionString, AppData.SqlScripts.ExecSP("addDocument01", visit.VisitID, Db.QuoteStr(d), Db.QuoteOrNullStr(comment)));
      d = System.IO.Path.Combine(visit.DocumentPath, d);
      System.IO.File.Copy(filename, d, true);

    }

    public void AddFile(string sourceFilename, string destFilename, string comment) {
      string d = System.IO.Path.GetFileName(destFilename);
      Carlop.Data.Db.Sql.ExecNonQuery(
        AppData.ConnectionString, AppData.SqlScripts.ExecSP("addDocument01", visit.VisitID, Db.QuoteStr(d), Db.QuoteOrNullStr(comment)));
      d = System.IO.Path.Combine(visit.DocumentPath, d);
      System.IO.File.Copy(sourceFilename, d, true);

    }

    private void btnAddFile_Click(object sender, EventArgs e) {
      if (openFileDialog.ShowDialog() == DialogResult.OK) {
        foreach (string f in openFileDialog.FileNames) {
          this.AddFile(f, null);
        }
      }
      Requery();
    }

    private string selFilename;
    private int selId;

    private void grid_SelectionChanged(object sender, EventArgs e) {
      if (grid.SelectedRows.Count > 0) {
        btnDeleteFile.Enabled = true;
        selFilename = System.IO.Path.Combine(visit.DocumentPath, grid.SelectedRows[0].Cells[1].Value.ToString());
        selId = (int)grid.SelectedRows[0].Cells[0].Value;
        string s = System.IO.Path.GetExtension(selFilename).ToLower();
        try {
          pictureBox.Load(selFilename);
          pictureBox.Show();
          webBrowser.Hide();
          btnPrint.Enabled = false;
        }
        catch {
          pictureBox.Hide();
          webBrowser.Show();
          webBrowser.DocumentText = string.Format("<iframe src=\"file://{0}\" frameborder=\"no\" style=\"width: 100%; height: 100%\">Preview Not Available</iframe>", selFilename);
          btnPrint.Enabled = true;
        }
      }
      else {
        selFilename = "";
        btnDeleteFile.Enabled = false;
      }
    }

    private void btnDeleteFile_Click(object sender, EventArgs e) {
      Carlop.Data.Db.Sql.ExecNonQuery(
        AppData.ConnectionString, AppData.SqlScripts.ExecSP("delDocuments", selId));
      File.Delete(selFilename);
      Requery();
    }

    private void btnExplore_Click(object sender, EventArgs e) {
      pictureBox.Hide();
      webBrowser.Show();
      webBrowser.Navigate(visit.DocumentPath);
    }

    private void grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
      int w = 0;
      foreach (DataGridViewColumn c in grid.Columns) {
        if (c.Visible) w += c.Width;
      }
      splitContainer2.SplitterDistance = w + 8;
    }

    private void btnCapture_Click(object sender, EventArgs e) {
      //MessageBox.Show("Not yet implemented!");
      autocap.ShowDialog();
    }

    void autocap_FileCaptured(object sender, FileSystemEventArgs e) {
      //string df = "V" + visit.VisitID.ToString() + "_" + Path.GetFileName(Path.GetTempFileName());
      //df = Path.ChangeExtension(df, Path.GetExtension(e.FullPath)).Replace("tmp", "cap");
      this.AddFile(e.FullPath, null); 
      File.Delete(e.FullPath);
      Requery();
    }


    private void btnAcquire_Click(object sender, EventArgs e) {
      string err;
      string[] files = Wia.Acquire(this, out err);
      if (!string.IsNullOrEmpty(err)) {
        MessageBox.Show(
          translation.str_acquisitionFailed + Environment.NewLine + err,
          translation.str_Failed,
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return;
      }
      foreach (string f in files) {
        string df = Path.GetFileName(f);
        if (File.Exists(f)) {
          AddFile(f, df.Replace("tmp", "wia"), null);
          File.Delete(f);
        }
        else {
          MessageBox.Show(
            translation.str_acquisitionFailed, 
            translation.str_Failed, 
            MessageBoxButtons.OK, 
            MessageBoxIcon.Error);
        }
      }
      Requery();
    }

    private void btnNavigate_Click(object sender, EventArgs e) {
      System.Diagnostics.Process.Start(visit.DocumentPath);
    }

    private void btnPrint_Click(object sender, EventArgs e) {
      if (webBrowser.Visible) {
        webBrowser.ShowPrintPreviewDialog();
      }
    }

    private void grid_CellLeave(object sender, DataGridViewCellEventArgs e) {
      if (grid.IsCurrentCellInEditMode) {
        btnSave.Enabled = true;
        btnUndo.Enabled = true;
      }
    }

    private void btnSave_Click(object sender, EventArgs e) {
      grid.EndEdit();
      bnd.EndEdit();
      da.Update(ds.Tables[0]);
      Requery();
    }

    private void btnUndo_Click(object sender, EventArgs e) {
      Requery();
    }

    private void pictureBox_DoubleClick(object sender, EventArgs e) {
      System.Diagnostics.Process.Start(selFilename);
    }

    private void btnShellExec_Click(object sender, EventArgs e) {
      System.Diagnostics.Process.Start(selFilename);
    }


  }


}
