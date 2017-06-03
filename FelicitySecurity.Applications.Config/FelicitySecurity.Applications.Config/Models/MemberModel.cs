using System;
using System.Collections.Generic;

namespace FelicitySecurity.Applications.Config.Models
{
    /// <summary>
    /// The Member Model contains personal member information
    /// </summary>
    public class MemberModel
    {
        public int MemberId { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public DateTime MemberDateOfBirth { get; set; }
        public string MemberPostCode { get; set; }
        public DateTime MemberDateOfRegistration { get; set; }
        public string MemberPhoneNumber { get; set; }
        public bool IsPersonARegisteredMember { get; set; }
        public bool IsPersonAStaffMember { get; set; }
        public byte[] MemberFacialImages { get; set; }

        public List<MemberModel> ListOfMembers = new List<MemberModel>();
    }
}
