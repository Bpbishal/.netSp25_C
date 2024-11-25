using DemoApp.Auth;
using DemoApp.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        UMSCFAEntities db = new UMSCFAEntities();
        public ActionResult List(int pageNo=1,int take=10)
        {
            
            
            int total = db.Students.Count();
            int totalPages = total / take;
            ViewBag.NoOfPage = totalPages;

            var data = db.Students.OrderByDescending(x => x.Id).Skip((pageNo-1)*take).Take(take).ToList();
            return View(data);
        }
        [AdminAccess]
        public ActionResult Delete(int id) {
            var data = db.Students.Find(id);
            db.Students.Remove(data);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}