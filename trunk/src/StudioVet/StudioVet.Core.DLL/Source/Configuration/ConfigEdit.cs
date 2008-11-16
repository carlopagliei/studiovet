using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StudioVet.Localization;

namespace StudioVet.Core {
  public partial class ConfigEdit : Form {


    public ConfigEdit() {
      InitializeComponent();
      obj_init();
    }

    public void obj_init() {

      // page 1
      eZipTable.Text = AppData.ZipcodesTable;
      eDocRoot.Text = AppData.Doma.DocumentsRoot;
      eAutocapture.Text = AppData.Doma.AutoCapturePath;

      // page 2
      eCurrency.Text = AppData.Invoicing.PaymentCurrency;
      eVat.Text = ((double)(100 * AppData.Invoicing.VAT)).ToString();
      ePaymentTerms.Text = AppData.Invoicing.PaymentTerms;
      eHeading1.Text = AppData.Invoicing.CompanyHeading1;
      eHeading2.Text = AppData.Invoicing.CompanyHeading2;
      rbVatIncluded.Checked = AppData.Invoicing.VatIncludedRates;
      rbVatNotIncluded.Checked = !AppData.Invoicing.VatIncludedRates;
      eInvoiceTemplate.Text = AppData.Invoicing.InvoiceTemplate;
      eReportTemplate.Text = AppData.Printing.ReportTemplate;
      eSignature.Text = AppData.Printing.Signature;
    }

    private void button1_Click(object sender, EventArgs e) {

      // check VAT
      try {
        if (!string.IsNullOrEmpty(eVat.Text)) AppData.Invoicing.VAT = double.Parse(eVat.Text) / 100.0;
        else AppData.Invoicing.VAT = 0;
      }
      catch {
        MessageBox.Show(
          translation.str_vatParseError, 
          translation.str_Failed + ": " + label5.Text, 
          MessageBoxButtons.OK, MessageBoxIcon.Error);
        eVat.Text = ((double)(100 * AppData.Invoicing.VAT)).ToString();
        return;
      }

      // page 1
      AppData.ZipcodesTable = eZipTable.Text;
      AppData.Doma.DocumentsRoot = eDocRoot.Text;
      AppData.Doma.AutoCapturePath = eAutocapture.Text;

      // page 2
      AppData.Invoicing.VatIncludedRates = rbVatIncluded.Checked;
      AppData.Invoicing.CompanyHeading1 = eHeading1.Text;
      AppData.Invoicing.CompanyHeading2 = eHeading2.Text;
      AppData.Invoicing.InvoiceTemplate = eInvoiceTemplate.Text;
      AppData.Invoicing.PaymentCurrency = eCurrency.Text;
      AppData.Invoicing.PaymentTerms = ePaymentTerms.Text;
      AppData.Printing.ReportTemplate = eReportTemplate.Text;
      AppData.Printing.Signature = eSignature.Text;

      //
      this.Close();

    }

    private void btnSelectTemplate_Click(object sender, EventArgs e) {
      openFileDialog1.FileName = eInvoiceTemplate.Text;
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
        eInvoiceTemplate.Text = openFileDialog1.FileName;
    }

    private void btnDocRoot_Click(object sender, EventArgs e) {
      folderBrowserDialog1.SelectedPath = eDocRoot.Text;
      if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        eDocRoot.Text = folderBrowserDialog1.SelectedPath;
    }

    private void btnAutocapture_Click(object sender, EventArgs e) {
      folderBrowserDialog1.SelectedPath = eAutocapture.Text;
      if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        eAutocapture.Text = folderBrowserDialog1.SelectedPath;

    }

    private void button1_Click_1(object sender, EventArgs e) {
      openFileDialog1.FileName = eReportTemplate.Text;
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
        eReportTemplate.Text = openFileDialog1.FileName;

    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {

    }



  }
}