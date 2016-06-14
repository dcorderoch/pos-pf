using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public interface ICustomerService 
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(string pIdNumber);
        bool SaveCustomer(Customer pNewCustomer);
        bool UpdateCustomer(string pIdNumber, Customer pUpdatedCustomer);
        bool DeleteCustomer(string pIdNumber);
    }
}