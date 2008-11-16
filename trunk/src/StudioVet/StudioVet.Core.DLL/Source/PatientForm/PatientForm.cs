using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Carlop.Data;
using StudioVet.Localization;

namespace StudioVet.Core {


  public partial class PatientForm : Form {
    
    public PatientForm() {
      InitializeComponent();
      _objInit();
    }


    private VisitListEdit visits;
    private VisitListEdit vaccines;
    private VisitEdit visit;

    private void _objInit() {

      lpanBorder.BackColor = AppData.Colors.StandardBorderColor;
      lpanContainer.BackColor = AppData.Colors.H2Background;
      cpanBorder.BackColor = AppData.Colors.StandardBorderColor;
      cpanContainer.BackColor = SystemColors.Control;

      toolStrip1.RenderMode = AppData.MenuRenderMode;
      toolStrip1.GripStyle = ToolStripGripStyle.Hidden;

      this.Icon = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("visit_folder_16", 32, 32);

      btnNewVisit.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("visit_new_16", 16, 16).ToBitmap();
      btnShowVisits.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("visitList_16", 16, 16).ToBitmap();
      btnShowVisits.Checked = true;
      btnShowVaccines.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("vaccinesList_16", 16, 16).ToBitmap();
      btnShowVaccines.Checked = true;

      visits = new VisitListEdit();
      visits.label1.Text = translation.str_visits;
      visits.Dock = DockStyle.Fill;
      visits.DblClicked += new EventHandler(visits_DblClicked);
      visits.Parent = splitContainer3.Panel1;
      visits.Dock = DockStyle.Fill;

      vaccines = new VisitListEdit();
      vaccines.label1.Text = translation.str_vaccinations;
      vaccines.Dock = DockStyle.Fill;
      vaccines.DblClicked += new EventHandler(visits_DblClicked);
      vaccines.Parent = splitContainer3.Panel2;
      vaccines.Dock = DockStyle.Fill;

      visit = new VisitEdit();
      visit.DataChanged += new EventHandler(visit_DataChanged);
      visit.Hide();
      cpanContainer.Controls.Add(visit);
      visit.Dock = DockStyle.Fill;

      


    }

    void visit_DataChanged(object sender, EventArgs e) {
      visits.Execute(PatientID, false);
      vaccines.Execute(PatientID, true);
      
    }

    int PatientID;

    void visits_DblClicked(object sender, EventArgs e) {
      visit.Open(visits.SelectedVisitID);
      visit.Show();
    }

    public void Execute(int patientID) {
      PatientID = patientID;
      using (SqlConnection conn = new SqlConnection(AppData.ConnectionString)) {
        conn.Open();
        SqlCommand cmd = new SqlCommand(AppData.SqlScripts.ExecSP("selectPatientTag", patientID), conn);
        SqlDataReader r = cmd.ExecuteReader();
        while (r.Read()) {
          this.Text =
            (string)r.GetSqlString(r.GetOrdinal("t_fn")) +
            " (" + (string)r.GetSqlString(r.GetOrdinal("p_fn")) + " " +
            (string)r.GetSqlString(r.GetOrdinal("p_ln")) + "): " +
            translation.str_Patient_Form;
          toolStripLabel1.Text =
            translation.str_code + " " +
            (string)r.GetSqlString(r.GetOrdinal("t_fn")) + ": " +
            ((int)r.GetInt32(r.GetOrdinal("t_id"))).ToString() + "  -  " +
            translation.str_code + " " +
            (string)r.GetSqlString(r.GetOrdinal("p_fn")) + " " +
            (string)r.GetSqlString(r.GetOrdinal("p_ln")) + ": " +
            ((int)r.GetInt32(r.GetOrdinal("p_id"))).ToString() + " ";
        }
      }
      visits.Execute(patientID, false);
      vaccines.Execute(patientID, true);
    }

    private void btnNewVisit_Click(object sender, EventArgs e) {
      visit.OpenNew(PatientID);
      visit.Show();
    }

    private void btnShowVisits_Click(object sender, EventArgs e) {
      btnShowVisits.Checked = !btnShowVisits.Checked;
      if (btnShowVisits.Checked) btnShowVisits.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("visitList_16", 16, 16).ToBitmap();
       else btnShowVisits.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("visitList_no_16", 16, 16).ToBitmap();

      splitContainer2.Panel1Collapsed = !((btnShowVaccines.Checked) || (btnShowVisits.Checked));
      if (!splitContainer2.Panel1Collapsed) {
        splitContainer3.Panel1Collapsed = !btnShowVisits.Checked;
        splitContainer3.Panel2Collapsed = !btnShowVaccines.Checked;
      }
    }

    private void btnShowVaccines_Click(object sender, EventArgs e) {
      btnShowVaccines.Checked = !btnShowVaccines.Checked;
      if (btnShowVaccines.Checked) btnShowVaccines.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("vaccinesList_16", 16, 16).ToBitmap();
      else btnShowVaccines.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("vaccinesList_no_16", 16, 16).ToBitmap();
      splitContainer2.Panel1Collapsed = !((btnShowVaccines.Checked) || (btnShowVisits.Checked));
      if (!splitContainer2.Panel1Collapsed) {
        splitContainer3.Panel1Collapsed = !btnShowVisits.Checked;
        splitContainer3.Panel2Collapsed = !btnShowVaccines.Checked;
      }
    }

  }


}