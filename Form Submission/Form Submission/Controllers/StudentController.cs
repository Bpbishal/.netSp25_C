using Form_Submission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form_Submission.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Index() {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Index(Student s) {
            if (ModelState.IsValid) { //checking the model validation
                return RedirectToAction("Index","Home");
            }
            return View(s);
        }
        //[HttpPost]
        //public ActionResult Index(string Name, string Id, string Email)
        //{
        //    ViewBag.Name = Name;
        //    ViewBag.Email = Email;

        //    ViewBag.Id = Id;
        //    //ViewBag.Gn = ;
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Index(FormCollection fc)
        //{
        //    ViewBag.Name = Request["Name"];
        //    ViewBag.Email = Request["Email"];

        //    ViewBag.Id = fc["Id"];
        //    ViewBag.Gn = fc["Gender"];
        //    return View();
        //}
    }
}