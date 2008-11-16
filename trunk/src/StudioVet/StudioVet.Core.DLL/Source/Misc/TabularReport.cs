using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Resources;

using Carlop.Data;
using StudioVet.Localization;
using System.IO;

namespace StudioVet.Core {


  public enum TabularReportAction {
    None,
    Print,
    SetupPrinter
  }

  public static class TabularReport {



    static TabularReport() {
      privateBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(privateBrowser_DocumentCompleted);
    }

    public static TabularReportAction PrintAction = TabularReportAction.None;
    private static WebBrowser privateBrowser = new WebBrowser();

    static void privateBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
      if (PrintAction == TabularReportAction.Print) {
        (sender as WebBrowser).ShowPrintDialog();
      }
      else if (PrintAction == TabularReportAction.SetupPrinter) {
        (sender as WebBrowser).ShowPageSetupDialog();
      }
    }


    public static void Print(string title, string subtitle, DataGridView grid) {
      PrintAction = TabularReportAction.Print;
      privateBrowser.Url = new Uri(CreateHtmlReport(title, subtitle, grid));
    }

    public static void HtmlView(string title, string subtitle, DataGridView grid) {
      PrintAction = TabularReportAction.Print;
      System.Diagnostics.Process.Start(CreateHtmlReport(title, subtitle, grid));
    }

    public static void SetupAndPrint(string title, string subtitle, DataGridView grid) {
      PrintAction = TabularReportAction.SetupPrinter;
      privateBrowser.Url = new Uri(CreateHtmlReport(title, subtitle, grid));
    }

    private static string CreateHtmlReport(string title, string subtitle, DataGridView grid) {

      StreamReader reader;
      reader = new StreamReader(AppData.Printing.TabularPrintTemplate, true);
      string template = reader.ReadToEnd();
      reader.Close();

      reader = new StreamReader(AppData.Printing.TabularPrintTemplate_tdh, true);
      string templateh = reader.ReadToEnd();
      reader.Close();

      reader = new StreamReader(AppData.Printing.TabularPrintTemplate_tdv, true);
      string templatev = reader.ReadToEnd();
      reader.Close();

      StringBuilder htm = new StringBuilder(template);
      htm.Replace("<%TITLE%>", title);
      htm.Replace("<%SUBTITLE%>", subtitle);
      StringBuilder b = new StringBuilder();
      b.Append("<tr>");

      foreach (DataGridViewColumn col in grid.Columns) {
        if (col.Visible)
          b.Append(templateh.Replace("<%COL_HEADING%>", col.HeaderText));
      }
      b.Append("</tr>");

      foreach (DataGridViewRow row in grid.Rows) {
        b.Append("<tr>");
        foreach (DataGridViewColumn col in grid.Columns) {
          if (col.Visible) {
            string val;
            if (row.Cells[col.Index].Value.GetType() == typeof(DateTime)) {
              val = (
                ((DateTime)row.Cells[col.Index].Value).TimeOfDay == TimeSpan.Zero ?
                ((DateTime)row.Cells[col.Index].Value).ToString("d") :
                ((DateTime)row.Cells[col.Index].Value).ToString("G"));
            }
            else
              if (row.Cells[col.Index].Value.GetType() == typeof(Boolean)) {
                val = ((bool)row.Cells[col.Index].Value ? translation.bool_Yes : translation.bool_No);
              }
              else {
                val = row.Cells[col.Index].Value.ToString();
              }
            b.Append(templatev.Replace("<%COL_VALUE%>", val));
          }
        }
        b.Append("</tr>");
      }
      htm.Replace("<%DATA_ROWS%>", b.ToString());
      htm.Replace("<%DATEPRINT%>", translation.print_footer + "  -  " + DateTime.Now.ToString("G"));

      

      string tempPath = Path.Combine(Environment.CurrentDirectory, "tempdata");
      System.IO.Directory.CreateDirectory(tempPath);
      string destFile = Path.Combine(tempPath, @"~tblrdt.htm");
      StreamWriter writer = new StreamWriter(destFile, false, System.Text.Encoding.Unicode);
      writer.Write(htm.ToString());
      writer.Close();

      return destFile;

    }




  }
}
