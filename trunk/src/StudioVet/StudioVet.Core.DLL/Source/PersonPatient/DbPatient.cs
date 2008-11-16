using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Carlop.Data;

namespace StudioVet.Core {




  public class DbPatient {

    public int PatientID = 0;
    public int PersonID = 0;
    public int AnimalID = 0;
    public string FirstName = "";
    public DateTime BirthDate;
    public string Identification = "";
    public string Notes = "";
    public string Animal_Label = "";


    public void FetchFromDb(int aPatientID) {

      string query = AppData.SqlScripts.ExecSP("loadPatient01", aPatientID);

      using (SqlConnection conn = new SqlConnection(AppData.ConnectionString)) {
        conn.Open();
        SqlCommand cmd = new SqlCommand(query, conn);
        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read()) {
          this.PatientID = aPatientID;
          this.AnimalID = (int)rdr.GetSqlInt32(rdr.GetOrdinal("AnimalID"));
          this.PersonID = (int)rdr.GetSqlInt32(rdr.GetOrdinal("PersonID"));
          this.FirstName = (string)rdr.GetSqlString(rdr.GetOrdinal("FirstName"));
          this.BirthDate = (DateTime)rdr.GetSqlDateTime(rdr.GetOrdinal("BirthDate"));
          this.Identification = (string)rdr.GetSqlString(rdr.GetOrdinal("Identification"));
          this.Notes = (string)rdr.GetSqlString(rdr.GetOrdinal("Notes"));
          this.Animal_Label = (string)rdr.GetSqlString(rdr.GetOrdinal("Label"));
        }
      }
    }

    public void SaveToDb() {

      string query = AppData.SqlScripts.ExecSP(
        "savePatient01",
        this.PatientID,
        this.PersonID,
        this.AnimalID,
        Db.QuoteStr(this.FirstName),
        Db.QuoteStr(this.BirthDate.ToString("s")),
        Db.QuoteStr(this.Identification),
        Db.QuoteStr(this.Notes));

      using (SqlConnection conn = new SqlConnection(AppData.ConnectionString)) {
        conn.Open();
        SqlCommand cmd = new SqlCommand(query, conn);
        this.PatientID = (int)cmd.ExecuteScalar();
      }


    }



  }






}
