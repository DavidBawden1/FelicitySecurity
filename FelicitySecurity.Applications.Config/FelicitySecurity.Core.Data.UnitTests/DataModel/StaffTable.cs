//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FelicitySecurity.Core.Data.UnitTests.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class StaffTable
    {
        public int StaffID { get; set; }
        public Nullable<int> BadgeNo { get; set; }
        public int MemID { get; set; }
    
        public virtual MemberTable MemberTable { get; set; }
    }
}
