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
        /// <summary>
        /// This method records a sale in the database
        /// </summary>
        /// <param name="pCustomerId"></param>
        /// <param name="pCashierId"></param>
        /// <param name="pOfficeId"></param>
        /// <returns></returns>
        public long StartSale(string pCustomerId, int pCashierId, byte pOfficeId)
        {
            var db = new PospfEntities();
            var theNewSale = new Sale
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
        /// <summary>
        /// This method updates a sale end date
        /// and saves all products that were sold in the appropriate table
        /// </summary>
        /// <param name="pSaleId"></param>
        /// <param name="pProdsEan"></param>
        /// <param name="pProdsQty"></param>
        /// <returns></returns>
        public bool EndSale(long pSaleId, List<string> pProdsEan, List<int> pProdsQty)
        {
            var db = new PospfEntities();
            try
            {
                var upperLimit = pProdsEan.Count;
                var i = 0;
                while (i < upperLimit)
                {
                    var tmpInSale = new ProductInSale
                    {
                        EAN = pProdsEan.ToArray()[i],
                        Quantity = pProdsQty.ToArray()[i],
                        SaleID = pSaleId
                    };
                    db.ProductInSales.Add(tmpInSale);

                    var tmpEan = pProdsEan.ToArray()[i];
                    var tmpQty = pProdsQty.ToArray()[i];

                    var product = db.Products.FirstOrDefault(p => p.EAN == tmpEan);
                    if (product != null)
                    {
                        product.Quantity -= tmpQty;
                    }

                    i++;
                }

                var thisSale = db.Sales.FirstOrDefault(x => x.SaleID == pSaleId);
                if (thisSale != null)
                {
                    thisSale.EOF = DateTime.Now;
                    db.Entry(thisSale).State = System.Data.Entity.EntityState.Modified;
                }

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