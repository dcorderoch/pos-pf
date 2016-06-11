using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public interface IStaffShiftService
    {
        long StartShift(int pStaffId, int pRegster, int pMoneyOnStart);
        bool EndShift(long pStaffLogId,int pMoneyOnEnd);
    }
}