

namespace Carlop.Data {



  /// <summary>
  /// List of login modes for logging into sql server
  /// </summary>
  public enum SqlServerLoginMode { 
    /// <summary>
    /// Use integrated windows OS authentication
    /// </summary>
    UseWindowsAuthentication,
    /// <summary>
    /// Use sql server security authentication
    /// </summary>
    UseSqlAuthentication,
    /// <summary>
    /// Use sql server security authentication, but always
    /// ask for password
    /// </summary>
    AskLoginPassword
  }




}