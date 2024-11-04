
using IntroEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class StudentController : Controller
    {
        StudentDB_C_F24Entities db = new StudentDB_C_F24Entities();
        // GET: Student
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s) {
            //validation
            
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult List() {
            var data = db.Students.ToList();
            
            return View(data);
        }
        public ActionResult Details(int id) {
            var data = db.Students.Find(id);
            if (data == null) {
                TempData["Msg"] = "Id with value " + id + " not found";
                return RedirectToAction("List");
            }
            return View(data);
        }
    }
}