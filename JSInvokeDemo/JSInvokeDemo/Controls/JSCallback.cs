using System;
namespace JSInvokeDemo.Controls
{
    public class JSCallback
    {
        // JSCallback Singleton
        private static readonly Lazy<JSCallback> lazy =
        new Lazy<JSCallback>(() => new JSCallback());

        public static JSCallback GetInstance { get { return lazy.Value; } }

        private Action<string> ActionJSCallback;

        public void RegisterJSCallback(Action<string> callback)
        {
            ActionJSCallback = callback;
        }

        public void Callback(string data)
        {
            if (ActionJSCallback != null)
                ActionJSCallback.Invoke(data);
        }

        public void ClearJSCallback()
        {
            ActionJSCallback = null;
        }
    }

}
