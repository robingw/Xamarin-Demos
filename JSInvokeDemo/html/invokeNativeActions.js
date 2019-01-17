// 日志
function log(str) {
	$('#result').text(str);
}

// 初始化回调
function callbackInitialized() {
	log("WebView is Initialized!!!");
}


// 测试输入函数
function invokeTestInput(data) {
	try {
		log("Push Test Input Button!!!!");
		invokeNativeAction("TestInput", data);
	}
	catch (err){
		log(err);
	}
}

// 测试输入函数回调
function callbackTestInput(data) {
    log("callbackTestInput: " + data);
}


// 测试进度函数
function invokeTestProgress() {
    try {
        log("Push Test Progress Button!!!!");
        invokeNativeAction("TestProgress");
    }
    catch (err){
        log(err);
    }
}

// 测试进度函数回调
function callbackTestProgress(data) {
    log("callbackTestProgress: " + data + "%");
}


// 设置属性值函数
function invokeSetPropertyValue(name, data) {
    try {
        log("Push Set Property Button!!!!");
        invokeNativeAction("SetPropertyValue", name, data);
    }
    catch (err){
        log(err);
    }
}

// 设置属性值函数回调
function callbackSetPropertyValue(name, value) {
    log("callbackSetPropertyValue: " + name + " " + value);
}
