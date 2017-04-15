using FelicitySecurity.Core.DataTransferObjects;
using System.Collections.Generic;

namespace FelicitySecurity.Services.Data.Interfaces
{
    public interface IFelicitySecurityBusinessLogic
    {
        /// <summary>
        /// calls the Add Administrator Repository method
        /// </summary>
        /// <param name="item">Administrators_dto</param>
        void AddAdministrator(Administrators_dto item);

        /// <summary>
        /// calls the Find All Administrator Repository method
        /// </summary>
        /// <param name="item">Administrators_dto</param>
        List<Administrators_dto> FindAllAdministrators();

        /// <summary>
        /// calls the Add Member Repository method
        /// </summary>
        /// <param name="item">Members_dto</param>
        void AddMember(Members_dto item);

        /// <summary>
        /// calls the Find All Members Repository method
        /// </summary>
        /// <param name="item">Members_dto</param>
        List<Members_dto> FindAllMembers();

        /// <summary>
        /// calls the Add Faces Repository method
        /// </summary>
        /// <param name="item">Faces_dto</param>
        void AddFaces(Faces_dto item);

        /// <summary>
        /// calls the Find All Faces Repository method
        /// </summary>
        /// <param name="item">Faces_dto</param>
        List<Faces_dto> FindAllMembersFaces();

        /// <summary>
        /// calls the Add Staff Repository method
        /// </summary>
        /// <param name="item">Staff_dto</param>
        void AddStaff(Staff_dto item);

        /// <summary>
        /// calls the Find All Staff Repository method
        /// </summary>
        /// <param name="item">Staff_dto</param>
        List<Staff_dto> FindAllStaff(Staff_dto item);

        /// <summary>
        /// Calls the Remove Administrator Repository method
        /// </summary>
        /// <param name="administratorId"></param>
        void RemoveAdministrator(int administratorId);

        /// <summary>
        /// Calls the Update Administrator Repository method
        /// </summary>
        /// <param name="item"></param>
        void UpdateAdministrator(Administrators_dto item);
       
    }
}
