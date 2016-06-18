using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// This method returns all Customers in the database
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            var db = new PospfEntities();
            return db.Customers.ToList();
        }
        /// <summary>
        /// This method returns all information of a single Customer
        /// </summary>
        /// <param name="pProdEan"></param>
        /// <returns></returns>
        public Customer GetCustomer(string pIdNumber)
        {
            var db = new PospfEntities();
            return db.Customers.FirstOrDefault(x => x.IDNumber == pIdNumber);
        }
        /// <summary>
        /// This method creates a new Customer in the Database
        /// </summary>
        /// <param name="pNewCustomer"></param>
        /// <returns></returns>
        public bool SaveCustomer(Customer pNewCustomer)
        {
            var db = new PospfEntities();
            try
            {
                db.Customers.Add(pNewCustomer);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// This method updates information of a Customer in the database
        /// </summary>
        /// <param name="pProdEan"></param>
        /// <param name="pUpdatedCustomer"></param>
        /// <returns></returns>
        public bool UpdateCustomer(string pIdNumber, Customer pUpdatedCustomer)
        {
            var db = new PospfEntities();
            try
            {
                db.Entry(pUpdatedCustomer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// This method deletes a Customer in the database
        /// </summary>
        /// <param name="pEan"></param>
        /// <returns></returns>
        public bool DeleteCustomer(string pIdNumber)
        {
            var db = new PospfEntities();
            try
            {
                var Customer = db.Customers.FirstOrDefault(x => x.OfficeIDEquals(pIdNumber));
                if (Customer == null)
                {
                    return false;
                }
                db.Entry(Customer).State = System.Data.Entity.EntityState.Deleted;
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