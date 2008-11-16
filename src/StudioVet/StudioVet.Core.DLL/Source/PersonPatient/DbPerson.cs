using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Carlop.Data;

namespace StudioVet.Core {




  public class DbPerson {

    public int PersonID = 0;
    public string FirstName = "";
    public string LastName = "";
    public string AddressLine1 = "";
    public string AddressLine2 = "";
    public string City = "";
    public string ZipCode = "";
    public string Province = "";
    public string Country = "";
    public string Phone1 = "";
    public string Phone2 = "";
    public string Fax = "";
    public string EMail = "";
    public string TaxCode = "";
    public string VatNumber = "";
    public string Notes = "";
    public DateTime? BirthDate = null;
    public string BirthPlace = "";

    private string SqlQuote(string s) {
      return "'" + s + "'";
    }

    public void FetchFromDb(int aPersonID) {

      //string query = AppData.SqlScripts.ExecSP("selectPerson01", aPersonID);
      string query = AppData.SqlScripts.ExecSP("selectPerson01", aPersonID);

      using (SqlConnection conn = new SqlConnection(AppData.ConnectionString)) {
        conn.Open();
        SqlCommand cmd = new SqlCommand(query, conn);
        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read()) {
          this.PersonID = aPersonID;
          this.FirstName = (string)rdr.GetSqlString(rdr.GetOrdinal("FirstName"));
          this.LastName = (string)rdr.GetSqlString(rdr.GetOrdinal("LastName"));
          this.AddressLine1 = (string)rdr.GetSqlString(rdr.GetOrdinal("AddressLine1"));
          this.AddressLine2 = (string)rdr.GetSqlString(rdr.GetOrdinal("AddressLine2"));
          this.City = (string)rdr.GetSqlString(rdr.GetOrdinal("City"));
          this.ZipCode = (string)rdr.GetSqlString(rdr.GetOrdinal("ZipCode"));
          this.Province = (string)rdr.GetSqlString(rdr.GetOrdinal("Province"));
          this.Country = (string)rdr.GetSqlString(rdr.GetOrdinal("Country"));
          this.Phone1 = (string)rdr.GetSqlString(rdr.GetOrdinal("Phone1"));
          this.Phone2 = (string)rdr.GetSqlString(rdr.GetOrdinal("Phone2"));
          this.Fax = (string)rdr.GetSqlString(rdr.GetOrdinal("Fax"));
          this.EMail = (string)rdr.GetSqlString(rdr.GetOrdinal("EMail"));
          this.TaxCode = (string)rdr.GetSqlString(rdr.GetOrdinal("TaxCode"));
          this.VatNumber = (string)rdr.GetSqlString(rdr.GetOrdinal("VatNumber"));
          this.Notes = (string)rdr.GetSqlString(rdr.GetOrdinal("Notes"));
          try { this.BirthDate = (DateTime)rdr.GetSqlDateTime(rdr.GetOrdinal("BirthDate")); }
          catch { this.BirthDate = null; }
          try { this.BirthPlace = (string)rdr.GetSqlString(rdr.GetOrdinal("BirthCity")); }
          catch { this.BirthPlace = ""; }
          if (this.BirthDate.Value.Year <= 1900) this.BirthDate = null; 
        }
      }
    }

    public void SaveToDb() {

      //string query = AppData.SqlScripts.ExecSP(
      string query = AppData.SqlScripts.ExecSP(
        "savePerson01",
        this.PersonID, 
        SqlQuote(this.FirstName), 
        SqlQuote(this.LastName), 
        SqlQuote(this.AddressLine1), 
        SqlQuote(this.AddressLine2), 
        SqlQuote(this.City),
        SqlQuote(this.ZipCode), 
        SqlQuote(this.Province), 
        SqlQuote(this.Country), 
        SqlQuote(this.Phone1), 
        SqlQuote(this.Phone2), 
        SqlQuote(this.Fax), 
        SqlQuote(this.EMail),
        SqlQuote(this.TaxCode), 
        SqlQuote(this.VatNumber), 
        SqlQuote(this.Notes),
        (this.BirthDate == null ? "NULL" : SqlQuote(this.BirthDate.Value.ToString("s"))),
        SqlQuote(this.BirthPlace)
        );

      using (SqlConnection conn = new SqlConnection(AppData.ConnectionString)) {
        conn.Open();
        SqlCommand cmd = new SqlCommand(query, conn);
        this.PersonID = (int)cmd.ExecuteScalar();
      }


    }



  }


}
