using FelicitySecurity.Core.Data.DataModel;
using System.Collections.Generic;

namespace FelicitySecurity.Core.Data.Interfaces
{
    public interface IStaffRepository
    {
        StaffTable AddStaff(StaffTable item);
        List<StaffTable> FindAllStaff();
        void UpdateStaff();
        void DeleteStaff();
    }
}
