using FelicitySecurity.Core.Data.DataModel;
using FelicitySecurity.Core.DataTransferObjects;
using FelicitySecurity.Core.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using FelicitySecurity.Services.Data.Interfaces;

namespace FelicitySecurity.Services.Data.Repository
{
    /// <summary>
    /// The Engine repository, responsible for handling database transactions for 
    /// administrators, members, facial image datasets and staff. 
    /// </summary>
    public class FelicitySecurityRepository : FelicitySecurityRepositoryBase, IFelicitySecurityRepository
    {
        #region Constructors
        /// <summary>
        /// initiates the Engine repository, responsible for handling database transactions for 
        /// administrators, members, facial image datasets and staff. 
        /// </summary>
        public FelicitySecurityRepository() : base()
        {

        }

        public FelicitySecurityRepository(FelicityLiveEntities context)
        {
            _context = context;
        }
        /// <summary>
        /// initiates the Engine repository, responsible for handling database transactions for 
        /// administrators, members, facial image datasets and staff. Passes a database connection to the base repository layer 
        /// </summary>
        public FelicitySecurityRepository(DbConnection connection) : base(connection)
        {

        }

        #endregion

        #region Properties 
        /// <summary>
        /// gets the dbContext of type FelicityLiveEntities
        /// </summary>
        protected override Type DbContextType
        {
            get
            {
                return typeof(FelicityLiveEntities);
            }
        }

        private FelicityLiveEntities _context;
        #endregion

        #region Methods
        /// <summary>
        /// returns all of the administrators within the administrators table. 
        /// </summary>
        /// <returns>a result list of all administrators in the system</returns>
        public List<Administrators_dto> FindAllAdministrators()
        {
            List<Administrators_dto> administratorsResult = new List<Administrators_dto>();
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    foreach (var item in dbContext.AdminTable)
                    {
                        Administrators_dto dto = new Administrators_dto();
                        dto.AdminID = item.AdminID;
                        dto.AdminEmail = item.AdminEmail;
                        dto.AdminName = item.AdminName;
                        dto.AdminPinCode = item.AdminPinCode;
                        administratorsResult.Add(dto);
                    }
                }
            }
            catch (Exception e)
            {
                Logging.LogErrorEvent(this, e);
            }
            return administratorsResult.ToList();
        }

        /// <summary>
        /// Adds an administer to the AdminTable when the registration scenario is applied. 
        /// </summary>
        public Administrators_dto AddAdministrator(Administrators_dto item)
        {
            try
            {
                using (DbContext dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    var entity = new AdminTable()
                    {
                        AdminEmail = item.AdminEmail,
                        AdminName = item.AdminName,
                        AdminPinCode = item.AdminPinCode
                    };
                    dbContext.Entry(entity).State = EntityState.Added;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Logging.LogErrorEvent(this, e);
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
                Logging.LogErrorEvent(this, e);
            }
            return membersResult.ToList();
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
                Logging.LogErrorEvent(this, e);
            }
            return item;
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
                Logging.LogErrorEvent(this, e);
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
                Logging.LogErrorEvent(this, e);
            }
            return staffResults.ToList();
        }

        /// <summary>
        /// Takes a specified administratorId and then removes the administrator associated with it.
        /// </summary>
        /// <param name="administratorId">The administrator to remove</param>
        public void DeleteAdministrator(int administratorId)
        {
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    AdminTable administratorToRemove = dbContext.AdminTable.SingleOrDefault(admin => admin.AdminID == administratorId);
                    dbContext.AdminTable.Remove(administratorToRemove);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Logging.LogErrorEvent(this, e);
            }
        }

        /// <summary>
        /// Updates the selected Administrator
        /// </summary>
        /// <param name="adminDto"></param>
        public void UpdateAdministrator(Administrators_dto adminDto)
        {
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    var administratorToUpdate = dbContext.AdminTable.SingleOrDefault(administrator => administrator.AdminID == adminDto.AdminID);
                    administratorToUpdate.AdminEmail = adminDto.AdminEmail;
                    administratorToUpdate.AdminName = adminDto.AdminName;
                    administratorToUpdate.AdminPinCode = adminDto.AdminPinCode;
                    dbContext.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Logging.LogErrorEvent(this, e);
            }
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
            }catch(Exception e)
            {
                Logging.LogErrorEvent(this, e);
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
            catch(Exception e)
            {
                Logging.LogErrorEvent(this, e);
            }
        }
    }
}
#endregion


