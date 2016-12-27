$(document).ready(function() {
	$(".usererror").hide();
	$(".password").hide();
		$("#bt-log").click(function() {
	
		var username = $("#username").val();
		var password = $("#password").val();
		console.log(username);
		console.log(password);
		if(username=="") {
			$(".usererror").show();
			$("#user").text('Please fill in the field');
		} else if(!(/^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/.test(username))) {
			$("#user").text("Email Error");
		} else {
			$(".usererror").hide();
			$("#user").text("");
		}
		if (password=="") {
			$(".password").show();
			$("#pass").text('Please fill in the field');
			
		} else if(password.length < 8) {
			$("#pass").text("password must be 8 characters long");
		} else {
			$(".password").hide();
			$("#pass").text("");
		}

		});
	
	$(".first").hide();
	$("#bt-create").click(function(){

		var fname=$("#fname").val();
		var lname=$("#lname").val();
		var mno=$("#mno").val();
		var email=$("email").val();
		var pw=$("pw").val();
		var birthday=$("birthday").val();
		console.log(fname);
		if(fname=="")
		 {
			$(".first").show();
			$("#fn").text('Please fill in the field');
		} 
		 else
		  {
			$(".first").hide();
			$("#fn").text("");
		}
		if(lname=="") {
			$(".last").show();
			$("#ln").text('Please fill in the field');
		}  else {
			$(".last").hide();
			$("#ln").text("");
		}
		if(mno=="") {
			
			$("#no").text('Please fill in the field');
		} else if(!(/^([0-9_.+-])+$/.test(mno))) {
			$("#no").text("Mobile number Error");
		} else {
		
			$("#no").text("");
		}
		if(email=="") {
			
			$("#em").text('Please fill in the field');
		} else if(!(/^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/.test(username))) {
			$("#em").text("Email Error");
		} else {
			
			$("#em").text("");
		}
		if (pw=="") {
			
			$("#pass").text('Please fill in the field');
			
		} else if(password.length < 8) {
			$("#pass").text("password must be 8 characters long");
		} else {
			$(".password").hide();
			$("#pass").text("");
		}
	});
	$("#myform :input").tooltip({
 
      // place tooltip on the right edge
      position: "center right",
 
      // a little tweaking of the position
      offset: [-2, 10],
 
      // use the built-in fadeIn/fadeOut effect
      effect: "fade",
 
      // custom opacity setting
      opacity: 0.7
 
    });
	$('[data-toggle="tooltip"]').tooltip();

});

