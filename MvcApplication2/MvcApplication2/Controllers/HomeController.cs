using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        MvcApplication2.ServiceReference1.Service1Client ser = new MvcApplication2.ServiceReference1.Service1Client();
       
        // GET: /Home/

        public ActionResult Index()
        {



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

            ViewBag.create = path;
            
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
        public ActionResult success()
        {
            string image = Request.QueryString["file"];
            ViewBag.file = image;
            string first_name = Request.QueryString["fname"];
            ViewBag.fname = first_name;
            string last_name = Request.QueryString["lname"];
            ViewBag.lname = last_name;
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
        public ActionResult search()
        {
            return View("home_friend_search");
        }
    }
}
