using DemoApp.DTOs;
using DemoApp.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        UMSCFAEntities db = new UMSCFAEntities();
        [HttpGet]
        public ActionResult Login() { 
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDTO log) {
            var user = (from u in db.Users
                        where u.Username.Equals(log.Uname) &&
                        u.Password.Equals(log.Password)
                        select u).SingleOrDefault();
            if (user != null) {
                Session["user"] = user;
                return RedirectToAction("List","Student");
            }
            return View();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}