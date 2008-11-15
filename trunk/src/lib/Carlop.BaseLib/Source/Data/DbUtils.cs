using System;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.OleDb;





namespace Carlop.Data
{



  public static class Db
  {

    public const string DiagnosticsCategory = "Db.Sql";

    /// <summary>
    /// replaces all newlines with /**/, this allows to write the query
    /// into a single line
    /// </summary>
    /// <param name="query">the initial query</param>
    /// <returns>the flattened query string</returns>
    public static string ToSingleLine(string query)
    {
      return "/**/" + query.Replace(Environment.NewLine, "/**/");
    }

    /// <summary>
    /// Quotes a string in the way SQL likes
    /// </summary>
    /// <param name="aString">the initial string</param>
    /// <returns>the quoted string</returns>
    public static string QuoteStr(string aString)
    {
      if (string.IsNullOrEmpty(aString)) return @"N''";
      StringBuilder s = new StringBuilder();
      Char quotation = '\'';
      s.Append("N" + quotation);
      foreach (Char ch in aString.ToCharArray())
      {
        s.Append(ch);
        if (ch == quotation) s.Append(quotation);
      }
      s.Append(quotation);
      return s.ToString();
    }

    /// <summary>
    /// Quotes a string in the way SQL likes. If string is NULL
    /// or empty returns NULL
    /// </summary>
    /// <param name="aString">the initial string</param>
    /// <returns>the quoted string or "NULL" if the string is null or empty</returns>
    public static string QuoteOrNullStr(string aString) {
      if (string.IsNullOrEmpty(aString)) return "NULL";
      else return QuoteStr(aString);
    }

    /// <summary>
    /// converts a boolean in the way SQL likes (true = 1; false = 0)
    /// </summary>
    /// <param name="aBool">the value to convert</param>
    /// <returns>the string converted</returns>
    public static string BoolStr(bool aBool)
    {
      if (aBool)
        return "1";
      else
        return "0";
    }
    public static string Sep()
    {
      
      return Environment.NewLine;
    }



    /// <summary>
    /// Get a field from the SqlReader. If field is null returns the default Value
    /// </summary>
    /// <param name="reader">The SqlDataReader object to fetch</param>
    /// <param name="fieldNum">The field number</param>
    /// <param name="defaultValue">default Value to return is field is null</param>
    /// <returns>the field value or the default one if field is null</returns>
    public static string Get(DbDataReader reader, Int32 fieldNum, string defaultValue)
    {
      if (reader.IsDBNull(fieldNum)) { return defaultValue; }
      else { return reader.GetString(fieldNum).ToString(); }
    }
    /// <summary>
    /// Get a field from the SqlReader. If field is null returns the default Value
    /// </summary>
    /// <param name="reader">The SqlDataReader object to fetch</param>
    /// <param name="fieldName">the field name</param>
    /// <param name="defaultValue">default Value to return is field is null</param>
    /// <returns>the field value or the default one if field is null</returns>
    public static string Get(DbDataReader reader, string fieldName, string defaultValue)
    {
      return Get(reader, reader.GetOrdinal(fieldName), defaultValue);
    }

    /// <summary>
    /// Get a field from the SqlReader. If field is null returns the default Value
    /// </summary>
    /// <param name="reader">The SqlDataReader object to fetch</param>
    /// <param name="fieldNum">The field number</param>
    /// <param name="defaultValue">default Value to return is field is null</param>
    /// <returns>the field value or the default one if field is null</returns>
    public static bool Get(DbDataReader reader, Int32 fieldNum, bool defaultValue)
    {
      if (reader.IsDBNull(fieldNum)) { return defaultValue; }
      else { return (bool)reader.GetBoolean(fieldNum); }
    }
    /// <summary>
    /// Get a field from the SqlReader. If field is null returns the default Value
    /// </summary>
    /// <param name="reader">The SqlDataReader object to fetch</param>
    /// <param name="fieldName">the field name</param>
    /// <param name="defaultValue">default Value to return is field is null</param>
    /// <returns>the field value or the default one if field is null</returns>
    public static bool Get(DbDataReader reader, string fieldName, bool defaultValue)
    {
      return Get(reader, reader.GetOrdinal(fieldName), defaultValue);
    }

    /// <summary>
    /// Get a field from the SqlReader. If field is null returns the default Value
    /// </summary>
    /// <param name="reader">The SqlDataReader object to fetch</param>
    /// <param name="fieldNum">The field number</param>
    /// <param name="defaultValue">default Value to return is field is null</param>
    /// <returns>the field value or the default one if field is null</returns>
    public static Int64 Get(DbDataReader reader, Int32 fieldNum, Int64 defaultValue)
    {
      if (reader.IsDBNull(fieldNum)) { return defaultValue; }
      else
      {
        Type t = reader.GetValue(fieldNum).GetType();
        if (t == typeof(System.Int64))
        {
          return (Int64)reader.GetInt64(fieldNum);
        }
        else
        {
          return (Int64)Get(reader, fieldNum, (Int32)defaultValue);
        }

      }
    }
    /// <summary>
    /// Get a field from the SqlReader. If field is null returns the default Value
    /// </summary>
    /// <param name="reader">The SqlDataReader object to fetch</param>
    /// <param name="fieldName">the field name</param>
    /// <param name="defaultValue">default Value to return is field is null</param>
    /// <returns>the field value or the default one if field is null</returns>
    public static Int64 Get(DbDataReader reader, string fieldName, Int64 defaultValue)
    {
      return Get(reader, reader.GetOrdinal(fieldName), defaultValue);
    }



    /// <summary>
    /// Get a field from the SqlReader. If field is null returns the default Value
    /// </summary>
    /// <param name="reader">The SqlDataReader object to fetch</param>
    /// <param name="fieldNum">The field number</param>
    /// <param name="defaultValue">default Value to return is field is null</param>
    /// <returns>the field value or the default one if field is null</returns>
    public static Double Get(DbDataReader reader, Int32 fieldNum, Double defaultValue) {
      if (reader.IsDBNull(fieldNum)) { return defaultValue; }
      else {
        Type t = reader.GetValue(fieldNum).GetType();
        if (t == typeof(System.Double)) {
          return (Double)reader.GetDouble(fieldNum);
        } 
        else
        if (t == typeof(System.Single)) {
          return (Double)reader.GetFloat(fieldNum);
        }
        else {
          return (Double)Get(reader, fieldNum, (Int32)defaultValue);
        }

      }
    }
    /// <summary>
    /// Get a field from the SqlReader. If field is null returns the default Value
    /// </summary>
    /// <param name="reader">The SqlDataReader object to fetch</param>
    /// <param name="fieldName">the field name</param>
    /// <param name="defaultValue">default Value to return is field is null</param>
    /// <returns>the field value or the default one if field is null</returns>
    public static Double Get(DbDataReader reader, string fieldName, Double defaultValue) {
      return Get(reader, reader.GetOrdinal(fieldName), defaultValue);
    }









    /// <summary>
    /// Get a field from the SqlReader. If field is null returns the default Value
    /// </summary>
    /// <param name="reader">The SqlDataReader object to fetch</param>
    /// <param name="fieldNum">The field number</param>
    /// <param name="defaultValue">default Value to return is field is null</param>
    /// <returns>the field value or the default one if field is null</returns>
    public static Int32 Get(DbDataReader reader, Int32 fieldNum, Int32 defaultValue)
    {
      if (reader.IsDBNull(fieldNum)) { return defaultValue; }
      else
      {
        Type t = reader.GetValue(fieldNum).GetType();
        if (t == typeof(System.Int16))
        {
          return (Int32)reader.GetInt16(fieldNum);
        }
        else
          if (t == typeof(System.Int32))
          {
            return reader.GetInt32(fieldNum);
          }
          else
          {
            throw new System.Data.SqlTypes.SqlTypeException("Type " + reader.GetDataTypeName(fieldNum) + " not supported in DbUtils.Get(...)");
          }

      }
    }
    /// <summary>
    /// Get a field from the SqlReader. If field is null returns the default Value
    /// </summary>
    /// <param name="reader">The SqlDataReader object to fetch</param>
    /// <param name="fieldName">the field name</param>
    /// <param name="defaultValue">default Value to return is field is null</param>
    /// <returns>the field value or the default one if field is null</returns>
    public static Int32 Get(DbDataReader reader, string fieldName, Int32 defaultValue)
    {
      return Get(reader, reader.GetOrdinal(fieldName), defaultValue);
    }
    /// <summary>
    /// Get a field from the SqlReader. If field is null returns the default Value
    /// </summary>
    /// <param name="reader">The SqlDataReader object to fetch</param>
    /// <param name="fieldNum">The field number</param>
    /// <param name="defaultValue">default Value to return is field is null</param>
    /// <returns>the field value or the default one if field is null</returns>
    public static DateTime Get(DbDataReader reader, Int32 fieldNum, DateTime defaultValue)
    {
      if (reader.IsDBNull(fieldNum)) { return defaultValue; }
      else { return reader.GetDateTime(fieldNum); }
    }
    /// <summary>
    /// Get a field from the SqlReader. If field is null returns the default Value
    /// </summary>
    /// <param name="reader">The SqlDataReader object to fetch</param>
    /// <param name="fieldName">the field name</param>
    /// <param name="defaultValue">default Value to return is field is null</param>
    /// <returns>the field value or the default one if field is null</returns>
    public static DateTime Get(DbDataReader reader, string fieldName, DateTime defaultValue)
    {
      return Get(reader, reader.GetOrdinal(fieldName), defaultValue);
    }



    // .................................................................................................

    /// <summary>
    /// SQL Native client utilities
    /// </summary>
    public static class Sql
    {

      ///// <summary>
      ///// Executes a query statement and returns the DataReader. The query is executed
      ///// in a new connection that will be closed at the end.
      ///// </summary>
      ///// <param name="sqlStatement">the query to execute</param>
      ///// <returns>the data reader with data</returns>
      //public static SqlDataReader ExecQuery(string sqlStatement)
      //{
      //  SqlConnection conn = null;
      //  SqlCommand cmd = null;
      //  SqlDataReader reader = null;
      //  try
      //  {
      //    conn = new SqlConnection(CoreLib.AppEnvironment.EnvHandler.Installation.DB.GetNativeSqlConnectionString());
      //    conn.Open();
      //    cmd = new SqlCommand(sqlStatement, conn);
      //    reader = cmd.ExecuteReader();
      //  }
      //  catch
      //  {
      //    if (reader != null) { reader.Close(); }
      //    if (conn != null) { conn.Close(); }
      //    throw;
      //  }
      //  return reader;
      //}

      /// <summary>
      /// Executes a query statement and returns the DataReader. The query is executed
      /// in a new connection that will be closed at the end.
      /// </summary>
      /// <param name="connectionString">the connection string, if empty or null the 
      /// current station conn string is used</param>
      /// <param name="sqlStatement">the query to execute</param>
      /// <returns>the data reader with data</returns>
      public static SqlDataReader ExecQuery(string connectionString, string sqlStatement)
      {
        string c = connectionString;
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        try
        {
          conn = new SqlConnection(c);
          conn.Open();
          System.Diagnostics.Debug.WriteLine("ExecQuery:" + Carlop.Utils.StrUtils.ToSingleLine(sqlStatement.Trim(), "/**/"), DiagnosticsCategory);
          cmd = new SqlCommand(sqlStatement, conn);
          reader = cmd.ExecuteReader();
        }
        catch
        {
          if (reader != null) { reader.Close(); }
          if (conn != null) { conn.Close(); }
          throw;
        }
        return reader;
      }

      /// <summary>
      /// Executes a query statement and returns the DataReader. The query is executed
      /// in a new connection that will be closed at the end.
      /// </summary>
      /// <param name="connectionString">the connection string, if empty or null the 
      /// current station conn string is used</param>
      /// <param name="sqlStatement">the query to execute</param>
      /// <param name="retryNum">Num of retries before throwing exception</param>
      /// <returns>the data reader with data</returns>
      public static SqlDataReader ExecQuery(string connectionString, string sqlStatement, Int32 retryNum)
      {
        int countdown = retryNum - 1;
        SqlDataReader reader = null;
        try
        {
          reader = ExecQuery(connectionString, sqlStatement);
        }
        catch
        {
          if (reader != null) reader.Close();
          if (countdown > 0)
          {
            reader = ExecQuery(connectionString, sqlStatement, countdown);
          }
          else
          {
            throw;
          }
        }
        return reader;
      }

      /// <summary>
      /// Executes a query statement and returns the DataReader.
      /// </summary>
      /// <param name="connection">the connection object to use. MUST be valid and connected</param>
      /// <param name="sqlStatement">the query to execute</param>
      /// <returns>the data reader with data</returns>
      public static SqlDataReader ExecQuery(SqlConnection connection, string sqlStatement)
      {
        if (connection == null)
          throw new ArgumentNullException("connection");
        if (connection.State != System.Data.ConnectionState.Open)
          throw new ArgumentException("Invalid connection.State");
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        try
        {
          cmd = new SqlCommand(sqlStatement, connection);
          reader = cmd.ExecuteReader();
        }
        catch
        {
          if (reader != null) reader.Close();
          throw;
        }
        return reader;
      }

      /// <summary>
      /// Executes a query statement and returns the DataReader.
      /// </summary>
      /// <param name="connection">the connection object to use. MUST be valid and connected</param>
      /// <param name="sqlStatement">the query to execute</param>
      /// <param name="retryNum">Num of retries before throwing exception</param>
      /// <returns>the data reader with data</returns>
      public static SqlDataReader ExecQuery(SqlConnection connection, string sqlStatement, Int32 retryNum)
      {
        int countdown = retryNum - 1;
        SqlDataReader reader = null;
        try
        {
          reader = ExecQuery(connection, sqlStatement);
        }
        catch
        {
          if (reader != null) reader.Close();
          if (countdown > 0)
          {
            reader = ExecQuery(connection, sqlStatement, countdown);
          }
          else
          {
            throw;
          }
        }
        return reader;
      }

      /// <summary>
      /// Builds the ADO.NET connection string give his params
      /// </summary>
      /// <param name="provider">The data provide</param>
      /// <param name="loginMode">login mode</param>
      /// <param name="dbServer">server address or ip</param>
      /// <param name="dbName">initial database name</param>
      /// <param name="loginName">login name (if integratedSecurity = false)</param>
      /// <param name="loginPassword">login password (if integratedSecurity = false)</param>
      /// <param name="askLogin">currently not supported </param>
      /// <returns></returns>
      public static string BuildConnectionString(string provider, SqlServerLoginMode loginMode, string dbServer, string dbName, string loginName, string loginPassword, bool askLogin) {
        return BuildConnectionString(provider, loginMode, dbServer, dbName, loginName, loginPassword, askLogin, null);
      }

      /// <summary>
      /// Builds the ADO.NET connection string give his params
      /// </summary>
      /// <param name="provider">The data provide</param>
      /// <param name="loginMode">login mode</param>
      /// <param name="dbServer">server address or ip</param>
      /// <param name="dbName">initial database name</param>
      /// <param name="loginName">login name (if integratedSecurity = false)</param>
      /// <param name="loginPassword">login password (if integratedSecurity = false)</param>
      /// <param name="askLogin">currently not supported </param>
      /// <param name="applicationName">application name to be displayed in the profiler</param>
      /// <returns></returns>
      public static string BuildConnectionString(string provider, SqlServerLoginMode loginMode, string dbServer, string dbName, string loginName, string loginPassword, bool askLogin, string applicationName)
      {
        StringBuilder s = new StringBuilder();
        if (provider != "")
          s.AppendFormat("Provider={0};", provider);
        s.Append("Persist Security Info=False;");
        switch (loginMode)
        {
          case SqlServerLoginMode.UseWindowsAuthentication:
            s.Append("Integrated Security=SSPI;");
            break;
          case SqlServerLoginMode.UseSqlAuthentication:
          case SqlServerLoginMode.AskLoginPassword:
            s.AppendFormat("User ID={0};", loginName);
            s.AppendFormat("Password={0};", loginPassword);
            break;
        }
        if (!string.IsNullOrEmpty(dbName)) 
          s.AppendFormat("Initial Catalog={0};", dbName);
        s.AppendFormat("Data Source={0};", dbServer);
        if (!string.IsNullOrEmpty(applicationName)) s.AppendFormat("Application Name={0};", applicationName);
        else s.AppendFormat("Application Name={0};", 
                            System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().CodeBase));
        return s.ToString();
      }

      /// <summary>
      /// Builds the SqlClient connection string give his params. In thsi case no
      /// provider is needed
      /// </summary>
      /// <param name="loginMode">login mode</param>
      /// <param name="dbServer">server address or ip</param>
      /// <param name="dbName">initial database name</param>
      /// <param name="loginName">login name (if integratedSecurity = false)</param>
      /// <param name="loginPassword">login password (if integratedSecurity = false)</param>
      /// <param name="askLogin">currently not supported </param>
      /// <returns></returns>
      public static string BuildConnectionString(SqlServerLoginMode loginMode, string dbServer, string dbName, string loginName, string loginPassword, bool askLogin)
      {
        return BuildConnectionString("", loginMode, dbServer, dbName, loginName, loginPassword, askLogin, null);
      }
      /// <summary>
      /// Builds the SqlClient connection string give his params. In thsi case no
      /// provider is needed
      /// </summary>
      /// <param name="loginMode">login mode</param>
      /// <param name="dbServer">server address or ip</param>
      /// <param name="dbName">initial database name</param>
      /// <param name="loginName">login name (if integratedSecurity = false)</param>
      /// <param name="loginPassword">login password (if integratedSecurity = false)</param>
      /// <param name="askLogin">currently not supported </param>
      /// <param name="applicationName">application name to be displayed in the profiler</param>
      /// <returns></returns>
      public static string BuildConnectionString(SqlServerLoginMode loginMode, string dbServer, string dbName, string loginName, string loginPassword, bool askLogin, string applicationName) {
        return BuildConnectionString("", loginMode, dbServer, dbName, loginName, loginPassword, askLogin, applicationName);
      }

      public static object SelectScalar(string connectionString, string sqlStatement, object defaultValue)
      {
        SqlDataReader r = null;
        object value = new object();
        value = defaultValue;
        try
       {
          r = ExecQuery(connectionString, sqlStatement);
          if (r.Read())
          {
            if (defaultValue is string)
              value = Get(r, 0, (string)defaultValue);
            else
              if (defaultValue is Int32)
                value = Get(r, 0, (Int32)defaultValue);
              else
                if (defaultValue is Int64)
                  value = Get(r, 0, (Int64)defaultValue);
                else
                  if (defaultValue is bool)
                    value = Get(r, 0, (bool)defaultValue);
                  else
                    if (defaultValue is DateTime)
                      value = Get(r, 0, (DateTime)defaultValue);
          }
          r.Close();
        }
        catch
        {
          if (r != null) { r.Close(); }
          throw;
        }
        return value;
      }
      // <summary>
      // Executes a query statement and returns the string result.
      // </summary>
      // <param name="sqlStatement">the query to execute</param>
      // <param name="defaultValue">the default value is used if ExecQuery returns null or eof</param>
      // <returns>the string value</returns>
      public static string SelectScalar(string connectionString, string sqlStatement, string defaultValue)
      {
        return (string)SelectScalar(connectionString, sqlStatement, (object)defaultValue);
      }
      // <summary>
      // Executes a query statement and returns the int32 result.
      // </summary>
      // <param name="sqlStatement">the query to execute</param>
      // <param name="defaultValue">the default value is used if ExecQuery returns null or eof</param>
      // <returns>the int32 value</returns>
      public static Int32 SelectScalar(string connectionString, string sqlStatement, Int32 defaultValue)
      {
        return (Int32)SelectScalar(connectionString, sqlStatement, (object)defaultValue);
      }
      // <summary>
      // Executes a query statement and returns the int64 result.
      // </summary>
      // <param name="sqlStatement">the query to execute</param>
      // <param name="defaultValue">the default value is used if ExecQuery returns null or eof</param>
      // <returns>the int64 value</returns>
      public static Int64 SelectScalar(string connectionString, string sqlStatement, Int64 defaultValue)
      {
        return (Int64)SelectScalar(connectionString, sqlStatement, (object)defaultValue);
      }
      // <summary>
      // Executes a query statement and returns the bool result.
      // </summary>
      // <param name="sqlStatement">the query to execute</param>
      // <param name="defaultValue">the default value is used if ExecQuery returns null or eof</param>
      // <returns>the bool value</returns>
      public static bool SelectScalar(string connectionString, string sqlStatement, bool defaultValue)
      {
        return (bool)SelectScalar(connectionString, sqlStatement, (object)defaultValue);
      }
      // <summary>
      // Executes a query statement and returns the datetime result.
      // </summary>
      // <param name="sqlStatement">the query to execute</param>
      // <param name="defaultValue">the default value is used if ExecQuery returns null or eof</param>
      // <returns>the datetime value</returns>
      public static DateTime SelectScalar(string connectionString, string sqlStatement, DateTime defaultValue)
      {
        return (DateTime)SelectScalar(connectionString, sqlStatement, (object)defaultValue);
      }
      
      // <summary>
      // Executes a query statement.
      // </summary>
      // <param name="sqlStatement">the query to execute</param>
      // <returns>true if successed</returns>
      public static bool ExecSingleQuery(string connectionString, string sqlStatement)
      {
        return (SelectScalar(connectionString, sqlStatement + Db.Sep() + "select 1", 0) == 1);
      }


      /// <summary>
      /// Executes a query statement. The query is executed
      /// in a new connection that will be closed at the end.
      /// </summary>
      /// <param name="connectionString">the connection string, if empty or null the 
      /// current station conn string is used</param>
      /// <param name="sqlStatement">the query to execute</param>
      public static void ExecNonQuery(string connectionString, string sqlStatement) {
        string c = connectionString;
        SqlConnection conn = null;
        SqlCommand cmd = null;
        try {
          conn = new SqlConnection(c);
          conn.Open();
          System.Diagnostics.Debug.WriteLine("ExecNonQuery:" + Carlop.Utils.StrUtils.ToSingleLine(sqlStatement.Trim(), "/**/"), DiagnosticsCategory);
          cmd = new SqlCommand(sqlStatement, conn);
          cmd.ExecuteNonQuery();
        }
        catch {
          if (conn != null) { conn.Close(); }
          throw;
        }
      }

      /// <summary>
      /// Executes a query statement. The query is executed
      /// in a new connection that will be closed at the end.
      /// </summary>
      /// <param name="connectionString">the connection string, if empty or null the 
      /// current station conn string is used</param>
      /// <param name="sqlStatement">the query to execute</param>
      /// <param name="retryNum">Num of retries before throwing exception</param>
      public static void ExecNonQuery(string connectionString, string sqlStatement, Int32 retryNum) {
        int countdown = retryNum - 1;
        try {
          ExecNonQuery(connectionString, sqlStatement);
        }
        catch {
          if (countdown > 0) {
            ExecNonQuery(connectionString, sqlStatement, countdown);
          }
          else {
            throw;
          }
        }
      }

      /// <summary>
      /// Executes a query statement.
      /// </summary>
      /// <param name="connection">the connection object to use. MUST be valid and connected</param>
      /// <param name="sqlStatement">the query to execute</param>
      public static void ExecNonQuery(SqlConnection connection, string sqlStatement) {
        if (connection == null)
          throw new ArgumentNullException("connection");
        if (connection.State != System.Data.ConnectionState.Open)
          throw new ArgumentException("Invalid connection.State");
        SqlCommand cmd = null;
        try {
          cmd = new SqlCommand(sqlStatement, connection);
          cmd.ExecuteNonQuery();
        }
        catch {
          throw;
        }
      }

      /// <summary>
      /// Executes a query statement.
      /// </summary>
      /// <param name="connection">the connection object to use. MUST be valid and connected</param>
      /// <param name="sqlStatement">the query to execute</param>
      /// <param name="retryNum">Num of retries before throwing exception</param>
      public static void ExecNonQuery(SqlConnection connection, string sqlStatement, Int32 retryNum) {
        int countdown = retryNum - 1;
        try {
          ExecNonQuery(connection, sqlStatement);
        }
        catch {
          if (countdown > 0) {
            ExecNonQuery(connection, sqlStatement, countdown);
          }
          else {
            throw;
          }
        }
      }









    }




    // .................................................................................................

    /// <summary>
    /// ADO.NET utilities
    /// </summary>
    public static class OleDb
    {

      ///// <summary>
      ///// Executes a query statement and returns the DataReader. The query is executed
      ///// in a new connection that will be closed at the end.
      ///// </summary>
      ///// <param name="connectionString">the connection string, if empty or null the 
      ///// current station conn string is used</param>
      ///// <param name="sqlStatement">the query to execute</param>
      ///// <returns>the data reader with data</returns>
      //public static OleDbDataReader ExecQuery(string sqlStatement)
      //{
      //  string c = CoreLib.AppEnvironment.EnvHandler.Installation.DB.GetAdoConnectionString();
      //  OleDbConnection conn = null;
      //  OleDbCommand cmd = null;
      //  OleDbDataReader reader = null;
      //  try
      //  {
      //    conn = new OleDbConnection(c);
      //    conn.Open();
      //    cmd = new OleDbCommand(sqlStatement, conn);
      //    reader = cmd.ExecuteReader();
      //  }
      //  catch
      //  {
      //    if (reader != null) { reader.Close(); }
      //    if (conn != null) { conn.Close(); }
      //    throw;
      //  }
      //  return reader;
      //}

      /// <summary>
      /// Executes a query statement and returns the DataReader. The query is executed
      /// in a new connection that will be closed at the end.
      /// </summary>
      /// <param name="connectionString">the connection string, if empty or null the 
      /// current station conn string is used</param>
      /// <param name="sqlStatement">the query to execute</param>
      /// <param name="retryNum">Num of retries before throwing exception</param>
      /// <returns>the data reader with data</returns>
      //public static OleDbDataReader ExecQuery(string sqlStatement, Int32 retryNum)
      //{
      //  int countdown = retryNum - 1;
      //  OleDbDataReader reader = null;
      //  try
      //  {
      //    reader = ExecQuery(sqlStatement);
      //  }
      //  catch
      //  {
      //    if (reader != null) reader.Close();
      //    if (countdown > 0)
      //    {
      //      reader = ExecQuery(sqlStatement, countdown);
      //    }
      //    else
      //    {
      //      throw;
      //    }
      //  }
      //  return reader;
      //}

      /// <summary>
      /// Executes a query statement and returns the DataReader. The query is executed
      /// in a new connection that will be closed at the end.
      /// </summary>
      /// <param name="connectionString">the connection string, if empty or null the 
      /// current station conn string is used</param>
      /// <param name="sqlStatement">the query to execute</param>
      /// <returns>the data reader with data</returns>
      public static OleDbDataReader ExecQuery(string connectionString, string sqlStatement)
      {
        string c = connectionString;
        OleDbConnection conn = null;
        OleDbCommand cmd = null;
        OleDbDataReader reader = null;
        try
        {
          conn = new OleDbConnection(c);
          conn.Open();
          cmd = new OleDbCommand(sqlStatement, conn);
          reader = cmd.ExecuteReader();
        }
        catch
        {
          if (reader != null) { reader.Close(); }
          if (conn != null) { conn.Close(); }
          throw;
        }
        return reader;
      }

      /// <summary>
      /// Executes a query statement and returns the DataReader. The query is executed
      /// in a new connection that will be closed at the end.
      /// </summary>
      /// <param name="connectionString">the connection string, if empty or null the 
      /// current station conn string is used</param>
      /// <param name="sqlStatement">the query to execute</param>
      /// <param name="retryNum">Num of retries before throwing exception</param>
      /// <returns>the data reader with data</returns>
      public static OleDbDataReader ExecQuery(string connectionString, string sqlStatement, Int32 retryNum)
      {
        int countdown = retryNum - 1;
        OleDbDataReader reader = null;
        try
        {
          reader = ExecQuery(connectionString, sqlStatement);
        }
        catch
        {
          if (reader != null) reader.Close();
          if (countdown > 0)
          {
            reader = ExecQuery(connectionString, sqlStatement, countdown);
          }
          else
          {
            throw;
          }
        }
        return reader;
      }

      /// <summary>
      /// Executes a query statement and returns the DataReader.
      /// </summary>
      /// <param name="connection">the connection object to use. MUST be valid and connected</param>
      /// <param name="sqlStatement">the query to execute</param>
      /// <returns>the data reader with data</returns>
      public static OleDbDataReader ExecQuery(OleDbConnection connection, string sqlStatement)
      {
        if (connection == null)
          throw new ArgumentNullException("connection");
        if (connection.State != System.Data.ConnectionState.Open)
          throw new ArgumentException("Invalid connection.State");
        OleDbCommand cmd = null;
        OleDbDataReader reader = null;
        try
        {
          cmd = new OleDbCommand(sqlStatement, connection);
          reader = cmd.ExecuteReader();
        }
        catch
        {
          if (reader != null) reader.Close();
          throw;
        }
        return reader;
      }

      /// <summary>
      /// Executes a query statement and returns the DataReader.
      /// </summary>
      /// <param name="connection">the connection object to use. MUST be valid and connected</param>
      /// <param name="sqlStatement">the query to execute</param>
      /// <param name="retryNum">Num of retries before throwing exception</param>
      /// <returns>the data reader with data</returns>
      public static OleDbDataReader ExecQuery(OleDbConnection connection, string sqlStatement, Int32 retryNum)
      {
        int countdown = retryNum - 1;
        OleDbDataReader reader = null;
        try
        {
          reader = ExecQuery(connection, sqlStatement);
        }
        catch
        {
          if (reader != null) reader.Close();
          if (countdown > 0)
          {
            reader = ExecQuery(connection, sqlStatement, countdown);
          }
          else
          {
            throw;
          }
        }
        return reader;
      }

      /// <summary>
      /// Builds the connection string for accessing an MDB database using Jet 4
      /// </summary>
      /// <param name="dbFileName">MDB File Name</param>
      /// <returns>The connection string</returns>
      public static string BuildMdbConnectionString(string dbFileName)
      {
        return string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Persist Security Info=False", dbFileName);
      }

    }

  }





}



