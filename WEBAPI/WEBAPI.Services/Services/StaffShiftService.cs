using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public class StaffShiftService : IStaffShiftService
    {
        /// <summary>
        /// This method records the shift of a member of staff in the database
        /// </summary>
        /// <param name="pStaffId"></param>
        /// <param name="pRegster"></param>
        /// <param name="pMoneyOnStart"></param>
        /// <returns></returns>
        public long StartShift(int pStaffId, int pRegster, int pMoneyOnStart)
        {
            var db = new PospfEntities();
            var newStaffLog = new Staff_Log
            {
                StaffID = pStaffId,
                Register = pRegster,
                MoneyOnShiftStart = pMoneyOnStart
            };

            try
            {
                db.Staff_Log.Add(newStaffLog);
                db.SaveChanges();

                return newStaffLog.LogID;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        /// <summary>
        /// This method updates a staff member shift information in the appropriate table
        /// </summary>
        /// <param name="pStaffLogId"></param>
        /// <param name="pMoneyOnEnd"></param>
        /// <returns></returns>
        public bool EndShift(long pStaffLogId, int pMoneyOnEnd)
        {
            var db = new PospfEntities();
            var thisShift = db.Staff_Log.FirstOrDefault(l => l.LogID == pStaffLogId);
            if (thisShift == null)
            {
                return false;
            }
            thisShift.MoneyOnShiftEnd = pMoneyOnEnd;
            try
            {
                db.Entry(thisShift).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}