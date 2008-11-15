using System;
using System.Xml;
using System.Xml.Serialization;


namespace Carlop.Utils {





  /// <summary>
  /// Groups utilitilies for serializing objects
  /// </summary>
  public static class SerializationUtils {

    /// <summary>
    /// Available options for serialization control
    /// By default both XML schema attributes and XML header are
    /// removed fro the final serialized object
    /// </summary>
    [Flags]
    public enum SerializationOptions {

      /// <summary>
      /// keeps XML schema attributes ("xmlns:xsi" and "xmlns:xsd").
      /// By default the schema is removed
      /// </summary>
      KeepXmlSchemaAttributes     = 0x01,

      /// <summary>
      /// Keeps the XML header into the string. By default, since the
      /// header is not strictly necessary, it is removed.
      /// </summary>
      KeepXmlHeader               = 0x02,
    }

    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    /// <summary>
    /// default serialization options used when SerializationOptions aren't specified.
    /// </summary>
    public static readonly SerializationOptions UseDefaults = 0;

    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    /// <summary>
    /// Serializes an object into an Xml string
    /// </summary>
    /// <param name="aObject">the object to serialize</param>
    /// <param name="options">specify parameters for controlling the serialization process</param>
    /// <returns>the xml string that represents the object</returns>
    public static string ToXml(object aObject, SerializationOptions options) {
      XmlSerializer ser = new XmlSerializer(aObject.GetType());
      System.IO.MemoryStream strm = new System.IO.MemoryStream();
      ser.Serialize(strm, aObject);
      strm.Seek(0, System.IO.SeekOrigin.Begin);
      System.IO.StreamReader reader = new System.IO.StreamReader(strm);
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(reader.ReadToEnd());

      if ((options & SerializationOptions.KeepXmlSchemaAttributes) == 0) {
        doc.DocumentElement.RemoveAttribute("xmlns:xsi");
        doc.DocumentElement.RemoveAttribute("xmlns:xsd");
      }

      if ((options & SerializationOptions.KeepXmlHeader) != 0) {
        return doc.OuterXml;
      }
      else {
        return doc.DocumentElement.OuterXml;
      }
    }

    /// <summary>
    /// Serializes an object into an Xml string
    /// </summary>
    /// <param name="aObject">the object to serialize</param>
    /// <returns>the xml string that represents the object</returns>
    public static string ToXml(object aObject) {
      return SerializationUtils.ToXml(aObject, UseDefaults);
    }


  }





  /// <summary>
  /// Groups utilitilies for serializing objects
  /// </summary>
  public static class DeserializationUtils {



    /// <summary>
    /// Deserializes the specified XML string object into an object
    /// </summary>
    /// <param name="aXml">the xml string that represents the object</param>
    /// <param name="aType">The type of the object to deserialize. </param>
    /// <returns>The deserialized object</returns>
    public static object FromXml(string aXml, Type aType) {
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(aXml);
      XmlReader xml = new XmlNodeReader(doc.DocumentElement);
      XmlSerializer ser = new XmlSerializer(aType);
      return ser.Deserialize(xml);
    }


  }



}