using System;
using System.Collections.Generic;
using System.Text;

namespace FelicitySecurity.CCTV.Data.Interfaces
{
    interface IAdministratorRepository
    {
        bool IsAdministrator(Models.AdministratorModel model);
    }
}
