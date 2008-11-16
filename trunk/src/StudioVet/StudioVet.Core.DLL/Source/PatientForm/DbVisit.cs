using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Carlop.Data;

namespace StudioVet.Core {




  //public static
  
  public class DbVisit {

    public int VisitID = 0;
    public int PatientID = 0;
    public int PersonID = 0;
    public int VisitTypeID = 0;
    public int InvoiceNum = 0;
    public DateTime VisitDate;
    public DateTime InvoiceDate;
    public string Description = "";
    public string Report = "";
    public string Notes = "";
    public string Doctor = "";

    public string DocumentPath {
      get { return AppData.Doma.Path(PersonID, PatientID, VisitID); }
    }

    public void FetchFromDb(int aVisitID) {

      string query = AppData.SqlScripts.ExecSP("loadVisit01", aVisitID);

      using (SqlConnection conn = new SqlConnection(AppData.ConnectionString)) {
        conn.Open();
        SqlCommand cmd = new SqlCommand(query, conn);
        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read()) {
          this.VisitID = aVisitID;
          this.PatientID = (int)rdr.GetSqlInt32(rdr.GetOrdinal("PatientID"));
          this.PersonID = (int)rdr.GetSqlInt32(rdr.GetOrdinal("PersonID"));
          this.VisitTypeID = (int)rdr.GetSqlInt32(rdr.GetOrdinal("VisitTypeID"));
          this.VisitDate = (DateTime)rdr.GetSqlDateTime(rdr.GetOrdinal("VisitDate"));
          try { this.InvoiceDate = (DateTime)rdr.GetSqlDateTime(rdr.GetOrdinal("InvoiceDate")); } catch { this.InvoiceDate = DateTime.MinValue; }
          try { this.InvoiceNum = (int)rdr.GetSqlInt32(rdr.GetOrdinal("InvoiceNum")); } catch { this.InvoiceNum = 0; }
          try { this.Description = (string)rdr.GetSqlString(rdr.GetOrdinal("Description")); }  catch { this.Description = ""; }
          try { this.Report = (string)rdr.GetSqlString(rdr.GetOrdinal("Report")); }  catch { this.Report = ""; }
          try { this.Notes = (string)rdr.GetSqlString(rdr.GetOrdinal("Notes")); }  catch { this.Notes = ""; }
          try { this.Doctor = (string)rdr.GetSqlString(rdr.GetOrdinal("Doctor")); } catch { this.Doctor = ""; }
        }
      }
    }

    public void CreateInvoiceNum() {
      string query = AppData.SqlScripts.ExecSP("createInvoiceNum01",this.VisitID);
      using (SqlConnection conn = new SqlConnection(AppData.ConnectionString)) {
        conn.Open();
        SqlCommand cmd = new SqlCommand(query, conn);
        this.InvoiceNum = (int)cmd.ExecuteScalar();
      }
      this.FetchFromDb(VisitID);
    }

    public void SaveToDb() {

      string query = AppData.SqlScripts.ExecSP(
        "saveVisit01",
        this.VisitID,
        this.PatientID,
        this.VisitTypeID,
        Db.QuoteStr(this.VisitDate.ToString("s")),
        Db.QuoteStr(this.Description),
        Db.QuoteStr(this.Report),
        Db.QuoteStr(this.Notes),
        Db.QuoteStr(this.Doctor));

      using (SqlConnection conn = new SqlConnection(AppData.ConnectionString)) {
        conn.Open();
        SqlCommand cmd = new SqlCommand(query, conn);
        this.VisitID = (int)cmd.ExecuteScalar();
      }


    }



  }


}
