using System;



namespace Carlop.ClassLib.Patterns {
 

  
  



  // === DisposablePatternBase ==========================================
  // implements the basic functionalities required
  // to follow the IDisposable pattern

  public abstract class DisposablePatternBase : IDisposable {
    protected abstract void ExecuteCleanup(Boolean disposing);
    public void Dispose() {
      GC.SuppressFinalize(this);
      Dispose(true);
    }
    public void Close() {
      Dispose();
    }
    public void Dispose(Boolean disposing) {
      lock (this) {
        ExecuteCleanup(disposing);
      }
    }
    ~DisposablePatternBase() {
      Dispose(false);
    }
  }





}

