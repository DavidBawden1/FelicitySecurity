using FelicitySecurity.Core.DataTransferObjects;
using System.Collections.Generic;

namespace FelicitySecurity.Services.Data.Interfaces
{
    /// <summary>
    /// Administrator Repository interface for Administration CRUD operations. 
    /// </summary>
    public interface IAdministratorRepository
    {
        List<Administrators_dto> FindAllAdministrators();
        Administrators_dto AddAdministrator(Administrators_dto item);
        void UpdateAdministrator(Administrators_dto admin);
        void DeleteAdministrator(int administratorsId);
    }
}
