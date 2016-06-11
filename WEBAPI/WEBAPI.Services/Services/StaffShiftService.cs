﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public class StaffShiftService : IStaffShiftService
    {
        /// <summary>
        /// This is the EF context database mapper
        /// </summary>
        private PospfEntities _db = new PospfEntities();
        /// <summary>
        /// This method records the shift of a member of staff in the database
        /// </summary>
        /// <param name="pStaffId"></param>
        /// <param name="pRegster"></param>
        /// <param name="pMoneyOnStart"></param>
        /// <returns></returns>
        public long StartShift(int pStaffId, int pRegster, int pMoneyOnStart)
        {
            Staff_Log newStaffLog = new Staff_Log();
            newStaffLog.StaffID = pStaffId;
            newStaffLog.Register = pRegster;
            newStaffLog.MoneyOnShiftStart = pMoneyOnStart;

            try
            {
                _db.Staff_Log.Add(newStaffLog);
                _db.SaveChanges();

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
            var thisShift = _db.Staff_Log.FirstOrDefault(l => l.LogID == pStaffLogId);
            if (thisShift == null)
            {
                return false;
            }
            thisShift.MoneyOnShiftEnd = pMoneyOnEnd;
            try
            {
                _db.Entry(thisShift).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}