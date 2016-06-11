using System.Web.Http;
using System.Web.Http.Results;
using WEBAPI.Services.Services;
using WEBAPI.WEBAPI.Models;

namespace WEBAPI.WEBAPI.Controllers
{
    public class StaffShiftController : ApiController
    {
        /// <summary>
        /// This is the method that starts recording the information of a staff member shift log
        /// </summary>
        /// <param name="pShiftInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<LongIdResult> Start(StaffShiftInfo pShiftInfo)
        {
            IStaffShiftService staffShiftService = new StaffShiftService();
            return
                Json(new LongIdResult
                {
                    LogID =
                        staffShiftService.StartShift(pShiftInfo.StaffId,
                                                     pShiftInfo.Regster,
                                                     pShiftInfo.MoneyOnStart)
                });
        }
        /// <summary>
        /// This method finalizes the staff member log information
        /// </summary>
        /// <param name="pShiftEndInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<ReturnStatus> End(ShiftEndInfo pShiftEndInfo)
        {
            IStaffShiftService staffShiftService = new StaffShiftService();
            return
                Json(new ReturnStatus
                {
                    StatusCode = staffShiftService.EndShift(pShiftEndInfo.StaffLogId, pShiftEndInfo.MoneyOnEnd)?1:0
                });
        }
    }
}