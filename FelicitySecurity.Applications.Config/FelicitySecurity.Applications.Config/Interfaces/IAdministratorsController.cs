using FelicitySecurity.Core.BusinessLogic;
using FelicitySecurity.Core.FelicitySecurityDataServiceReference;
using FelicitySecurity.Core.Models;
using System.Collections.Generic;

namespace FelicitySecurity.Applications.Config.Interfaces
{
    public interface IAdministratorsController
    {
        void IAdministratorsController(FelicitySecurityBusinessLogic engineRepository);
        void AddAdministrators(string email, string username, string pincode);
        List<AdministratorsModel> AllAdministrators(AdministratorsModel model);
        Administrators_dto ReturnAdministratorByEmail(string email);
        Administrators_dto ReturnAdministratorByEmail(string email, string pinCode);
        void RemoveSelectedAdministrator(AdministratorsModel model);
        void UpdateSelectedAdministrator(AdministratorsModel model);
    }
}
