using System;
using System.Collections.Generic;
using System.Text;

namespace FelicitySecurity.CCTV.Repository.Interfaces
{
    interface ICCTVRepository
    {
        bool IsAdminAuthorised(string email, string pinCode);
    }
}
