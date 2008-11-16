using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using StudioVet.Localization;
using System.Drawing.Printing;
using System.IO;
using Carlop.Data;

namespace StudioVet.Core {

  public partial class VisitEdit : UserControl {


    public VisitEdit() {
      InitializeComponent();
      _objInit();
    }



    private void _objInit() {
      this.splitContainer1.Panel1.BackColor = AppData.Colors.H1Background;
      this.splitContainer1.Panel1.ForeColor = AppData.Colors.H1Foreground;
      this.label1.Font = AppData.Fonts.H1;
      this.label1.ForeColor = AppData.Colors.H1Foreground;
      this.titleImage.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("ActivityMonitor32", 32, 32).ToBitmap();

      toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
      toolStrip1.RenderMode = AppData.MenuRenderMode;
      toolStrip1.ForeColor = SystemColors.ControlText;

      btnSave.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("floppy_16", 16, 16).ToBitmap();
      btnSave.Enabled = false;
      btnSave.Text = translation.btnSave;

      btnCreateInvoice.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("createinvoice_16", 16, 16).ToBitmap();
      btnCreateInvoice.Enabled = false;
      btnCreateInvoice.Text = translation.btn_createInvoice;

      btnPrintInvoice.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("print_16", 16, 16).ToBitmap();
      btnPrintInvoice.Enabled = false;
      btnPrintInvoice.Text = translation.btn_printInvoice;

      btnPrintReport.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("print2_16", 16, 16).ToBitmap();
      btnPrintReport.Enabled = false;
      btnPrintReport.Text = translation.btn_printReport;

      btnPageSetup.Image = Carlop.Graphics.IconHandler.LoadFromSystemLibrary("pagesetup_16", 16, 16).ToBitmap();
      btnPageSetup.Enabled = false;
      btnPageSetup.Text = translation.btn_pageSetup;

      labDescription.Text = translation.str_description;
      labDoctor.Text = translation.str_doctor;
      labNotes.Text = translation.str_notes;
      labReport.Text = translation.str_report;
      labVisitDatetime.Text = translation.str_date;
      labVisitType.Text = translation.str_visitType;

      services.Title = translation.str_services;
      dispenses.Title = translation.str_dispenses;
      dispenses.BoosterAdded += new EventHandler(boosters_BoosterAdded);
      boosters.Title = translation.str_Boosters;
      docs.Title = translation.str_documents;
      docs.Parent = splitContainer4.Panel2;
      docs.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Controls.Add(services, 0, 0);
      services.Dock = DockStyle.Fill;
      services.ChangesSaved += new EventHandler(services_ChangesSaved);
      this.tableLayoutPanel1.Controls.Add(dispenses, 1, 0);
      dispenses.Dock = DockStyle.Fill;
      dispenses.ChangesSaved += new EventHandler(services_ChangesSaved);
      this.tableLayoutPanel1.Controls.Add(boosters, 2, 0);
      boosters.Dock = DockStyle.Fill;
      boosters.ChangesSaved += new EventHandler(services_ChangesSaved);
      _initDataBindings();

      privateBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(b_DocumentCompleted);

    }

    void services_ChangesSaved(object sender, EventArgs e) {
      if (DataChanged != null) DataChanged(this, null);
    }

    void boosters_BoosterAdded(object sender, EventArgs e) {
      boosters.Requery();
    }

    int PatientID = 0;
    DbVisit visit = new DbVisit();
    DataSet dsVisitTypes;
    SqlDataAdapter daVisitTypes;
    ServiceDispenseBoosterEdit services = new ServiceDispenseBoosterEdit();
    ServiceDispenseBoosterEdit dispenses = new ServiceDispenseBoosterEdit();
    ServiceDispenseBoosterEdit boosters = new ServiceDispenseBoosterEdit();
    DocumentMgmt docs = new DocumentMgmt();
    WebBrowser privateBrowser = new WebBrowser();


    private void _initDataBindings() {
      string query = AppData.SqlScripts.ExecSP("selectAllVisitTypes");
      dsVisitTypes = new DataSet();
      daVisitTypes = new SqlDataAdapter(query, AppData.ConnectionString);
      daVisitTypes.Fill(dsVisitTypes);
      cbVisitType.DataSource = dsVisitTypes.Tables[0].DefaultView;
      cbVisitType.DisplayMember = "Label";
      cbVisitType.ValueMember = "VisitTypeID";
    }

    public void OpenNew(int patientID) {
      PatientID = patientID;
      this.label1.Text = translation.str_NewVisit;
      dtVisitDatetime.Value = System.DateTime.Now;
      splitContainer2.Panel2Collapsed = true;
      visit = new DbVisit();
      visit.PatientID = patientID;
      _Obj2Ui();
      btnPrintInvoice.Enabled = false;
      btnCreateInvoice.Enabled = false;
      btnPrintReport.Enabled = false;
    }

    public void Open(int visitID) {
      visit.FetchFromDb(visitID);
      _Obj2Ui();
      services.ExecuteServices(visit.VisitID);
      dispenses.ExecuteDispenses(visit.VisitID);
      boosters.ExecuteReminders(visit.VisitID);
      docs.BindToVisit(visit);
      splitContainer2.Panel2Collapsed = false;
      btnPrintInvoice.Enabled = true;
      btnPageSetup.Enabled = true;
      btnPrintReport.Enabled = true;
    }      


    private void panel2_Resize(object sender, EventArgs e) {
      dtVisitDatetime.Width = (panel2.Width - 12) / 6;
      dtVisitDatetime.Left = 0;
      cbVisitType.Width = dtVisitDatetime.Width;
      cbVisitType.Left = 4 + dtVisitDatetime.Right;
      eDoctor.Width = dtVisitDatetime.Width;
      eDoctor.Left = 4 + cbVisitType.Right;
      eDescription.Left = 4 + eDoctor.Right;
      eDescription.Width = panel2.Width - eDoctor.Right - 4;
      eReport.Width = eDoctor.Right;
      eReport.Left = 0;
      eNotes.Width = eDescription.Width;
      eNotes.Left = eDescription.Left;
      labReport.Left = eReport.Left;
      labDescription.Left = eDescription.Left;
      labNotes.Left = eNotes.Left;
      labDescription.Left = eDescription.Left;
      labVisitDatetime.Left = dtVisitDatetime.Left;
      labVisitType.Left = cbVisitType.Left;
      labDoctor.Left = eDoctor.Left;
    }

    private void panel6_Resize(object sender, EventArgs e) {
      splitContainer4.SplitterDistance = splitContainer4.Width / 4;
    }

    private void _Obj2Ui(){
      eNotes.Text = visit.Notes;
      eReport.Text = visit.Report;
      try {
        dtVisitDatetime.Value = visit.VisitDate;
      }
      catch {
        dtVisitDatetime.Value = System.DateTime.Now;
      }
      PatientID = visit.PatientID;
      cbVisitType.SelectedValue = visit.VisitTypeID;
      eDoctor.Text = visit.Doctor;
      eDescription.Text = visit.Description;
      this.label1.Text = cbVisitType.Text + ", " + visit.VisitDate.ToString("D");
      btnSave.Enabled = false;
      btnPrintInvoice.Enabled = (visit.InvoiceNum > 0);
      btnCreateInvoice.Enabled = true;
      btnPrintReport.Enabled = true;
    }

    private void _Ui2Obj() {
      visit.Notes = eNotes.Text;
      visit.Report = eReport.Text;
      visit.VisitDate = dtVisitDatetime.Value.Date;
      visit.PatientID = PatientID;
      visit.VisitTypeID = (int)cbVisitType.SelectedValue;
      visit.Doctor = eDoctor.Text;
      visit.Description = eDescription.Text;
    }

    public event EventHandler DataChanged;

    private void btnSave_Click(object sender, EventArgs e) {
      _Ui2Obj();
      visit.SaveToDb();
      if (DataChanged != null) DataChanged(this, null);
      Open(visit.VisitID);
    }

    private void eReport_TextChanged(object sender, EventArgs e) {
      btnSave.Enabled = true;
    }

    private void dtVisitDatetime_ValueChanged(object sender, EventArgs e) {
      btnSave.Enabled = true;
    }

    private int printAction = 0;

    private void btnPrintInvoice_Click(object sender, EventArgs e) {
      printAction = 0;
      string destFile = Path.Combine(visit.DocumentPath, @"invoice.htm");
      if (!File.Exists(destFile)) {
        btnCreateInvoice_Click(null, null);
      }
      privateBrowser.Url = new Uri(destFile);
    }

    private void btnPageSetup_Click(object sender, EventArgs e) {
      printAction = 1;
      string destFile = Path.Combine(visit.DocumentPath, @"invoice.htm");
      if (!File.Exists(destFile)) {
        btnCreateInvoice_Click(null, null);
      }
      privateBrowser.Url = new Uri(destFile);
    }

    void b_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
      if (printAction == 0) {
        (sender as WebBrowser).ShowPrintDialog();
      }
      else if (printAction == 1) {
        (sender as WebBrowser).ShowPageSetupDialog();
      }
    }


    private void btnPrintReport_Click(object sender, EventArgs e) {
      printAction = 0;
      string destFile = Path.Combine(visit.DocumentPath, @"report.htm");
      CreateReport();
      privateBrowser.Url = new Uri(destFile);
    }

    private void CreateReport() {

      StreamReader reader = new StreamReader(AppData.Printing.ReportTemplate, true);
      string template = reader.ReadToEnd();
      StringBuilder b = new StringBuilder(template);
      reader.Close();

      SqlDataReader rdr1 = Db.Sql.ExecQuery(AppData.ConnectionString,
                                                       AppData.SqlScripts.ExecSP("getReportData01", visit.VisitID));
      StringBuilder personData = new StringBuilder();
      StringBuilder patientData = new StringBuilder();
      while (rdr1.Read()) {
        personData.Append(Db.Get(rdr1, "p_name1", ""));
        personData.Append(" ");
        personData.Append(Db.Get(rdr1, "p_name2", ""));
        personData.Append("<br />");
        string stmp;
        stmp = Db.Get(rdr1, "p_addr1", "");
        if (!string.IsNullOrEmpty(stmp)) {
          personData.Append(stmp);
          personData.Append("<br />");
        }
        stmp = Db.Get(rdr1, "p_addr2", "");
        if (!string.IsNullOrEmpty(stmp)) {
          personData.Append(stmp);
          personData.Append("<br />");
        }
        stmp = Db.Get(rdr1, "p_zip", "") + " " + Db.Get(rdr1, "p_city", "") + " " + Db.Get(rdr1, "p_prov", "");
        if (!string.IsNullOrEmpty(stmp)) {
          personData.Append(stmp);
          personData.Append("<br />");
        }

        patientData.Append(Db.Get(rdr1, "t_name", ""));
        patientData.Append("<br />");
        patientData.Append(Db.Get(rdr1, "t_animal", ""));
        patientData.Append("<br />");
        patientData.Append(translation.dbcol_patient_birthdate);
        patientData.Append(": ");
        patientData.Append(((DateTime)rdr1.GetSqlDateTime(rdr1.GetOrdinal("t_birthdate"))).ToString("d"));
        patientData.Append("<br />");
        patientData.Append(translation.dbcol_patient_identification);
        patientData.Append(": ");
        patientData.Append(Db.Get(rdr1, "t_ident", ""));
      }

      b.Replace("<%COMPANY_HEADING1%>", AppData.Invoicing.CompanyHeading1.Replace(Environment.NewLine, "<br/>"));
      b.Replace("<%COMPANY_HEADING2%>", AppData.Invoicing.CompanyHeading2.Replace(Environment.NewLine, "<br/>"));

      b.Replace("<%PERSON_TITLE%>", translation.str_owner);
      b.Replace("<%PATIENT_TITLE%>", translation.str_animal);
      b.Replace("<%PERSON_DESCRIPTION%>", personData.ToString());
      b.Replace("<%PATIENT_DESCRIPTION%>", patientData.ToString());

      b.Replace("<%VISIT_DESCRIPTION%>", visit.Description.Replace(Environment.NewLine, "<br/>"));
      b.Replace("<%VISIT_REPORT%>", visit.Report.Replace(Environment.NewLine, "<br/>"));

      b.Replace("<%SIGNATURE%>", AppData.Printing.Signature);
      b.Replace("<%DATE%>", System.DateTime.Now.ToString("D"));

      SqlDataReader rdr2 = Db.Sql.ExecQuery(
        AppData.ConnectionString,
        AppData.SqlScripts.ExecSP("getReportData02", visit.VisitID)
        );

      int ds1 = template.IndexOf("<!--%DATASET_BEGIN%-->");
      int ds2 = template.IndexOf("<!--%DATASET_END%-->", ds1) - 1;
      string row;
      if ((ds1 > 0) && (ds2 > 0)) {
        string ds = template.Substring(ds1 + 22, ds2 - ds1 - 22);
        bool goOn = true;
        while (goOn) {
          goOn = false;
          if (rdr2.Read()) {
            row = ds.Replace("<%IMG1%>", "<img src=\"" + Db.Get(rdr2, "filename", "") + "\"  width=\"320px\" />");
            if (rdr2.Read()) {
              row = row.Replace("<%IMG2%>", "<img src=\"" + Db.Get(rdr2, "filename", "") + "\"  width=\"320px\" />");
              goOn = true;
            }
            else row = row.Replace("<%IMG2%>", "");
          }
          else {
            row = ds.Replace("<%IMG1%>", "");
            row = row.Replace("<%IMG2%>", "");
          }
          b.Replace(ds, row + ds);
        }
        b.Replace(ds, "");
        b.Replace("<!--%DATASET_BEGIN%-->", "");
        b.Replace("<!--%DATASET_END%-->", "");
      }

      string tempPath = Path.Combine(Environment.CurrentDirectory, "tempdata");
      System.IO.Directory.CreateDirectory(tempPath);
      string destFile = Path.Combine(tempPath, @"report.htm");
      StreamWriter writer = new StreamWriter(destFile, false, System.Text.Encoding.Unicode);
      writer.Write(b.ToString());
      writer.Close();
      docs.AddFile(destFile, translation.str_report);
      System.IO.File.Delete(destFile);
      docs.Requery();
    }



    private void btnCreateInvoice_Click(object sender, EventArgs e) {


      if (visit.InvoiceNum == 0) { 
        visit.CreateInvoiceNum(); 
      }

      
      SelectPaymentTerm spt = new SelectPaymentTerm();
      if (spt.ShowDialog() != DialogResult.OK) return;

      string payterm = spt.SelectedTerms;
      StreamReader reader = new StreamReader(AppData.Invoicing.InvoiceTemplate, true);
      string template = reader.ReadToEnd();
      StringBuilder b = new StringBuilder(template);
      reader.Close();

      SqlDataReader rdr1 = Db.Sql.ExecQuery(AppData.ConnectionString,
                                                       AppData.SqlScripts.ExecSP("getInvoiceData01", visit.VisitID));
      StringBuilder personData = new StringBuilder();
      StringBuilder patientData = new StringBuilder();
      while (rdr1.Read()){
        personData.Append(Db.Get(rdr1, "p_name1", ""));
        personData.Append(" ");
        personData.Append(Db.Get(rdr1, "p_name2", ""));
        personData.Append("<br />");
        string stmp;
        stmp = Db.Get(rdr1, "p_addr1", "");
        if (!string.IsNullOrEmpty(stmp)) {
          personData.Append(stmp);
          personData.Append("<br />");
        }
        stmp = Db.Get(rdr1, "p_addr2", "");
        if (!string.IsNullOrEmpty(stmp)) {
          personData.Append(stmp);
          personData.Append("<br />");
        }
        stmp = Db.Get(rdr1, "p_zip", "") + " " + Db.Get(rdr1, "p_city", "") + " " + Db.Get(rdr1, "p_prov", "");
        if (!string.IsNullOrEmpty(stmp)) {
          personData.Append(stmp);
          personData.Append("<br />");
        }
        stmp = Db.Get(rdr1, "p_cf", "");
        if (!string.IsNullOrEmpty(stmp)) {
          personData.Append(translation.str_invoiceTaxCodeAbb);
          personData.Append(": ");
          personData.Append(stmp);
          personData.Append("<br />");
        }
        stmp = Db.Get(rdr1, "p_pi", "");
        if (!string.IsNullOrEmpty(stmp)) {
          personData.Append(translation.str_invoiceVatAbb);
          personData.Append(": ");
          personData.Append(stmp);
          personData.Append("<br />");
        }
        //
        patientData.Append(Db.Get(rdr1, "t_name", ""));
        patientData.Append(", ");
        patientData.Append(Db.Get(rdr1, "t_animal", ""));
        patientData.Append(". ");
        patientData.Append(translation.dbcol_patient_birthdate);
        patientData.Append(": ");
        patientData.Append(((DateTime)rdr1.GetSqlDateTime(rdr1.GetOrdinal("t_birthdate"))).ToString("d"));
        patientData.Append(". ");
        patientData.Append(translation.dbcol_patient_identification);
        patientData.Append(": ");
        patientData.Append(Db.Get(rdr1, "t_ident", ""));
      }

      b.Replace("<%COMPANY_HEADING1%>", AppData.Invoicing.CompanyHeading1.Replace(Environment.NewLine, "<br/>"));
      b.Replace("<%COMPANY_HEADING2%>", AppData.Invoicing.CompanyHeading2.Replace(Environment.NewLine, "<br/>"));

      //DateTime ivdt;
      //try {
      //  ivdt = Db.Get(rdr1, "v_date", visit.VisitDate);
      //}
      //catch {
      //  ivdt = visit.InvoiceDate;
      //}

      b.Replace("<%INVOICE_HEADING1%>", translation.str_invoiceDataTitle);
      b.Replace(
        "<%INVOICE_HEADING1_VALUE%>", 
        string.Concat(
          translation.str_invoiceNum, ": ", visit.InvoiceNum.ToString(), "<br />",
          translation.str_invoiceDate, ": ", visit.InvoiceDate.ToString("d"), "<br />",
          translation.str_invoiceCurrency, ": ", AppData.Invoicing.PaymentCurrency, "<br />"
        )
      );

      b.Replace("<%INVOICE_HEADING2%>", translation.str_invoicePaymentTerms);
      //s = "";
      //foreach(string i in AppData.Invoicing.PaymentTerms.Split(Environment.NewLine.ToCharArray())){
      //  if (!string.IsNullOrEmpty(i.Trim())) s += string.Concat("[ ] ", i, "<br />");
      //}
      //s += string.Concat("[ ] ", translation.str_invoicePaymentOther);
      //b.Replace("<%INVOICE_HEADING2_VALUE%>", s);
      b.Replace("<%INVOICE_HEADING2_VALUE%>", payterm);

      b.Replace("<%INVOICE_HEADING3%>", translation.str_invoiceCustomerDataTitle);
      b.Replace("<%INVOICE_HEADING3_VALUE%>", personData.ToString());

      b.Replace("<%PATIENT_DESCRIPTION%>", patientData.ToString());

      b.Replace("<%VISIT_DESCRIPTION%>", visit.Description);
      b.Replace("<%DATASET_HEADING%>", translation.str_invoiceTitle);

      b.Replace("<%DATASETCOL1_HEADING%>", translation.str_invoiceColCode);
      b.Replace("<%DATASETCOL2_HEADING%>", translation.str_invoiceColDescription);
      b.Replace("<%DATASETCOL3_HEADING%>", translation.str_invoiceColQuantity);
      b.Replace("<%DATASETCOL4_HEADING%>", translation.str_invoiceColUnitPrice);
      b.Replace("<%DATASETCOL5_HEADING%>", translation.str_invoiceVat);


      SqlDataReader rdr2 = Db.Sql.ExecQuery(
        AppData.ConnectionString,
        AppData.SqlScripts.ExecSP("getInvoiceData02", visit.VisitID)
        );

      int ds1 = template.IndexOf("<!--%DATASET_BEGIN%-->");
      int ds2 = template.IndexOf("<!--%DATASET_END%-->", ds1) - 1;
      double taxIncome = 0;
      double grandTotal = 0;
      string row;
      if ((ds1 > 0) && (ds2 > 0)) {
        string ds = template.Substring(ds1 + 22, ds2 - ds1 -22);
        while (rdr2.Read()) {
          double charge = rdr2.GetSqlMoney(rdr2.GetOrdinal("d_charge")).ToDouble();
          int qtt = Db.Get(rdr2, "d_qtt", 1);
          if (AppData.Invoicing.VatIncludedRates) {
            grandTotal += (charge * qtt);
            charge /= (1 + AppData.Invoicing.VAT);
            taxIncome += (charge * qtt);
          } else {
            taxIncome += (charge * qtt);
            grandTotal += charge * qtt * (1 + AppData.Invoicing.VAT);
          }
          row = ds.Replace("<%DATASETCOL1_VALUE%>", Db.Get(rdr2, "d_code", ""));
          row = row.Replace("<%DATASETCOL2_VALUE%>", Db.Get(rdr2, "d_descr", ""));
          row = row.Replace("<%DATASETCOL3_VALUE%>", qtt.ToString());
          row = row.Replace("<%DATASETCOL4_VALUE%>", charge.ToString("f2"));
          row = row.Replace("<%DATASETCOL5_VALUE%>", (AppData.Invoicing.VAT * 100).ToString());
          b.Replace(ds, row + ds);
        }
        row = ds.Replace("<%DATASETCOL1_VALUE%>", "");
        row = row.Replace("<%DATASETCOL2_VALUE%>", "");
        row = row.Replace("<%DATASETCOL3_VALUE%>", "");
        row = row.Replace("<%DATASETCOL4_VALUE%>", "");
        row = row.Replace("<%DATASETCOL5_VALUE%>", "");
        b.Replace(ds, row);
        b.Replace("<!--%DATASET_BEGIN%-->", "");
        b.Replace("<!--%DATASET_END%-->", "");
      }


      b.Replace("<%TAXINCOME_HEADING%>", translation.str_invoiceTaxIncome);
      b.Replace("<%TAXINCOME_VALUE%>", taxIncome.ToString("f2"));
      b.Replace("<%TAX_HEADING%>", translation.str_invoiceTax);
      b.Replace("<%TAX_VALUE%>", (grandTotal - taxIncome).ToString("f2"));
      b.Replace("<%GRANDTOTAL_HEADING%>", translation.str_invoiceGrandTotal);
      b.Replace("<%GRANDTOTAL_VALUE%>", grandTotal.ToString("f2"));

      string tempPath =  Path.Combine(Environment.CurrentDirectory, "tempdata");
      System.IO.Directory.CreateDirectory(tempPath); 
      string destFile = Path.Combine(tempPath, @"invoice.htm");
      StreamWriter writer = new StreamWriter(destFile, false, System.Text.Encoding.Unicode);
      writer.Write(b.ToString());
      writer.Close();
      docs.AddFile(destFile, translation.str_invoice);
      System.IO.File.Delete(destFile);
      docs.Requery();

    }

    private void cbVisitType_VisibleChanged(object sender, EventArgs e) {
      if ((this.Visible) && (label1.Text != translation.str_NewVisit)) {
        this.label1.Text = cbVisitType.Text + ", " + visit.VisitDate.ToString("D");
      }
    }



  }

}
