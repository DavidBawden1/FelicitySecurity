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
    }
}
