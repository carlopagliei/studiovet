
using System;
using System.Collections.Generic;



namespace Carlop.ClassLib {


  /// <summary>
  /// used to add metadata to classes
  /// </summary>
  [AttributeUsage(AttributeTargets.Class)]
  public class ClassMetadataAttribute : Attribute {

    private String _verboseDescription;
    private String _shortDescription;
    private object _customData;


    /// <summary>
    /// A short description of the class
    /// </summary>
    public String ShortDescription {
      get { return _shortDescription; }
      set { _shortDescription = value; }
    }

    /// <summary>
    /// A verbose description of the class
    /// </summary>
    public String VerboseDescription {
      get { return _verboseDescription; }
      set { _verboseDescription = value; }
    }

    /// <summary>
    /// Custom data
    /// </summary>
    public object CustomData {
      get { return _customData; }
      set { _customData = value; }
    }
  }





  /// <summary>
  /// This is a small class used to simplify the way you can
  /// provide class info
  /// </summary>
  public class ClassInfo {

    private string _fullName;
    private Type _classType;
    private ClassMetadataAttribute _metadata;

    /// <summary>
    /// The type full name (namespace.classname), this could be
    /// considered as a class unique id
    /// </summary>
    public string FullName {
      get { return _fullName; }
      set { _fullName = value; }
    }

    /// <summary>
    /// ClassMetadataAttribute the class has been decorated with 
    /// may be null
    /// </summary>
    public ClassMetadataAttribute Metadata {
      get { return _metadata; }
      set { _metadata = value; }
    }

    /// <summary>
    /// The runtime Type information
    /// </summary>
    public Type ClassType {
      get { return _classType; }
      set { _classType = value; }
    }

    /// <summary>
    /// Creates a new instance of this class
    /// </summary>
    /// <param name="classType">The class Type (typeof)</param>
    public ClassInfo(Type classType) {
      _classType = classType;
      _fullName = _classType.FullName;
      foreach (Attribute at in _classType.GetCustomAttributes(typeof(ClassMetadataAttribute), false)) {
        _metadata = (at as ClassMetadataAttribute);
        break;
      }
    }
  }





  /// <summary>
  /// a simple list of ClassInfo
  /// </summary>
  public class ClassInfoList : List<ClassInfo> {

  }



}