using System;


namespace Carlop.ClassLib.UnitTesting {



   public class SelfTestFailed : System.Exception {
    public SelfTestFailed(String classInfo, String testInfo, String details)
      : base(string.Format("SelfTest Failed.\r\nclass={0}, test={1}, details={2}", classInfo, testInfo, details)) {
      ClassInfo = classInfo;
      TestInfo = testInfo;
      Details = details;
    }
    private String _classInfo;
    private String _testInfo;
    private String _details;
    public String ClassInfo {
      get { return _classInfo; }
      set { _classInfo = value; }
    }
    public String TestInfo {
      get { return _testInfo; }
      set { _testInfo = value; }
    }
    public String Details {
      get { return _details; }
      set { _details = value; }
    }
  }




}