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
    public class CustomerController : ApiController
    {
        /// <summary>
        /// This method returns all Customer Information
        /// </summary>
        /// <param name="pEan"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<Customer> Get(CustById pIdNumber)
        {
            ICustomerService CustomerService = new CustomerService();
            return Json(CustomerService.GetCustomer(pIdNumber.IdNumber));
        }
        /// <summary>
        /// This Method returns all information of all Customers in the Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult<List<Customer>> GetAll()
        {
            ICustomerService CustomerService = new CustomerService();
            return Json(CustomerService.GetCustomers());
        }
        /// <summary>
        /// This Method receives the necessary information of a Customer
        /// and Creates it in the Database
        /// </summary>
        /// <param name="pNewCustomer"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<LongReturnStatus> Create(Customer pNewCustomer)
        {
            ICustomerService CustomerService = new CustomerService();
            var retVal = new LongReturnStatus() { StatusCode = CustomerService.SaveCustomer(pNewCustomer) ? 1 : 0 };
            return Json(retVal);
        }
        /// <summary>
        /// This Method receives the necessary information of a Customer
        /// and Updates it in the database
        /// </summary>
        /// <param name="pUpdatedCustomer"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<LongReturnStatus> Update(Customer pUpdatedCustomer)
        {
            ICustomerService CustomerService = new CustomerService();
            var retVal = new LongReturnStatus() { StatusCode = CustomerService.UpdateCustomer(pUpdatedCustomer.IDNumber, pUpdatedCustomer) ? 1 : 0 };
            return Json(retVal);
        }
        /// <summary>
        /// This Method receives the EAN of a Customer and deletes it, if it exists in the database
        /// </summary>
        /// <param name="pEan"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<LongReturnStatus> Delete(CustById IdNumber)
        {
            ICustomerService CustomerService = new CustomerService();
            var retVal = new LongReturnStatus() { StatusCode = CustomerService.DeleteCustomer(IdNumber.IdNumber) ? 1 : 0 };
            return Json(retVal);
        }
    }
}
