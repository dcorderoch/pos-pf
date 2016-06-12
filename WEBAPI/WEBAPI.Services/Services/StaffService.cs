using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public class StaffService : IStaffService
    {
        public List<Staff> GetStaffMembers()
        {
            var db = new PospfEntities();
            return db.Staffs.ToList();
        }

        public Staff GetStaff(int pStaffId)
        {
            var db = new PospfEntities();
            return db.Staffs.FirstOrDefault(x => x.StaffID == pStaffId);
        }

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