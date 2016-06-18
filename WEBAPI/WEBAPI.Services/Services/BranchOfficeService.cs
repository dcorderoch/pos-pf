using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public class BranchOfficeService : IBranchOfficeService
    {
        /// <summary>
        /// This method returns all BranchOffices in the database
        /// </summary>
        /// <returns></returns>
        public List<BranchOffice> GetBranchOffices()
        {
            var db = new PospfEntities();
            return db.BranchOffices.ToList();
        }
        /// <summary>
        /// This method returns all information of a single BranchOffice
        /// </summary>
        /// <param name="pProdEan"></param>
        /// <returns></returns>
        public BranchOffice GetBranchOffice(byte pIdNumber)
        {
            var db = new PospfEntities();
            return db.BranchOffices.FirstOrDefault(x => x.OfficeID == pIdNumber);
        }
        /// <summary>
        /// This method creates a new BranchOffice in the Database
        /// </summary>
        /// <param name="pNewBranchOffice"></param>
        /// <returns></returns>
        public bool SaveBranchOffice(BranchOffice pNewBranchOffice)
        {
            var db = new PospfEntities();
            try
            {
                db.BranchOffices.Add(pNewBranchOffice);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// This method updates information of a BranchOffice in the database
        /// </summary>
        /// <param name="pProdEan"></param>
        /// <param name="pUpdatedBranchOffice"></param>
        /// <returns></returns>
        public bool UpdateBranchOffice(byte pIdNumber, BranchOffice pUpdatedBranchOffice)
        {
            var db = new PospfEntities();
            try
            {
                db.Entry(pUpdatedBranchOffice).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// This method deletes a BranchOffice in the database
        /// </summary>
        /// <param name="pEan"></param>
        /// <returns></returns>
        public bool DeleteBranchOffice(byte pIdNumber)
        {
            var db = new PospfEntities();
            try
            {
                var BranchOffice = db.BranchOffices.FirstOrDefault(x => x.OfficeID == pIdNumber);
                if (BranchOffice == null)
                {
                    return false;
                }
                db.Entry(BranchOffice).State = System.Data.Entity.EntityState.Deleted;
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