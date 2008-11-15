using System;
using System.ComponentModel;
using System.Reflection;

namespace Carlop.Utils {


  /// <summary>
  /// Groups together reflection related utils
  /// </summary>
  public static class Reflector {


    /// <summary>
    /// Get the Enum description
    /// </summary>
    /// <param name="value">The Enum value</param>
    /// <returns>The Description if present else the enum value converted to a string. To
    /// apply a desctiption you have to decorate the enum value with the 
    /// System.ComponentModel.DescriptionAttribute attribute</returns>
    public static string GetEnumDescription(Enum value) {
      FieldInfo fi = value.GetType().GetField(value.ToString());
      DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(
            typeof(DescriptionAttribute), false);
      return ( (attributes.Length > 0) ? attributes[0].Description : value.ToString() );
    }

  }


}