using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public class StaffService : IStaffService
    {
        /// <summary>
        /// This method returns all Staff Members in the database
        /// </summary>
        /// <returns></returns>
        public List<Staff> GetStaffMembers()
        {
            var db = new PospfEntities();
            return db.Staffs.ToList();
        }
        /// <summary>
        /// This method returns all information of a single Staff Member
        /// </summary>
        /// <param name="pStaffId"></param>
        /// <returns></returns>
        public Staff GetStaff(int pStaffId)
        {
            var db = new PospfEntities();
            return db.Staffs.FirstOrDefault(x => x.StaffID == pStaffId);
        }
        /// <summary>
        /// This method creates a new Staff Member in the Database
        /// </summary>
        /// <param name="pNewStaff"></param>
        /// <returns></returns>
        public int SaveStaff(Staff pNewStaff)
        {
            var db = new PospfEntities();
            try
            {
                var newStaffMember = pNewStaff;
                db.Staffs.Add(newStaffMember);
                db.SaveChanges();
                return pNewStaff.StaffID;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        /// <summary>
        /// This method updates information of a Staff Member in the database
        /// </summary>
        /// <param name="pUpdatedStaff"></param>
        /// <returns></returns>
        public bool UpdateStaff(Staff pUpdatedStaff)
        {
            var db = new PospfEntities();
            try
            {
                var staffmember = db.Staffs.FirstOrDefault(x => x.StaffID == pUpdatedStaff.StaffID);
                if (staffmember != null)
                {
                    staffmember.BOfficeID = pUpdatedStaff.BOfficeID;
                    staffmember.LastName1 = pUpdatedStaff.LastName1;
                    staffmember.LastName2 = pUpdatedStaff.LastName2;
                    staffmember.Name = pUpdatedStaff.Name;

                    db.Entry(staffmember).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// This method deletes a product in the database
        /// </summary>
        /// <param name="pStaffId"></param>
        /// <returns></returns>
        public bool DeleteStaff(int pStaffId)
        {
            var db = new PospfEntities();
            try
            {
                var staffmember = db.Staffs.FirstOrDefault(x => x.StaffID == pStaffId);
                if (staffmember == null)
                {
                    return false;
                }
                db.Entry(staffmember).State = System.Data.Entity.EntityState.Deleted;
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