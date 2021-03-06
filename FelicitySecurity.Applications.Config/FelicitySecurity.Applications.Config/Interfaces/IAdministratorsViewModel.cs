﻿using FelicitySecurity.Applications.Config.Controllers;
using FelicitySecurity.Applications.Config.ViewModels;
using FelicitySecurity.Applications.Config.Views;
using FelicitySecurity.Core.Models;

namespace FelicitySecurity.Applications.Config.Interfaces
{
    public interface IAdministratorsViewModel
    {
        int AdminID { get; set; }
        string Email { get; set; }
        string Username { get; set; }
        string PinCode { get; set; }
        string PinCodeConfirmed { get; set; }
        void DisplayAdministratorEmails(RegisterAdministrators_Form form, AdministratorsController controller, AdministratorsModel model, CurrentSortingType sortingType);
        void UpdateSelectedAdministrator(AdministratorsController controller, AdministratorsModel model);
        void DeleteSelectedAdministrator(AdministratorsController controller, AdministratorsModel model);
        bool IsPersonAuthorised(AuthenticateAdministrators_Form form, string email, string pinCode, AdministratorsController controller, AdministratorsModel model);
    }

}
