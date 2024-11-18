using EFwithDTO.DTOs;
using EFwithDTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFwithDTO.Controllers
{
    public class LoginController : Controller
    {
        StudentDB_C_F24Entities db = new StudentDB_C_F24Entities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDTO log) {
            //
            var user = (from u in db.Users
                        where u.UName.Equals(log.UName) &&
                        u.Password.Equals(log.Password)
                        select u).SingleOrDefault();
            if (user != null) {
                Session["user"] = user; //boxing
                return RedirectToAction("List","Department");
            }
            TempData["Msg"] = "User not found";
            return View();
        }
    }
}