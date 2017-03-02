using System;
using System.Collections.Generic;

namespace FelicitySecurity.Core.DataTransferObjects
{
    /// <summary>
    /// The Members dto transfers members data from the database along with the responsible admin for registering them to the system 
    /// </summary>
    public class Members_dto
    {
        public int MemID { get; set; }
        public string MemFirstname { get; set; }
        public string MemLastname { get; set; }
        public string MemPhonenumber { get; set; }
        public Nullable<System.DateTime> MemDOB { get; set; }
        public string MemPostcode { get; set; }
        public Nullable<bool> MemStatus { get; set; }
        public Nullable<System.DateTime> MemRegDate { get; set; }
        public Nullable<bool> IsStaff { get; set; }
        public int AdminID { get; set; }

        public virtual IEnumerable <Administrators_dto> ResponsibleAdministrators { get; set; }
  

    }
}
