//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FelicitySecurity.Core.Data.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class MemberTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberTable()
        {
            this.StaffTable = new HashSet<StaffTable>();
        }
    
        public int MemID { get; set; }
        public string MemFirstname { get; set; }
        public string MemLastname { get; set; }
        public string MemPhonenumber { get; set; }
        public Nullable<System.DateTime> MemDOB { get; set; }
        public string MemPostcode { get; set; }
        public Nullable<bool> MemStatus { get; set; }
        public Nullable<System.DateTime> MemRegDate { get; set; }
        public Nullable<bool> IsStaff { get; set; }
        public byte[] MemFacialImage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffTable> StaffTable { get; set; }
    }
}
