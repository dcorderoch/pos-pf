using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBAPI.Data;

namespace WEBAPI.Services.Services
{
    public interface IStaffService
    {
        List<Staff> GetStaffMembers();
        Staff GetStaff(int pStaffId);
        int SaveStaff(Staff pNewStaff);
        bool UpdateStaff(Staff pUpdatedStaff);
        bool DeleteStaff(int pStaffId);
    }
}
