using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using WEBAPI.Services.Services;
using WEBAPI.WEBAPI.Models;

namespace WEBAPI.WEBAPI.Controllers
{
    /// <summary>
    /// This is The Sales Controller
    /// it's the interface between the application and the Sales
    /// related Tables DB
    /// </summary>
    public class SaleController : ApiController
    {
        /// <summary>
        /// This is the method that starts recording the information of a sale
        /// </summary>
        /// <param name="pSaleData"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<SaleIdJson> Make(StartSaleData pSaleData)
        {
            ISaleService saleService = new SaleService();
            var retVal = new SaleIdJson()
            {
                SaleId = saleService.StartSale(pSaleData.CustomerId,
                                                pSaleData.CashierId,
                                                pSaleData.OfficeId)
            };
            return Json(retVal);
        }
        /// <summary>
        /// This method finalizes a sale and updates the time
        /// the cashier took to finish it,
        /// along with the products that were sold
        /// </summary>
        /// <param name="pSaleEndData"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<LongReturnStatus> End(SaleEndData pSaleEndData)
        {
            ISaleService saleService = new SaleService();
            var retVal = new LongReturnStatus();

            List<string> listOfEan = pSaleEndData.
                Products.Select(product => product.EAN).ToList();

            List<int> listOfQtys = pSaleEndData.
                Products.Select(product => product.Qty).ToList();

            retVal.StatusCode = saleService.
                EndSale(pSaleEndData.SaleID, listOfEan, listOfQtys) ? 1 : 0;

            return Json(retVal);
        }
    }
}
