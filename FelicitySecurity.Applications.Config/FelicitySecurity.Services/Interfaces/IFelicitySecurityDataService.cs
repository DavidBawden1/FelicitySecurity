using FelicitySecurity.Core.Data.DataModel;
using System.Collections.Generic;
using System.ServiceModel;

namespace FelicitySecurity.Services
{
    /// <summary>
    /// The Interface for the FelicitySecurityDataService. 
    /// </summary>
    [ServiceContract]
    public interface IFelicitySecurityDataService
    {
        void AddAdministrator(AdminTable item);
        List<AdminTable> FindAllAdministrators();
        void AddMember(MemberTable item);
        List<MemberTable> FindAllMembers();
        void AddStaff(StaffTable item);
        List<StaffTable> FindAllStaff();
        void RemoveAdministrator(AdminTable item);
        void UpdateAdministrator(AdminTable item);
        void UpdateMember(MemberTable item);
        void DeleteMember(MemberTable item);
    }
}
