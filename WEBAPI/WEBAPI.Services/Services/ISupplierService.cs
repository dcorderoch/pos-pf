using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public interface ISupplierService
    {
        Supplier GetSupplier(byte pSupplierId);
        List<Supplier> GetSuppliers();
        byte SaveSupplier(Supplier pNewSupplier);
        bool UpdateSupplier(Supplier pUpdatedSupplier);
        bool DeleteSupplier(byte pSupplierId);
    }
}
