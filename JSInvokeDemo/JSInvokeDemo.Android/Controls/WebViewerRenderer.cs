using Android.Content;
using JSInvokeDemo.Controls;
using JSInvokeDemo.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WebViewer), typeof(WebViewerRenderer))]
namespace JSInvokeDemo.Droid.Controls
{
    public class WebViewerRenderer : ViewRenderer<WebViewer, Android.Webkit.WebView>
    {
        public WebViewerRenderer(Context context) : base(context) { }

        Android.Webkit.WebView webView;
        public string originalUri = "";

        protected override void OnElementChanged(ElementChangedEventArgs<WebViewer> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                webView = new Android.Webkit.WebView(this.Context);
                webView.Settings.JavaScriptEnabled = true;

                // 不使用网页缓存
                webView.Settings.CacheMode = Android.Webkit.CacheModes.NoCache;
                webView.SetWebViewClient(new CustomWebViewClient(this));
                SetNativeControl(webView);

                Element.RegisterJSCallback(this.JSCallBack);
            }
            if (e.OldElement != null)
            {
                Control.RemoveJavascriptInterface("jsBridge");
                var webViewer = e.OldElement as WebViewer;
                webViewer.Cleanup();
            }
            if (e.NewElement != null)
            {
                Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");
#if LOCALHTMLTEST
                string filePath = "file:///android_asset/Local.html";
                Control.LoadUrl(filePath);
#else
                originalUri = Element.Uri;
                Control.LoadUrl(Element.Uri);
#endif
                InjectJS(JSDefines.JavaScriptFunction_Droid);
            }
        }

        public void InjectJS(string script)
        {
            if (Control != null)
            {
                Control.LoadUrl(string.Format("javascript: {0}", script));
            }
        }

        public void JSCallBack(string strJS)
        {
            // 安卓的webview相关操作需要放在主线程中,否则会有警告
            Device.BeginInvokeOnMainThread(() =>
                webView.LoadUrl("javascript:" + strJS));
        }
    }

    public class CustomWebViewClient : Android.Webkit.WebViewClient
    {
        WebViewerRenderer webViewerRenderer;

        public CustomWebViewClient(WebViewerRenderer webViewerRenderer)
        {
            this.webViewerRenderer = webViewerRenderer;
        }

        public override void OnPageFinished(Android.Webkit.WebView view, string url)
        {
            // 为防止跳转后jsBridge失效，每次跳转后都添加一次
            view.AddJavascriptInterface(new JSBridge(webViewerRenderer), "jsBridge");
            webViewerRenderer.InjectJS(JSDefines.JavaScriptFunction_Droid);

            webViewerRenderer.JSCallBack(JSDefines.JSCallbackInitialized());

            base.OnPageFinished(view, url);
        }
    }
}
