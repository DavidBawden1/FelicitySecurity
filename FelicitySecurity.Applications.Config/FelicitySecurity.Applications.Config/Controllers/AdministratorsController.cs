using System.Collections.Generic;
using System.Linq;
using FelicitySecurity.Core.DataTransferObjects;
using FelicitySecurity.Applications.Config.Interfaces;
using FelicitySecurity.Core.Models;
using FelicitySecurity.Services;
using FelicitySecurity.Applications.Config.FelicitySecurityServiceReference;

namespace FelicitySecurity.Applications.Config.Controllers
{
    /// <summary>
    /// Returns an Administrators model to Administrator related Views.
    /// </summary>
    public class AdministratorsController : IAdministratorsController
    {
        FelicitySecurityDataService  dataService = new FelicitySecurityDataService();
        FelicitySecurityDataServiceClient client = new FelicitySecurityDataServiceClient();
        public void IAdministratorsController(FelicitySecurityDataService dataService)
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
            dataService.AddAdministrator(admin);
        }

        /// <summary>
        /// Returns a list of all administrators. 
        /// </summary>
        /// <param name="viewModel">Administrators ViewModel</param>
        /// <returns>model</returns>
        public List<AdministratorsModel> AllAdministratorsEmail(AdministratorsModel model)
        {
            List<Administrators_dto> allAdministrators = dataService.FindAllAdministrators();

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
            return dataService.FindAllAdministrators().Where(e => e.AdminEmail == email).FirstOrDefault();
        }


        /// <summary>
        /// Returns the Administrators details for the selected Administrators email. 
        /// </summary>
        /// <param name="email"></param>
        /// <returns>The administrator</returns>
        public Administrators_dto ReturnAdministratorByEmail(string email, string pinCode)
        {
            return dataService.FindAllAdministrators().Where(e => e.AdminEmail == email && e.AdminPinCode == pinCode).FirstOrDefault();
        }
        /// <summary>
        /// Calls the repository to remove the specified administrator. 
        /// </summary>
        /// <param name="model"></param>
        public void RemoveSelectedAdministrator(AdministratorsModel model)
        {
            dataService.RemoveAdministrator(model.AdminID);
        }

        /// <summary>
        /// updates the old Administrators dto with the new Administrators model. 
        /// </summary>
        /// <param name="model"></param>
        public void UpdateSelectedAdministrator(AdministratorsModel model)
        {
            Administrators_dto admin_dto = new Administrators_dto()
            {
                AdminID = model.AdminID,
                AdminEmail = model.AdminEmail,
                AdminName = model.AdminName,
                AdminPinCode = model.AdminPinCode
            };
            dataService.UpdateAdministrator(admin_dto);
        }
    }
}

