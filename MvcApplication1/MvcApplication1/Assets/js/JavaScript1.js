$(document).ready(function(){
    $("#Button1").click(function(){
        var name=$("#username").val();
        var paswd=$("#password").val();
        $.ajax(
            {
                'url':'http://services.trainees.baabtra.com/LoginService/login.php',
                'DataType':'jsonp',
                'data':{email:name,password:paswd},
        success:function(data)
        {
            var obj = jQuery.parseJSON(data);
            console.log(obj);
            if (obj[0].ResponseCode == 200) {
                window.location.href = ("http://localhost:50792/facebookhome.aspx?image=" + obj[0].vchr_prof_pic + "");

            }
            else if (obj[0].ResponseCode == 500) {
                //$('#Image1').attr('src', obj[0].vchr_prof_pic);
                window.location.href = ("http://localhost:50792/ajax_incorrect_password.aspx?image="+obj[0].vchr_prof_pic+"&&fname="+obj[0].vchr_first_name+"&&lname="+obj[0].vchr_last_name+"&&uname="+obj[0].vchr_user_name+"");
                
            }
            else {
                window.location.href=("http://localhost:50792/ajax_loginpage.aspx");
            }
        },
        error: function (response)
        {
            console.log(name);
        }
    });
});
});