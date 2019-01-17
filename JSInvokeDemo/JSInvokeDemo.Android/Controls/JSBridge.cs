using System;
using Android.Webkit;
using Java.Interop;

namespace JSInvokeDemo.Droid.Controls
{
    public class JSBridge : Java.Lang.Object
    {
        readonly WeakReference<WebViewerRenderer> webViewerRenderer;

        public JSBridge(WebViewerRenderer webRenderer)
        {
            webViewerRenderer = new WeakReference<WebViewerRenderer>(webRenderer);
        }

        [JavascriptInterface]
        [Export("invokeAction")]
        public void InvokeAction(string func, string data1, string data2)
        {
            if (webViewerRenderer != null && webViewerRenderer.TryGetTarget(out WebViewerRenderer webRenderer))
            {
                if (data2 == null || data2 == "undefined")
                {
                    webRenderer.Element.InvokeAction(func, data1);
                }
                else
                {
                    webRenderer.Element.InvokeAction(func, data1, data2);
                }
            }
        }
    }
}
