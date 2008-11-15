using System;
using System.Text;
using System.Resources;
using System.Reflection;

namespace Carlop.ClassLib.Scripting {


  /// <summary>
  /// This is the abstract class used for managing scripts
  /// </summary>
  public abstract class ScriptHandler {
    /// <summary>
    /// loads a script file into the script handler
    /// </summary>
    /// <param name="filename">the filename to load</param>
    public abstract void LoadFile(string filename);
    /// <summary>
    /// loads a script embedded into an assembly file into the script handler
    /// </summary>
    /// <param name="aAssembly">the assembly that embeds script</param>
    public abstract void LoadAssembly(Assembly aAssembly);
    /// <summary>
    /// removes a previous loaded object (filename or assembly)
    /// </summary>
    /// <param name="o">the object to remove</param>
    public abstract void Remove(object o);
    /// <summary>
    /// clears and reloads all scripts previously loaded
    /// </summary>
    public abstract void ReloadAll() ;
    /// <summary>
    /// checks if a script exists
    /// </summary>
    /// <param name="scriptName">the script name to search for</param>
    /// <returns>true if the script exists</returns>
    public abstract bool Exists(string scriptName);
    /// <summary>
    /// build the script by replacing each param with the text equivalent of a 
    /// corresponding object's value.
    /// </summary>
    /// <param name="scriptName">the script name to build</param>
    /// <param name="parms">the params to put in the script</param>
    /// <returns>the build script</returns>
    public abstract string Build(string scriptName, params object[] parms);
    /// <summary>
    /// get the raw script text
    /// </summary>
    /// <param name="scriptName">the script name to get</param>
    /// <returns>the script text</returns>
    public abstract string GetScriptText(string scriptName);
    /// <summary>
    /// get the metadata associated with the script
    /// </summary>
    /// <param name="scriptName">the script name to get</param>
    /// <returns>the metadata</returns>
    public abstract string GetScriptMetadata(string scriptName);
  }


}
