using FelicitySecurity.Core.DataTransferObjects;
using FelicitySecurity.Core.Models;
using FelicitySecurity.Services;
using System.Collections.Generic;

namespace FelicitySecurity.Applications.Config.Interfaces
{
    public interface IAdministratorsController
    {
        void IAdministratorsController(FelicitySecurityDataService engineRepository);
        void AddAdministrators(string email, string username, string pincode);
        List<AdministratorsModel> AllAdministratorsEmail(AdministratorsModel model);
        Administrators_dto ReturnAdministratorByEmail(string email);
        Administrators_dto ReturnAdministratorByEmail(string email, string pinCode);
        void RemoveSelectedAdministrator(AdministratorsModel model);
        void UpdateSelectedAdministrator(AdministratorsModel model);
    }
}
