﻿$(document).ready(function () {

    $("#search").click(function () {
        var name = $("#name").val();
        //var paswd = $("#password").val();
        $.ajax(
            {

                url: '/Home/login2',
                DataType: 'json',
                data: { name: names},
                success: function (data) {
                    console.log(data);
                    //var obj = jQuery.parseJSON(data);
                    //console.log(obj);

                    //if (obj[0].ResponseCode == 200) {
                    //    window.location.href = ("/Home/search?name=" + objt[0].FIRST_NAME + "");
                    //}
                    //else {
                    //    window.location.href = ("/Home/success?name=" + objt[0].FIRST_NAME + "");
                    //}
                   


                },
                error: function (response) {

                    console.log(name);
                }
            });
    });
});