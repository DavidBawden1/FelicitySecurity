using System;
using System.Collections.Generic;
using System.Text;

namespace FelicitySecurity.CCTV.Repository.Interfaces
{
    interface IAdministratorRepository
    {
        bool IsAdministrator(Models.AdministratorModel model);
    }
}
