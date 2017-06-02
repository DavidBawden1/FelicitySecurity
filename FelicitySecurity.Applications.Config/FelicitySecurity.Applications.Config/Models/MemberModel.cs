using System;

namespace FelicitySecurity.Applications.Config.Models
{
    public class MemberModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsMember { get; set; }
        public bool IsStaff { get; set; }
        public byte[] FacialImages { get; set; }
    }
}
