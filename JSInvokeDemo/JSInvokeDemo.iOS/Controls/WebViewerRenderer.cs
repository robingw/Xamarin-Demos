using System;
using System.IO;
using Foundation;
using JSInvokeDemo.Controls;
using JSInvokeDemo.iOS.Controls;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(WebViewer), typeof(WebViewerRenderer))]
namespace JSInvokeDemo.iOS.Controls
{
    public class WebViewerRenderer : ViewRenderer<WebViewer, WKWebView>, IWKScriptMessageHandler
    {
        WKUserContentController userController;
        WKWebView webView = null;

        protected override void OnElementChanged(ElementChangedEventArgs<WebViewer> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                userController = new WKUserContentController();
                var script = new WKUserScript(new NSString(JSDefines.JavaScriptFunction_iOS), WKUserScriptInjectionTime.AtDocumentEnd, false);
                userController.AddUserScript(script);
                userController.AddScriptMessageHandler(this, "invokeAction");

                var config = new WKWebViewConfiguration { UserContentController = userController };
                webView = new WKWebView(Frame, config) { WeakNavigationDelegate = new WebViewNavigationDelegate(this, Element.Uri) };
                SetNativeControl(webView);
                Element.RegisterJSCallback(this.JSCallBack);
            }
            if (e.OldElement != null)
            {
                userController.RemoveAllUserScripts();
                userController.RemoveScriptMessageHandler("invokeAction");
                var webViewer = e.OldElement as WebViewer;
                webViewer.Cleanup();
            }
            if (e.NewElement != null)
            {
#if LOCALHTMLTEST
                string localhtmlurl = Path.Combine(NSBundle.MainBundle.BundlePath, "Local.html");
                Control.LoadRequest(new NSUrlRequest(new NSUrl(localhtmlurl, false)));
#else
                Control.LoadRequest(new NSUrlRequest(new NSUrl(Element.Uri)));
#endif
            }
        }

        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            NSDictionary dicMessage = (NSDictionary)message.Body;
            if (dicMessage["dataValue2"] == null)
                Element.InvokeAction(dicMessage["funcName"].Description, (dicMessage["dataValue1"] == null ? "undefined" : dicMessage["dataValue1"].Description));
            else
                Element.InvokeAction(dicMessage["funcName"].Description, (dicMessage["dataValue1"] == null ? "undefined" : dicMessage["dataValue1"].Description), (dicMessage["dataValue2"] == null ? "undefined" : dicMessage["dataValue2"].Description));
        }

        public void JSCallBack(string strJS)
        {
            webView.EvaluateJavaScript(string.Format(strJS), (result, error) =>
            {
                if (error != null) Console.WriteLine(error);
            });
        }

    }

    public class WebViewNavigationDelegate : WKNavigationDelegate
    {
        private WebViewerRenderer webViewRender;
        private string uri;
        public WebViewNavigationDelegate(WebViewerRenderer render, string originalUri)
        {
            webViewRender = render;
            uri = originalUri;
        }

        public override void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
        {
            webViewRender.JSCallBack(JSDefines.JSCallbackInitialized());
        }
    }
}
