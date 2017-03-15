using FelicitySecurity.Core.Data.Repository;
using FelicitySecurity.Core.Models;
using System.Collections.Generic;

namespace FelicitySecurity.Applications.Config.Interfaces
{
    public interface IAdministratorsController
    {
        void IAdministratorsController(FelicitySecurityRepository engineRepository);
        void AddAdministrators(string email, string username, string pin);
        List<AdministratorsModel> AllAdministratorsEmail(AdministratorsModel model);
        void RemoveSelectedAdministrator(AdministratorsModel model);
    }
}
