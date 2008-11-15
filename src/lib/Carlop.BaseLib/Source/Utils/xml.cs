
using System;
using System.Xml;
using System.Xml.Schema;


namespace Carlop.Utils {


  /// <summary>
  /// helper class used to manage params in XML files
  /// <remarks>
  /// If you want to add a parameter named "address" which value is 
  /// "192.168.0.1" you can write it in one of the following formats. 
  /// <code>
  /// <...>
  ///   <address value="192.168.0.1" />
  ///   <address>192.168.0.1"</address>
  ///   <param name="address" value="192.168.0.1"/>
  ///   <param name="address">192.168.0.1</param>
  /// </...>
  /// </code>
  /// </remarks>
  public class XmlParamReader {

    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
    string originalString = "";

    /// <summary>
    /// Sets the raw XML string. Once set the XML is validated, 
    /// this method can throw an exception if the XML is not valid
    /// </summary>
    /// <param name="rawXml">the raw XML string</param>
    public void SetXml(string rawXml) {
      System.Xml.XmlDocument tempdoc = new System.Xml.XmlDocument();
      tempdoc.LoadXml(rawXml);
      originalString = rawXml;
    }

    /// <summary>
    /// gets the original XML string set by SetXML
    /// </summary>
    /// <returns>The raw XML string</returns>
    public string GetXml() {
      return originalString;
    }

    /// <summary>
    /// Retrieves a param value
    /// </summary>
    /// <param name="paramName">the param name to search for (search is case-sensitive)</param>
    /// <param name="defaultValue">The value to return if the param is not found (can be null)</param>
    /// <returns>The specified param if exists, else the default value</returns>
    public string GetValue(string paramName, string defaultValue) {
      System.Xml.XmlNodeList nodes;
      // 1st search in the form <name value="XXX"/>
      nodes = doc.DocumentElement.SelectNodes(paramName + "[@value]");
      if (nodes.Count > 0) {
        return nodes[0].Attributes.GetNamedItem("value").Value;
      }
      else {
        // 2nd search in the form <name>XXX</name>
        nodes = doc.DocumentElement.SelectNodes(paramName);
        if (nodes.Count > 0) {
          return nodes[0].InnerXml;
        }
        else {
          // 3rd search in the form <param name="name" value="XXX" />
          nodes = doc.DocumentElement.SelectNodes("param[@name='" + paramName + "']");
          if (nodes.Count > 0) {
            try {
              return nodes[0].Attributes.GetNamedItem("value").Value;
            }
            catch {
              return nodes[0].InnerXml;
            }
          }
          else {
            return defaultValue;
          }
        }
      }
    }


  }



  public static class XmlSchemaUtils {

    internal class _validationClass {
      public string message = "";
      public void _validationCb(object sender, ValidationEventArgs e) {
        message = e.Message;
      }
    }

    /// <summary>
    /// validates an XML document against a schema
    /// </summary>
    /// <param name="message">The error message if validation fails</param>
    /// <param name="xmlFile">The XML file name</param>
    /// <param name="xsdFile">The Schema file name (XSD)</param>
    /// <param name="namesp">The namespace (xmlns="????")</param>
    /// <returns>true if validation successful, false otherwise</returns>
    public static bool ValidateXmlAgainstSchema(string xmlFile, string xsdFile, string targetNamespace, out string message) {
      _validationClass v = new _validationClass();
      try {
        XmlSchemaSet sc = new XmlSchemaSet();
        // Add the schema to the collection.
        sc.Add(targetNamespace, xsdFile);
        // Set the validation settings.
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ValidationType = ValidationType.Schema;
        settings.Schemas = sc;
        settings.ValidationEventHandler += new ValidationEventHandler(v._validationCb);
        // Create the XmlReader object.
        XmlReader reader = XmlReader.Create(xmlFile, settings);
        // Parse the file. 
        while (reader.Read()) ;
        reader.Close();
      }
      catch (Exception e) {
        v.message = e.Message;
      }
      message = v.message;
      return (v.message == "");
    }


  }



}