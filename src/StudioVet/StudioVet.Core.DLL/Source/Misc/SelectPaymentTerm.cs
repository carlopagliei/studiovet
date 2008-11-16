using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudioVet.Core {
  public partial class SelectPaymentTerm : Form {
    public SelectPaymentTerm() {
      InitializeComponent();
      foreach (string i in AppData.Invoicing.PaymentTerms.Split(Environment.NewLine.ToCharArray())) {
        if (i.Trim().Length > 0) comboBox1.Items.Add(i);
      }
      comboBox1.SelectedIndex = 0;

    }

    private void comboBox1_TextChanged(object sender, EventArgs e) {
      button1.Enabled = (comboBox1.Text.Length > 0);
    }

    private void button1_Click(object sender, EventArgs e) {
      SelectedTerms = comboBox1.Text;
      DialogResult = DialogResult.OK;
    }

    public string SelectedTerms = "";

    private void button2_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.Cancel;
    }

    private void label1_Click(object sender, EventArgs e) {

    }

  }
}