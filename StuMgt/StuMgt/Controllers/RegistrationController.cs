using StuMgt.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StuMgt.Controllers
{
    public class RegistrationController : Controller
    {
        StudentMgt_AF25Entities db = new StudentMgt_AF25Entities();
        // GET: Registration

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["Id"] == null) {
                TempData["Msg"] = "Please provide student id";
                return RedirectToAction("Index", "Home");
            }

            var sId = Int32.Parse(Session["Id"].ToString());

            var data = (from cs in db.CourseStudents
                        where cs.SId == sId
                        select cs).ToList();
            ViewBag.CourseStudents = data;
            //var student = db.Students.Find(sId);
            //var courseStudents = student.CourseStudents;

            var courses = db.Courses.ToList();
            return View(courses);
        }
        [HttpPost]
        public ActionResult Index(int[] Courses) {
            var sId = Int32.Parse(Session["Id"].ToString());

            var reg = (from r in db.Registrations
                      where r.SId == sId && "Sp24-25".Equals(r.Semester)
                      select r).SingleOrDefault();
            if (reg == null) {
                reg = new Registration()
                {
                    EnrollDate = DateTime.Now,
                    Semester= "Sp24-25",
                    Status = "Enrolled",
                    SId= sId,
                };
                db.Registrations.Add(reg);
                db.SaveChanges();
            }

            foreach(var c in Courses)
            {
                var crs = db.Courses.Find(c);
                if (crs.CourseStudents.Count < crs.MaxCapacity)
                {
                    if (!IsExist(c, sId, reg.Id))
                    {
                        var cs = new CourseStudent()
                        {
                            SId = sId,
                            CourseId = c,
                            Status = "invalid",
                            Date = DateTime.Now,
                            RegId = reg.Id
                        };
                        db.CourseStudents.Add(cs);
                    }
                }
                else {
                    TempData["Msg"] += crs.Name + " exceeds max capacity ";
                }

                
                
            }
            db.SaveChanges();
            return RedirectToAction("Index","Home");   
        }

        private bool IsExist(int cId, int sId, int regId) {
            var data = (from cs in db.CourseStudents
                        where cs.CourseId == cId &&
                        cs.SId == sId && cs.RegId == regId
                        select cs).SingleOrDefault();
            if (data != null) return true;
            return false;


        }

    }
}