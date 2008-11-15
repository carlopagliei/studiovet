using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Reflection;



namespace Carlop.Configuration {





  /// <summary>
  /// describes a generic configuration param
  /// </summary>
  public class StorageAttachedParamAttribute : Attribute {
    /// <summary>
    /// the param name
    /// </summary>
    public string ParamName = null;
    /// <summary>
    /// the default value
    /// </summary>
    public string DefaultValue = null;
    /// <summary>
    /// if true tells the storage writer to write the default value
    /// into the storage itself the first time it accesses the param
    /// and if it does not find it
    /// </summary>
    public bool SetDefault = false;
    /// <summary>
    /// the description summary
    /// </summary>
    public string Summary = null;
    /// <summary>
    /// the extended description
    /// </summary>
    public string Description = null;
    /// <summary>
    /// used to convert and object to a string before the cfg is written
    /// to the storage
    /// </summary>
    internal virtual string Encode(object value) {
      return value.ToString();
    }
    /// <summary>
    /// used to convert a string into an object after the cfg has been read
    /// from the storage
    /// </summary>
    internal virtual object Parse(string value) {
      return value;
    }
  }





  /// <summary>
  /// describes a configuration param that represents a color
  /// </summary>
  public class StorageAttachedColorParamAttribute : StorageAttachedParamAttribute {
    internal override string Encode(object value) {
      return ((Color)value).ToArgb().ToString();
    }
    internal override object Parse(string value) {
      return Color.FromArgb(int.Parse(value));
    }
    /// <summary>
    /// creates a new instance
    /// </summary>
    /// <param name="defaultColor">the initial color value</param>
    public StorageAttachedColorParamAttribute(KnownColor defaultColor) {
      DefaultValue = this.Encode(Color.FromKnownColor(defaultColor));
    }
  }




  /// <summary>
  /// The base class that manager a storage-attached configuration. The key point
  /// is that the configuration is read/written from/to the storage each time you
  /// request an access. 
  /// </summary>
  /// <remarks>In order to create your own storage class you must 1) override the 
  /// StorageRead/StorageWrite methods 2) use StorageAttachedParamAttribute on the
  /// properies you want to read/write from/to the storage 3) use 
  /// GetPropertyValue/SetPropertyValue from inside your property getter/setter
  /// to read/write the property value</remarks>
  public abstract class StorageAttachedConfigurationBase {



    //---(cache)---

    private class CachedParams : System.Collections.Generic.Dictionary<string, object> { }
    private bool _readCaching = false;

    private CachedParams cache = new CachedParams();

    private void CacheWrite(string propertyName, object value) {
      if (!_readCaching) return;
      System.Diagnostics.Trace.WriteLine("cache write");
      if (cache.ContainsKey(propertyName)) {
        cache[propertyName] = value;
      }
      else {
        cache.Add(propertyName, value);
      }
    }
    private object CacheRead(string propertyName, string defaultValue) {
      if (!_readCaching) return null;
      if (cache.ContainsKey(propertyName)) {
        System.Diagnostics.Trace.WriteLine("cache hit");
        return cache[propertyName];
      } 
      else {
        return null;
      }
    }



    // ---(get/set)---

    protected object GetPropertyValue(string propertyName) {
      PropertyInfo p = this.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
      if (p != null) {
        object[] a = p.GetCustomAttributes(typeof(StorageAttachedParamAttribute), false);
        if (a.Length > 0) {
          StorageAttachedParamAttribute data = (StorageAttachedParamAttribute)a[0];
          string s1 = data.ParamName;
          if (string.IsNullOrEmpty(s1)) s1 = p.Name;
          object obj = CacheRead(s1, data.DefaultValue);
          if (obj == null) {
            obj = data.Parse(StorageRead(s1, data));
            CacheWrite(s1, obj);
          }
          return obj;
        }
      }
      return null;
    }
    protected void SetPropertyValue(string propertyName, object value) {
      PropertyInfo p = this.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
      if (p != null) {
        object[] a = p.GetCustomAttributes(typeof(StorageAttachedParamAttribute), false);
        if (a.Length > 0) {
          StorageAttachedParamAttribute data = (StorageAttachedParamAttribute)a[0];
          string s1 = data.ParamName;
          if (string.IsNullOrEmpty(s1)) s1 = p.Name;
          CacheWrite(s1, value);
          StorageWrite(s1, data.Encode(value), data);
        }
      }
    }


    protected abstract void StorageWrite(string propertyName, string value, StorageAttachedParamAttribute attributes);
    protected abstract string StorageRead(string propertyName, StorageAttachedParamAttribute attributes);



    //---(public)---

    /// <summary>
    /// if true once a param has been read it is cached and no further access to the 
    /// storage will be performed until cache is cleared
    /// </summary>
    public bool UseReadCaching {
      get { return _readCaching; }
      set { _readCaching = value; }
    }
    /// <summary>
    /// Clears the cached params
    /// </summary>
    public void ClearCache() {
      cache.Clear();
    }
    /// <summary>
    /// forces all values to be read and chached
    /// </summary>
    public void CacheAll() {
      _readCaching = true;
      ClearCache();
      foreach (PropertyInfo p in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
        GetPropertyValue(p.Name);
      }

    }

  }



















}
