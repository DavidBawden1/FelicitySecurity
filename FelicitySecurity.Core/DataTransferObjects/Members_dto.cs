using System;

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
        public DateTime MemDOB { get; set; }
        public string MemPostcode { get; set; }
        public bool? MemStatus { get; set; }
        public DateTime MemRegDate { get; set; }
        public bool? IsStaff { get; set; }
        public byte[] MemFacialImage { get; set; }
    }
}
