using FelicitySecurity.Core.DataTransferObjects;
using System.Collections.Generic;

namespace FelicitySecurity.Services.Data.Interfaces
{
    public interface IFelicitySecurityRepository
    {
        List<Administrators_dto> FindAllAdministrators();
        Administrators_dto AddAdministrator(Administrators_dto item);
        List<Members_dto> FindAllMembers();
        Members_dto AddMember(Members_dto item);
        Staff_dto AddStaff(Staff_dto item);
        List<Staff_dto> FindAllStaff();
        void RemoveAdministrator(int administratorsId);
        void UpdateAdministrator(Administrators_dto admin);

    }
}
