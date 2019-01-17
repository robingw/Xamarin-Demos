using System;
using System.Threading;
using System.Threading.Tasks;

namespace JSInvokeDemo.Controls
{
    public class JSImplement
    {
        public void RegisterJSCallback(Action<string> callback)
        {
            JSCallback.GetInstance.RegisterJSCallback(callback);
        }

        public void ClearJSCallback()
        {
            JSCallback.GetInstance.ClearJSCallback();
        }

        public void TestInput(string dataValue)
        {
            JSInvokeDemo.Controls.JSCallback.GetInstance.Callback(JSInvokeDemo.Controls.JSDefines.JSCallbackTestInput(dataValue));
        }

        public void SetPropertyValue(string keyValue, string dataValue)
        {
            JSInvokeDemo.Controls.JSCallback.GetInstance.Callback(JSInvokeDemo.Controls.JSDefines.JSCallbackSetPropertyValue(keyValue, dataValue));
        }

        public void TestProgress(string dataValue)
        {
            var progress = new Progress<int>();
            progress.ProgressChanged += ProgressChanged;

            Task.Run(() => { CreateProgressTask(progress); });
        }

        private void ProgressChanged(object sender, int e)
        {
            JSCallback.GetInstance.Callback(JSInvokeDemo.Controls.JSDefines.JSCallbackTestProgress(e));
        }

        public static void CreateProgressTask(IProgress<int> progessReporter)
        {
            int progress = 0;
            while (progress <= 100)
            {
                progessReporter.Report(progress);
                progress++;
                Thread.Sleep(50);
            }
        }
    }
}
