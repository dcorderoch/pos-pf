using WEBAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBAPI.Services.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(long pProdEan);
        bool SaveProduct(Product pNewProduct);
        bool UpdateProduct(string pProdEan,Product pUpdatedProduct);
        bool DeleteProduct(long pEan);
    }
}
