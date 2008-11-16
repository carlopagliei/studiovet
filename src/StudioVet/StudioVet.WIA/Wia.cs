using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using WIALib;
using System.IO;
using System.Windows.Forms;


namespace StudioVet.WIA {


  public class Wia {


    public static string[] Acquire(Control callerForm, out string errorMessage) {

      WiaClass wiaManager = null;		// WIA manager COM object
      CollectionClass wiaDevs = null;		// WIA devices collection COM object
      ItemClass wiaRoot = null;		// WIA root device COM object
      CollectionClass wiaPics = null;		// WIA collection COM object
      ItemClass wiaItem = null;		// WIA image COM object

      errorMessage = null;
      string[] acqfiles = null;

      try {
        wiaManager = new WiaClass();		// create COM instance of WIA manager

        wiaDevs = wiaManager.Devices as CollectionClass;			// call Wia.Devices to get all devices
        if ((wiaDevs == null) || (wiaDevs.Count == 0)) {
          errorMessage = "No WIA devices found!";
          return acqfiles;
        }

        object selectUsingUI = System.Reflection.Missing.Value;			// = Nothing
        wiaRoot = (ItemClass)wiaManager.Create(ref selectUsingUI);	// let user select device
        if (wiaRoot == null)											// nothing to do
          return acqfiles;

        // this call shows the common WIA dialog to let the user select a picture:
        wiaPics = wiaRoot.GetItemsFromUI(WiaFlag.SingleImage, WiaIntent.ImageTypeColor) as CollectionClass;
        if (wiaPics == null)
          return acqfiles;

        // enumerate all the pictures the user selected
        Cursor.Current = Cursors.WaitCursor;
        acqfiles = new string[wiaPics.Length];
        int i = 0;
        foreach (object wiaObj in wiaPics) {
          wiaItem = (ItemClass)Marshal.CreateWrapperOfType(wiaObj, typeof(ItemClass));
          callerForm.Refresh();
          acqfiles[i] = Path.ChangeExtension(Path.GetTempFileName(), ".bmp");				// create temporary file for image
          wiaItem.Transfer(acqfiles[i], false);			// transfer picture to our temporary file
          i++;
          Marshal.ReleaseComObject(wiaObj);					// release enumerated COM object
        }
      }
      catch (Exception ee) {
        errorMessage = "Acquire from WIA Imaging failed\r\n" + ee.Message;
      }
      finally {
        if (wiaItem != null) Marshal.ReleaseComObject(wiaItem);		// release WIA image COM object
        if (wiaPics != null) Marshal.ReleaseComObject(wiaPics);		// release WIA collection COM object
        if (wiaRoot != null) Marshal.ReleaseComObject(wiaRoot);		// release WIA root device COM object
        if (wiaDevs != null) Marshal.ReleaseComObject(wiaDevs);		// release WIA devices collection COM object
        if (wiaManager != null) Marshal.ReleaseComObject(wiaManager);		// release WIA manager COM object
      }
      Cursor.Current = Cursors.Default;
      return acqfiles;
    }


  }


}
