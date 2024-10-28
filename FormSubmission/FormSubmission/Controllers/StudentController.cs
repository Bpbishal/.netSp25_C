using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormSubmission.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Create() {
            ViewBag.Name = Request["Name"];
            ViewBag.Id = Request["Id"];
            return View();
        }
        /*[HttpPost]
        public ActionResult Create(FormCollection fc) {
            ViewBag.Name = fc["Name"];
            ViewBag.Id = fc["Id"];
            return View();
        }*/
        [HttpPost]
        public ActionResult Create(string Name) {
            ViewBag.Name = Name;
           
            return View();
        }
    }
}