using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

using StudioVet;
using StudioVet.Core;
using StudioVet.Localization;

namespace StudioVet {



  public partial class MainForm : Form {

    Control lastAttached;

    RemindersEdit Remindrs;
    InvoiceMgmt Invoicing;
    GenericDirecoryEdit VisitDir;
    GenericDirecoryEdit ServiceDir;
    GenericDirecoryEdit PharmaDir;
    GenericDirecoryEdit AnimalDir;
    GenericDirecoryEdit ZipDir;
    PersonEdit person;
    GenericDirectoryView personpatientSearch;

    public MainForm() {

      // check language
      CultureInfo ci = new CultureInfo(StudioVet.Core.AppData.Culture);
      Thread.CurrentThread.CurrentCulture = ci;
      Thread.CurrentThread.CurrentUICulture = ci;

      // check if database server is configured
      if (string.IsNullOrEmpty(AppData.Db.Server)) {
        AppData.Db.Server = @".\SQLExpress";
        DbMaintenance cfg = new DbMaintenance();
        cfg.ShowDialog();
        cfg.Close();
        cfg = null;
      }


      InitializeComponent();
      //menuStrip1.RenderMode = AppData.MenuRenderMode;
      
      borderPanel.BackColor = AppData.Colors.StandardBorderColor;
      pClientBorder.BackColor = AppData.Colors.StandardBorderColor;
      pClient.BackColor = SystemColors.Control;

      cpPanel.BackColor = AppData.Colors.H2Background;
      cpTitlePanel.BackColor = AppData.Colors.H1Background;
      cpTitlePanel.ForeColor = AppData.Colors.H1Foreground;
      cpTitleLabel.ForeColor = cpTitlePanel.ForeColor;
      cpTitleLabel.Font = AppData.Fonts.H1;
      cpLink1.Font = AppData.Fonts.Hyperlink;
      cpLink1.LinkColor = AppData.Colors.HyperlinkNormal;
      cpLink1.ActiveLinkColor = AppData.Colors.HyperlinkActive;
      cpLink2.Font = AppData.Fonts.Hyperlink;
      cpLink2.LinkColor = AppData.Colors.HyperlinkNormal;
      cpLink2.ActiveLinkColor = AppData.Colors.HyperlinkActive;
      cpLink3.Font = AppData.Fonts.Hyperlink;
      cpLink3.LinkColor = AppData.Colors.HyperlinkNormal;
      cpLink3.ActiveLinkColor = AppData.Colors.HyperlinkActive;
      cpTitleImage.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("Amora_Users", 32, 32).ToBitmap();
      labCustomer.ForeColor = AppData.Colors.HyperlinkNormal;
      labPatient.ForeColor = AppData.Colors.HyperlinkNormal;

      rmPanel.BackColor = AppData.Colors.H2Background;
      rmTitlePanel.BackColor = AppData.Colors.H1Background;
      rmTitlePanel.ForeColor = AppData.Colors.H1Foreground;
      rmTitleLabel.Font = AppData.Fonts.H1;
      rmTitleLabel.ForeColor = rmTitlePanel.ForeColor;
      rmLink1.Font = AppData.Fonts.Hyperlink;
      rmLink1.LinkColor = AppData.Colors.HyperlinkNormal;
      rmLink1.ActiveLinkColor = AppData.Colors.HyperlinkActive;
      rmLink2.Font = AppData.Fonts.Hyperlink;
      rmLink2.LinkColor = AppData.Colors.HyperlinkNormal;
      rmLink2.ActiveLinkColor = AppData.Colors.HyperlinkActive;
      rmTitleImage.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("Amora_Public", 32, 32).ToBitmap();

      adPanel.BackColor = AppData.Colors.H2Background;
      adTitlePanel.BackColor = AppData.Colors.H1Background;
      adTitlePanel.ForeColor = AppData.Colors.H1Foreground;
      adTitleLabel.Font = AppData.Fonts.H1;
      adTitleLabel.ForeColor = adTitlePanel.ForeColor;
      adLink1.Font = AppData.Fonts.Hyperlink;
      adLink1.LinkColor = AppData.Colors.HyperlinkNormal;
      adLink1.ActiveLinkColor = AppData.Colors.HyperlinkActive;
      adLink2.Font = AppData.Fonts.Hyperlink;
      adLink2.LinkColor = AppData.Colors.HyperlinkNormal;
      adLink2.ActiveLinkColor = AppData.Colors.HyperlinkActive;
      adLink3.Font = AppData.Fonts.Hyperlink;
      adLink3.LinkColor = AppData.Colors.HyperlinkNormal;
      adLink3.ActiveLinkColor = AppData.Colors.HyperlinkActive;
      adLink4.Font = AppData.Fonts.Hyperlink;
      adLink4.LinkColor = AppData.Colors.HyperlinkNormal;
      adLink4.ActiveLinkColor = AppData.Colors.HyperlinkActive;
      adLink5.Font = AppData.Fonts.Hyperlink;
      adLink5.LinkColor = AppData.Colors.HyperlinkNormal;
      adLink5.ActiveLinkColor = AppData.Colors.HyperlinkActive;
      adTitleImage.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("Amora_Library", 32, 32).ToBitmap();

      WindowState = FormWindowState.Maximized;

    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void personDirectoryToolStripMenuItem_Click(object sender, EventArgs e) {
    }

    private void cpLink1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      if (person == null) {
        person = new PersonEdit();
        person.label1.Text = translation.str_Customer_Form;
        pClient.Controls.Add(person);
        person.Dock = DockStyle.Fill;
        person.UserActionExit += new EventHandler(delegate { person.Hide(); });
      }
      if (lastAttached != null) lastAttached.Hide();
      lastAttached = person;
      person.Show();
      person.Execute(ExecuteMode.Insert, 0);
    }

    private void eCustomer_KeyUp(object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Return) {
        cpLink2_LinkClicked(null, null);
      }
    }

    private void cpLink3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      if (personpatientSearch == null) {
        personpatientSearch = new GenericDirectoryView();
        personpatientSearch.label1.Text = translation.str_Customer_Form;
        pClient.Controls.Add(personpatientSearch);
        personpatientSearch.Dock = DockStyle.Fill;
        personpatientSearch.DblClicked += new EventHandler(delegate { OpenPatient((int)personpatientSearch.selRow.Cells[0].Value); });
      }
      if (lastAttached != null) lastAttached.Hide();
      lastAttached = personpatientSearch;
      string query = AppData.SqlScripts.ExecSP("searchPersonPatient02");
      personpatientSearch.Show();
      personpatientSearch.Execute(
        query,
        new int[] { 1, 2 },
        new string[] { 
          translation.dbcol_patient_personid, 
          "", 
          "",
          translation.ppsearch_pfirstname,
          translation.ppsearch_plastname,
          translation.ppsearch_address,
          translation.ppsearch_pfirstname,
          translation.ppsearch_alabel,
          translation.ppsearch_arace,
          translation.ppsearch_aspecies
        });

    }

    private void cpLink2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      StringBuilder filter = new StringBuilder("");
      bool junct = false;
      if (!string.IsNullOrEmpty(eCustomer.Text)) { 
        foreach (string s in eCustomer.Text.Split(' ')) {
          if (((s == "+") || (s == "AND")) && (!junct)) {
            filter.Append(" AND ");
            junct = true;
          }
          else {
            if ((filter.Length > 0)&&(!junct)) filter.Append(" OR ");
            filter.Append(string.Format("(PersonKey like '%{0}%')", s));
            junct = false;
          }
        }
      }
      if (!string.IsNullOrEmpty(ePatient.Text)) {
        string pt;
        if (filter.Length > 0) { pt = "+ " + ePatient.Text; }
        else { pt = ePatient.Text; }
        foreach (string s in pt.Split(' ')) {
          if (((s == "+") || (s == "AND")) && (!junct)) {
            filter.Append(" AND ");
            junct = true;
          }
          else {
            if ((filter.Length > 0) && (!junct)) filter.Append(" OR ");
            filter.Append(string.Format("(PatientKey like '%{0}%')", s));
            junct = false;
          }
        }
      }

      if (string.IsNullOrEmpty(filter.ToString())) {
        MessageBox.Show(translation.str_oopsTextIsEmpty, cpLink2.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }

      if (personpatientSearch == null) {
        personpatientSearch = new GenericDirectoryView();
        personpatientSearch.label1.Text = translation.str_Customer_Form;
        pClient.Controls.Add(personpatientSearch);
        personpatientSearch.Dock = DockStyle.Fill;
        personpatientSearch.DblClicked += new EventHandler(delegate { OpenPatient((int)personpatientSearch.selRow.Cells[0].Value); });
      }
      if (lastAttached != null) lastAttached.Hide();
      lastAttached = personpatientSearch;
      //string query = AppData.SqlScripts.ExecSP("searchPersonPatient01", filter.ToString());
      string query = AppData.SqlScripts.ExecSP("searchPersonPatient01", Carlop.Data.Db.QuoteStr(filter.ToString()));
      personpatientSearch.Show();
      personpatientSearch.Execute(
        query, 
        new int[] { 1, 2 }, 
        new string[] { 
          translation.dbcol_patient_personid, 
          "", 
          "",
          translation.ppsearch_pfirstname,
          translation.ppsearch_plastname,
          translation.ppsearch_address,
          translation.ppsearch_pfirstname,
          translation.ppsearch_alabel,
          translation.ppsearch_arace,
          translation.ppsearch_aspecies
        });

    }

    private void OpenPatient(int patientID) {
      if (person == null) {
        person = new PersonEdit();
        person.label1.Text = translation.str_Customer_Form;
        pClient.Controls.Add(person);
        person.Dock = DockStyle.Fill;
        person.UserActionExit += new EventHandler(delegate { person.Hide(); });
      }
      if (lastAttached != null) lastAttached.Hide();
      lastAttached = person;
      person.Show();
      person.Execute(ExecuteMode.ViewExisting, patientID);
    }


    private void rmLink1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      if (Remindrs == null) {
        Remindrs = new RemindersEdit();
        pClient.Controls.Add(Remindrs);
        Remindrs.Dock = DockStyle.Fill;
        Remindrs.UserActionExit += new EventHandler(delegate { Remindrs.Hide(); });
      }
      if (lastAttached != null) lastAttached.Hide();
      lastAttached = Remindrs;
      Remindrs.label1.Text = rmLink1.Text;
      Remindrs.Show();
      Remindrs.Execute(AppData.SqlScripts.ExecSP("searchReminders01"), 0, "", false, false);
    }


    private void rmLink2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      if (Invoicing == null) {
        Invoicing = new InvoiceMgmt();
        pClient.Controls.Add(Invoicing);
        Invoicing.Dock = DockStyle.Fill;
        Invoicing.UserActionExit += new EventHandler(delegate { Invoicing.Hide(); });
      }
      if (lastAttached != null) lastAttached.Hide();
      lastAttached = Invoicing;
      Invoicing.label1.Text = rmLink2.Text;
      Invoicing.Show();
      Invoicing.Execute();

    }


    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      if (VisitDir == null) {
        VisitDir = new GenericDirecoryEdit();
        VisitDir.label1.Text = translation.str_Visit_Directory;
        pClient.Controls.Add(VisitDir);
        VisitDir.Dock = DockStyle.Fill;
        VisitDir.UserActionExit += new EventHandler(delegate { VisitDir.Hide(); });
      }
      if (lastAttached != null) lastAttached.Hide();
      lastAttached = VisitDir;
      VisitDir.Show();
      VisitDir.Execute("select [VisitTypeID], [Label], [Description] from [dbo].[VisitType]", 0, "[dbo].[VisitType]", AppData.PreviewCodesWhenEditing, false);
    }

    private void adLink2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      if (ServiceDir == null) {
        ServiceDir = new GenericDirecoryEdit();
        ServiceDir.label1.Text = translation.str_Service_Directory;
        pClient.Controls.Add(ServiceDir);
        ServiceDir.Dock = DockStyle.Fill;
        ServiceDir.UserActionExit += new EventHandler(delegate{ServiceDir.Hide();});
      }
      if (lastAttached != null) lastAttached.Hide();
      lastAttached = ServiceDir;
      ServiceDir.Show();
      ServiceDir.Execute("select [ServiceTypeID], [Label], [Rate], [Description] from [dbo].[ServiceType]", 0, "[dbo].[ServiceType]", AppData.PreviewCodesWhenEditing, false);
    }

    private void adLink3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      if (PharmaDir == null) {
        PharmaDir = new GenericDirecoryEdit();
        PharmaDir.label1.Text = translation.str_Pharmaceutical_Directory;
        pClient.Controls.Add(PharmaDir);
        PharmaDir.Dock = DockStyle.Fill;
        PharmaDir.UserActionExit += new EventHandler(delegate { PharmaDir.Hide(); });
      }
      if (lastAttached != null) lastAttached.Hide();
      lastAttached = PharmaDir;
      PharmaDir.Show();
      PharmaDir.Execute("select [PharmaceuticalID], [Label], [Rate], [IsVaccine], [Booster], [Description] from [dbo].[Pharmaceutical]", 0, "[dbo].[Pharmaceutical]", AppData.PreviewCodesWhenEditing, false);
    }

    private void adLink4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      if (AnimalDir == null) {
        AnimalDir = new GenericDirecoryEdit();
        AnimalDir.label1.Text = translation.str_Animal_Directory;
        pClient.Controls.Add(AnimalDir);
        AnimalDir.Dock = DockStyle.Fill;
        AnimalDir.UserActionExit += new EventHandler(delegate { AnimalDir.Hide(); });
      }
      if (lastAttached != null) lastAttached.Hide();
      lastAttached = AnimalDir;
      AnimalDir.Show();
      AnimalDir.Execute("select [AnimalID], [Label], [Species], [Race] from [dbo].[Animal]", 0, "[dbo].[Animal]", AppData.PreviewCodesWhenEditing, false);
    }

    private void adLink5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      if (ZipDir == null) {
        ZipDir = new GenericDirecoryEdit();
        ZipDir.label1.Text = adLink5.Text;
        pClient.Controls.Add(ZipDir);
        ZipDir.Dock = DockStyle.Fill;
        ZipDir.UserActionExit += new EventHandler(delegate { ZipDir.Hide(); });
      }
      if (lastAttached != null) lastAttached.Hide();
      lastAttached = ZipDir;
      ZipDir.Show();
      ZipDir.Execute("select [ZipCode], [Province], [City1],	[City2],	[Fraction1], [Fraction2],	[Address1],	[Address2],	[DUG],	[Number],	[Country] from " + AppData.ZipcodesTable, -1, "zipcode", false, false);
    }

    private void timer1_Tick(object sender, EventArgs e) {
      pictureBox1.Hide();
      timer1.Enabled = false;
    }

    private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e) {
      pictureBox1.Left = (pClient.Width - pictureBox1.Width) / 2;
      pictureBox1.Top = (pClient.Height - pictureBox1.Height) / 2;
    }

    private void italianoToolStripMenuItem_Click(object sender, EventArgs e) {
      AppData.Culture = "it-IT";
      MessageBox.Show(
        translation.str_needRestart,
        selectLanguageToolStripMenuItem.Text,
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
    }

    private void englishToolStripMenuItem_Click(object sender, EventArgs e) {
      AppData.Culture = CultureInfo.InvariantCulture.Name;
    }

    private void aboutStudioVetToolStripMenuItem_Click(object sender, EventArgs e) {
      AboutBox ab = new AboutBox();
      ab.ShowDialog();
    }

    private void databaseSetupToolStripMenuItem_Click(object sender, EventArgs e) {
      DbMaintenance dbm = new DbMaintenance();
      dbm.ShowDialog();
    }

    private void tESTToolStripMenuItem_Click(object sender, EventArgs e) {
      PatientForm p = new PatientForm();
      p.Execute(1);
      p.Show();
    }

    private void optionsToolStripMenuItem1_Click(object sender, EventArgs e) {
      ConfigEdit cfgEdit = new ConfigEdit();
      cfgEdit.Text = optionsToolStripMenuItem1.Text;
      cfgEdit.ShowDialog();
      cfgEdit.Close();
    }






  }



}