
using IntroMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
            ;
            ;
            ;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";


            //return Redirect("Https://www.aiub.edu/contact");
            TempData["Msg"] = "Redirected from Contact";
            return RedirectToAction("Students");
        }
        public ActionResult MyPage() { 
            return View();  
        }
        public ActionResult Students()
        {
            ViewBag.S1Name = "Tanvir";
            ViewBag.S2Name = "Rahim";

            ViewData["S1Id"] = 12;


            Student s1 = new Student() { 
                Id = 1,
                Name= "S1"
            };
            Student s2 = new Student()
            {
                Id = 2,
                Name = "S2"
            };
            Student[] students = new Student[] { s1, s2 };

            return View(students);
        }
    }
}