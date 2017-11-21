using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FelicitySecurity.CCTV.Models
{
    public class AdministratorModel
    {
        public int AdminId { get; set; }

        [Required]
        [StringLength(100)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(12)]
        public string Password { get; set; }

        public List<AdministratorModel> Administrators = new List<AdministratorModel>();
    }
}
