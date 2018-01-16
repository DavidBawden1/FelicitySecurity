﻿using FelicitySecurity.Core.Data.DataModel;
using FelicitySecurity.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FelicitySecurity.Services.Data.Repository
{
    public class MemberRepository : Repository<MemberTable>, IMemberRepository
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
        public MemberTable AddMember(MemberTable item)
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
                        MemStatus = item.MemStatus,
                        MemDOB = item.MemDOB,
                        MemRegDate = item.MemRegDate,
                        IsStaff = item.IsStaff,
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
        public List<MemberTable> FindAllMembers()
        {
            List<MemberTable> membersResult = new List<MemberTable>();
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    foreach (var item in dbContext.MemberTable)
                    {
                        MemberTable dto = new MemberTable();
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
        public void UpdateMember(MemberTable memberDto)
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
                    memberToUpdate.MemStatus = memberDto.MemStatus;
                    memberToUpdate.IsStaff = memberDto.IsStaff;
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
        public void DeleteMember(MemberTable model)
        {
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    MemberTable memberToDelete = dbContext.MemberTable.SingleOrDefault(member => member.MemID == model.MemID);
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
