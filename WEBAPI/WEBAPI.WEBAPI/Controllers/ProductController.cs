using System.Collections.Generic;
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
        /// This method returns all Product Information
        /// </summary>
        /// <param name="pEan"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<Product> Get(ProdByEan pEan)
        {
            IProductService productService = new ProductService();
            return Json(productService.GetProduct(pEan.EAN));
        }
        /// <summary>
        /// This Method returns all information of all Products in the Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult<List<Product>> GetAll()
        {
            IProductService productService = new ProductService();
            return Json(productService.GetProducts());
        }
        /// <summary>
        /// This Method receives the necessary information of a Product
        /// and Creates it in the Database
        /// </summary>
        /// <param name="pNewProduct"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<LongReturnStatus> Create(Product pNewProduct)
        {
            IProductService productService = new ProductService();
            var retVal = new LongReturnStatus() {StatusCode = productService.SaveProduct(pNewProduct)?1:0};
            return Json(retVal);
        }
        /// <summary>
        /// This Method receives the necessary information of a Product
        /// and Updates it in the database
        /// </summary>
        /// <param name="pUpdatedProduct"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<LongReturnStatus> Update(Product pUpdatedProduct)
        {
            IProductService productService = new ProductService();
            var retVal = new LongReturnStatus() { StatusCode = productService.UpdateProduct(pUpdatedProduct.EAN,pUpdatedProduct) ? 1 : 0 };
            return Json(retVal);
        }
        /// <summary>
        /// This Method receives the EAN of a product and deletes it, if it exists in the database
        /// </summary>
        /// <param name="pEan"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<LongReturnStatus> Delete(ProdByEan pEan)
        {
            IProductService productService = new ProductService();
            var retVal = new LongReturnStatus() { StatusCode = productService.DeleteProduct(pEan.EAN) ? 1 : 0 };
            return Json(retVal);
        }
    }
}
