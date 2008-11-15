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
  public sealed class IconHandler : IcoLoader {


    static ResourceManager sysGrafx;
    const string graphics_lib = "Carlop.Graphics.dll";

    // ============================================================================================

    /// <summary>
    /// Loads an icon from the Etere shared library of graphics
    /// </summary>
    /// <param name="name">The icon name (search is case insensitive)</param>
    /// <param name="width">The icon width to load (useful for multi-format icons)</param>
    /// <param name="height">The icon height to load (useful for multi-format icons)</param>
    /// <returns>an Icon object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// </remarks>
    public static Icon LoadFromSystemLibrary(string name, Int32 width, Int32 height) {
      if (sysGrafx == null) {
        string filename = System.IO.Path.Combine(Environment.CurrentDirectory, graphics_lib);
        Assembly a = Assembly.LoadFile(filename);
        string s = System.IO.Path.GetFileNameWithoutExtension(a.CodeBase);
        sysGrafx = new ResourceManager(s + ".ico", a);
      }
      return new Icon((Icon)sysGrafx.GetObject(name.ToLower()), width, height);
    }

    /// <summary>
    /// Loads an icon from the Etere shared library of graphics
    /// </summary>
    /// <param name="name">The icon name (search is case insensitive)</param>
    /// <returns>an Icon object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// </remarks>
    public static Icon LoadFromSystemLibrary(string name) {
      if (sysGrafx == null) {
        string filename = System.IO.Path.Combine(Environment.CurrentDirectory, graphics_lib);
        Assembly a = Assembly.LoadFile(filename);
        string s = System.IO.Path.GetFileNameWithoutExtension(a.CodeBase);
        sysGrafx = new ResourceManager(s + ".ico", a);
        resTable.Add(s, sysGrafx);
      }
      return (Icon)sysGrafx.GetObject(name.ToLower());
    }





  }

}