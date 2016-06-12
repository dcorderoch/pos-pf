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
    /// <summary>
    /// This is The Staff Members Controller
    /// it's the interface between the application
    /// and the Staff Table in the DB
    /// </summary>
    public class StaffController : ApiController
    {
        /// <summary>
        /// This method returns all Staff Member Information
        /// </summary>
        /// <param name="pStaff"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<Staff> Get(StaffById pStaff)
        {
            IStaffService staffService = new StaffService();
            return Json(staffService.GetStaff(pStaff.StaffID));
        }
        /// <summary>
        /// This Method returns all information of all Staff Members in the Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult<List<Staff>> GetAll()
        {
            IStaffService staffService = new StaffService();
            return Json(staffService.GetStaffMembers());
        }
        /// <summary>
        /// This Method receives the necessary information of a Staff Member
        /// and Creates it in the Database
        /// </summary>
        /// <param name="pNewStaff"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<StaffById> Create(Staff pNewStaff)
        {
            IStaffService staffService = new StaffService();
            return Json(new StaffById() {StaffID = staffService.SaveStaff(pNewStaff)});
        }
        /// <summary>
        /// This Method receives the necessary information of a Staff Member
        /// and Updates it in the database
        /// </summary>
        /// <param name="pUpdatedStaff"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<IntReturnStatus> Update(Staff pUpdatedStaff)
        {
            IStaffService staffService = new StaffService();
            return Json(new IntReturnStatus() { StatusCode = staffService.UpdateStaff(pUpdatedStaff) ? 1 : 0 });
        }
        /// <summary>
        /// This Method receives the StaffID of a Staff Member and deletes it, if it exists in the database
        /// </summary>
        /// <param name="pStaff"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<IntReturnStatus> Delete(StaffById pStaff)
        {
            IStaffService staffService = new StaffService();
            return Json(new IntReturnStatus() {StatusCode = staffService.DeleteStaff(pStaff.StaffID) ? 1 : 0 });
        }
    }
}
