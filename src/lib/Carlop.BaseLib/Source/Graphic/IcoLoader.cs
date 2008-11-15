using System;
using System.Resources;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Reflection;
using Microsoft.Win32;




namespace Carlop.Graphics {

  


  /// <summary>
  /// This class provides static helper methods that works
  /// with icon loading
  /// </summary>
  /// <remarks>
  /// Credits: LoadFromFileExtension and LoadFromFileExtension
  /// has been originally written by Gil Schmidt (Gil_Smdt@Hotmail.com)
  /// Source files has been taken from the following codeproject column:
  /// http://www.thecodeproject.com/csharp/IconHandler.asp
  /// </remarks>
  public class IcoLoader : AbstractGraphicLoader {

    #region === private ===


    protected static System.Collections.Hashtable resTable;
    protected static System.Collections.Hashtable filesTable;

    //constructor
    static IcoLoader() {
      resTable = new System.Collections.Hashtable();
      filesTable = new System.Collections.Hashtable();
      string s = System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
    }

    // resource access point
    protected static ResourceManager resManager(Assembly assembly) {
      string s = System.IO.Path.GetFileNameWithoutExtension(assembly.CodeBase);
      ResourceManager r = (ResourceManager)resTable[s];
      if (r == null) {
        r = new ResourceManager(s + ".ico", assembly);
        resTable.Add(s, r);
      }
      return r;
    }
    protected static ResourceManager resManager(string filename) {
      ResourceManager r = (ResourceManager)filesTable[filename];
      if (r == null) {
        Assembly a = Assembly.LoadFile(filename);
        r = resManager(a);
        if (r != null) filesTable.Add(filename, r);
      }
      return r;
    }

    // win32
    struct SHFILEINFO {
      public IntPtr hIcon;
      public IntPtr iIcon;
      public uint dwAttributes;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
      public string szDisplayName;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
      public string szTypeName;
    };

    const uint SHGFI_ICON = 0x100;
    const uint SHGFI_USEFILEATTRIBUTES = 0x10;

    [DllImport("Shell32", CharSet = CharSet.Auto)]
    internal extern static int ExtractIconEx(
      [MarshalAs(UnmanagedType.LPTStr)] 
			string lpszFile,                //size of the icon
      int nIconIndex,                 //index of the icon (in case we have more then 1 icon in the file
      IntPtr[] phIconLarge,           //32x32 icon
      IntPtr[] phIconSmall,           //16x16 icon
      int nIcons);                    //how many to get

    [DllImport("shell32.dll")]
    static extern IntPtr SHGetFileInfo(
      string pszPath,				//path
      uint dwFileAttributes,		//attributes
      ref SHFILEINFO psfi,		//struct pointer
      uint cbSizeFileInfo,		//size
      uint uFlags);	//flags


    #endregion


    #region === public ===

    /// <summary>
    /// used to select which size to load when legacy Win32 APIs
    /// are used (LoadFromExtension, LoadFromFile, ...)
    /// </summary>
    public enum IconSize {
      Large = 0x0,  //32x32
      Small = 0x1 //16x16		
    }




    // ============================================================================================

    /// <summary>
    /// Loads an icon from the process executable in the default application domain.
    /// </summary>
    /// <param name="name">The icon name (search is case insensitive)</param>
    /// <param name="width">The icon width to load (useful for multi-format icons)</param>
    /// <param name="height">The icon height to load (useful for multi-format icons)</param>
    /// <returns>an Icon object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// The assembly is supposed to have embedded icons from a single resource
    /// file named ico.resource, so the namespace of the xxx icon is
    /// (assemblyNameWithoutExtension).ico.xxx
    /// </remarks>
    public static Icon LoadFromEntryAssembly(string name, Int32 width, Int32 height) {
      return new Icon((Icon)resManager(Assembly.GetEntryAssembly()).GetObject(name.ToLower()), width, height);
    }

    /// <summary>
    /// Loads an icon from the process executable in the default application domain
    /// </summary>
    /// <param name="name">The icon name (search is case insensitive)</param>
    /// <returns>an Icon object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// The assembly is supposed to have embedded icons from a single resource
    /// file named ico.resource, so the namespace of the xxx icon is
    /// (assemblyNameWithoutExtension).ico.xxx
    /// </remarks>
    public static Icon LoadFromEntryAssembly(string name) {
      return (Icon)resManager(Assembly.GetEntryAssembly()).GetObject(name.ToLower());
    }




    // ============================================================================================

    /// <summary>
    /// Loads an icon from the calling assembly (current for the caller)
    /// </summary>
    /// <param name="name">The icon name (search is case insensitive)</param>
    /// <param name="width">The icon width to load (useful for multi-format icons)</param>
    /// <param name="height">The icon height to load (useful for multi-format icons)</param>
    /// <returns>an Icon object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// The assembly is supposed to have embedded icons from a single resource
    /// file named ico.resource, so the namespace of the xxx icon is
    /// (assemblyNameWithoutExtension).ico.xxx
    /// </remarks>
    public static Icon LoadFromCurrentAssembly(string name, Int32 width, Int32 height) {
      return new Icon((Icon)resManager(Assembly.GetCallingAssembly()).GetObject(name.ToLower()), width, height);
    }

    /// <summary>
    /// Loads an icon from the calling assembly (current for the caller)
    /// </summary>
    /// <param name="name">The icon name (search is case insensitive)</param>
    /// <returns>an Icon object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// The assembly is supposed to have embedded icons from a single resource
    /// file named ico.resource, so the namespace of the xxx icon is
    /// (assemblyNameWithoutExtension).ico.xxx
    /// </remarks>
    public static Icon LoadFromCurrentAssembly(string name) {
      return (Icon)resManager(Assembly.GetCallingAssembly()).GetObject(name.ToLower());
    }





    // ============================================================================================

    /// <summary>
    /// Loads an icon from the attached resourcea
    /// </summary>
    /// <param name="name">The icon name (search is case insensitive)</param>
    /// <param name="width">The icon width to load (useful for multi-format icons)</param>
    /// <param name="height">The icon height to load (useful for multi-format icons)</param>
    /// <returns>an Icon object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// The assembly is supposed to have embedded icons from a single resource
    /// file named ico.resource, so the namespace of the xxx icon is
    /// (assemblyNameWithoutExtension).ico.xxx
    /// </remarks>
    public static Icon Load(string name, Int32 width, Int32 height) {
      object obj;
      foreach(ResourceManager r in resTable.Values){
        try {
          obj = r.GetObject(name.ToLower());
          if (obj != null) {
            return new Icon((Icon)obj, width, height);
          }
        }
        catch { 
        }
      }
      return null;

    }

    public static void AddAssemly(string filename) {
      resManager(filename);
    }
    public static void AddAssemly(Assembly assembly) {
      resManager(assembly);
    }

    
    
    // ============================================================================================

    /// <summary>
    /// Loads an icon from the process executable in the default application domain
    /// </summary>
    /// <param name="filename">The assembly filename with fully qualified path</param>
    /// <param name="name">The icon name (search is case insensitive)</param>
    /// <param name="width">The icon width to load (useful for multi-format icons)</param>
    /// <param name="height">The icon height to load (useful for multi-format icons)</param>
    /// <returns>an Icon object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// The assembly is supposed to have embedded icons from a single resource
    /// file named ico.resource, so the namespace of the xxx icon is
    /// (assemblyNameWithoutExtension).ico.xxx
    /// </remarks>
    public static Icon LoadFromAssembly(string filename, string name, Int32 width, Int32 height) {
      return new Icon((Icon)resManager(filename).GetObject(name.ToLower()), width, height);
      
    }

    /// <summary>
    /// Loads an icon from the specified assembly
    /// </summary>
    /// <param name="filename">The assembly filename with fully qualified path</param>
    /// <param name="name">The icon name (search is case insensitive)</param>
    /// <returns>an Icon object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// The assembly is supposed to have embedded icons from a single resource
    /// file named ico.resource, so the namespace of the xxx icon is
    /// (assemblyNameWithoutExtension).ico.xxx
    /// </remarks>
    public static Icon LoadFromAssembly(string filename, string name) {
      return (Icon)resManager(filename).GetObject(name.ToLower());
    }




    // ============================================================================================

    /// <summary>
    /// Look thru the registry to find if the extension have an icon
    /// </summary>
    /// <param name="extension">the file extension (with the .)</param>
    /// <param name="size">Large for 32x32 or Small for 16x16</param>
    /// <returns>an Icon object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// </remarks>
    public static Icon LoadFromFileExtension(string extension, IconSize size) {
      //add '.' if nessesry
      if (extension[0] != '.') extension = '.' + extension;

      //opens the registry for the wanted key.
      RegistryKey Root = Registry.ClassesRoot;
      RegistryKey ExtensionKey = Root.OpenSubKey(extension);
      ExtensionKey.GetValueNames();
      RegistryKey ApplicationKey = Root.OpenSubKey(ExtensionKey.GetValue("").ToString());

      //gets the name of the file that have the icon.
      string IconLocation = ApplicationKey.OpenSubKey("DefaultIcon").GetValue("").ToString();
      string[] IconPath = IconLocation.Split(',');

      if (IconPath[1] == null) IconPath[1] = "0";
      IntPtr[] Large = new IntPtr[1];
      IntPtr[] Small = new IntPtr[1];

      //extracts the icon from the file.
      ExtractIconEx(IconPath[0], Convert.ToInt16(IconPath[1]), Large, Small, 1);
      return size == IconSize.Large ? Icon.FromHandle(Large[0]) : Icon.FromHandle(Small[0]);
    }

    /// <summary>
    /// Uses the Windows shell to find if the extension have an icon
    /// </summary>
    /// <param name="extension">the file extension (with the .)</param>
    /// <param name="size">Large for 32x32 or Small for 16x16</param>
    /// <returns>an Icon object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// </remarks>
    public static Icon LoadFromFileExtensionShell(string extension, IconSize size) {

      if (extension[0] != '.') extension = '.' + extension;

      //temp struct for getting file shell info
      SHFILEINFO TempFileInfo = new SHFILEINFO();

      SHGetFileInfo(
        extension,
        0,
        ref TempFileInfo,
        (uint)Marshal.SizeOf(TempFileInfo),
        SHGFI_ICON | SHGFI_USEFILEATTRIBUTES | (uint)size);

      return Icon.FromHandle(TempFileInfo.hIcon);
    }

    #endregion


  

  }

  

}
