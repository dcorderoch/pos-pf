using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.WEBAPI.Models
{
    public class SaleEndData
    {
        public List<SaleEndProd> Products { get; set; }
        public long SaleID { get; set; }
    }
}