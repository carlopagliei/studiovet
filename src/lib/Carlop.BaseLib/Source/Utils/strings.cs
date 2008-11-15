using System;
using System.Text;


namespace Carlop.Utils {




  public sealed class StrUtils {


    /// <summary>
    /// Reverses a string: "abc" ---> "cba"
    /// </summary>
    /// <param name="inputStr">the input string</param>
    /// <returns>the reverted string</returns>
    public static String Reverse(String inputStr) {
      char[] Chars = inputStr.ToCharArray();
      int Length = inputStr.Length - 1;
      for (int i = 0; i < Length; i++, Length--) {
        Chars[i] ^= Chars[Length];
        Chars[Length] ^= Chars[i];
        Chars[i] ^= Chars[Length];
      }
      return new string(Chars);
    }


    /// <summary>
    /// Retrieves a substring by eliminating as much characters as needed from the 
    /// beginning of the input string: RightSubstring("abcdefg", 4) = "defg"
    /// </summary>
    /// <param name="inputStr">The input string</param>
    /// <param name="length">The length of the substring</param>
    /// <returns>The right substring</returns>
    public static String RightSubstring(String inputStr, Int32 length) {
      StringBuilder s = new StringBuilder();
      int c = 0;
      for (int i = inputStr.Length - 1; i >= 0; i--) {
        s.Insert(0, inputStr[i]);
        c++;
        if (c >= length) break;
      }
      return s.ToString();
    }



    /// <summary>
    /// cuts all newlines replacing them with the replacement string
    /// if replacement is null or empty a blank space is used
    /// </summary>
    /// <param name="query">the string to be flattened</param>
    /// <param name="replacement">with the replacement string. if replacement is null or empty a blank space is used</param>
    /// <returns>the string to be flattened string </returns>
    public static string ToSingleLine(string inputStr, string replacement) {
      if (string.IsNullOrEmpty(inputStr)) return "";
      string r;
      if (string.IsNullOrEmpty(replacement)) { r = " "; }
      else { r = replacement; };
      return r + inputStr.Replace(Environment.NewLine, r);
    }


    /// <summary>
    /// returns a new string of a specified length filled with the filler char
    /// </summary>
    /// <param name="filler">the filling char</param>
    /// <param name="length">string length</param>
    /// <returns>the new filler-filled string</returns>
    public static string StringOfChar(Char filler, Int32 length) {
      StringBuilder s = new StringBuilder(length);
      for (int i = 0; i < length; i++) {
        s.Append(filler);
      }
      return s.ToString();
    }

    /// <summary>
    /// converts a boolean value to string
    /// </summary>
    /// <param name="value">value to convert</param>
    /// <param name="strTrue">string returned if value is true</param>
    /// <param name="strFalse">string returned if value is false</param>
    /// <returns>with value = true function returns strTrue else strFalse</returns>
    public static string BoolToString(bool value, string strTrue, string strFalse)
    {
      if (value)
        return strTrue;
      else
        return strFalse;
    }

    /// <summary>
    /// Removes all non alphanumeric characters from the input string
    /// </summary>
    /// <param name="str">The input string in any available encoding</param>
    /// <returns>The stripped string. First of all the string is converted into ASCII
    /// then all non letter/digit chars are removed.</returns>
    public static string StripToAsciiAlphaDigit(string str) {
      System.Text.Encoding e = System.Text.Encoding.ASCII;
      //byte[] buf = ;
      StringBuilder s = new StringBuilder(e.GetString(e.GetBytes(str)));
      for (int i = s.Length - 1; i >= 0; i--) {
        if (!Char.IsLetterOrDigit(s[i])) {
          s.Remove(i, 1);
        }
      }
      return s.ToString();
    }






    /// <summary>
    /// used to group together all comma-delimited text functions
    /// </summary>
    public static class CommaText {

      /// <summary>
      /// The default quotation char. Used if no quotationChar is specified
      /// </summary>
      const Char DefaultQuotation = '"';

      /// <summary>
      /// The default separation char. Used if no separationChar is specified
      /// </summary>
      const Char DefaultSeparator = ',';

      /// <summary>
      /// Quotes a string. The default quotation char is used
      /// </summary>
      /// <param name="text">The string to be quoted</param>
      /// <returns>The quoted string: x"x'x --> "x""x'x" </returns>
      public static string Quote(string text) {
        return Quote(text, DefaultQuotation);
      }
      /// <summary>
      /// Quotes a string. 
      /// </summary>
      /// <param name="text">The string to be quoted</param>
      /// <param name="quotationChar">The quotation char</param>
      /// <returns>The quoted string x"x'x, ' --> 'x"x''x' </returns>
      public static string Quote(string text, Char quotationChar) {
        StringBuilder s = new StringBuilder();
        s.Append(quotationChar);
        if (!string.IsNullOrEmpty(text)) {
          foreach (Char ch in text.ToCharArray()) {
            s.Append(ch);
            if (ch == quotationChar) s.Append(quotationChar);
          }
        }
        s.Append(quotationChar);
        return s.ToString();
      }

      /// <summary>
      /// Removes quotations from a string. The default quotation char is used
      /// </summary>
      /// <param name="quotedText">The string to be unquoted</param>
      /// <returns>The unquoted string: "x""x'x" --> x"x'x</returns>
      public static string Unquote(string quotedText) {
        return Unquote(quotedText, DefaultQuotation);
      }
      /// <summary>
      /// Removes quotations from a string. 
      /// </summary>
      /// <param name="quotedText">The string to be unquoted</param>
      /// <param name="quotationChar">The quotation char</param>
      /// <returns>The unquoted string: 'x"x''x', ' --> x"x'x</returns>
      public static string Unquote(string quotedText, Char quotationChar) {
        int i = 0;
        bool quotn = false;
        StringBuilder s = new StringBuilder();
        while (i < quotedText.Length - 1) {
          if (quotedText[i] == quotationChar) {
            if ((quotn) && (i > 0) && (quotedText[i - 1] == quotationChar)) {
              s.Append(quotationChar);
              quotn = false;
            }
            else {
              quotn = (i > 0);
            }
          }
          else {
            s.Append(quotedText[i]);
            quotn = false;
          }
          i++;
        }
        return s.ToString();
      }

      /// <summary>
      /// Joins an array of strings into a comma delimited string. Default quotation and
      /// separation char are used to encode the string
      /// </summary>
      /// <param name="array">the strings to join</param>
      /// <returns>a string that represents the array in the comma-delimited format</returns>
      public static string Join(string[] array) {
        return Join(array, DefaultQuotation, DefaultSeparator);
      }
      /// <summary>
      /// Joins an array of strings into a comma delimited string
      /// </summary>
      /// <param name="array">the strings to join</param>
      /// <param name="quotationChar">The quotation char to use</param>
      /// <param name="separatorChar">The delimiter char to use</param>
      /// <returns>a string that represents the array in the comma-delimited format</returns>
      public static string Join(string[] array, Char quotationChar, Char separatorChar) {
        StringBuilder s = new StringBuilder();
        int i = 0;
        while (i < array.Length) {
          if (i > 0) s.Append(separatorChar);
          if ((array[i].IndexOf(separatorChar) > -1) || (array[i].IndexOf(quotationChar) > -1)) {
            s.Append(Quote(array[i], quotationChar));
          }
          else {
            s.Append(array[i]);
          }
          i++;
        }
        return s.ToString();
      }

      /// <summary>
      /// Splits a comma delimited string into an array of strings. Default quotation and
      /// separation char are used to encode the string
      /// </summary>
      /// <param name="commaText">the strings to split</param>
      /// <returns>the original array of string before it was converted to comma-text</returns>
      public static string[] Split(string commaText) {
        return Split(commaText, DefaultQuotation, DefaultSeparator);
      }
      /// <summary>
      /// Splits a comma delimited string into an array of strings
      /// </summary>
      /// <param name="quotationChar">The quotation char to use</param>
      /// <param name="separatorChar">The delimiter char to use</param>
      /// <param name="commaText">the strings to split</param>
      /// <returns>the original array of string before it was converted to comma-text</returns>
      public static string[] Split(string commaText, Char quotationChar, Char separatorChar) {
        int i = 0;
        int quotnFlag = 0;
        int arrayPos = 1;
        while (i < commaText.Length) {
          if (commaText[i] == quotationChar) {
            quotnFlag++;
            quotnFlag %= 2;
          }
          if ((quotnFlag == 0) && (commaText[i] == separatorChar)) {
            arrayPos++;
          }
          i++;
        }
        StringBuilder s = new StringBuilder();
        string[] strArray = new string[arrayPos];
        bool quotn = false;
        bool first = true;
        i = 0;
        quotnFlag = 0;
        arrayPos = 0;
        while (i < commaText.Length) {
          if (commaText[i] == quotationChar) {
            if ((quotn) && (!first) && (commaText[i - 1] == quotationChar)) {
              s.Append(quotationChar);
              quotn = false;
            }
            else {
              quotn = !first;
            }
            quotnFlag++;
            quotnFlag %= 2;
            first = false;
          }
          else
            if ((quotnFlag == 0) && (commaText[i] == separatorChar)) {
              strArray[arrayPos] = s.ToString();
              s.Length = 0;
              arrayPos++;
              first = true;
            }
            else {
              s.Append(commaText[i]);
              first = false;
            }
          i++;

        }
        strArray[arrayPos] = s.ToString();
        return strArray;

      }



    }











  }



}