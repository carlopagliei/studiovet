

namespace Carlop.ClassLib.Encryption {



  /// <summary>
  /// provides a simplified access to the .NET encryption API
  /// </summary>
  public static class SimpleEncryptionApi {

    private static Symmetric.Provider _defaultProvider = Symmetric.Provider.TripleDES;
    private static Symmetric _defaultEnc;
    private readonly static string CipherKey = "9874nc937y5@z4k";
    private readonly static string MagicNum = "AFADE";

    /// <summary>
    /// Encrypts a text using the Triple DES algorythm and a standard key
    /// </summary>
    /// <param name="text">The thext to encrypt</param>
    /// <returns>The encrypted text</returns>
    /// <remarks>This Encryption method is NOT SAFE. anyone can access the DLL and
    /// crack the Ciphering key. Consider it as a way to hide plain text to 
    /// "not too skilled" users, not a way to really cipher a text</remarks>
    public static string Encrypt(string text) {
      Data d = new Data(text);
      d = _defaultEnc.Encrypt(d);
      return d.Hex;
    }

    /// <summary>
    /// Decrypts a text encrypted with the Encrypt method
    /// </summary>
    /// <param name="text">The text to decrypt</param>
    /// <returns>The decrypted text</returns>
    public static string Decrypt(string cipherText) {
      Data d = new Data();
      d.Hex = cipherText;
      d = _defaultEnc.Decrypt(d);
      return d.Text;
    }

    /// <summary>
    /// Encrypts a password using the Triple DES algorythm and a standard key, the
    /// ecrypted text is prefixed by a standard string so that the DecryptPassword
    /// method is able to distinguish between encrypled and plain text passwords
    /// </summary>
    /// <param name="text">The password to encrypt</param>
    /// <returns>The encrypted password</returns>
    /// <remarks>This Encryption method is NOT SAFE. anyone can access the DLL and
    /// crack the Ciphering key. Consider it as a way to hide plain text passwords 
    /// to "not too skilled" users, not a way to really cipher and secure a password
    /// </remarks>
    public static string EncryptPassword(string text) {
      Data d = new Data(text);
      d = _defaultEnc.Encrypt(d);
      return MagicNum + d.Hex;
    }

    /// <summary>
    /// Decrypts a password encrypted with the Encrypt method and/or a plain
    /// text password (not encrypted)
    /// </summary>
    /// <param name="text">The password to decrypt</param>
    /// <returns>The decrypted password</returns>
    public static string DecryptPassword(string cipherText) {
      Data d = new Data();
      if (cipherText.StartsWith(MagicNum)) {
        d.Hex = cipherText.Substring(MagicNum.Length);
        d = _defaultEnc.Decrypt(d);
        return d.Text;
      }
      else { 
        return cipherText;
      }
    }


    static SimpleEncryptionApi() { 
      _defaultEnc = new Symmetric(_defaultProvider, true);
      _defaultEnc.Key.Text = SimpleEncryptionApi.CipherKey;
    }


  }


}