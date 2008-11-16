using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudioVet.Core {
  public partial class DialogHostForm : Form {
    public DialogHostForm() {
      InitializeComponent();
    }
    public DialogResult ShowComponent(Control ctrl) {

      this.Size = new Size(ctrl.Width + 5, ctrl.Height + splitContainer1.Panel2.Height + 25);
      //this.MaximumSize = this.MinimumSize
      splitContainer1.Panel1.Controls.Add(ctrl);
      ctrl.Dock = DockStyle.Fill;

      button1.Left = (this.Width - ( 5 + (2 * button1.Width))) / 2;
      button2.Left = button1.Left + button1.Width + 5;

      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.StartPosition = FormStartPosition.CenterScreen;

      return this.ShowDialog();

    }
  }
}