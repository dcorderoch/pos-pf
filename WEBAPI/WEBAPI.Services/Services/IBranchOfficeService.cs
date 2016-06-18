using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public interface IBranchOfficeService
    {
        List<BranchOffice> GetBranchOffices();
        BranchOffice GetBranchOffice(byte pIdNumber);
        bool SaveBranchOffice(BranchOffice pNewBranchOffice);
        bool UpdateBranchOffice(byte pIdNumber, BranchOffice pUpdatedBranchOffice);
        bool DeleteBranchOffice(byte pIdNumber);
    }
}