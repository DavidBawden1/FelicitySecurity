using FelicitySecurity.Core.Data.DataModel;
using FelicitySecurity.Core.DataTransferObjects;
using FelicitySecurity.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FelicitySecurity.Services.Data.Repository
{
    public class MemberRepository : Repository<Members_dto>, IMemberRepository
    {
        public MemberRepository(string connectionString) 
            : base(connectionString)
        {

        }

        public MemberRepository()
        {

        }

        /// <summary>
        /// returns a list of all members and their data. 
        /// </summary>
        /// <returns> a result list of all members of the system</returns>
        public List<Members_dto> FindAllMembers()
        {
            List<Members_dto> membersResult = new List<Members_dto>();
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    foreach (var item in dbContext.MemberTable)
                    {
                        Members_dto dto = new Members_dto();
                        dto.MemID = item.MemID;
                        dto.MemFirstname = item.MemFirstname;
                        dto.MemLastname = item.MemLastname;
                        dto.MemPhonenumber = item.MemPhonenumber;
                        dto.MemDOB = item.MemDOB;
                        dto.MemPostcode = item.MemPostcode;
                        dto.MemStatus = item.MemStatus;
                        dto.MemRegDate = item.MemRegDate;
                        dto.IsStaff = item.IsStaff;
                        dto.MemFacialImage = item.MemFacialImage;
                        membersResult.Add(dto);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return membersResult.ToList();
        }
    }
}
