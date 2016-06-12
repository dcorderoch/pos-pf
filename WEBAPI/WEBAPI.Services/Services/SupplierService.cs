using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public class SupplierService : ISupplierService
    {
        /// <summary>
        /// This method returns all information of a single Supplier
        /// </summary>
        /// <param name="pSupplierId"></param>
        /// <returns></returns>
        public Supplier GetSupplier(byte pSupplierId)
        {
            var db = new PospfEntities();
            return db.Suppliers.FirstOrDefault(x => x.SupplerID == pSupplierId);
        }
        /// <summary>
        /// This method returns all Suppliers in the database
        /// </summary>
        /// <returns></returns>
        public List<Supplier> GetSuppliers()
        {
            var db = new PospfEntities();
            return db.Suppliers.ToList();
        }
        /// <summary>
        /// This method creates a new Supplier in the Database
        /// </summary>
        /// <param name="pNewSupplier"></param>
        /// <returns></returns>
        public byte SaveSupplier(Supplier pNewSupplier)
        {
            var db = new PospfEntities();
            try
            {
                var newSupplier = pNewSupplier;
                db.Suppliers.Add(newSupplier);
                db.SaveChanges();
                return newSupplier.SupplerID;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// This method updates information of a Supplier in the database
        /// </summary>
        /// <param name="pUpdatedSupplier"></param>
        /// <returns></returns>
        public bool UpdateSupplier(Supplier pUpdatedSupplier)
        {
            var db = new PospfEntities();
            try
            {
                var supplier = db.Suppliers.FirstOrDefault(x => x.SupplerID == pUpdatedSupplier.SupplerID);
                if (supplier != null)
                {
                    supplier.Name = pUpdatedSupplier.Name;
                    supplier.PhoneNumber = pUpdatedSupplier.PhoneNumber;

                    db.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
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
        /// This method deletes a Supplier in the database
        /// </summary>
        /// <param name="pSupplierId"></param>
        /// <returns></returns>
        public bool DeleteSupplier(byte pSupplierId)
        {
            var db = new PospfEntities();
            try
            {
                var supplier = db.Suppliers.FirstOrDefault(x => x.SupplerID == pSupplierId);
                
                if (supplier == null)
                {
                    return false;
                }
                db.Entry(supplier).State = System.Data.Entity.EntityState.Deleted;
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