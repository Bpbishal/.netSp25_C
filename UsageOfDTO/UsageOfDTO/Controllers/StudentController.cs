using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsageOfDTO.DTOs;
using UsageOfDTO.EF;

namespace UsageOfDTO.Controllers
{
    public class StudentController : Controller
    {
        private Sp25_CEntities db = new Sp25_CEntities();
        // GET: Student
        public ActionResult Index()
        {
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
            }
            return View(s);
        }

        public static Student Convert(StudentDTO s) {
            return new Student() { 
                Name = s.FName + " "+s.LName,
                Cgpa = s.Cgpa,
                Dob = s.Dob,
                Age = DateTime.Now.Year - s.Dob.Year
            };
        }
        public static StudentDTO Convert(Student s)
        {
            var name = s.Name.Split(' ');
            return new StudentDTO()
            {
                FName = name[0],
                LName= name[1],
                Cgpa = s.Cgpa,
                Dob = s.Dob,
                
            };
        }
        public static List<StudentDTO> Convert(List<Student> data) { 
            var list = new List<StudentDTO>();
            foreach (var item in data) { 
                list.Add(Convert(item));
            }
            return list;
        }
    }
}