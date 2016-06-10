using System;
using System.Collections.Generic;
using System.Linq;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public class ProductService : IProductService
    {
        private PospfEntities db = new PospfEntities();
        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProduct(string pProdEan)
        {
            return db.Products.FirstOrDefault(x => x.EAN.Equals(pProdEan));
        }

        public bool SaveProduct(Product pNewProduct)
        {
            try
            {
                db.Products.Add(pNewProduct);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProduct(string pProdEan,Product pUpdatedProduct)
        {
            try
            {
                db.Entry(pUpdatedProduct).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(string pEan)
        {
            try
            {
                var product = db.Products.FirstOrDefault(x => x.EAN.Equals(pEan));//FirstOrDefault(x => x.EAN == pEan);
                if (product == null)
                {
                    return false;
                }
                db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
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