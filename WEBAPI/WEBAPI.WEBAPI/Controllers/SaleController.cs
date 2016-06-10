using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WEBAPI.Data;
using WEBAPI.Services.Services;
using WEBAPI.WEBAPI.Models;

namespace WEBAPI.WEBAPI.Controllers
{
    public class SaleController : ApiController
    {
        private ISaleService saleService = new SaleService();
        [HttpPost]
        public JsonResult<SaleIdJson> Make(StartSaleData pSaleData)
        {
            //private IProductService productService = new ProductService();
            var retVal = new SaleIdJson() {SaleID = saleService.StartSale(pSaleData.CustomerId,pSaleData.CashierId,pSaleData.OfficeId)};
            return Json(retVal);
        }
    }
}
