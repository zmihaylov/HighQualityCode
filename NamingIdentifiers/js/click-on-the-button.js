function clickOnTheButton( event, arguments) {
  var myWindow= window,
      browser = myWindow.navigator.appCodeName,
      isBrowserMozzila = browser == "Mozilla";
	  
  if(isBrowserMozzila) {
    alert("Yes");
  } else {
    alert("No");
  }
}