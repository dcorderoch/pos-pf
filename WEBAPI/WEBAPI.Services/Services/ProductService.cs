using System;
using System.Collections.Generic;
using System.Linq;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// This method returns all products in the database
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            var db = new PospfEntities();
            return db.Products.ToList();
        }
        /// <summary>
        /// This method returns all information of a single product
        /// </summary>
        /// <param name="pProdEan"></param>
        /// <returns></returns>
        public Product GetProduct(string pProdEan)
        {
            var db = new PospfEntities();
            return db.Products.FirstOrDefault(x => x.EAN == pProdEan);
        }
        /// <summary>
        /// This method creates a new Product in the Database
        /// </summary>
        /// <param name="pNewProduct"></param>
        /// <returns></returns>
        public bool SaveProduct(Product pNewProduct)
        {
            var db = new PospfEntities();
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
        /// <summary>
        /// This method updates information of a product in the database
        /// </summary>
        /// <param name="pProdEan"></param>
        /// <param name="pUpdatedProduct"></param>
        /// <returns></returns>
        public bool UpdateProduct(string pProdEan,Product pUpdatedProduct)
        {
            var db = new PospfEntities();
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
        /// <summary>
        /// This method deletes a product in the database
        /// </summary>
        /// <param name="pEan"></param>
        /// <returns></returns>
        public bool DeleteProduct(string pEan)
        {
            var db = new PospfEntities();
            try
            {
                var product = db.Products.FirstOrDefault(x => x.EAN.Equals(pEan));
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