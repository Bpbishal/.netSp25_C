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
        Sp25_CEntities db = new Sp25_CEntities();
        // GET: Student
        public ActionResult Index()
        {
            //listing all students
            var data = db.Students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create() { 

            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s) {
            //no validation
            
            db.Students.Add(s);
            if (db.SaveChanges() > 0) {
                TempData["Msg"] = "Student Added";
                return RedirectToAction("Index");
            }
            TempData["Msg"] = "Not successfull";
            return View(s);

        }
        [HttpGet]
        public ActionResult Edit(int id) { 
            var student = db.Students.Find(id); 
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student s) {
            var exobj = db.Students.Find(s.Id);
            exobj.Name = s.Name;
            exobj.Dob = s.Dob;
            if (db.SaveChanges() > 0)
            {

                TempData["Msg"] = "Student Updated";
                return RedirectToAction("Index");
            }
            return View(s);

        }

        //db.Students.Remove(exobj);

        

    }
}