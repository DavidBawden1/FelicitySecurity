using FelicitySecurity.Core.DataTransferObjects;
using System.Collections.Generic;

namespace FelicitySecurity.Core.Data.Interfaces
{
    public interface IStaffRepository
    {
        List<Staff_dto> FindAllStaff();
    }
}
