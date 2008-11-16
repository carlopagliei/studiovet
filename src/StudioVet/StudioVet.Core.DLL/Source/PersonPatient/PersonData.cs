using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Carlop.Data;
using StudioVet.Localization;

namespace StudioVet.Core {

  public enum ExecuteMode {
    Insert,
    Search,
    ViewExisting
  }




  public partial class PersonDataEdit : UserControl {


    public DbPerson Person = new DbPerson();

    public void _translateComponent() {
      labPersonID.Text = translation.dbcol_person_personid;
      labFirstName.Text = translation.dbcol_person_firstname;
      labLastName.Text = translation.dbcol_person_lastname;
      labAddress.Text = translation.str_address;
      labCity.Text = translation.dbcol_person_city;
      labZip.Text = translation.dbcol_person_zipcode;
      labProvince.Text = translation.dbcol_person_province;
      labCountry.Text = translation.dbcol_person_country;
      labPhone1.Text = translation.dbcol_person_phone1;
      labPhone2.Text = translation.dbcol_person_phone2;
      labFax.Text = translation.dbcol_person_fax;
      labEMail.Text = translation.dbcol_person_email;
      labTaxCode.Text = translation.dbcol_person_taxcode;
      labVatNumber.Text = translation.dbcol_person_vatnumber;
      labNotes.Text = translation.dbcol_person_notes;
      labBirthDate.Text = translation.dbcol_person_birthdate;
      labBirthPlace.Text = translation.dbcol_person_birthcity;
    }

    private bool zipsearch;

    public int PersonID {
      get { return Person.PersonID; }
    }

    public void Execute(ExecuteMode mode, int viewId) {
      switch (mode) {
        case ExecuteMode.Insert:
          this.Clear();
          ePersonID.Enabled = false;
          break;
        case ExecuteMode.Search:
          this.Clear();
          ePersonID.Enabled = true;
          break;
        default:
          this.LoadID(viewId);
          ePersonID.Enabled = false;
          break;
      }
    }

    public PersonDataEdit() {
      InitializeComponent();
      btnTaxCodeTool.Enabled = System.IO.File.Exists(AppData.TaxCodeCalculator);
      _translateComponent();
      zipsearch = !string.IsNullOrEmpty(AppData.ZipcodesTable);
      cbLookup.Checked = AppData.Registry.GetValue("Preferences", "ZipcodesLookup", true);
    }


    public void SyncUI() {
      if (Person.PersonID > 0) {
        ePersonID.Text = Person.PersonID.ToString();
        eFirstName.Text = Person.FirstName;
        eLastName.Text = Person.LastName;
        eAddressLine1.Text = Person.AddressLine1;
        eAddressLine2.Text = Person.AddressLine2;
        eCity.Text = Person.City;
        eZip.Text = Person.ZipCode;
        eProvince.Text = Person.Province;
        eCountry.Text = Person.Country;
        ePhone1.Text = Person.Phone1;
        ePhone2.Text = Person.Phone2;
        eFax.Text = Person.Fax;
        EMail.Text = Person.EMail;
        eTaxCode.Text = Person.TaxCode;
        eVatNumber.Text = Person.VatNumber;
        eNotes.Text = Person.Notes;
        eVatNumber.Text = Person.VatNumber;
        eNotes.Text = Person.Notes;
        eBirthDate.Checked = (Person.BirthDate != null);
        if (eBirthDate.Checked) eBirthDate.Value = Person.BirthDate.Value.Date;
      }
      else {
        ePersonID.Text = "";
        eFirstName.Text = "";
        eLastName.Text = "";
        eAddressLine1.Text = "";
        eAddressLine2.Text = "";
        eCity.Text = "";
        eZip.Text = "";
        eProvince.Text = "";
        eCountry.Text = "";
        ePhone1.Text = "";
        ePhone2.Text = "";
        eFax.Text = "";
        EMail.Text = "";
        eTaxCode.Text = "";
        eVatNumber.Text = "";
        eNotes.Text = "";
        eBirthDate.Checked = false;
      }
    }


    public void SyncObj() {
      Person.FirstName = eFirstName.Text;
      Person.LastName = eLastName.Text;
      Person.AddressLine1 = eAddressLine1.Text;
      Person.AddressLine2 = eAddressLine2.Text;
      Person.City = eCity.Text;
      Person.ZipCode = eZip.Text;
      Person.Province = eProvince.Text;
      Person.Country = eCountry.Text;
      Person.Phone1 = ePhone1.Text;
      Person.Phone2 = ePhone2.Text;
      Person.Fax = eFax.Text;
      Person.EMail = EMail.Text;
      Person.TaxCode = eTaxCode.Text;
      Person.VatNumber = eVatNumber.Text;
      Person.Notes = eNotes.Text;
      if (eBirthDate.Checked) Person.BirthDate = eBirthDate.Value.Date;
      else Person.BirthDate = null;
    }


    public void Clear() {

      Person = new DbPerson();
      SyncUI();

    }

    public void LoadID(int personID) {

      Person.FetchFromDb(personID);
      SyncUI();

    }

    public void SaveToDb() {

      SyncObj();
      Person.SaveToDb();

    }

    private void _process(string text, string fieldName, StringBuilder sb) {
      if (!string.IsNullOrEmpty(text)) {
        if (sb.Length > 0) sb.Append("and");
        sb.Append("([");
        sb.Append(fieldName);
        sb.Append("] LIKE ");
        sb.Append(Db.QuoteStr("%" + text + '%'));
        sb.Append(")");
      }

    }

    public string GenerateSearchFilter() {

      StringBuilder sb = new StringBuilder();

      _process(eFirstName.Text, "FirstName", sb);
      _process(eLastName.Text, "LastName", sb);
      _process(eAddressLine1.Text, "AddressLine1", sb);
      _process(eAddressLine2.Text, "AddressLine2", sb);
      _process(eCity.Text, "City", sb);
      _process(eZip.Text, "Zip", sb);
      _process(eProvince.Text, "Province", sb);
      _process(eCountry.Text, "Country", sb);
      _process(ePhone1.Text, "Phone1", sb);
      _process(ePhone2.Text, "Phone2", sb);
      _process(eFax.Text, "Fax", sb);
      _process(EMail.Text, "Mail", sb);
      _process(eTaxCode.Text, "TaxCode", sb);
      _process(eVatNumber.Text, "VatNumber", sb);
      _process(eNotes.Text, "Notes", sb);

      return sb.ToString();

    }

    public event EventHandler DataChanged;

    bool zipLookupToDo = false;

    private void textChanged(object sender, EventArgs e) {
      if (DataChanged != null) DataChanged(this, null);
      if ( (sender == eCity) || (sender == eZip) ) zipLookupToDo = true;
    }

    private void btnTaxCodeTool_Click(object sender, EventArgs e) {
      System.Diagnostics.Process.Start(AppData.TaxCodeCalculator);
    }

    private void eZip_Leave(object sender, EventArgs e) {
      if (!zipLookupToDo) return;
      if ((zipsearch) && (cbLookup.Checked)) {
        ZipCodesLookup(sender);
        zipLookupToDo = false;
      }
    }

    private void ZipCodesLookup(object sender) {
      string filter1 = "";
      string filter2 = "";

      // prepare query
      if (sender == eCity) {
        filter1 = "([City1] like " + Db.QuoteStr(eCity.Text + '%') + ")";
        string[] addr = eAddressLine1.Text.Split(' ');
        for (int i = 1; i < addr.Length; i++) {
          int x;
          if (!int.TryParse(addr[i], out x)) {
            filter2 += ((filter2.Length > 0) ? (" AND ") : ("")) + "([Address1] like " + Db.QuoteStr('%' + addr[i] + '%') + ") ";
            //filter2 += "(" + ((filter2.Length > 0) ? (" AND ") : ("")) + "[Address1] like " + Db.QuoteStr('%' + addr[i] + '%') + ") ";
          }
        }
      }
      else
        if (sender == eZip) {
          if (eZip.Text.Length == 5) filter1 = "([ZipCode] = " + Db.QuoteStr(eZip.Text) + ")";
          else filter1 = "([ZipCode] like " + Db.QuoteStr(eZip.Text + '%') + ")";
        }
        else
          if (sender == null) {
            filter1 = "([ZipCode] IS NOT NULL)";
          }

      string query =
        "select distinct * from (" + System.Environment.NewLine +
        "  select [ZipCode], [Province], [City1],	[City2], [Fraction1], [Fraction2],	[Address1],	[Address2],	[DUG],	[Number],	[Country]" + System.Environment.NewLine +
        "  from " + AppData.ZipcodesTable + System.Environment.NewLine +
        "  where " + filter1 + System.Environment.NewLine +
        "  ) XX " + System.Environment.NewLine +
        ((filter2 == "") ? ("") : ("where ( ([Address1] = '')or([address1] is null) ) or ( " + filter2 + " )")) + System.Environment.NewLine +
        "order by city1, Address1"
        ;

      DataSet ds = new DataSet();
      SqlDataAdapter da = new SqlDataAdapter(query, AppData.ConnectionString);
      da.Fill(ds);

      int pos = 0;

      if (ds.Tables[0].Rows.Count == 0) {
        eZip.Text = "";
        eCity.Text = "";
        eProvince.Text = "";
        eCountry.Text = "";
      }
      else
        if (ds.Tables[0].Rows.Count > 1) {
          GenericDirectoryView dv = new GenericDirectoryView();
          dv.Height = 400;
          dv.Width = 500;
          dv.Show();
          dv.HideTitle();
          DialogHostForm df = new DialogHostForm();
          df.Text = translation.dbcol_zipcode_zipcode;
          dv.Execute(
            ds,
            null,
            new string[] { 
                 translation.dbcol_zipcode_zipcode,
                 translation.dbcol_zipcode_province,
                 translation.dbcol_zipcode_city1,
                 translation.dbcol_zipcode_city2,
                 translation.dbcol_zipcode_fraction1,
                 translation.dbcol_zipcode_fraction2,
                 translation.dbcol_zipcode_address1,
                 translation.dbcol_zipcode_address2,
                 translation.dbcol_zipcode_dug,
                 translation.dbcol_zipcode_number,
                 translation.dbcol_zipcode_country
               });
          dv.DblClicked += new EventHandler(delegate {
            df.DialogResult = DialogResult.OK;
            df.Close();
          });
          if (df.ShowComponent(dv) != DialogResult.OK) {
            pos = -1;
          }
          else {
            pos = dv.selRow.Index;
            eZip.Text = (string)dv.selRow.Cells[0].Value;
            eCity.Text = (string)dv.selRow.Cells[2].Value;
            eProvince.Text = (string)dv.selRow.Cells[1].Value;
            eCountry.Text = (string)dv.selRow.Cells[10].Value;
            pos = -1;
          }
        }
      try {
        if (pos >= 0) {
          eZip.Text = (string)ds.Tables[0].Rows[pos][0];
          eCity.Text = (string)ds.Tables[0].Rows[pos][2];
          eProvince.Text = (string)ds.Tables[0].Rows[pos][1];
          eCountry.Text = (string)ds.Tables[0].Rows[pos][10];
        }
      }
      catch {
        eZip.Text = "";
        eCity.Text = "";
        eProvince.Text = "";
        eCountry.Text = "";
      }
    }

    private void button1_Click(object sender, EventArgs e) {
      ZipCodesLookup(null);
    }

    private void cbLookup_Click(object sender, EventArgs e) {
      AppData.Registry.SetValue("Preferences", "ZipcodesLookup", cbLookup.Checked);
    }


  }
}
