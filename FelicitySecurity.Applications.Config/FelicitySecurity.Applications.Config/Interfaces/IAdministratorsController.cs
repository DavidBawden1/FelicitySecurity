﻿using FelicitySecurity.Applications.Config.ViewModels;
using FelicitySecurity.Core.Data.Repository;
using FelicitySecurity.Core.Models;
using System.Collections.Generic;

namespace FelicitySecurity.Applications.Config.Interfaces
{
    public interface IAdministratorsController
    {
        void IAdministratorsController(FelicitySecurityRepository engineRepository);
        void AddAdministrators(string email, string username, string pincode);
        List<AdministratorsModel> AllAdministratorsEmail(AdministratorsModel model);
        void RemoveSelectedAdministrator(AdministratorsModel model);
        void UpdateSelectedAdministrator(string email, string username, string pincode);
    }
}
