using EFwithDTO.DTOs;
using EFwithDTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFwithDTO.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        StudentDB_C_F24Entities db = new StudentDB_C_F24Entities();
        public static Student Convert(StudentDTO s) {
            return new Student() { 
                Id = s.Id,
                Name = s.FName + " "+ s.LName,
                Dob  = s.Dob,
                Age = DateTime.Now.Year - s.Dob.Year
            };
        }
        public static StudentDTO Convert(Student s)
        {
            var name = s.Name.Split(' ');
            return new StudentDTO()
            {
                Id = s.Id,
                FName = name[0],
                LName = name[1],
                Dob = (DateTime)s.Dob,
                Cgpa = s.Cgpa,
            };
        }
        public static List<StudentDTO> Convert(List<Student> data) { 
            var list = new List<StudentDTO>();
            foreach (var s in data)
            {
                list.Add(Convert(s));
            }
            return list;
        }

        public ActionResult List() {
            var data = db.Students.ToList();
            return View(Convert(data));
        }
        [HttpGet]
        public ActionResult Create() { 
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentDTO s) {
            if (ModelState.IsValid) {
                db.Students.Add(Convert(s));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
        
        }
    }
}