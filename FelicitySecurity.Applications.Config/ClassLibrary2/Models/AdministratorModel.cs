using System;
using System.Collections.Generic;
using System.Text;

namespace FelicitySecurity.CCTV.Repository.Models
{
    public class AdministratorModel
    {
        public int AdminId { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
