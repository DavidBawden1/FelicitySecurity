using System;
using System.Collections.Generic;
using System.Text;

namespace FelicitySecurity.CCTV.Repository.Interfaces
{
    public interface ICCTVRepository
    {
        bool IsAdminAuthorised(string email, string pinCode);
    }
}
