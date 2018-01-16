using FelicitySecurity.Core.Data.DataModel;
using System.Collections.Generic;

namespace FelicitySecurity.Services.Data.Interfaces
{
    /// <summary>
    /// Administrator Repository interface for Administration CRUD operations. 
    /// </summary>
    public interface IAdministratorRepository
    {
        List<AdminTable> FindAllAdministrators();
        AdminTable AddAdministrator(AdminTable item);
        void UpdateAdministrator(AdminTable admin);
        void DeleteAdministrator(AdminTable admin);
    }
}
