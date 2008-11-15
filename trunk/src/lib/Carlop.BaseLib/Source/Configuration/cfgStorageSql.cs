/*
 * AMS.Profile Class Library
 * 
 * Written by Alvaro Mendez
 * Copyright (c) 2005. All Rights Reserved.
 * 
 * The AMS.Profile namespace contains interfaces and classes that 
 * allow reading and writing of user-profile data.
 * This file contains the Ini class.
 * 
 * The code is thoroughly documented, however, if you have any questions, 
 * feel free to email me at alvaromendez@consultant.com.  Also, if you 
 * decide to this in a commercial application I would appreciate an email 
 * message letting me know.
 *
 * This code may be used in compiled form in any way you desire. This
 * file may be redistributed unmodified by any means providing it is 
 * not sold for profit without the authors written consent, and 
 * providing that this notice and the authors name and all copyright 
 * notices remains intact. This file and the accompanying source code 
 * may not be hosted on a website or bulletin board without the author's 
 * written permission.
 * 
 * This file is provided "as is" with no expressed or implied warranty.
 * The author accepts no liability for any damage/loss of business that
 * this product may cause.
 *
 * Last Updated: Feb. 17, 2005
 */


using System;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using Carlop.Data;

namespace Carlop.Configuration {

  public class SqlCfgStorage : ConfigurationProviderBase {
    //Field
    private string _connectionString = null;
    private string _machineName = null;
    private string _loginName = null;
    public SqlCfgStorage() {
    }
    public SqlCfgStorage(string connectionString, string machineName, string loginName, string name)
      :
      base(name) {
      this.ConnectionString = connectionString;
      this.MachineName = machineName;
      this.LoginName = loginName;
    }
    public SqlCfgStorage(SqlCfgStorage sql)
      :
      base(sql) {
      this.ConnectionString = sql.ConnectionString;
      this.MachineName = sql.MachineName;
      this.LoginName = sql.LoginName;
    }
    public override string DefaultName {
      get {
        return "";
      }
    }
    public override object Clone() {
      return new SqlCfgStorage(this);
    }
    public string MachineName {
      get { return _machineName; }
      set { _machineName = value; }
    }
    public string LoginName {
      get { return _loginName; }
      set { _loginName = value; }
    }
    public string ConnectionString {
      get { return _connectionString; }
      set { _connectionString = value; }
    }
    private string buildObj_Name(string section, string entry) {
      string result;
      result = Name;
      if (section != "") {
        if (result != "")
          result += "/";
        result += section;
        if (entry != "")
          result += "/" + entry;
      }
      return result;
    }
    private string buildCod_user(int? stationID) {
      if (stationID.HasValue)
        return stationID.ToString();
      else
        return "null";
    }
    private string buildPc_Name(string pcName) {
      if ((pcName != null) && (pcName != "") && (pcName != "*"))
        return Db.QuoteStr(pcName);
      else
        return "null";
    }
    private string buildLogin_Name(string LoginName) {
      return buildPc_Name(LoginName);
    }
    private string buildEqual(string value) {
      if (value.Equals("null", StringComparison.CurrentCultureIgnoreCase))
        return " is " + value;
      else
        return " = " + value;
    }
    private string buildKey(string pcName, string loginName) {
      string result = "";
      if (pcName != "*") result += " and pcname" + buildEqual(buildPc_Name(pcName));
      if (loginName != "*") result += " and loginname" + buildEqual(buildLogin_Name(LoginName));
      return result;
    }
    private string BuildQuerySetValue(string section, string entry, object value) {
      string sQuery = "update [dbo].[Configuration] with (rowlock) set objvalue={2} where objname={0} {1}"
             + Db.Sep() + "if @@rowcount=0"
             + Db.Sep() + "insert [dbo].[Configuration] with (rowlock) (objname,objvalue,pcname,loginname) values ({0}, {2}, {3}, {4})"
             ;
      return string.Format(sQuery
                           , Db.QuoteStr(buildObj_Name(section, entry))
                           , buildKey(MachineName, LoginName)
                           , Db.QuoteStr(value.ToString())
                           , buildPc_Name(MachineName)
                           , buildLogin_Name(LoginName));
    }
    private string BuildQueryGetValue(string section, string entry) {
      string sQuery = "select top 1 objvalue from [dbo].[Configuration] with (nolock) where objname = {0} {1}";
      return string.Format(sQuery
                           , Db.QuoteStr(buildObj_Name(section, entry))
                           , buildKey(MachineName, LoginName));
    }
    private string BuildQueryRemoveValue(string section, string entry) {
      string sQuery = "delete [dbo].[Configuration] with (rowlock) where objname = {0} {1}";
      return string.Format(sQuery
                           , Db.QuoteStr(buildObj_Name(section, entry))
                           , buildKey(MachineName, LoginName));
    }
    private string BuildQueryGetName(string section, string entry) {
      string sQuery = "select objname from [dbo].[Configuration] with (nolock) where objname = {0} {1}";
      return string.Format(sQuery
                           , Db.QuoteStr(buildObj_Name(section, entry))
                           , buildKey(MachineName, LoginName));
    }
    public override void SetValue(string section, string entry, object value) {
      // If the value is null, remove the entry
      if (value == null) {
        RemoveEntry(section, entry);
        return;
      }

      VerifyNotReadOnly();
      VerifyAndAdjustSection(ref section);
      VerifyAndAdjustEntry(ref entry);

      if (!RaiseChangeEvent(true, ConfigurationChangeType.SetValue, section, entry, value))
        return;

      Db.Sql.ExecSingleQuery(ConnectionString, BuildQuerySetValue(section, entry, value));

      RaiseChangeEvent(false, ConfigurationChangeType.SetValue, section, entry, value);
    }
    public override object GetValue(string section, string entry) {
      VerifyAndAdjustSection(ref section);
      VerifyAndAdjustEntry(ref entry);

      return Db.Sql.SelectScalar(ConnectionString, BuildQueryGetValue(section, entry), "");
    }
    public override void RemoveEntry(string section, string entry) {
      VerifyNotReadOnly();
      VerifyAndAdjustSection(ref section);
      VerifyAndAdjustEntry(ref entry);

      if (!RaiseChangeEvent(true, ConfigurationChangeType.RemoveEntry, section, entry, null))
        return;

      Db.Sql.ExecSingleQuery(ConnectionString, BuildQueryRemoveValue(section, entry));

      RaiseChangeEvent(false, ConfigurationChangeType.RemoveEntry, section, entry, null);
    }
    public override void RemoveSection(string section) {
      VerifyNotReadOnly();
      VerifyName();
      VerifyAndAdjustSection(ref section);

      if (!RaiseChangeEvent(true, ConfigurationChangeType.RemoveSection, section, null, null))
        return;

      Db.Sql.ExecSingleQuery(ConnectionString, BuildQueryRemoveValue(section, ""));
      RaiseChangeEvent(false, ConfigurationChangeType.RemoveSection, section, null, null);
    }
    public override string[] GetEntryNames(string section) {
      return new string[0];
      /*
      VerifyAndAdjustSection(ref section);
      string[] names;
      System.Data.SqlClient.SqlDataReader r = null;
      r = DB.Sql.ExecQuery(BuildQueryGetValue(section,""));
      */

    }
    public override string[] GetSectionNames() {
      return new string[0];
      /*
      VerifyName();

      using (RegistryKey key = m_rootKey.OpenSubKey(Name))
      {
        if (key == null)
          return null;
        return key.GetSubKeyNames();
      }
      */
    }
  }
}
