using System;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Xml;

namespace Carlop.ClassLib.Scripting {


  /// <summary>
  /// This class is a script helper that works with XML script files
  /// An XML script file is a file that contains script of any type
  /// organized using an XML structure
  /// </summary>
  /// <example> <![CDATA[
  /// Here we have an example of an xml-script file:
  /// 
  /// <scripts>
  ///	  <script type="sql" name="myscript" caption="test script">
  ///		  <param index="0" type="???" caption="???"/>
  ///		  <text> select mycolumn from mytable where myid = {0}</text>
  ///	  </script>
  ///	  <script >
  ///   ...
  ///	  </script>
  /// </scripts>
  /// ]]>
  /// </example>
  public class XmlScriptHelper : ScriptHandler {

    XmlDocument scripts = new XmlDocument();
    System.Collections.Hashtable objs = new System.Collections.Hashtable();
    private void AppendDocument(XmlDocument xmlDocument) {
      XmlNodeList items = xmlDocument.SelectNodes("scripts/script");
      foreach (XmlNode n in items) {
        scripts.DocumentElement.AppendChild(scripts.ImportNode(n, true));
      }
    }
    
    /// <summary>
    /// loads an xmlscript file
    /// </summary>
    /// <param name="filename">the xmlscript to load</param>
    public override void LoadFile(string filename){
      XmlDocument dom = new XmlDocument();
      dom.Load(filename);
      this.AppendDocument(dom);
      if (!objs.Contains(filename)) objs.Add(filename, filename);
    }
    /// <summary>
    /// loads an xml file embedded into an assembly as a .resource file.
    /// the embedded file must be named script.resource and must contain
    /// a string named "xmlscript" that contains the raw xml
    /// </summary>
    /// <param name="aAssembly">the assembly to load</param>
    public override void LoadAssembly(Assembly aAssembly) {
      string s = System.IO.Path.GetFileNameWithoutExtension(aAssembly.CodeBase);
      ResourceManager res = new ResourceManager(s + ".script", aAssembly);
      XmlDocument dom = new XmlDocument();
      dom.LoadXml(res.GetString("xmlscript"));
      this.AppendDocument(dom);
      if (!objs.Contains(aAssembly)) objs.Add(aAssembly, aAssembly);
    }

    public override void Remove(object o) {
      if (objs.Contains(o)) {
        objs.Remove(o);
        ReloadAll();
      }
    }
    public override void ReloadAll() {
      scripts.DocumentElement.RemoveAll();
      foreach (object o in objs.Values) {
        if (o is string) {
          this.LoadFile((string)o);
        }
        else
        if (o is Assembly) {
          this.LoadAssembly((Assembly)o);
        }
      }
    }
    public override bool Exists(string scriptName) {
      string q = "/scripts/script[@name='" + scriptName + "']";
      return (scripts.SelectNodes(q).Count > 0);
    }
    public override string Build(string scriptName, params object[] parms) {
      return string.Format(GetScriptText(scriptName), parms);
    }
    public override string GetScriptText(string scriptName) {
      string q = "/scripts/script[@name='" + scriptName + "']/text";
      XmlNodeList list = scripts.SelectNodes(q);
      if (list.Count > 0) {
        return list.Item(0).InnerText.Trim();
      }
      else {
        return "";
      }
    }
    public override string GetScriptMetadata(string scriptName) {
      string q = "/scripts/script[@name='" + scriptName + "']/meta";
      XmlNodeList list = scripts.SelectNodes(q);
      if (list.Count > 0) {
        return list.Item(0).InnerText.Trim();
      }
      else {
        return "";
      }
    }
    public XmlScriptHelper() {
      scripts.AppendChild(scripts.CreateElement("scripts"));
    }
  }
}
