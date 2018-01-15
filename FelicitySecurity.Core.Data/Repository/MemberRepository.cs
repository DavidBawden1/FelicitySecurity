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
        /// Adds a member to the MembersTable when the registration scenario is applied. 
        /// </summary>
        public Members_dto AddMember(Members_dto item)
        {
            try
            {
                using (DbContext dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    var entity = new MemberTable()
                    {
                        MemFirstname = item.MemFirstname,
                        MemLastname = item.MemLastname,
                        MemPhonenumber = item.MemPhonenumber,
                        MemPostcode = item.MemPostcode,
                        MemStatus = item.MemStatus.Value,
                        MemDOB = item.MemDOB,
                        MemRegDate = item.MemRegDate,
                        IsStaff = item.IsStaff.Value,
                        MemFacialImage = item.MemFacialImage
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


        /// <summary>
        /// Updates the selected Member
        /// </summary>
        /// <param name="memberDto"></param>
        public void UpdateMember(Members_dto memberDto)
        {
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    var memberToUpdate = dbContext.MemberTable.SingleOrDefault(member => member.MemID == memberDto.MemID);
                    memberToUpdate.MemFirstname = memberDto.MemFirstname;
                    memberToUpdate.MemLastname = memberDto.MemLastname;
                    memberToUpdate.MemPhonenumber = memberDto.MemPhonenumber;
                    memberToUpdate.MemPostcode = memberDto.MemPostcode;
                    memberToUpdate.MemDOB = memberDto.MemDOB;
                    memberToUpdate.MemStatus = memberDto.MemStatus.Value;
                    memberToUpdate.IsStaff = memberDto.IsStaff.Value;
                    memberToUpdate.MemRegDate = memberDto.MemRegDate;
                    memberToUpdate.MemFacialImage = memberDto.MemFacialImage;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }
        }
        /// <summary>
        /// Removes a Member from the Member table for a given MemberId
        /// </summary>
        /// <param name="memberId"></param>
        public void DeleteMember(int memberId)
        {
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    MemberTable memberToDelete = dbContext.MemberTable.SingleOrDefault(member => member.MemID == memberId);
                    dbContext.MemberTable.Remove(memberToDelete);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
