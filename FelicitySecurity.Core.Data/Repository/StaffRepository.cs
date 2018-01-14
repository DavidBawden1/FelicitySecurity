using FelicitySecurity.Core.Data.DataModel;
using FelicitySecurity.Core.Data.Interfaces;
using FelicitySecurity.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FelicitySecurity.Services.Data.Repository
{
    public class StaffRepository : Repository<Staff_dto>, IStaffRepository
    {
        public StaffRepository(string connectionString) 
            : base(connectionString)
        {

        }

        public StaffRepository()
        {

        }

        /// <summary>
        /// Adds a staff members to the StaffTable when the registration scenario is applied. 
        /// </summary>
        public Staff_dto AddStaff(Staff_dto item)
        {
            try
            {
                using (DbContext dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    var entity = new StaffTable()
                    {
                        BadgeNo = item.BadgeNo.Value,
                        MemID = item.MemID
                    };
                    dbContext.Entry(entity).State = EntityState.Added;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }
            return item;
        }

        /// <summary>
        /// returns a list of all staff and their data. 
        /// </summary>
        /// <returns>a result list of all staff members within the system</returns>
        public List<Staff_dto> FindAllStaff()
        {
            List<Staff_dto> staffResults = new List<Staff_dto>();
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    foreach (var item in dbContext.StaffTable)
                    {
                        Staff_dto dto = new Staff_dto();
                        dto.StaffID = item.StaffID;
                        dto.BadgeNo = item.BadgeNo;
                        dto.MemID = item.MemID;
                    }
                }
            }
            catch (Exception e)
            {

            }
            return staffResults.ToList();
        }

        public void UpdateStaff()
        {
            throw new NotImplementedException();
        }

        public void DeleteStaff()
        {
            throw new NotImplementedException();
        }


    }
}
