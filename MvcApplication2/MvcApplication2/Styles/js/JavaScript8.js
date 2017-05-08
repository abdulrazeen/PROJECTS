$(document).ready(function () {

    $(".search").click(function () {
        var name = $("#fname").val();
        //var paswd = $("#password").val();
        $.ajax(
            {

                url: '/Home/login2',
                DataType: 'json',
                data: { fname: name },
                success: function (data) {
                    console.log(data);

                    var obj = jQuery.parseJSON(data);
                    console.log(obj);
                  
                    //$.each(obj, function (i, item) {//silmliar to loop
                    $("#search").empty();//this will empty the div in each search.
                    for (i = 0; i <= obj.length - 1; i++) {
                        console.log(obj[i].first_name);
                        console.log(obj[i]);

                        //if (obj[i].ResponseCode == 200) {
                        //    
                        //            window.location.href = ("/Home/search");//it is used to redirect the page and it would reload the page.
                        //        }
                        //        else {
                                   
                        //            window.location.href = ("/Home/search?fname=" + obj[i].first_name + "&&lname=" + obj[i].LAST_NAME + "&&file=" + obj[i].image + "");
                        //        }
                                //}, time);
                        //window.location.href = ("/Home/search?q=" + name + "");/this would load the page and remove the content.

                       // $("#search").append("@using (Html.BeginForm("friendrequest", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))");
                       
                        $("#search").append('<img src="../../Images/' + obj[i].image + '" style="margin-left:15px;width:36px;"/>&nbsp');

                        $("#search").append("<label>" + obj[i].first_name + "</label>&nbsp");
                       

                        $("#search").append('<input type="hidden" name="user_two_id" id="user_two_id"  value="' + obj[i].id + '"/>');

                       // alert(obj[i].id);

                        $("#search").append('<input type="button" name="addfriend" class="addfriend" id="addfriend" data-q_id="' + obj[i].id + '" value="Add Friend"/><br><br>');
                        //$("#search").append('<a  href="#" class="addfriend" data-q_id="' + obj[i].id + '">Add Friend</a>');
                        
                        
                
                        
                        $(".addfriend").click(function (e) {
                            //alert('clicked');
                            //e.preventDefault();
                            //var t2 = $(this).data('q_id');
                            //alert(t2);
                            var userone = $(".user_one_id").val();
                            var usertwo = $(this).data('q_id');
                            var actionuser = $(".action_user_id").val();
                            //alert(userone);
                            //alert(usertwo);
                            this.value = 'Friend Request Sent';
                        
                            $.ajax(
                               {

                                   url: '/Home/req',
                                   DataType: 'json',
                                   data: { user_one_id: userone, user_two_id: usertwo,action_user_id:actionuser },
                                   success: function (data) {
                                       console.log(data);
                                       var obj = jQuery.parseJSON(data);
                                       console.log(obj);


                                   },
                                   error: function (response) {

                                       console.log(name);
                                   }
                               });
                        });

                       
                        
                    }
                },
                error: function (response) {

                    console.log(name);
                }
            });
        //location.reload();
    });
    $("#logout").click(function () {
        
        alert("log out");
        window.location.href = ("http://localhost:20136/#");
    });
    //$("#search_friends").click(function () {

    //    window.location.href = ("http://localhost:20136/#");
    //}
    $(".show").click(function () {
        var user_one = $("#user_one_id").val();
        //var paswd = $("#password").val();
        $.ajax(
            {

                url: '/Home/show2',
                DataType: 'json',
                data: { user_one_id: user_one },
                success: function (data) {
                    console.log(data);

                    var obj = jQuery.parseJSON(data);
                    console.log(obj);
                    $("#search").empty();//this will empty the div in each search.
                    $("#search").append("<label>Friend Requests </label><br><br>");
                    for (i = 0; i <= obj.length - 1; i++) {
                        console.log(obj[i].first_name);
                        console.log(obj[i]);
                       
                        $("#search").append('<img src="../../Images/' + obj[i].image + '" style="margin-left:15px;width:36px;"/>&nbsp');

                        $("#search").append("<label>" + obj[i].first_name + "</label>&nbsp");


                        $("#search").append('<input type="hidden" name="user_two_id" class="user_two_id" value="' + obj[i].id + '"/>');

                        // alert(obj[i].id);

                        $("#search").append('<input type="button" name="confirm" class="confirm" id="confirm" data-q_id="' + obj[i].id + '" value="confirm" style="background-color:#1F618D;color:white;border-radius:2px;border:1px solid;border-color:darkblue"/>');
                        $(".confirm").click(function () {
                            //alert('clicked');

                            var userone = $(".user_one_id").val();
                            var usertwo = $(this).data('q_id');
                            var actionuser = $(".action_user_id").val();
                            //alert(userone);
                            //alert(usertwo);
                            this.value = 'Friend';
                            $.ajax(
                               {

                                   url: '/Home/acc',
                                   DataType: 'json',
                                   data: { user_one_id: userone, user_two_id: usertwo, action_user_id: actionuser },
                                   success: function (data) {
                                       console.log(data);
                                       var obj = jQuery.parseJSON(data);
                                       console.log(obj);


                                   },
                                   error: function (response) {

                                       console.log(name);
                                   }
                               });
                        });
                        $("#search").append('<input type="button" name="delreq" class="delreq" id="delreq" value="Delete Requests"/><br><br>');
                        $(".delreq").click(function () {
                            
                            this.value = 'Mark as spam';
                           
                        });
                    }
                },
                error: function (response) {

                    console.log(user_one);
                }
            });
    });
    $(".friends").click(function () {
        var user_one = $("#user_one_id").val();
        //var paswd = $("#password").val();
        $.ajax(
            {

                url: '/Home/friends',
                DataType: 'json',
                data: { user_one_id: user_one },
                success: function (data) {
                    console.log(data);

                    var obj = jQuery.parseJSON(data);
                    console.log(obj);
                    $("#search").empty();//this will empty the div in each search.
                    $("#search").append("<label>Friends</label><br><br>");
                    for (i = 0; i <= obj.length - 1; i++) {
                        console.log(obj[i].first_name);
                        console.log(obj[i]);

                        $("#search").append('<img src="../../Images/' + obj[i].image + '" style="margin-left:15px;width:36px;"/>&nbsp');

                        $("#search").append("<label>" + obj[i].first_name + "</label>&nbsp");


                        $("#search").append('<input type="hidden" name="user_two_id" class="user_two_id" value="' + obj[i].id + '"/>');

                        // alert(obj[i].id);

                        $("#search").append('<input type="button" name="unfriend" class="unfriend" id="unfriend" data-q_id="' + obj[i].id + '" value="unfriend" /><br><br>');
                        $(".unfriend").click(function () {
                            //alert('clicked');

                            var userone = $(".user_one_id").val();
                            var usertwo = $(this).data('q_id');
                            var actionuser = $(".action_user_id").val();
                            //alert(userone);
                            //alert(usertwo);
                            this.value = 'Block';
                            $.ajax(
                              {

                                  url: '/Home/unfriend',
                                  DataType: 'json',
                                  data: { user_one_id: userone, user_two_id: usertwo, action_user_id: actionuser },
                                  success: function (data) {
                                      console.log(data);
                                      var obj = jQuery.parseJSON(data);
                                      console.log(obj);


                                  },
                                  error: function (response) {

                                      console.log(name);
                                  }
                              });
                           
                        });
                       
                    }
                },
                error: function (response) {

                    console.log(user_one);
                }
            });
    });

              

});



//"[{\"FIRST_NAME\":\"info\",\"LAST_NAME\":\"baabte\",\"MOBILE_NO\":84684673678,\"EMAIL\":\"info@" +
//"baabte.com\",\"PASSWORD\":\"qwerty\",\"GENDER\":\"Female\",\"dob\":\"2017-04-12T00:00:00\",\"i" +
//"mage\":\"baabte.png\",\"id\":87,\"ResponseCode\":200,\"Msg\":\"Login Succesful\"}]"