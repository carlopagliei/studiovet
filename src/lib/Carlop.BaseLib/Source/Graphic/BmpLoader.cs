using System;
using System.Resources;
using System.Drawing;
using System.Reflection;




namespace Carlop.Graphics {




  /// <summary>
  /// This class provides static helper methods that works
  /// with Bitmap loading
  /// </summary>
  public class BmpLoader : AbstractGraphicLoader {

    #region === private ===


    protected static System.Collections.Hashtable resTable;
    protected static System.Collections.Hashtable filesTable;

    // constructor
    static BmpLoader() {
      resTable = new System.Collections.Hashtable();
      filesTable = new System.Collections.Hashtable();
      string s = System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
    }
    
    // resource access point
    protected static ResourceManager resManager(Assembly assembly) {
      string s = System.IO.Path.GetFileNameWithoutExtension(assembly.CodeBase);
      ResourceManager r = (ResourceManager)resTable[s];
      if (r == null) {
        r = new ResourceManager(s + ".bmp", assembly);
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




    #endregion

    #region === public ===


 

    // ============================================================================================

    /// <summary>
    /// Loads a Bitmap from the process executable in the default application domain
    /// </summary>
    /// <param name="name">The Bitmap name (search is case insensitive)</param>
    /// <param name="width">The Bitmap width to load (useful for multi-format Bitmaps)</param>
    /// <param name="height">The Bitmap height to load (useful for multi-format Bitmaps)</param>
    /// <returns>a Bitmap object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// The assembly is supposed to have embedded Bitmaps from a single resource
    /// file named bmp.resource, so the namespace of the xxx Bitmap is
    /// (assemblyNameWithoutExtension).bmp.xxx
    /// </remarks>
    public static Bitmap LoadFromEntryAssembly(string name, Int32 width, Int32 height) {
      return new Bitmap((Bitmap)resManager(Assembly.GetEntryAssembly()).GetObject(name.ToLower()), width, height);
    }

    /// <summary>
    /// Loads a Bitmap from the process executable in the default application domain
    /// </summary>
    /// <param name="name">The Bitmap name (search is case insensitive)</param>
    /// <returns>a Bitmap object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// The assembly is supposed to have embedded Bitmaps from a single resource
    /// file named bmp.resource, so the namespace of the xxx Bitmap is
    /// (assemblyNameWithoutExtension).bmp.xxx
    /// </remarks>
    public static Bitmap LoadFromEntryAssembly(string name) {
      return (Bitmap)resManager(Assembly.GetEntryAssembly()).GetObject(name.ToLower());
    }




    // ============================================================================================

    /// <summary>
    /// Loads a Bitmap from the calling assembly (current for the caller)
    /// </summary>
    /// <param name="name">The Bitmap name (search is case insensitive)</param>
    /// <param name="width">The Bitmap width to load (useful for multi-format Bitmaps)</param>
    /// <param name="height">The Bitmap height to load (useful for multi-format Bitmaps)</param>
    /// <returns>a Bitmap object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// The assembly is supposed to have embedded Bitmaps from a single resource
    /// file named bmp.resource, so the namespace of the xxx Bitmap is
    /// (assemblyNameWithoutExtension).bmp.xxx
    /// </remarks>
    public static Bitmap LoadFromCurrentAssembly(string name, Int32 width, Int32 height) {
      return new Bitmap((Bitmap)resManager(Assembly.GetCallingAssembly()).GetObject(name.ToLower()), width, height);
    }

    /// <summary>
    /// Loads a Bitmap from the calling assembly (current for the caller)
    /// </summary>
    /// <param name="name">The Bitmap name (search is case insensitive)</param>
    /// <returns>a Bitmap object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// The assembly is supposed to have embedded Bitmaps from a single resource
    /// file named bmp.resource, so the namespace of the xxx Bitmap is
    /// (assemblyNameWithoutExtension).bmp.xxx
    /// </remarks>
    public static Bitmap LoadFromCurrentAssembly(string name) {
      return (Bitmap)resManager(Assembly.GetCallingAssembly()).GetObject(name.ToLower());
    }




    // ============================================================================================

    /// <summary>
    /// Loads a Bitmap from the process executable in the default application domain
    /// </summary>
    /// <param name="filename">The assembly filename with fully qualified path</param>
    /// <param name="name">The Bitmap name (search is case insensitive)</param>
    /// <param name="width">The Bitmap width to load (useful for multi-format Bitmaps)</param>
    /// <param name="height">The Bitmap height to load (useful for multi-format Bitmaps)</param>
    /// <returns>a Bitmap object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// The assembly is supposed to have embedded Bitmaps from a single resource
    /// file named bmp.resource, so the namespace of the xxx Bitmap is
    /// (assemblyNameWithoutExtension).bmp.xxx
    /// </remarks>
    public static Bitmap LoadFromAssembly(string filename, string name, Int32 width, Int32 height) {
      //Assembly a = Assembly.LoadFile(filename);
      //string s = System.IO.Path.GetFileNameWithoutExtension(a.CodeBase);
      //ResourceManager r = new ResourceManager(s + ".bmp", a);
      //return new Bitmap((Bitmap)r.GetObject(name.ToLower()), width, height);
      return new Bitmap((Bitmap)resManager(filename).GetObject(name.ToLower()), width, height);

    }

    /// <summary>
    /// Loads a Bitmap from the specified assembly
    /// </summary>
    /// <param name="filename">The assembly filename with fully qualified path</param>
    /// <param name="name">The Bitmap name (search is case insensitive)</param>
    /// <returns>a Bitmap object if successful</returns>
    /// <remarks>
    /// This method does not catch any exception.
    /// The assembly is supposed to have embedded Bitmaps from a single resource
    /// file named bmp.resource, so the namespace of the xxx Bitmap is
    /// (assemblyNameWithoutExtension).bmp.xxx
    /// </remarks>
    public static Bitmap LoadFromAssembly(string filename, string name) {
      //Assembly a = Assembly.LoadFile(filename);
      //string s = System.IO.Path.GetFileNameWithoutExtension(a.CodeBase);
      //ResourceManager r = new ResourceManager(s + ".bmp", a);
      //return (Bitmap)r.GetObject(name.ToLower());
      return (Bitmap)resManager(filename).GetObject(name.ToLower());
    }




    #endregion


  }



}
