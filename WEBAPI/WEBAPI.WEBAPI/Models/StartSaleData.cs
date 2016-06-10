using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.WEBAPI.Models
{
    public class StartSaleData
    {
        public string CustomerId { get; set; }
        public int CashierId { get; set; }
        public byte OfficeId { get; set; }
    }
}