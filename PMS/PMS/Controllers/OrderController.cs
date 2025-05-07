using PMS.DTOs;
using PMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        PMS_Sp25_AEntities db = new PMS_Sp25_AEntities();
        public ActionResult Index()
        {
            var products = db.Products.ToList();
            var data = ProductController.Convert(products);
            return View(data);
        }
        public ActionResult AddtoCart(int id) { 
            var pr = db.Products.Find(id);
            var prd = ProductController.Convert(pr);
            prd.Qty = 1;
            List<ProductDTO> cart = null;
            if (Session["cart"] == null)
            {
                cart = new List<ProductDTO>();
            }
            else {
                cart = (List<ProductDTO>) Session["cart"];
            }
            cart.Add(prd);
            Session["cart"] = cart;
            TempData["Msg"] = "Product "+ prd.Name + " added to cart";
            return RedirectToAction("Index");
        }
        public ActionResult Cart() {
            if (Session["cart"] == null)
            {
                TempData["Msg"] = "Cart is empty";
                return RedirectToAction("Index");
            }
            else {
                var data = (List<ProductDTO>)Session["cart"];
                return View(data);
            }
            

        }
        public ActionResult CartInc(int id) {
            var cart = (List<ProductDTO>)Session["cart"];
            var p = (from pr in cart where pr.Id == id select pr).SingleOrDefault();
            p.Qty++;
            return RedirectToAction("Cart");
        }
        public ActionResult CartDec(int id)
        {
            var cart = (List<ProductDTO>)Session["cart"];
            var p = (from pr in cart where pr.Id == id select pr).SingleOrDefault();
            p.Qty--;
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public ActionResult PlaceOrder(decimal Total) {
            if (Session["User"] == null)
            {
                TempData["Msg"] = "Please login to place order";
                TempData["Class"] = "danger";
                return RedirectToAction("Login", "Login");
            }
            else {
                var login = (Login)Session["User"];
                var order = new Order() { 
                    Time = DateTime.Now,
                    Total = Total,
                    StatusId = 1,
                    CusId = login.UserId
                };
                db.Orders.Add(order);
                db.SaveChanges();
                var cart = (List<ProductDTO>)Session["cart"];
                foreach (var p in cart) {
                    var od = new OrderDetail() { 
                        PId = p.Id,
                        Qty = p.Qty,
                        Price = p.Price,
                        OId = order.Id

                    };
                    db.OrderDetails.Add(od);
                }
                db.SaveChanges();
                Session["cart"] = null;
                TempData["Msg"] = "Order Placed successfully";
                return RedirectToAction("Index");
            }
        }
    }
}