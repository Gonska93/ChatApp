// /public/javascript.js

// Get the current username from the cookies
var user = getNameFromCookie();
if (!user) {

  // Ask for the username if there is none set already
  user = prompt('Choose a username:');
  if (!user) {
    alert('We cannot work with you like that!');
  } else {
    // Store it in the cookies for future use
    setNameInCookie(user);
  }
}

function getNameFromCookie() {
  
	var name = "user=";
  
	var ca = document.cookie.split(';');
  
	for(var i = 0; i < ca.length; i++) {
    
		var c = ca[i];
    
		while (c.charAt(0) == ' ') {
	
      		c = c.substring(1);
    }

	      		if (c.indexOf(name) == 0) {
		
      		return c.substring(name.length, c.length);
    
		      		}	
  
	      		}

			
return "";

	}


function setNameInCookie(name) {
  document.cookie = "user=" + name;
}