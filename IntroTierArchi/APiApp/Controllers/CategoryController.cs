using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APiApp.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("api/category/all")]
        public HttpResponseMessage Get() {
            var data = CategoryService.Get();
            return Request.CreateResponse(HttpStatusCode.OK,data);
        }
        [HttpPost]
        [Route("api/category/create")]
        public HttpResponseMessage Post(CategoryDTO c) {
            CategoryService.Create(c);
            return Request.CreateResponse(HttpStatusCode.OK, "Inserted");
        }
    }
}
