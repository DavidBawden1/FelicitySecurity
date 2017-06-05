using System;
using System.Collections;
using System.Collections.Generic;

namespace FelicitySecurity.Core.Models
{
    public class AdministratorsModel: IEnumerable
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPinCode { get; set; }

        public List<AdministratorsModel> ListOfAdministrators = new List<AdministratorsModel>();

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
