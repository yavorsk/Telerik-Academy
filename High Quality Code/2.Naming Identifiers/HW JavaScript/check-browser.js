function onCheckBrowserButtonClick(event, args) {
	var currentWindow = window;
	var currentBrowser = currentWindow.navigator.appCodeName;

	var browserIsMozzila = currentBrowser === "Mozilla";

	if (browserIsMozzila) {
		alert("Yes");
	} else {
		alert("No");
	}
}