using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using Carlop.ClassLib.Patterns;


namespace Carlop.ClassLib.Messaging {




  public static class MessagePriority {
    public const int TimeCritical = 1;
    public const int VeryHigh = 10;
    public const int High = 100;
    public const int Normal = 1000;
    public const int Low = 10000;
    public const int VeryLow = 100000;
    public const int Lowest = int.MaxValue;
  }

  public struct NotifyMessageArgs {
    public object OriginalSender;
    public int MessageID;
    public string Text;
    public int Priority;
    public string Category;
    public Dictionary<string, object> Params;
    public NotifyMessageArgs(int messageId) {
      OriginalSender = null;
      Text = null;
      MessageID = messageId;
      Priority = 0;
      Category = null;
      Params = null;
    }
    public NotifyMessageArgs(int messageId, string text) { 
     OriginalSender = null;
     Text = text;
     MessageID = messageId;
     Priority = 0;
     Category = null;
     Params = null;
    }
    public NotifyMessageArgs(int messageId, string text, string category) {
      OriginalSender = null;
      Text = text;
      MessageID = messageId;
      Priority = MessagePriority.Lowest;
      Category = category;
      Params = null;
    }
    public NotifyMessageArgs(int messageId, string text, int priority) {
      OriginalSender = null;
      Text = text;
      MessageID = messageId;
      Priority = priority;
      Category = null;
      Params = null;
    }
    public NotifyMessageArgs(int messageId, string text, string category, int priority) {
      OriginalSender = null;
      Text = text;
      MessageID = messageId;
      Priority =  priority;
      Category = category;
      Params = null;
    }
    public NotifyMessageArgs(int messageId, string text, string[] paramNames, object[] paramValues) {
      if (((paramNames != null) && (paramValues == null)) ||
          ((paramNames == null) && (paramValues != null)) ||
          ((paramNames != null) && (paramValues != null) && (paramNames.Length != paramValues.Length))) {
        throw new ArgumentException("paramNames andparamValues must be both null or have the same length");
      }
      Text = text;
      OriginalSender = null;
      MessageID = messageId;
      Priority = MessagePriority.Lowest;
      Category = null;
      if (paramNames != null) {
        Params = new Dictionary<string, object>();
        for (int i = 0; i < paramNames.Length; i++) {
          this.AddParam(paramNames[i], paramValues[i]);
        }
      }
      else Params = null;
    }
    public NotifyMessageArgs(int messageId, string text, string category, string[] paramNames, object[] paramValues) {
      if (((paramNames != null) && (paramValues == null)) ||
          ((paramNames == null) && (paramValues != null)) ||
          ((paramNames != null) && (paramValues != null) && (paramNames.Length != paramValues.Length))) {
        throw new ArgumentException("paramNames andparamValues must be both null or have the same length");
      }
      OriginalSender = null;
      Text = text;
      MessageID = messageId;
      Priority = MessagePriority.Lowest;
      Category = category;
      if (paramNames != null) {
        Params = new Dictionary<string, object>();
        for (int i = 0; i < paramNames.Length; i++) {
          this.AddParam(paramNames[i], paramValues[i]);
        }
      }
      else Params = null;
    }
    public NotifyMessageArgs(int messageId, string text, string category, int priority, string[] paramNames, object[] paramValues) {
      if (((paramNames != null) && (paramValues == null)) ||
          ((paramNames == null) && (paramValues != null)) ||
          ((paramNames != null) && (paramValues != null) && (paramNames.Length != paramValues.Length))) {
        throw new ArgumentException("paramNames andparamValues must be both null or have the same length");
      }
      Text = text;
      OriginalSender = null;
      MessageID = messageId;
      Priority = priority;
      Category = category;
      if (paramNames != null) {
        Params = new Dictionary<string, object>();
        for (int i = 0; i < paramNames.Length; i++) {
          this.AddParam(paramNames[i], paramValues[i]);
        }
      }
      else Params = null;
    }
    public void AddParam(string paramName, object paramValue) {
      if (Params == null) {
        Params = new Dictionary<string, object>();
      }
      Params.Add(paramName, paramValue);
    }
    public object GetParam(string paramName) {
      if (Params == null) return null;
      else return Params[paramName];
    }
    public Type GetParamType(string paramName) {
      if (Params == null) return null;
      else {
        object o = Params[paramName];
        if (o == null) return null;
        else return o.GetType();
      }
    }
    public override string ToString() {
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      if (!string.IsNullOrEmpty(Text)) sb.Append("\"" + Text + "\", ");
      sb.Append("Id=" + MessageID.ToString() + ", ");
      sb.Append("Priority=" + Priority.ToString() + ", ");
      if (!string.IsNullOrEmpty(Category)) sb.Append("Category=" + Category + ", ");
      if (OriginalSender != null) sb.Append("Sender=" + OriginalSender.ToString() + ", ");
      sb.Append("Params: ");
      if (Params != null) {
        foreach (string k in Params.Keys) {
          sb.Append(k);
          sb.Append("=\"");
          sb.Append(Params[k] + "\" ");
        }
      }
      else sb.Append(" <null>");
      return sb.ToString();
    }
  }



  public delegate void NotifyMessageHandler(object sender, NotifyMessageArgs e);



  public struct SubscriptionData {
    private ArrayList required;
    private ArrayList junk;
    internal NotifyMessageHandler CallbackMethod;
    private void InitArrays(string RequiredCategories, string JunkCategories) {
      if ((required == null) && (RequiredCategories != null)) {
        required = new ArrayList();
        if (RequiredCategories.Contains(".")) {
          foreach (string s in RequiredCategories.ToLower().Split(".".ToCharArray())) {
            required.Add(s);
          }
        } 
        else {
          required.Add(RequiredCategories.ToLower());
        }
        required.Sort();
      }
      if ((junk == null) && (JunkCategories != null)) {
        junk = new ArrayList();
        if (JunkCategories.Contains(".")) {
          foreach (string s in JunkCategories.ToLower().Split(".".ToCharArray())) {
            junk.Add(s);
          }
        }
        else {
          junk.Add(JunkCategories.ToLower());
        }
        junk.Sort();
      }
    }
    private bool RequiredCategory(String category) {
      if (string.IsNullOrEmpty(category)) return true;
      string cat = category.ToLower();
      bool rq = ((required == null) || ((required != null) && (required.Contains(cat))));
      bool jk = ((junk != null) && (junk.Contains(cat)));
      return ((rq) && (!jk));
    }
    internal bool CategorySubscribed(string categoryName) {
      return RequiredCategory(categoryName);
    }
    public SubscriptionData(NotifyMessageHandler callbackMethod) {
      CallbackMethod = callbackMethod;
      required = null;
      junk = null;
    }
    public SubscriptionData(NotifyMessageHandler callbackMethod, string requiredCategories) {
      CallbackMethod = callbackMethod;
      required = null;
      junk = null;
      InitArrays(requiredCategories, null);
    }
    public SubscriptionData(NotifyMessageHandler callbackMethod, string requiredCategories, string junkCategories) {
      CallbackMethod = callbackMethod;
      required = null;
      junk = null;
      InitArrays(requiredCategories, junkCategories);
    }
  }

  struct InternalSubscriptionData {
    public Int64 Handle;
    public SubscriptionData Data;
  }


  public class Dispatcher : DisposablePatternBase {

    private Queue<NotifyMessageArgs> messages = new Queue<NotifyMessageArgs>();
    private Dictionary<Int64, InternalSubscriptionData> subscribers = new Dictionary<Int64, InternalSubscriptionData>();
    private int packedDispatch = 0;
    private static Int64 LastHandle = 0;
    private static Int64 nMessages = 0;
    private static Int64 nInvokes = 0;

    public Int64 Subscribe(SubscriptionData data) {
      InternalSubscriptionData newSubscriber = new InternalSubscriptionData();
      lock (this) {
        LastHandle += 1;
        newSubscriber.Data = data;
        newSubscriber.Handle = LastHandle;
        subscribers.Add(LastHandle, newSubscriber);
      }
      return newSubscriber.Handle;
    }
    public Int64 Subscribe(Int64 subscriptionHandle, SubscriptionData data) {
      Unsubscribe(subscriptionHandle);
      return Subscribe(data);
    }
    public void Unsubscribe(Int64 subscriptionHandle) {
      lock (this) {
        if (subscribers.ContainsKey(subscriptionHandle)) {
          subscribers.Remove(subscriptionHandle);
        }
      }
    }

    protected virtual void beforeInvoke(NotifyMessageArgs args) { }

    private static void NotificationCallback(IAsyncResult ar) {
      NotifyMessageHandler handler = (NotifyMessageHandler)ar.AsyncState;
      handler.EndInvoke(ar);
    }
    private void ExecuteDispatchNext() {
      NotifyMessageArgs args;
      lock (this) {
        args = messages.Dequeue();
        nMessages++;
      }
      beforeInvoke(args);
      foreach (InternalSubscriptionData subscription in subscribers.Values) {
        if (subscription.Data.CategorySubscribed(args.Category)) {
          NotifyMessageHandler handler = new NotifyMessageHandler(subscription.Data.CallbackMethod);
          IAsyncResult ar = handler.BeginInvoke(this, args, new AsyncCallback(NotificationCallback), handler);
          nInvokes++;
        }
      }
    }
    private void ExecuteDispatch() {
      while (messages.Count > 0) { ExecuteDispatchNext(); }
    }

    public void BeginDispatch() {
      lock (this) {
        packedDispatch += 1;
      }
    }
    public void EndDispatch() {
      int n;
      lock (this) {
        packedDispatch -= 1;
        n = packedDispatch;
      }
      if (n < 0) {
        throw new SystemException("Dispatcher.EndDispatch() does not pairs with Dispatcher.BeginDispatch()");
      }
      else
      if (n == 0) {
        ExecuteDispatch();
      }
    }
    public void Dispatch(NotifyMessageArgs data) {
      try {
        BeginDispatch();
        messages.Enqueue(data);
      }
      finally {
        EndDispatch();
      }
    }

    public Int64 PendingMessages {
      get { return messages.Count; }
    }
    public Int64 TotalMessagesDispatched {
      get { return nMessages; }
    }
    public Int64 TotalCallbacksInvoked {
      get { return nInvokes; }
    }

    protected override void ExecuteCleanup(bool disposing) {
      lock (this) {
        messages.Clear();
        InternalSubscriptionData[] values = new InternalSubscriptionData[subscribers.Count];// { };
        subscribers.Values.CopyTo(values, 0);
        foreach (InternalSubscriptionData subscription in values) {
          this.Unsubscribe(subscription.Handle);
        }
      }
    }
  }


}