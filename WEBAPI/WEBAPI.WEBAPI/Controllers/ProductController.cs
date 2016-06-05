using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Results;
using WEBAPI.Data;
using WEBAPI.Services.Services;
using WEBAPI.WEBAPI.Models;

namespace WEBAPI.WEBAPI.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService productService = new ProductService();

        [HttpPost]
        public JsonResult<Product> Get(ProdByEan pEan)
        {
            return Json(productService.GetProduct(pEan.EAN));
        }

        [HttpGet]
        public JsonResult<List<Product>> GetAll()
        {
            return Json(productService.GetProducts());
        }

        [HttpPost]
        public JsonResult<ReturnStatus> Create(Product pNewProduct)
        {
            var retVal = new ReturnStatus() {StatusCode = productService.SaveProduct(pNewProduct)?1:0};
            return Json(retVal);
        }

        [HttpPost]
        public JsonResult<ReturnStatus> Update(Product pUpdatedProduct)
        {
            var retVal = new ReturnStatus() { StatusCode = productService.UpdateProduct(pUpdatedProduct.EAN,pUpdatedProduct) ? 1 : 0 };
            return Json(retVal);
        }

        [HttpPost]
        public JsonResult<ReturnStatus> Delete(ProdByEan pEan)
        {
            var retVal = new ReturnStatus() { StatusCode = productService.DeleteProduct(pEan.EAN) ? 1 : 0 };
            return Json(retVal);
        }
    }
}
