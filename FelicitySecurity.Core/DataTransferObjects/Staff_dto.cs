using System;
using System.Collections.Generic;


namespace FelicitySecurity.Core.DataTransferObjects
{
    /// <summary>
    /// The Staff dto transfers staff data to and from database. also staff that are also members
    /// </summary>
    public class Staff_dto
    {
        public int StaffID { get; set; }
        public Nullable<bool> IsStaff { get; set; }
        public Nullable<int> BadgeNo { get; set; }
        public int MemID { get; set; }

        public virtual List<Members_dto> StaffMembers { get; set; }
    }
}
