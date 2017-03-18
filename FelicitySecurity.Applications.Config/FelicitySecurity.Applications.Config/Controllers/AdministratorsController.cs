using System.Collections.Generic;
using System.Linq;
using FelicitySecurity.Core.Data.Repository;
using FelicitySecurity.Core.DataTransferObjects;
using FelicitySecurity.Applications.Config.Interfaces;
using FelicitySecurity.Core.Models;
using FelicitySecurity.Core.Utils;
using FelicitySecurity.Applications.Config.ViewModels;
using System;

namespace FelicitySecurity.Applications.Config.Controllers
{
    /// <summary>
    /// Returns an Administrators model to Administrator related Views.
    /// </summary>
    public class AdministratorsController : IAdministratorsController
    {
        FelicitySecurityRepository engineRepository = new FelicitySecurityRepository();
        public void IAdministratorsController(FelicitySecurityRepository engineRepository)
        {

        }

        /// <summary>
        /// Creates an administrator and then returns a model of all of the administrators. 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="pin"></param>
        public void AddAdministrators(string email, string username, string pin)
        {
            Administrators_dto admin = new Administrators_dto();
            admin.AdminEmail = email;
            admin.AdminName = username;
            admin.AdminPinCode = pin;
            engineRepository.AddAdministrator(admin);
        }

        /// <summary>
        /// Returns a list of all administrators. 
        /// </summary>
        /// <param name="viewModel">Administrators ViewModel</param>
        /// <returns>model</returns>
        public List<AdministratorsModel> AllAdministratorsEmail(AdministratorsModel model)
        {
            List<Administrators_dto> allAdministrators = engineRepository.FindAllAdministrators();

            foreach (Administrators_dto admin in allAdministrators)
            {
                AdministratorsModel administrator = new AdministratorsModel();
                administrator.AdminID = admin.AdminID;
                administrator.AdminEmail = admin.AdminEmail;
                administrator.AdminName = admin.AdminName;
                administrator.AdminPinCode = admin.AdminPinCode;
                model.ListOfAdministrators.Add(administrator);
            }
            return model.ListOfAdministrators;
        }

        /// <summary>
        /// Returns the Administrators details for the selected Administrators email. 
        /// </summary>
        /// <param name="email"></param>
        /// <returns>The administrator</returns>
        public Administrators_dto ReturnAdministratorByEmail(string email)
        {
            return engineRepository.FindAllAdministrators().Where(e => e.AdminEmail == email).FirstOrDefault();
        }

        /// <summary>
        /// Calls the repository to remove the specified administrator. 
        /// </summary>
        /// <param name="model"></param>
        public void RemoveSelectedAdministrator(AdministratorsModel model)
        {
            engineRepository.RemoveAdministrator(model.AdminID);
        }

        public void UpdateSelectedAdministrator(string email, string username, string pincode)
        {
            Administrators_dto admin_dto = new Administrators_dto()
            {
                AdminEmail = email,
                AdminName = username,
                AdminPinCode = pincode
            };
            engineRepository.UpdateAdministrator(admin_dto);
        }
    }
}

