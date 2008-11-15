



namespace Carlop.ClassLib {


  public class ImageListHandler {

    private System.Windows.Forms.ImageList _imagelist;

    private void addIcon(string name, System.Drawing.Icon icon) {
      _imagelist.Images.Add(icon);
      _imagelist.Images[_imagelist.Images.Count - 1].Tag = name;
    }
    public void Add(string name, System.Drawing.Icon icon) {
      int i;
      i = this.IndexOf(name);
      if (i == -1) { addIcon(name, icon); }
    }
    public void Add(string name) {
      int i;
      i = this.IndexOf(name);
      if (i == -1) {
        System.Drawing.Icon ico = Carlop.Graphics.IcoLoader.Load(name, _imagelist.ImageSize.Width, _imagelist.ImageSize.Height);
        if (ico != null) { addIcon(name, ico); }
      }
    }
    public int IndexOf(string name) {
      for (int i = 0; i < _imagelist.Images.Count; i++) {
        if (string.Compare(_imagelist.Images[i].Tag as string, name) == 0) {
          return i;
        }
      }
      System.Drawing.Icon ico = Carlop.Graphics.IcoLoader.Load(name, _imagelist.ImageSize.Width, _imagelist.ImageSize.Height);
      if (ico != null) {
        addIcon(name, ico);
        return _imagelist.Images.Count - 1;
      }
      return -1;
    }
    public void Clear() {
      _imagelist.Images.Clear();
    }

    public ImageListHandler(System.Windows.Forms.ImageList imagelist) {
      this._imagelist = imagelist;
    }
  }


}