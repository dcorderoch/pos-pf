using WEBAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBAPI.Services.Services
{
    public interface ISaleService
    {
        long StartSale(string pCustomerId, int pCashierId, byte pOfficeId);
        bool EndSale(long pSaleId);
    }
}