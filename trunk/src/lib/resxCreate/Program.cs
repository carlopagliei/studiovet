using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Drawing;
using System.Xml;

namespace resxCreate {
  class Program {
    static void Main(string[] args) {

      try {
        string[] files;
        System.Text.StringBuilder s = new StringBuilder();

        Console.WriteLine("========== resx builder ==========");



        // bitmaps
        try {
          Console.WriteLine("\nBITMAPS");
          ResXResourceWriter res = new ResXResourceWriter("bmp.resX");
          files = System.IO.Directory.GetFiles(@".\", "*.bmp");
          foreach (string f in files) {
            s.Length = 0;
            Image bmp = new Bitmap(f);
            s.Append(f.Substring(2, f.Length - 2));
            s.Replace(".bmp", "");
            res.AddResource(s.ToString().ToLower(), bmp);
            Console.WriteLine("  AddResource({0}, (bmp){1})", s.ToString().ToLower(), f);
          }
          Console.WriteLine("\nGenerate bmp.resX");
          res.Generate();
          res.Close();
          Console.WriteLine("bmp generated ok");

        }
        catch (Exception ex) {
          Console.WriteLine("Operation failed !");
          Console.WriteLine(ex.Message);
        }



        // icons
        try {
          Console.WriteLine("\nICONS");
          ResXResourceWriter res = new ResXResourceWriter("ico.resX");
          files = System.IO.Directory.GetFiles(@".\", "*.ico");
          foreach (string f in files) {
            s.Length = 0;
            Icon ico = new Icon(f);
            s.Append(f.Substring(2, f.Length - 2));
            s.Replace(".ico", "");
            res.AddResource(s.ToString().ToLower(), ico);
            Console.WriteLine("  AddResource({0}, (ico){1})", s.ToString().ToLower(), f);
          }
          Console.WriteLine("\nGenerate ico.resX");
          res.Generate();
          res.Close();
          Console.WriteLine("ico generated ok");
        }
        catch (Exception ex) {
          Console.WriteLine("Operation failed !");
          Console.WriteLine(ex.Message);
        }



        // scripts
        try {
          Console.WriteLine("\nSCRIPTS");
          ResXResourceWriter res = new ResXResourceWriter("script.resX");
          files = System.IO.Directory.GetFiles(@".\", "*.xmlscript");
          s.Length = 0;
          s.Append("<scripts>");
          foreach (string f in files) {
            XmlDocument dom = new XmlDocument();
            dom.Load(f);
            XmlNodeList nodes = dom.SelectNodes("/scripts/script");
            foreach (XmlNode n in nodes) {
              s.Append(n.OuterXml);
              //string name = n.Attributes.GetNamedItem("name").Value;
              //if (!string.IsNullOrEmpty(name)) {
              //  res.AddResource("xmlscript/" + name, n.OuterXml);
              //  Console.WriteLine("  AddResource({0}, (xmlscript))", name);
              //}
            }
          }
          s.Append("</scripts>");
          res.AddResource("xmlscript", s.ToString());
          Console.WriteLine("\nGenerate script.resX");
          res.Generate();
          res.Close();
          Console.WriteLine("scripts generated ok");
        }
        catch (Exception ex) {
          Console.WriteLine("Operation failed !");
          Console.WriteLine(ex.Message);
        }



      }
      catch (Exception ex) {

        Console.WriteLine("Operation failed !");
        Console.WriteLine(ex.Message);
      }



    }
  }
}
