using System;
using System.Collections.Generic;
namespace JSInvokeDemo.Controls
{
    public class InvokeActions
	{
		private Dictionary<string, Action<string>> actions;
		private Dictionary<string, Action<string, string>> actions2;
		private JSImplement jsImplement;
		private readonly int maxActionCount = 2;
		private readonly int maxAction2Count = 1;

		public InvokeActions()
		{
			actions = new Dictionary<string, Action<string>>(maxActionCount);
            actions2 = new Dictionary<string, Action<string, string>>(maxAction2Count);
			jsImplement = new JSImplement();
			RegisterDefaultAction();
		}

		public void RegisterDefaultAction()
		{
            // 0 arg & 1 arg
			RegisterActionWithActionName("TestInput"    			            ,jsImplement.TestInput);
            RegisterActionWithActionName("TestProgress"                         ,jsImplement.TestProgress);

			// 2 args
			RegisterAction2WithActionName("SetPropertyValue"                    ,jsImplement.SetPropertyValue);
		}

		public void RegisterActionWithActionName(string actionName, Action<string> action)
		{
            if (!string.IsNullOrEmpty(actionName) && action != null)
				actions.Add(actionName, action);
		}

		public void RegisterAction2WithActionName(string actionName, Action<string, string> action)
		{
			if (!string.IsNullOrEmpty(actionName) && action != null)
				actions2.Add(actionName, action);
		}

        public void RegisterJSCallback(Action<string> callback)
		{
			jsImplement.RegisterJSCallback(callback);
		}

		public void Cleanup()
		{
			actions.Clear();
            actions2.Clear();
			jsImplement.ClearJSCallback();
		}

        // 1 arg
		public void InvokeAction(string funcName, string dataValue)
		{
            if (actions != null && !string.IsNullOrEmpty(funcName))
			{
                if (actions.TryGetValue(funcName, out Action<string> action))
                    action.Invoke(dataValue);
            }
        }

        // 2 args
		public void InvokeAction(string funcName, string keyValue, string dataValue)
		{
			if (actions2 != null && !string.IsNullOrEmpty(funcName))
			{
                if (actions2.TryGetValue(funcName, out Action<string, string> action))
                    action.Invoke(keyValue, dataValue);
            }
        }
	}
}
