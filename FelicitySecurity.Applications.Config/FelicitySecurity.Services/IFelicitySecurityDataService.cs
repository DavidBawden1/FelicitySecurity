using FelicitySecurity.Core.DataTransferObjects;
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
        void AddAdministrator(Administrators_dto item);
        List<Administrators_dto> FindAllAdministrators();
        void AddMember(Members_dto item);
        List<Members_dto> FindAllMembers();
        void AddFaces(Faces_dto item);
        List<Faces_dto> FindAllMembersFaces();
        void AddStaff(Staff_dto item);
        List<Staff_dto> FindAllStaff();
        void RemoveAdministrator(int administratorId);
        void UpdateAdministrator(Administrators_dto item);
    }
}
