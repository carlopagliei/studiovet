namespace Carlop.ClassLib.Encryption
{
    //using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Configuration;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Friend class for shared utility methods used by multiple Encryption classes
    /// </summary>
    internal class Utils
    {
        /// <summary>
        /// converts from a string Base64 representation to an array of bytes
        /// </summary>
        internal static byte[] FromBase64(string base64Encoded)
        {
            byte[] buffer1;
            if ((((base64Encoded == null) || (base64Encoded.Length == 0)) ? 1 : 0) != 0)
            {
                return null;
            }
            try
            {
                buffer1 = Convert.FromBase64String(base64Encoded);
            }
            catch (FormatException exception2)
            {
                throw new FormatException("The provided string does not appear to be Base64 encoded:" + Environment.NewLine + base64Encoded + Environment.NewLine, exception2);
            }
            return buffer1;
        }

        internal static byte[] FromHex(string hexEncoded)
        {
            byte[] buffer1;
            if ((((hexEncoded == null) || (hexEncoded.Length == 0)) ? 1 : 0) != 0)
            {
                return null;
            }
            try
            {
                int num1 = Convert.ToInt32((double) (((double) hexEncoded.Length) / 2));
                byte[] buffer2 = new byte[(num1 - 1) + 1];
                int num3 = num1 - 1;
                for (int num2 = 0; num2 <= num3; num2++)
                {
                    buffer2[num2] = Convert.ToByte(hexEncoded.Substring(num2 * 2, 2), 0x10);
                }
                buffer1 = buffer2;
            }
            catch (Exception exception2)
            {
                throw new FormatException("The provided string does not appear to be Hex encoded:" + Environment.NewLine + hexEncoded + Environment.NewLine, exception2);
            }
            return buffer1;
        }

        internal static string GetConfigString(string key, [Optional] bool isRequired /* = true */)
        {
            string text2 = System.Configuration.ConfigurationManager.AppSettings.Get(key);
            if (string.Compare(text2, null, false) != 0)  {
                return text2;
            }
            if (isRequired) {
                throw new System.Configuration.ConfigurationErrorsException("key <" + key + "> is missing from .config file");
            }
            return "";
        }

        /// <summary>
        /// retrieve an element from an XML string
        /// </summary>
        internal static string GetXmlElement(string xml, string element)
        {
            string[] textArray1 = new string[] { "<", element, ">(?<Element>[^>]*)</", element, ">" };
            Match match1 = Regex.Match(xml, string.Concat(textArray1), RegexOptions.IgnoreCase);
            if (match1 == null)
            {
                textArray1 = new string[] { "Could not find <", element, "></", element, "> in provided Public Key XML." };
                throw new Exception(string.Concat(textArray1));
            }
            return match1.Groups["Element"].ToString();
        }

        internal static string ToBase64(byte[] b)
        {
            if ((((b == null) || (b.Length == 0)) ? 1 : 0) != 0)
            {
                return "";
            }
            return Convert.ToBase64String(b);
        }

        /// <summary>
        /// converts an array of bytes to a string Hex representation
        /// </summary>
        internal static string ToHex(byte[] ba)
        {
            if ((((ba == null) || (ba.Length == 0)) ? 1 : 0) != 0)
            {
                return "";
            }
            StringBuilder builder1 = new StringBuilder();
            byte[] buffer1 = ba;
            for (int num2 = 0; num2 < buffer1.Length; num2++)
            {
                byte num1 = buffer1[num2];
                builder1.Append(string.Format("{0:X2}", num1));
            }
            return builder1.ToString();
        }

        internal static string WriteConfigKey(string key, string value)
        {
            string text1 = "<add key=\"{0}\" value=\"{1}\" />" + Environment.NewLine;
            return string.Format(text1, key, value);
        }

        internal static string WriteXmlElement(string element, string value)
        {
            string text1 = "<{0}>{1}</{0}>" + Environment.NewLine;
            return string.Format(text1, element, value);
        }

        internal static string WriteXmlNode(string element, [Optional] bool isClosing /* = false */)
        {
            string text1;
            if (isClosing)
            {
                text1 = "</{0}>" + Environment.NewLine;
            }
            else
            {
                text1 = "<{0}>" + Environment.NewLine;
            }
            return string.Format(text1, element);
        }

    }
}

