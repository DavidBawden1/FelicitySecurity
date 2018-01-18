namespace FelicitySecurity.Core.Data.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FelicityLiveEntities : DbContext
    {
        public FelicityLiveEntities()
            : base("name=FelicityLiveEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminTable>().ToTable("AdminTable");
            modelBuilder.Entity<MemberTable>().ToTable("MemberTable");
            modelBuilder.Entity<StaffTable>().ToTable("StaffTable");
        }
    
        public virtual DbSet<AdminTable> AdminTable { get; set; }
        public virtual DbSet<MemberTable> MemberTable { get; set; }
        public virtual DbSet<StaffTable> StaffTable { get; set; }
    }
}
