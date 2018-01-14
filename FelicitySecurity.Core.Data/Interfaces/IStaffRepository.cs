using FelicitySecurity.Core.DataTransferObjects;
using System.Collections.Generic;

namespace FelicitySecurity.Core.Data.Interfaces
{
    public interface IStaffRepository
    {
        Staff_dto AddStaff(Staff_dto item);
        List<Staff_dto> FindAllStaff();
        void UpdateStaff();
        void DeleteStaff();
    }
}
