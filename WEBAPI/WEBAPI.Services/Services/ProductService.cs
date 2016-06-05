using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public class ProductService : IProductService
    {
        private PosPFDBEntities db = new PosPFDBEntities();
        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProduct(long pProdEan)
        {
            return db.Products.FirstOrDefault(x => x.EAN == pProdEan);
        }

        public bool SaveProduct(Product pNewProduct)
        {
            try
            {
                db.Products.Add(pNewProduct);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateProduct(long pProdEan,Product pUpdatedProduct)
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

        public bool DeleteProduct(long pEan)
        {
            try
            {
                var Product = db.Products.FirstOrDefault(x => x.EAN == pEan);
                if (Product == null)
                {
                    return false;
                }
                db.Entry(Product).State = System.Data.Entity.EntityState.Deleted;
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