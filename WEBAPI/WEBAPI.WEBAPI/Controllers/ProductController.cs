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
    /// <summary>
    /// This is The Products Controller
    /// it's the interface between the application and the Products
    /// related Tables DB
    /// </summary>
    public class ProductController : ApiController
    {
        /// <summary>
        /// This is the most direct programming-DB mapping service
        /// </summary>
        private IProductService _productService = new ProductService();
        /// <summary>
        /// This method returns all Product Information
        /// </summary>
        /// <param name="pEan"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<Product> Get(ProdByEan pEan)
        {
            return Json(_productService.GetProduct(pEan.EAN));
        }
        /// <summary>
        /// This Method returns all information of all Products in the Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult<List<Product>> GetAll()
        {
            return Json(_productService.GetProducts());
        }
        /// <summary>
        /// This Method receives the necessary information of a Product
        /// and Creates it in the Database
        /// </summary>
        /// <param name="pNewProduct"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<ReturnStatus> Create(Product pNewProduct)
        {
            var retVal = new ReturnStatus() {StatusCode = _productService.SaveProduct(pNewProduct)?1:0};
            return Json(retVal);
        }
        /// <summary>
        /// This Method receives the necessary information of a Product
        /// and Updates it in the database
        /// </summary>
        /// <param name="pUpdatedProduct"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<ReturnStatus> Update(Product pUpdatedProduct)
        {
            var retVal = new ReturnStatus() { StatusCode = _productService.UpdateProduct(pUpdatedProduct.EAN,pUpdatedProduct) ? 1 : 0 };
            return Json(retVal);
        }
        /// <summary>
        /// This Method receives the EAN of a product and deletes it, if it exists in the database
        /// </summary>
        /// <param name="pEan"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<ReturnStatus> Delete(ProdByEan pEan)
        {
            var retVal = new ReturnStatus() { StatusCode = _productService.DeleteProduct(pEan.EAN) ? 1 : 0 };
            return Json(retVal);
        }
    }
}
