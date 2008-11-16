using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Carlop.Data;
using StudioVet.Core;
using StudioVet.Localization;

namespace StudioVet {
  public partial class DbMaintenance : Form {
    public DbMaintenance() {
      InitializeComponent();
    }

    private void DbMaintenance_Load(object sender, EventArgs e) {

      eDatabase.Text = AppData.Db.Database;
      eServer.Text = AppData.Db.Server;
      rbWin.Checked = AppData.Db.WindowsAuthentication;
      rbSQL.Checked = !AppData.Db.WindowsAuthentication;
      eUser.Text = AppData.Db.User;
      ePassword.Text = AppData.Db.Password;
      _setupUI();
    }

    private void _setupUI() {
      eUser.Enabled = rbSQL.Checked;
      ePassword.Enabled = rbSQL.Checked;
    }

    private void button1_Click(object sender, EventArgs e) {
      SqlServerLoginMode lm = (rbWin.Checked ? SqlServerLoginMode.UseWindowsAuthentication : SqlServerLoginMode.UseSqlAuthentication);
      string cs = Carlop.Data.Db.Sql.BuildConnectionString(lm, eServer.Text, "master", eUser.Text, ePassword.Text, false);
      try {
        SqlConnection conn = new SqlConnection(cs);
        conn.Open();
        conn.Close();
        MessageBox.Show(translation.str_Ok, button1.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex) {
        MessageBox.Show(translation.str_Failed + Environment.NewLine + ex.Message, button1.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btnOk_Click(object sender, EventArgs e) {
      AppData.Db.Database = eDatabase.Text;
      AppData.Db.Server = eServer.Text;
      AppData.Db.WindowsAuthentication = rbWin.Checked;
      AppData.Db.User = eUser.Text;
      AppData.Db.Password = ePassword.Text;
    }

    private void rbSQL_Click(object sender, EventArgs e) {
      _setupUI();
    }

    private void button2_Click(object sender, EventArgs e) {
      //
    }

  }
}