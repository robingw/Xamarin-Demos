using System;
using Xamarin.Forms;

namespace JSInvokeDemo.Controls
{
    public class WebViewer : View
    {
        private InvokeActions m_actions = new InvokeActions();

        public static readonly BindableProperty UriProperty = BindableProperty.Create(
            propertyName: "Uri",
            returnType: typeof(string),
            declaringType: typeof(WebViewer),
            defaultValue: default(string));

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }

        public void RegisterJSCallback(Action<string> callback)
        {
            m_actions.RegisterJSCallback(callback);
        }

        public void Cleanup()
        {
            m_actions.Cleanup();
        }

        public void InvokeAction(string funcName, string dataValue)
        {
            if (m_actions != null && funcName != null)
                m_actions.InvokeAction(funcName, dataValue);
        }

        public void InvokeAction(string funcName, string dataValue1, string dataValue2)
        {
            if (m_actions != null && funcName != null)
                m_actions.InvokeAction(funcName, dataValue1, dataValue2);
        }
    }
}
