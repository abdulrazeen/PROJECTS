﻿/// <reference path="../../Views/Home/facebook_incorrect_password.cshtml" />
/// <reference path="../../Views/Home/facebook_incorrect_password.cshtml" />
/// <reference path="../../Views/Home/facebook_incorrect_password.cshtml" />



    $(document).ready(function(){
        $("#Button1").click(function(){
            var name = $("#username").val();;
            var paswd = $("#password").val();
            console.log(paswd);
            $.ajax(
                {
                    url: '/Home/login',
                    DataType: 'json',
                    data: { username: name, password: paswd },
                    success: function (data) {
                        console.log(data);
                    var obj = jQuery.parseJSON(data);
                    console.log(obj);
                   //if (obj[0].ResponseCode == 200) {
                   //    // window.location.href = ("http://localhost:50792/facebookhome.aspx?image=" + obj[0].vchr_prof_pic + "");
                   //    window.location.href = ("/Home/success");
                   // }
                   // else  {
                   //    // $('#Image1').attr('src', obj[0].vchr_prof_pic);
                   //    // window.location.href = ("http://localhost:50792/ajax_incorrect_password.aspx?image=" + obj[0].vchr_prof_pic + "&&fname=" + obj[0].vchr_first_name + "&&lname=" + obj[0].vchr_last_name + "&&uname=" + obj[0].vchr_user_name + "");
                   //     window.location.href = ("/Home/incorrect_password");
                   // }
                    
                },
                error: function (response) {
                    console.log(name);
                }
            });
    });
});