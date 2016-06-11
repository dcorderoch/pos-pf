using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public class SaleService : ISaleService
    {
        private PospfEntities db = new PospfEntities();

        public long StartSale(string pCustomerId, int pCashierId, byte pOfficeId)
        {
            Sale theNewSale = new Sale
            {
                IDNumber = pCustomerId,
                StaffID = pCashierId,
                BOfficeID = pOfficeId
            };
            try
            {
                db.Sales.Add(theNewSale);
                db.SaveChanges();

                return theNewSale.SaleID;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public bool EndSale(long pSaleId, List<string> pProdsEan, List<int> pProdsQty)
        {
            try
            {
                int upperLimit = pProdsEan.Count;
                int i = 0;
                while (i < upperLimit)
                {
                    ProductInSale tmpInSale = new ProductInSale();
                    tmpInSale.EAN = pProdsEan.ToArray()[i];
                    tmpInSale.Quantity = pProdsQty.ToArray()[i];
                    tmpInSale.SaleID = pSaleId;
                    db.ProductInSales.Add(tmpInSale);
                    i++;
                }

                var thisSale = db.Sales.FirstOrDefault(x => x.SaleID == pSaleId);
                thisSale.EOF = DateTime.Now;
                db.Entry(thisSale).State = System.Data.Entity.EntityState.Modified;

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