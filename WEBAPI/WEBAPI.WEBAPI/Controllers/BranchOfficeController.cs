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
    public class BranchOfficeController : ApiController
    {
        /// <summary>
        /// This method returns all BranchOffice Information
        /// </summary>
        /// <param name="pEan"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<BranchOffice> Get(BOfyId pIdNumber)
        {
            IBranchOfficeService BranchOfficeService = new BranchOfficeService();
            return Json(BranchOfficeService.GetBranchOffice(pIdNumber.IdNumber));
        }
        /// <summary>
        /// This Method returns all information of all BranchOffices in the Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult<List<BranchOffice>> GetAll()
        {
            IBranchOfficeService BranchOfficeService = new BranchOfficeService();
            return Json(BranchOfficeService.GetBranchOffices());
        }
        /// <summary>
        /// This Method receives the necessary information of a BranchOffice
        /// and Creates it in the Database
        /// </summary>
        /// <param name="pNewBranchOffice"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<LongReturnStatus> Create(BranchOffice pNewBranchOffice)
        {
            IBranchOfficeService BranchOfficeService = new BranchOfficeService();
            var retVal = new LongReturnStatus() { StatusCode = BranchOfficeService.SaveBranchOffice(pNewBranchOffice) ? 1 : 0 };
            return Json(retVal);
        }
        /// <summary>
        /// This Method receives the necessary information of a BranchOffice
        /// and Updates it in the database
        /// </summary>
        /// <param name="pUpdatedBranchOffice"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<LongReturnStatus> Update(BranchOffice pUpdatedBranchOffice)
        {
            IBranchOfficeService BranchOfficeService = new BranchOfficeService();
            var retVal = new LongReturnStatus() { StatusCode = BranchOfficeService.UpdateBranchOffice(pUpdatedBranchOffice.OfficeID, pUpdatedBranchOffice) ? 1 : 0 };
            return Json(retVal);
        }
        /// <summary>
        /// This Method receives the EAN of a BranchOffice and deletes it, if it exists in the database
        /// </summary>
        /// <param name="pEan"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<LongReturnStatus> Delete(BOfyId IdNumber)
        {
            IBranchOfficeService BranchOfficeService = new BranchOfficeService();
            var retVal = new LongReturnStatus() { StatusCode = BranchOfficeService.DeleteBranchOffice(IdNumber.IdNumber) ? 1 : 0 };
            return Json(retVal);
        }
    }
}
