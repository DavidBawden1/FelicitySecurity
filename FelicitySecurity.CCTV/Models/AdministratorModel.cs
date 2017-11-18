using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FelicitySecurity.CCTV.Models
{
    public class AdministratorModel
    {
        public int AdminId { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public List<AdministratorModel> Administrators = new List<AdministratorModel>();
    }
}
