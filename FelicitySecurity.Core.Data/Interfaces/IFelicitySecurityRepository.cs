using FelicitySecurity.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelicitySecurity.Core.Data.Interfaces
{
    public interface IFelicitySecurityRepository
    {
        List<Administrators_dto> FindAllAdministrators();
        Administrators_dto AddAdministrator(Administrators_dto item);
        List<Members_dto> FindAllMembers();
        Members_dto AddMember(Members_dto item);
        List<Faces_dto> FindAllMembersFaces();
        Faces_dto AddFaces(Faces_dto item);
        Staff_dto AddStaff(Staff_dto item);
        List<Staff_dto> FindALLStaff();
        void RemoveAdministrator(int administratorsId);
        void UpdateAdministrator(Administrators_dto admin);

    }
}
