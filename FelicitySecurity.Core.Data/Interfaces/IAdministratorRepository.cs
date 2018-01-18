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
    }
}
