using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

using Carlop.Configuration;
using Carlop.Data;
using Carlop.Utils;
using System.Windows.Forms;

namespace StudioVet.Core {


  public static class AppData {

    public static RegistryCfgStorage Registry = new RegistryCfgStorage();

    private static XmlFileCfgStorage _localXml;

    private static SqlCfgStorage _sqlCfg;

    private static SqlCfgStorage cfg {
      get {
        if (_sqlCfg == null) _sqlCfg = new SqlCfgStorage();
        if (_sqlCfg.ConnectionString != ConnectionString) _sqlCfg.ConnectionString = ConnectionString;
        return _sqlCfg;
      }
    }

    public static ToolStripRenderMode MenuRenderMode = ToolStripRenderMode.Professional;

    public static class Colors {

      #region COLOR_PALETTES
      /*
            public enum Palette {
              System1,
              //System2,
              //MenuLike,
              //Gold,
              //Default,
              //Green,
              //RoyalBlue,
              //Custom
            }

            private static bool customPalette = false;

            internal static void SelectPalette(Palette palette) {
              customPalette = (palette == Palette.System1);
              switch (palette) {
                case Palette.System1:
                  _H1Background = SystemColors.InactiveCaption;
                  _H1Foreground = SystemColors.InactiveCaptionText;
                  _H2Background = SystemColors.ControlLight;
                  _H2Foreground = SystemColors.ControlText;
                  _H3Background = SystemColors.InactiveCaption;
                  _H3Foreground = SystemColors.InactiveCaptionText;
                  _Control = SystemColors.Window;
                  _ControlText = SystemColors.WindowText;
                  _Selection = Color.LemonChiffon;
                  _SelectionText = Color.Black;
                  _HyperlinkNormal = SystemColors.ControlText;
                  _HyperlinkActive = SystemColors.ControlText;
                  break;
                //case Palette.System1:
                //  _H1Background = SystemColors.InactiveCaption;
                //  _H1Foreground = SystemColors.InactiveCaptionText;
                //  _H2Background = SystemColors.Control;
                //  _H2Foreground = SystemColors.ControlText;
                //  _H3Background = SystemColors.InactiveCaption;
                //  _H3Foreground = SystemColors.InactiveCaptionText;
                //  _HyperlinkNormal = SystemColors.ControlText;
                //  _HyperlinkActive = SystemColors.ControlText;
                //  break;
                //case Palette.System2:
                //  _H1Background = SystemColors.ControlDark;
                //  _H1Foreground = SystemColors.ControlLightLight;
                //  _H2Background = SystemColors.ControlLight;
                //  _H2Foreground = SystemColors.ControlText;
                //  _H3Background = SystemColors.ControlDark;
                //  _H3Foreground = SystemColors.ControlLightLight;
                //  _HyperlinkNormal = SystemColors.ControlText;
                //  _HyperlinkActive = SystemColors.ControlText;
                //  break;
                //case Palette.Gold:
                //  _H1Background = Color.DarkGoldenrod;
                //  _H1Foreground = Color.PaleGoldenrod;
                //  _H2Background = Color.PaleGoldenrod;
                //  _H2Foreground = Color.Brown;
                //  _H3Background = Color.DarkGoldenrod;
                //  _H3Foreground = Color.PaleGoldenrod;
                //  _HyperlinkNormal = Color.DarkRed;
                //  _HyperlinkActive = Color.DarkOrange;
                //  break;
                //case Palette.Default:
                //  _H1Background = Color.SteelBlue;
                //  _H1Foreground = Color.LightSteelBlue;
                //  _H2Background = Color.LightSteelBlue;
                //  _H2Foreground = Color.SteelBlue;
                //  _H3Background = Color.SteelBlue;
                //  _H3Foreground = Color.LightSteelBlue;
                //  _HyperlinkNormal = Color.DarkRed;
                //  _HyperlinkActive = Color.SteelBlue;
                //  break;
                //case Palette.Green:
                //  _H1Background = Color.Green;
                //  _H1Foreground = Color.White;
                //  _H2Background = Color.YellowGreen;
                //  _H2Foreground = Color.ForestGreen;
                //  _H3Background = Color.Green;
                //  _H3Foreground = Color.White;
                //  _HyperlinkNormal = Color.DarkGreen;
                //  _HyperlinkActive = Color.DarkGreen;
                //  break;
                //case Palette.RoyalBlue:
                //  _H1Background = Color.RoyalBlue;
                //  _H1Foreground = Color.LightSteelBlue;
                //  _H2Background = Color.LightSteelBlue;
                //  _H2Foreground = Color.RoyalBlue;
                //  _H3Background = Color.RoyalBlue;
                //  _H3Foreground = Color.LightSteelBlue;
                //  _HyperlinkNormal = Color.RoyalBlue;
                //  _HyperlinkActive = Color.LightCyan;
                //  break;
                //case Palette.MenuLike:
                //  _H1Background = SystemColors.MenuHighlight;
                //  _H1Foreground = SystemColors.Menu;
                //  _H2Background = SystemColors.InactiveCaptionText;
                //  _H2Foreground = SystemColors.ActiveCaption;
                //  _H3Background = SystemColors.MenuHighlight;
                //  _H3Foreground = SystemColors.Menu;
                //  _HyperlinkNormal = SystemColors.ActiveCaption;
                //  _HyperlinkActive = SystemColors.ActiveCaption;
                //  break;
                //case Palette.Custom:
                //  break;

              };
              _paletteSet = true;
            }


            public static Color StandardBorderColor = SystemColors.ControlDarkDark;

            static bool _paletteSet = false;
            internal static Palette defaultPalette = Palette.System1;
            static Color _get(string colorName, Color defValue) {
              if (customPalette) {
                return Color.FromName(_localXml.GetValue("colors", colorName, defValue.Name));
              }
              else
                return defValue;
            }
            static void _load() {
              if (!_paletteSet) {
                Palette p = (Palette)_localXml.GetValue("colors", "palette", (int)defaultPalette);
                SelectPalette(p);
                _paletteSet = true;
              }
            }

            static Color _H1Background;
            static Color _H1Foreground;
            static Color _H2Background;
            static Color _H2Foreground;
            static Color _H3Background;
            static Color _H3Foreground;
            static Color _Control;
            static Color _ControlText;
            static Color _Selection;
            static Color _SelectionText;
            static Color _HyperlinkNormal;
            static Color _HyperlinkActive;

            public static Color H1Background { get { _load(); return _get("H1Background", _H1Background); } }
            public static Color H1Foreground { get { _load(); return _get("H1Foreground", _H1Foreground); } }
            public static Color H2Background { get { _load(); return _get("H2Background", _H2Background); } }
            public static Color H2Foreground { get { _load(); return _get("H2Foreground", _H2Foreground); } }
            public static Color H3Background { get { _load(); return _get("H3Background", _H3Background); } }
            public static Color H3Foreground { get { _load(); return _get("H3Foreground", _H3Foreground); } }
            public static Color Control { get { _load(); return _get("ControlBackground", _Control); } }
            public static Color ControlText { get { _load(); return _get("ControlText", _ControlText); } }
            public static Color Selection { get { _load(); return _get("SelectionBackground", _Selection); } }
            public static Color SelectionText { get { _load(); return _get("SelectionText", _SelectionText); } }
            public static Color HyperlinkNormal { get { _load(); return _get("HyperlinkNormal", _HyperlinkNormal); } }
            public static Color HyperlinkActive { get { _load(); return _get("HyperlinkActive", _HyperlinkActive); } }

            //public static Color MyColor
            //{
            //  get { return Color.FromName(_localXml.GetValue("appearance", "testColor", "DarkOrange")); }
            //  set { _localXml.SetValue("appearance", "testColor", value.Name); }
            //}

      */


      //private static Color StandardBorderColorDefault = SystemColors.ControlDarkDark;
      //private static Color H1BackgroundDefault = Color.SlateGray;
      //private static Color H1ForegroundDefault = Color.Gainsboro;
      //private static Color H2BackgroundDefault = Color.Gainsboro;
      //private static Color H2ForegroundDefault = Color.SlateGray;
      //private static Color H3BackgroundDefault = Color.LightSlateGray;
      //private static Color H3ForegroundDefault = Color.Gainsboro;
      //private static Color ControlDefault = SystemColors.Window;
      //private static Color ControlTextDefault = SystemColors.WindowText;
      //private static Color SelectionDefault = Color.LemonChiffon;
      //private static Color SelectionTextDefault = Color.Black;
      //private static Color HyperlinkNormalDefault = Color.SlateGray;
      //private static Color HyperlinkActiveDefault = Color.DarkGoldenrod;
      //private static Color GridCellBkReadOnlyDefault = Color.Lavender;
      //private static Color GridCellBkWarnDefault = Color.Gold;
      //private static Color GridCellBkOopsDefault = Color.Orange;
      #endregion

      private static Color StandardBorderColorDefault = SystemColors.ControlDarkDark;
      private static Color H1BackgroundDefault = SystemColors.ActiveCaption;
      private static Color H1ForegroundDefault = SystemColors.ActiveCaptionText;
      private static Color H2BackgroundDefault = SystemColors.InactiveCaptionText;
      private static Color H2ForegroundDefault = SystemColors.InactiveCaption;
      private static Color H3BackgroundDefault = SystemColors.InactiveCaption;
      private static Color H3ForegroundDefault = SystemColors.InactiveCaptionText;
      private static Color ControlDefault = SystemColors.Window;
      private static Color ControlTextDefault = SystemColors.WindowText;
      private static Color SelectionDefault = SystemColors.InactiveCaption;
      private static Color SelectionTextDefault = SystemColors.InactiveCaptionText;
      private static Color HyperlinkNormalDefault = SystemColors.HotTrack;
      private static Color HyperlinkActiveDefault = SystemColors.HotTrack;
      private static Color GridCellBkReadOnlyDefault = SystemColors.ControlLight;
      private static Color GridCellBkWarnDefault = Color.Gold;
      private static Color GridCellBkOopsDefault = Color.Orange;
      private static Color GridCellBkAzzDefault = Color.Red;

      private static Color? _StandardBorderColor;
      private static Color? _H1Background;
      private static Color? _H1Foreground;
      private static Color? _H2Background;
      private static Color? _H2Foreground;
      private static Color? _H3Background;
      private static Color? _H3Foreground;
      private static Color? _Control;
      private static Color? _ControlText;
      private static Color? _Selection;
      private static Color? _SelectionText;
      private static Color? _HyperlinkNormal;
      private static Color? _HyperlinkActive;
      private static Color? _GridCellBkReadOnly;
      private static Color? _GridCellBkWarn;
      private static Color? _GridCellBkOops;
      private static Color? _GridCellBkAzz;

      public static Color StandardBorderColor {
        get {
          if (_StandardBorderColor == null)
            _StandardBorderColor = Color.FromName(
              _localXml.GetValue("colors", "StandardBorderColor",
              StandardBorderColorDefault.Name)
              );
          return _StandardBorderColor.Value;
        }
        set {
          _StandardBorderColor = value;
          _localXml.SetValue("colors", "StandardBorderColor", value.Name);
        }
      }
      public static Color H1Background {
        get {
          if (_H1Background == null)
            _H1Background = Color.FromName(
              _localXml.GetValue("colors", "H1Background",
              H1BackgroundDefault.Name)
              );
          return _H1Background.Value;
        }
        set {
          _H1Background = value;
          _localXml.SetValue("colors", "H1Background", value.Name);
        }
      }
      public static Color H1Foreground {
        get {
          if (_H1Foreground == null)
            _H1Foreground = Color.FromName(
              _localXml.GetValue("colors", "H1Foreground",
              H1ForegroundDefault.Name)
              );
          return _H1Foreground.Value;
        }
        set {
          _H1Foreground = value;
          _localXml.SetValue("colors", "H1Foreground", value.Name);
        }
      }
      public static Color H2Background {
        get {
          if (_H2Background == null)
            _H2Background = Color.FromName(
              _localXml.GetValue("colors", "H2Background",
              H2BackgroundDefault.Name)
              );
          return _H2Background.Value;
        }
        set {
          _H2Background = value;
          _localXml.SetValue("colors", "H2Background", value.Name);
        }
      }
      public static Color H2Foreground {
        get {
          if (_H2Foreground == null)
            _H2Foreground = Color.FromName(
              _localXml.GetValue("colors", "H2Foreground",
              H2ForegroundDefault.Name)
              );
          return _H2Foreground.Value;
        }
        set {
          _H2Foreground = value;
          _localXml.SetValue("colors", "H2Foreground", value.Name);
        }
      }
      public static Color H3Background {
        get {
          if (_H3Background == null)
            _H3Background = Color.FromName(
              _localXml.GetValue("colors", "H3Background",
              H3BackgroundDefault.Name)
              );
          return _H3Background.Value;
        }
        set {
          _H3Background = value;
          _localXml.SetValue("colors", "H3Background", value.Name);
        }
      }
      public static Color H3Foreground {
        get {
          if (_H3Foreground == null)
            _H3Foreground = Color.FromName(
              _localXml.GetValue("colors", "H3Foreground",
              H3ForegroundDefault.Name)
              );
          return _H3Foreground.Value;
        }
        set {
          _H3Foreground = value;
          _localXml.SetValue("colors", "H3Foreground", value.Name);
        }
      }
      public static Color Control {
        get {
          if (_Control == null)
            _Control = Color.FromName(
              _localXml.GetValue("colors", "Control",
              ControlDefault.Name)
              );
          return _Control.Value;
        }
        set {
          _Control = value;
          _localXml.SetValue("colors", "Control", value.Name);
        }
      }
      public static Color ControlText {
        get {
          if (_ControlText == null)
            _ControlText = Color.FromName(
              _localXml.GetValue("colors", "ControlText",
              ControlTextDefault.Name)
              );
          return _ControlText.Value;
        }
        set {
          _ControlText = value;
          _localXml.SetValue("colors", "ControlText", value.Name);
        }
      }
      public static Color Selection {
        get {
          if (_Selection == null)
            _Selection = Color.FromName(
              _localXml.GetValue("colors", "Selection",
              SelectionDefault.Name)
              );
          return _Selection.Value;
        }
        set {
          _Selection = value;
          _localXml.SetValue("colors", "Selection", value.Name);
        }
      }
      public static Color SelectionText {
        get {
          if (_SelectionText == null)
            _SelectionText = Color.FromName(
              _localXml.GetValue("colors", "SelectionText",
              SelectionTextDefault.Name)
              );
          return _SelectionText.Value;
        }
        set {
          _SelectionText = value;
          _localXml.SetValue("colors", "SelectionText", value.Name);
        }
      }
      public static Color HyperlinkNormal {
        get {
          if (_HyperlinkNormal == null)
            _HyperlinkNormal = Color.FromName(
              _localXml.GetValue("colors", "HyperlinkNormal",
              HyperlinkNormalDefault.Name)
              );
          return _HyperlinkNormal.Value;
        }
        set {
          _HyperlinkNormal = value;
          _localXml.SetValue("colors", "HyperlinkNormal", value.Name);
        }
      }
      public static Color HyperlinkActive {
        get {
          if (_HyperlinkActive == null)
            _HyperlinkActive = Color.FromName(
              _localXml.GetValue("colors", "HyperlinkActive",
              HyperlinkActiveDefault.Name)
              );
          return _HyperlinkActive.Value;
        }
        set {
          _HyperlinkActive = value;
          _localXml.SetValue("colors", "HyperlinkActive", value.Name);
        }
      }
      public static Color GridCellBkReadOnly {
        get {
          if (_GridCellBkReadOnly == null)
            _GridCellBkReadOnly = Color.FromName(
              _localXml.GetValue("colors", "GridCellBkReadOnly",
              GridCellBkReadOnlyDefault.Name)
              );
          return _GridCellBkReadOnly.Value;
        }
        set {
          _GridCellBkReadOnly = value;
          _localXml.SetValue("colors", "GridCellBkReadOnly", value.Name);
        }
      }
      public static Color GridCellBkWarn {
        get {
          if (_GridCellBkWarn == null)
            _GridCellBkWarn = Color.FromName(
              _localXml.GetValue("colors", "GridCellBkWarn",
              GridCellBkWarnDefault.Name)
              );
          return _GridCellBkWarn.Value;
        }
        set {
          _GridCellBkWarn = value;
          _localXml.SetValue("colors", "GridCellBkWarn", value.Name);
        }
      }
      public static Color GridCellBkOops {
        get {
          if (_GridCellBkOops == null)
            _GridCellBkOops = Color.FromName(
              _localXml.GetValue("colors", "GridCellBkOops",
              GridCellBkOopsDefault.Name)
              );
          return _GridCellBkOops.Value;
        }
        set {
          _GridCellBkOops = value;
          _localXml.SetValue("colors", "GridCellBkOops", value.Name);
        }
      }
      public static Color GridCellBkAzz {
        get {
          if (_GridCellBkAzz == null)
            _GridCellBkAzz = Color.FromName(
              _localXml.GetValue("colors", "GridCellBkAzz",
              GridCellBkAzzDefault.Name)
              );
          return _GridCellBkAzz.Value;
        }
        set {
          _GridCellBkAzz = value;
          _localXml.SetValue("colors", "GridCellBkAzz", value.Name);
        }
      }


    }

    public class Fonts {

      private static Font H1Default = new Font("Georgia", 14);
      private static Font H2Default = new Font("Georgia", 12);
      private static Font H3Default = new Font("Georgia", 11);
      private static Font HyperlinkDefault = new Font("Georgia", 11);
      private static Font NormalTextDefault = new Font("Tahoma", 10);

      private static Font _H1;
      private static Font _H2;
      private static Font _H3;
      private static Font _Hyperlink;
      private static Font _NormalText;

      public static Font H1 {
        get {
          if (_H1 == null)
            _H1 = new Font(
              _localXml.GetValue("fonts", "H1.Name", H1Default.Name),
              (float)_localXml.GetValue("fonts", "H1.Size", H1Default.Size)
              );
          return _H1;
        }
        set {
          _H1 = value;
          _localXml.SetValue("fonts", "H1.Name", value.Name);
          _localXml.SetValue("fonts", "H1.Size", value.Size);
        }
      }
      public static Font H2 {
        get {
          if (_H2 == null)
            _H2 = new Font(
              _localXml.GetValue("fonts", "H2.Name", H2Default.Name),
              (float)_localXml.GetValue("fonts", "H2.Size", H2Default.Size)
              );
          return _H2;
        }
        set {
          _H2 = value;
          _localXml.SetValue("fonts", "H2.Name", value.Name);
          _localXml.SetValue("fonts", "H2.Size", value.Size);
        }
      }
      public static Font H3 {
        get {
          if (_H3 == null)
            _H3 = new Font(
              _localXml.GetValue("fonts", "H3.Name", H3Default.Name),
              (float)_localXml.GetValue("fonts", "H3.Size", H3Default.Size)
              );
          return _H3;
        }
        set {
          _H3 = value;
          _localXml.SetValue("fonts", "H3.Name", value.Name);
          _localXml.SetValue("fonts", "H3.Size", value.Size);
        }
      }
      public static Font Hyperlink {
        get {
          if (_Hyperlink == null)
            _Hyperlink = new Font(
              _localXml.GetValue("fonts", "Hyperlink.Name", HyperlinkDefault.Name),
              (float)_localXml.GetValue("fonts", "Hyperlink.Size", HyperlinkDefault.Size)
              );
          return _Hyperlink;
        }
        set {
          _Hyperlink = value;
          _localXml.SetValue("fonts", "Hyperlink.Name", value.Name);
          _localXml.SetValue("fonts", "Hyperlink.Size", value.Size);
        }
      }
      public static Font NormalText {
        get {
          if (_NormalText == null)
            _NormalText = new Font(
              _localXml.GetValue("fonts", "NormalText.Name", NormalTextDefault.Name),
              (float)_localXml.GetValue("fonts", "NormalText.Size", NormalTextDefault.Size)
              );
          return _NormalText;
        }
        set {
          _NormalText = value;
          _localXml.SetValue("fonts", "NormalText.Name", value.Name);
          _localXml.SetValue("fonts", "NormalText.Size", value.Size);
        }
      }



    }

    public static class Db {
      public static string Server {
        get { return (string)_localXml.GetValue("db", "server", @""); }
        set { _localXml.SetValue("db", "server", value); }
      }
      public static string Database {
        get { return (string)_localXml.GetValue("db", "database", ""); }
        set { _localXml.SetValue("db", "database", value); }
      }
      public static bool WindowsAuthentication {
        get { return (bool)_localXml.GetValue("db", "windowsAuthentication", true); }
        set { _localXml.SetValue("db", "windowsAuthentication", value); }
      }
      public static string User {
        get { return (string)_localXml.GetValue("db", "user", ""); }
        set { _localXml.SetValue("db", "user", value); }
      }
      public static string Password {
        get { return EncryptionUtils.DecryptPassword((string)_localXml.GetValue("db", "password", "")); }
        set { _localXml.SetValue("db", "password", EncryptionUtils.EncryptPassword(value)); }
      }

    }

    public static string ConnectionString {
      get {
        SqlServerLoginMode lm = (Db.WindowsAuthentication ? SqlServerLoginMode.UseWindowsAuthentication : SqlServerLoginMode.UseSqlAuthentication);
        return Carlop.Data.Db.Sql.BuildConnectionString(lm, Db.Server, Db.Database, Db.User, Db.Password, false);
      }
    }

    public static string ZipcodesTable {
      get { return cfg.GetValue("db", "ZipcodesTable", "[dbo].[ZipCode]"); }
      set { cfg.SetValue("db", "ZipcodesTable", value); }
    }

    public static bool PreviewCodesWhenEditing {
      get { return false; }
    }


    public static string TaxCodeCalculator {
      get { return System.IO.Path.Combine(Environment.CurrentDirectory, "codfis.exe"); }
    }

    public static string Culture {
      get { return (string)_localXml.GetValue("language", "culture", ""); }
      set { _localXml.SetValue("language", "culture", value); }
    }

    public static class SqlScripts {

      //public static bool Exists(string scriptName) {
      //  return (sqlscripts_file.DocumentElement.SelectSingleNode("./" + scriptName) != null);
      //}

      //public static string Format(string scriptName, params object[] paramsArray) {
      //  XmlNode x = sqlscripts_file.DocumentElement.SelectSingleNode("./" + scriptName);
      //  if (x != null) return string.Format(x.InnerText, paramsArray);
      //  else return "";
      //}

      public static string ExecSP(string spName, params object[] paramsArray) {
        string s = "";
        if (paramsArray.Length > 0) {
          foreach (object o in paramsArray) s += o.ToString() + ", ";
          s = s.Substring(0, s.Length - 2);
        }
        return string.Format("exec [dbo].[{0}] {1}", spName, s);
      }

    }

    public static class Doma {

      private static string _documentsRoot = null;

      public static string AutoCapturePath {
        get { return (string)_localXml.GetValue("doma", "autocapturePath", Doma.DocumentsRoot); }
        set { _localXml.SetValue("doma", "autocapturePath", value); }

      }

      static bool forcedir = true;
      public static string DocumentsRoot {
        get {
          if (string.IsNullOrEmpty(_documentsRoot)) {
            _documentsRoot = cfg.GetValue("doma", "DocumentsRoot", "");
            if (string.IsNullOrEmpty(_documentsRoot))
              _documentsRoot = System.IO.Path.Combine(Environment.CurrentDirectory, "documents");
          }
          if (forcedir) {
              try
              {
                  System.IO.Directory.CreateDirectory(_documentsRoot);
                  forcedir = false;
              }
              catch 
              {
                  _documentsRoot = System.IO.Path.Combine(Environment.CurrentDirectory, "documents");
              }
          }
          return _documentsRoot;
        }
        set {
          _documentsRoot = value;
          cfg.SetValue("doma", "DocumentsRoot", value);
        }

      }

      public static string Path(int PersonId, int PatientId, int VisitId) {
        string s = DocumentsRoot;
        if (PersonId > 0) {
          s = System.IO.Path.Combine(s, "P" + PersonId.ToString("D7"));
        }
        if (PatientId > 0) {
          s = System.IO.Path.Combine(s, "T" + PatientId.ToString("D7"));
        }
        if (VisitId > 0) {
          s = System.IO.Path.Combine(s, "V" + VisitId.ToString("D7"));
        }
        return s;


      }

    }

    public static class Printing {

      private static string _reportTemplate = null;
      private static string _tabrepTemplate = null;
      public static string ReportTemplate {
        get {
          if (string.IsNullOrEmpty(_reportTemplate)) {
            _reportTemplate = cfg.GetValue("prints", "reportTemplate", "");
            if (string.IsNullOrEmpty(_reportTemplate))
              _reportTemplate = System.IO.Path.Combine(Environment.CurrentDirectory, @"templates\report.htm");
          }
          return _reportTemplate;
        }
        set {
          _reportTemplate = value;
          cfg.SetValue("prints", "reportTemplate", value);
        }
      }
      public static string TabularPrintTemplate {
        get {
          if (string.IsNullOrEmpty(_tabrepTemplate)) {
            _reportTemplate = cfg.GetValue("prints", "tabreportTemplate", "");
            if (string.IsNullOrEmpty(_tabrepTemplate))
              _tabrepTemplate = System.IO.Path.Combine(Environment.CurrentDirectory, @"templates\tabreport.htm");
          }
          return _tabrepTemplate;
        }
        set {
          _tabrepTemplate = value;
          cfg.SetValue("prints", "tabreportTemplate", value);
        }
      }
      public static string TabularPrintTemplate_tdh {
        get {
          return
            System.IO.Path.Combine(
              System.IO.Path.GetDirectoryName(TabularPrintTemplate),
              System.IO.Path.GetFileNameWithoutExtension(TabularPrintTemplate) + "_tdh.htm");
        }
      }
      public static string TabularPrintTemplate_tdv {
        get {
          return
            System.IO.Path.Combine(
              System.IO.Path.GetDirectoryName(TabularPrintTemplate),
              System.IO.Path.GetFileNameWithoutExtension(TabularPrintTemplate) + "_tdv.htm");
        }
      }

      private static string _signature = null;

      public static string Signature {
        get {
          if (string.IsNullOrEmpty(_signature)) _signature = cfg.GetValue("prints", "signature", "");
          return _signature;
        }
        set {
          _signature = value;
          cfg.SetValue("prints", "signature", value);
        }
      }
    }

    public static class Invoicing {

      private static double? _vat;
      private static bool? _vatIncludedRates;
      private static string _invoiceTemplate = null;
      private static string _companyHeading1 = null;
      private static string _companyHeading2 = null;
      private static string _paymentTerms = null;
      private static string _paymentCurrency = null;

      public static double VAT {
        get {
          if (_vat == null) {
            double d = 0.0;
            double.TryParse(cfg.GetValue("invoicing", "VAT", ""), out d);
            _vat = d;
          }
          return _vat.Value;
        }
        set {
          _vat = value;
          cfg.SetValue("invoicing", "VAT", _vat.Value);
        }
      }
      public static bool VatIncludedRates {
        get {
          if (_vatIncludedRates == null) {
            bool b = true;
            bool.TryParse(cfg.GetValue("invoicing", "VATIncludedRates", "True"), out b);
            _vatIncludedRates = b;
          }
          return _vatIncludedRates.Value;
        }
        set {
          _vatIncludedRates = value;
          cfg.SetValue("invoicing", "VATIncludedRates", _vatIncludedRates.Value);
        }
      }
      public static string InvoiceTemplate {
        get {
          if (string.IsNullOrEmpty(_invoiceTemplate)) {
            _invoiceTemplate = cfg.GetValue("invoicing", "InvoiceTemplate", "");
            if (string.IsNullOrEmpty(_invoiceTemplate))
              _invoiceTemplate = System.IO.Path.Combine(Environment.CurrentDirectory, @"templates\invoice.htm");
          }
          return _invoiceTemplate;
        }
        set {
          _invoiceTemplate = value;
          cfg.SetValue("invoicing", "InvoiceTemplate", value);
        }
      }
      public static string CompanyHeading1 {
        get {
          if (string.IsNullOrEmpty(_companyHeading1))
            _companyHeading1 = cfg.GetValue("invoicing", "CompanyHeading1", "");
          return _companyHeading1;
        }
        set {
          _companyHeading1 = value;
          cfg.SetValue("invoicing", "CompanyHeading1", value);
        }
      }
      public static string CompanyHeading2 {
        get {
          if (string.IsNullOrEmpty(_companyHeading2))
            _companyHeading2 = cfg.GetValue("invoicing", "CompanyHeading2", "");
          return _companyHeading2;
        }
        set {
          _companyHeading2 = value;
          cfg.SetValue("invoicing", "CompanyHeading2", value);
        }
      }
      public static string PaymentTerms {
        get {
          if (string.IsNullOrEmpty(_paymentTerms))
            _paymentTerms = cfg.GetValue("invoicing", "PaymentTerms", "");
          return _paymentTerms;
        }
        set {
          _paymentTerms = value;
          cfg.SetValue("invoicing", "PaymentTerms", value);
        }
      }
      public static string PaymentCurrency {
        get {
          if (string.IsNullOrEmpty(_paymentCurrency))
            _paymentCurrency = cfg.GetValue("invoicing", "PaymentCurrency", "");
          return _paymentCurrency;
        }
        set {
          _paymentCurrency = value;
          cfg.SetValue("invoicing", "PaymentCurrency", value);
        }
      }


    }



    private static XmlDocument cfg_file;
    //private static XmlDocument sqlscripts_file;

    static AppData() {

      string config_xml = System.IO.Path.Combine(Environment.CurrentDirectory, "config.xml");

      cfg_file = new XmlDocument();

      if (System.IO.File.Exists(config_xml)) {
        try {
          cfg_file.Load(config_xml);
        } 
        catch (Exception) {
          MessageBox.Show(
            "The configuration file \"" + config_xml + "\" is corrupted. Configuration has been reset to default", 
            "Error", 
            MessageBoxButtons.OK, 
            MessageBoxIcon.Error);
          cfg_file.LoadXml("<configuration />");
          cfg_file.Save(config_xml);
        }
      }

      _localXml = new XmlFileCfgStorage(config_xml);

      //sqlscripts_file = new XmlDocument();
      //sqlscripts_file.Load(System.IO.Path.Combine(Environment.CurrentDirectory, "sqlscripts.xml"));


      // TMP: JUST TO WRITE VALUES IN THE XML CONFIG FILE
      // UNTIL I'LL WRITE AN EDITING FORM
      Colors.StandardBorderColor = Colors.StandardBorderColor;
      Colors.H1Background = Colors.H1Background;
      Colors.H1Foreground = Colors.H1Foreground;
      Colors.H2Background = Colors.H2Background;
      Colors.H2Foreground = Colors.H2Foreground;
      Colors.H3Background = Colors.H3Background;
      Colors.H3Foreground = Colors.H3Foreground;
      Colors.Control = Colors.Control;
      Colors.ControlText = Colors.ControlText;
      Colors.Selection = Colors.Selection;
      Colors.SelectionText = Colors.SelectionText;
      Colors.HyperlinkNormal = Colors.HyperlinkNormal;
      Colors.HyperlinkActive = Colors.HyperlinkActive;
      Colors.GridCellBkReadOnly = Colors.GridCellBkReadOnly;
      Colors.GridCellBkWarn = Colors.GridCellBkWarn;
      Colors.GridCellBkOops = Colors.GridCellBkOops;

      Fonts.H1 = Fonts.H1;
      Fonts.H2 = Fonts.H2;
      Fonts.H3 = Fonts.H3;
      Fonts.Hyperlink = Fonts.Hyperlink;
      Fonts.NormalText = Fonts.NormalText;

    }



  }
}
