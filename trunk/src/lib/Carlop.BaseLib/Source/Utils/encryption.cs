

namespace Carlop.Utils {



  /// <summary>
  /// provides basic utils for encryption
  /// </summary>
  public static class EncryptionUtils {

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
      return Carlop.ClassLib.Encryption.SimpleEncryptionApi.EncryptPassword(text);
    }

    /// <summary>
    /// Decrypts a password encrypted with the Encrypt method and/or a plain
    /// text password (not encrypted)
    /// </summary>
    /// <param name="text">The password to decrypt</param>
    /// <returns>The decrypted password</returns>
    public static string DecryptPassword(string cipherText) {
      return Carlop.ClassLib.Encryption.SimpleEncryptionApi.DecryptPassword(cipherText);
    }

  }


}