namespace JSInvokeDemo.Controls
{
    public class JSDefines
	{
		// Android Implement
		public static readonly string JavaScriptFunction_Droid 
		= "function invokeNativeAction(func, data1, data2){jsBridge.invokeAction(func, data1, data2);}";

		// iOS Implement
		public static readonly string JavaScriptFunction_iOS 
        = "function invokeNativeAction(func, data1, data2){window.webkit.messageHandlers.invokeAction.postMessage({funcName: func, dataValue1: data1, dataValue2:data2});}";

		// callback initialized
		public static string JSCallbackInitialized()
        {
            string strJSCallbackInitializedFuncName = "callbackInitialized" + "()";
            return strJSCallbackInitializedFuncName;
        }

        // callback test input
        public static string JSCallbackTestInput(string result)
        {
            string strJSCallbackTestInputFuncName = "callbackTestInput" + "('{0}')";
            return string.Format(strJSCallbackTestInputFuncName, result);
        }

        // callback test progress
        public static string JSCallbackTestProgress(int result)
        {
            string strJSCallbackTestInputFuncName = "callbackTestProgress" + "('{0}')";
            return string.Format(strJSCallbackTestInputFuncName, result.ToString());
        }

        // callback set property value
        public static string JSCallbackSetPropertyValue(string property, string value)
        {
            string strJSCallbackSetPropertyValueFuncName = "callbackSetPropertyValue" + "('{0}', '{1}')";
            return string.Format(strJSCallbackSetPropertyValueFuncName, property, value);
        }
    }
}
