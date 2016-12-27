using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View("facebook_homepage2");
        }
        public ActionResult success()
        {
            return View("facebook_profile_home");
        }
        public ActionResult incorrect_password()
        {
            return View("facebook_incorrect_password");
        }
        public ActionResult wrong_login()
        {
            return View("facebook_loginpage");
        }

    }
}
