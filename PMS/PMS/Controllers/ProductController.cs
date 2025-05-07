using PMS.DTOs;
using PMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public static ProductDTO Convert(Product p) {
            return new ProductDTO() { 
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Qty = p.Qty,
            };
        }
        public static List<ProductDTO> Convert(List<Product> data) {
            var list = new List<ProductDTO>();
            foreach (var item in data) { 
                list.Add(Convert(item));
            }
            return list;
        }
    }
}