using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using WEBAPI.Data;
using WEBAPI.Services.Services;
using WEBAPI.WEBAPI.Models;

namespace WEBAPI.WEBAPI.Controllers
{
    /// <summary>
    /// This is The Suppliers Controller
    /// it's the interface between the application and the Suppliers
    /// related Tables DB
    /// </summary>
	public class SupplierController : ApiController
    {
        /// <summary>
        /// This method returns all Supplier Information
        /// </summary>
        /// <param name="pEan"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<Supplier> Get(SupplierById pSupplierId)
        {
            ISupplierService SupplierService = new SupplierService();
            return Json(SupplierService.GetSupplier(pSupplierId.SupplerID));
        }
        /// <summary>
        /// This Method returns all information of all Suppliers in the Database
        /// </summary>
        /// <returns></returns>
		[HttpGet]
        public JsonResult<List<Supplier>> GetAll()
        {
            ISupplierService SupplierService = new SupplierService();
            return Json(SupplierService.GetSuppliers());
        }
        /// <summary>
        /// This Method receives the necessary information of a Supplier
        /// and Creates it in the Database
        /// </summary>
        /// <param name="pNewSupplier"></param>
        /// <returns></returns>
		[HttpPost]
        public JsonResult<ByteReturnStatus> Create(Supplier pNewSupplier)
        {
            ISupplierService SupplierService = new SupplierService();
            var retVal = new ByteReturnStatus() { SupplerID = SupplierService.SaveSupplier(pNewSupplier) };
            return Json(retVal);
        }
        /// <summary>
        /// This Method receives the necessary information of a Supplier
        /// and Updates it in the database
        /// </summary>
        /// <param name="pUpdatedSupplier"></param>
        /// <returns></returns>
		[HttpPost]
        public JsonResult<LongReturnStatus> Update(Supplier pUpdatedSupplier)
        {
            ISupplierService SupplierService = new SupplierService();
            var retVal = new LongReturnStatus() { StatusCode = SupplierService.UpdateSupplier(pUpdatedSupplier) ? 1 : 0 };
            return Json(retVal);
        }
        /// <summary>
        /// This Method receives the SupplerID of a Supplier and deletes it, if it exists in the database
        /// </summary>
        /// <param name="pEan"></param>
        /// <returns></returns>
		[HttpPost]
        public JsonResult<LongReturnStatus> Delete(SupplierById pSupplierId)
        {
            ISupplierService SupplierService = new SupplierService();
            var retVal = new LongReturnStatus() { StatusCode = SupplierService.DeleteSupplier(pSupplierId.SupplerID) ? 1 : 0 };
            return Json(retVal);
        }
    }
}
