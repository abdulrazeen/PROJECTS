using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.Required)]
    public class HomeController : Controller
    {
        
        MvcApplication2.ServiceReference3.Service1Client ser = new MvcApplication2.ServiceReference3.Service1Client();
       
        // GET: /Home/

        public ActionResult Index()
        {
            Session["test"] = "Session less controller test";


            //string data = ser.validate_login("info@baabte.com","qwerty");
            //ViewBag.login = data;
          

            return View("facebook_homepage2");
            //return View("home_friend_search");

        }



        public string login(FormCollection fc)
        {
            string username = Request.QueryString["username"];
            ViewBag.email = username;
            string password = Request.QueryString["password"];
            var obj = ser.validate_login(username, password);
            return obj;

        }
        public string login2(FormCollection fc)
        {
            string name = Request.QueryString["fname"];
            ViewBag.name = name;
            string first_name = Request.QueryString["fname"];
            ViewBag.fname = first_name;
            string last_name = Request.QueryString["lname"];
            ViewBag.lname = last_name;
            string image = Request.QueryString["file"];
            ViewBag.file = image;
            
            var obj = ser.search(first_name, last_name, image);
            return obj;

        }

        public ActionResult create(FormCollection fc)
        {


            // string username = "info@baabte.com";
            // string password = "qwerty";
            // ViewBag.login = ser.validate_login(username,password);

            string[] user = new string[10];

            string first_name = fc["fname"];



            ViewBag.fname = first_name;
            string last_name = fc["lname"];
            ViewBag.lname = last_name;
            
            string mobile_no = fc["mno"];
            ViewBag.mno = mobile_no;
            string email = fc["email"];
            ViewBag.email = email;
            string id = fc["id"];
            ViewBag.id = id;
            string password = fc["pw"];
            ViewBag.pw = password;
            string gender = fc["gender"];
            ViewBag.gender = gender;
            //string day = fc["day"];
            //string month = fc["month"];
            //string year = fc["year"];
            //string dob = string.Concat(year, month, day);
               // str = strcat(str1,str2)
            //fc["dob"] = fc["day" + "month" + "year"];

            string dob = fc["dob"];
            ViewBag.dob = dob;
            
            
            string success;
            var file = Request.Files[0];
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
            file.SaveAs(path);
            success = ser.insert_user(first_name, last_name, mobile_no, email, password, gender, dob, fileName);
            string image = fc["file"];
            ViewBag.file = path;
            Session["image"] = path;
            ViewBag.create = ser.insert_user(first_name, last_name, mobile_no, email, password, gender, dob, fileName);
            
            user[0] = ViewBag.create;

           // var obj = ser.insert_user(first_name, last_name, mobile_no, email, password, gender, dob,image);

           // ViewData["user"] = obj;


            return View("facebook_homepage2");
        }

        public ActionResult validation(FormCollection fc)
        {

            // string username = "info@baabte.com";
            // string password = "qwerty";
            // ViewBag.login = ser.validate_login(username,password);

            string[] user = new string[10];

            string username = fc["username"];
            ViewBag.username = username;

            string password = fc["password"];
            ViewBag.password = password;

            ViewBag.login = ser.validate_login(username, password);
            user[0] = ViewBag.login;

            var obj = ser.validate_login(username, password);

            ViewData["user"] = obj;


            return View("facebook_homepage2");


        }

        public ActionResult validation2(FormCollection fc)
        {

            // string username = "info@baabte.com";
            // string password = "qwerty";
            // ViewBag.login = ser.validate_login(username,password);

            string[] user = new string[10];

            string username =fc["username"];
            ViewBag.username = username;

            string password = fc["password"];
            ViewBag.password = password;

            ViewBag.login = ser.validate_login(username, password);
            user[0] = ViewBag.login;
            string image = Request.QueryString["file"];
            ViewBag.file = image;
            var obj = ser.validate_login(username, password);

            ViewData["user"] = obj;


            return View("facebook_profile_home");


        }
        public ActionResult success(FormCollection fc)
        {
            string[] user = new string[10];
            string[] sch=   new string[20];

            //string username = fc["username"];
            //string password = fc["password"];
            //ViewBag.password = password;
            //var obj = ser.validate_login(username, password);
            //ViewData["user"] = obj;

            string name = Request.QueryString["fname"];
            ViewBag.name = name;
            string image = Request.QueryString["file"];
            ViewBag.file = image;
            string first_name = Request.QueryString["fname"];
            ViewBag.fname = first_name;
            string last_name = Request.QueryString["lname"];
            ViewBag.lname = last_name;
            string id = Request.QueryString["id"];
            ViewBag.id = id;
            
            //ViewBag.user_one = user_one;

            string user_one = fc["user_one_id"];
            ViewBag.user_one = user_one;
            string action_user = fc["action_user_id"];
            ViewBag.action_user = action_user;
            //string user_one = id;
            
            string user_two = fc["user_two_id"];
            ViewBag.user_two = user_two;
           // string action_user = id;
            Session["one"] = id;
            Session["two"] = user_two;
           
           
            //ViewBag.username = username;
            //string text1 = Request.QueryString["text1"];
            //ViewBag.text1 = text1;
            Session["tag"] = first_name;
            Session["tag2"] = last_name;
            Session["image"] = image;
            Session["one"] = id;

            //var  sc=ser.search(first_name,last_name,image);
            //ViewData["sch"] = sc;

            ViewBag.sch = ser.search(first_name, last_name, image);
            //ViewBag.sch = ser.search(first, last, image);
            user[0] = ViewBag.sch;
            
         
            return View("facebook_profile_home");
        }
        public ActionResult incorrect_password()
        {
            string image = Request.QueryString["file"];
            ViewBag.file = image;
            string first_name = Request.QueryString["fname"];
            ViewBag.fname = first_name;
            string email = Request.QueryString["email"];
            ViewBag.email = email;
            string last_name = Request.QueryString["lname"];
            ViewBag.lname = last_name;
            return View("facebook_incorrect_password");
        }
        public ActionResult wrong_login()
        {
            return View("facebook_loginpage");
        }
        public ActionResult search(FormCollection fc)
        {
            string[] user = new string[10];
            string[] sch = new string[20];

            string username = fc["username"];
            string password = fc["password"];
            ViewBag.password = password;
            var obj = ser.validate_login(username, password);
            ViewData["user"] = obj;

            string name = Request.QueryString["fname"];
            ViewBag.name = name;
            string image = Request.QueryString["file"];
            ViewBag.file = image;
            string first_name = Request.QueryString["fname"];
            ViewBag.fname = first_name;
            string last_name = Request.QueryString["lname"];
            ViewBag.lname = last_name;
            ViewBag.username = username;
            ViewBag.path = Server.MapPath("~/Images/");
           
            ViewBag.sch = ser.search(first_name, last_name, image);
           
            user[0] = ViewBag.sch;
            
            return View("home_friend_search");
        }
        public ActionResult showreq(FormCollection fc)
        {
            return View("home_friend_search");
        }
        public ActionResult friendrequest(FormCollection fc)
        {
            string[] user = new string[10];
            string user_one = fc["user_one_id"];
            ViewBag.user_one = user_one;
            string user_two = fc["user_two_id"];
            ViewBag.user_two = user_two;
            Session["two"] = user_two;
            string action_user = fc["action_user_id"];
            Session["one"] = user_one;
            ViewBag.action_user = action_user;
            string request;

            request = ser.send_request(user_one, user_two, action_user);
            ViewBag.req = request;
            user[0] = ViewBag.req;

            var obj = ser.send_request(user_one, user_two, action_user);
            //return obj;


            // user[0] = ViewBag.create;
            //string a = ser.request(user_one, user_two,status,action_user);//define parameters in this controller function

            return View("home_profile_home");

        }
        public string req(FormCollection fc)
        {
            string user_one = Request.QueryString["user_one_id"];
            ViewBag.user_one = user_one;
            Session["one"] = user_one;
            string action_user = Request.QueryString["action_user_id"];
            ViewBag.action_user = action_user;
            string user_two = Request.QueryString["user_two_id"];
            ViewBag.user_two = user_two;
            Session["two"] = user_two;
            string id = Request.QueryString["id"];
            ViewBag.id = id; 

            var obj = ser.send_request(user_one, user_two, action_user);

            return obj;

        }
       
        public string show2(FormCollection fc)
        {
            
            string user_one = Request.QueryString["user_one_id"];
            ViewBag.user_one = user_one;
            Session["one"] = user_one;
            string id = Request.QueryString["id"];
            ViewBag.id = id;

            var obj = ser.show_request(user_one);
            return obj;

        }
        public string friends(FormCollection fc)
        {

            string user_one = Request.QueryString["user_one_id"];
            ViewBag.user_one = user_one;
            Session["one"] = user_one;
            string id = Request.QueryString["id"];
            ViewBag.id = id;

            var obj = ser.friendship(user_one);
            return obj;

        }
        public string acc(FormCollection fc)
        {
            string user_one = Request.QueryString["user_one_id"];
            ViewBag.user_one = user_one;
            Session["one"] = user_one;
            string action_user = Request.QueryString["action_user_id"];
            ViewBag.action_user = action_user;
            string user_two = Request.QueryString["user_two_id"];
            ViewBag.user_two = user_two;
            Session["two"] = user_two;
            string id = Request.QueryString["id"];
            ViewBag.id = id;

            var obj = ser.accept_request(user_one, user_two, action_user);

            return obj;

        }
        public string unfriend(FormCollection fc)
        {
            string user_one = Request.QueryString["user_one_id"];
            ViewBag.user_one = user_one;
            Session["one"] = user_one;
            string action_user = Request.QueryString["action_user_id"];
            ViewBag.action_user = action_user;
            string user_two = Request.QueryString["user_two_id"];
            ViewBag.user_two = user_two;
            Session["two"] = user_two;
            string id = Request.QueryString["id"];
            ViewBag.id = id;

            var obj = ser.unfriend(user_one, user_two, action_user);

            return obj;

        }


    }
}
