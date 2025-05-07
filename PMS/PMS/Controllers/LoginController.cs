using PMS.DTOs;
using PMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class LoginController : Controller
    {
        PMS_Sp25_AEntities db = new PMS_Sp25_AEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Uname, string Pass) {
            var user = (from u in db.Logins
                        where u.Username.Equals(Uname) &&
                        u.Password.Equals(Pass)
                        select u).SingleOrDefault();
            if (user != null) {
                if (user.UserType.Equals("Customer"))
                {
                    Session["User"] = user;
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    return RedirectToAction("Index", "Employee");
                }
            }
            TempData["Class"] = "danger";
            TempData["Msg"] = "Username Password Invalid";
            return View();
            
        }
        [HttpGet]
        public ActionResult Registration() { 
            return View();
        }
        [HttpPost]
        public ActionResult Registration(CustomerDTO cs) { 
            //validation
            var data = Convert(cs);
            data.CreatedAt = DateTime.Now;
            data.UpdatedAt = null;
            data.CreatedBy = null;
            data.UpdatedBy = null;
            db.Customers.Add(data);
            db.SaveChanges();
            var lg = new Login() {
                Username = data.Email,
                Password = data.Password,
                UserId = data.Id,
                UserType = "Customer"
            };
            db.Logins.Add(lg);
            db.SaveChanges();
            TempData["Class"] = "success";
            TempData["Msg"] = "Registration Successfull";
            return RedirectToAction("Login");



        }

        public static Customer Convert(CustomerDTO c) {
            return new Customer() { 
                Name = c.Name,
                Id = c.Id,
                Address = c.Address,
                Email = c.Email,
                Password = c.Password,
               
            };
        }
    }
}