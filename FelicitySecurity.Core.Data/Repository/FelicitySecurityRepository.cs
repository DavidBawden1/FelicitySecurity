using FelicitySecurity.Core.Data.DataModel;
using FelicitySecurity.Core.Data.Interfaces;
using FelicitySecurity.Core.DataTransferObjects;
using FelicitySecurity.Core.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace FelicitySecurity.Core.Data.Repository
{
    /// <summary>
    /// The Engine repository, responsible for handling database transactions for 
    /// administrators, members, facial image datasets and staff. 
    /// </summary>
    public class FelicitySecurityRepository : FelicitySecurityRepositoryBase, IFelicitySecurityRepository, IFelicitySecurityRepositoryBase
    {
        #region Constructors
        /// <summary>
        /// initiates the Engine repository, responsible for handling database transactions for 
        /// administrators, members, facial image datasets and staff. 
        /// </summary>
        public FelicitySecurityRepository() : base()
        {

        }
        /// <summary>
        /// initiates the Engine repository, responsible for handling database transactions for 
        /// administrators, members, facial image datasets and staff. Passes a database connection to the base repository layer 
        /// </summary>
        public FelicitySecurityRepository(DbConnection connection) : base(connection)
        {

        }

        /// <summary>
        /// initiates the Engine repository, responsible for handling database transactions for 
        /// administrators, members, facial image datasets and staff. Passes a database commitMode to the base repository layer 
        /// </summary>
        public FelicitySecurityRepository(RepositoryCommitMode commitMode)
            : base(commitMode)
        {

        }

        /// <summary>
        /// initiates the Engine repository, responsible for handling database transactions for 
        /// administrators, members, facial image datasets and staff. Passes a database connection and commitMode to the base repository layer 
        /// </summary>
        public FelicitySecurityRepository(DbConnection connection, RepositoryCommitMode commitMode)
            : base(connection, commitMode)
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
                Logging.LogErrorEvent(null, e);
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
                Logging.LogErrorEvent(null, e);
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
                        dto.MemRegDate = item.MemRegDate;
                        dto.MemStatus = item.MemStatus;
                        dto.IsStaff = item.IsStaff;
                        dto.AdminID = item.AdminID;
                    }
                }
            }
            catch (Exception e)
            {
                Logging.LogErrorEvent(null, e);
            }
            return membersResult.ToList();
        }

        /// <summary>
        /// Adds a member and the id of the administrator whom added them to the MembersTable when the registration scenario is applied. 
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
                        MemStatus = item.MemStatus,
                        MemDOB = item.MemDOB,
                        MemRegDate = item.MemRegDate,
                        AdminID = item.AdminID
                    };
                    dbContext.Entry(entity).State = EntityState.Added;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Logging.LogErrorEvent(null, e);
            }
            return item;
        }



        /// <summary>
        /// returns all of the members faces 
        /// </summary>
        /// <returns>a result list of faces that can be used for a dataset to run recognition on.</returns>
        public List<Faces_dto> FindALLMembersFaces()
        {
            List<Faces_dto> facesResult = new List<Faces_dto>();
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    foreach (var item in dbContext.FacesTable)
                    {
                        Faces_dto dto = new Faces_dto();
                        dto.FaceID = item.FaceID;
                        dto.MemFace0 = item.MemFace0;
                        dto.MemFace1 = item.MemFace1;
                        dto.MemFace2 = item.MemFace2;
                        dto.MemFace3 = item.MemFace3;
                        dto.MemFace4 = item.MemFace4;
                        dto.MemFace5 = item.MemFace5;
                        dto.MemFace6 = item.MemFace6;
                        dto.MemFace7 = item.MemFace7;
                        dto.MemFace8 = item.MemFace8;
                        dto.MemFace9 = item.MemFace9;
                        dto.MemFace10 = item.MemFace10;
                        dto.MemFace11 = item.MemFace11;
                        dto.MemFace12 = item.MemFace12;
                        dto.MemFace13 = item.MemFace13;
                        dto.MemFace14 = item.MemFace14;
                        dto.MemFace15 = item.MemFace15;
                        dto.MemFace16 = item.MemFace16;
                        dto.MemFace17 = item.MemFace17;
                        dto.MemFace18 = item.MemFace18;
                        dto.MemFace19 = item.MemFace19;
                        dto.MemFace20 = item.MemFace20;
                        dto.MemID = item.MemID;
                    }
                }
            }
            catch (Exception e)
            {
                Logging.LogErrorEvent(null, e);
            }
            return facesResult.ToList();
        }

        /// <summary>
        /// Adds a membersface to the FacesTable when the registration scenario is applied. 
        /// </summary>
        public Faces_dto AddFaces(Faces_dto item)
        {
            try
            {
                using (DbContext dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    var entity = new FacesTable()
                    {
                        MemFace0 = item.MemFace0,
                        MemFace1 = item.MemFace1,
                        MemFace2 = item.MemFace2,
                        MemFace3 = item.MemFace3,
                        MemFace4 = item.MemFace4,
                        MemFace5 = item.MemFace5,
                        MemFace6 = item.MemFace6,
                        MemFace7 = item.MemFace7,
                        MemFace8 = item.MemFace8,
                        MemFace9 = item.MemFace9,
                        MemFace10 = item.MemFace10,
                        MemFace11 = item.MemFace11,
                        MemFace12 = item.MemFace12,
                        MemFace13 = item.MemFace13,
                        MemFace14 = item.MemFace14,
                        MemFace15 = item.MemFace15,
                        MemFace16 = item.MemFace16,
                        MemFace17 = item.MemFace17,
                        MemFace18 = item.MemFace18,
                        MemFace19 = item.MemFace19,
                        MemFace20 = item.MemFace20,
                        MemID = item.MemID
                    };
                    dbContext.Entry(entity).State = EntityState.Added;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Logging.LogErrorEvent(null, e);
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
                        BadgeNo = item.BadgeNo,
                        MemID = item.MemID
                    };
                    dbContext.Entry(entity).State = EntityState.Added;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Logging.LogErrorEvent(null, e);
            }
            return item;
        }

        /// <summary>
        /// returns a list of all staff and their data. 
        /// </summary>
        /// <returns>a result list of all staff members within the system</returns>
        public List<Staff_dto> FindALLStaff()
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
                Logging.LogErrorEvent(null, e);
            }
            return staffResults.ToList();
        }

        /// <summary>
        /// Takes a specified administratorId and then removes the administrator associated with it.
        /// </summary>
        /// <param name="administratorId">The administrator to remove</param>
        public new void RemoveAdministrator(int administratorId)
        {
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    AdminTable administratorToRemove = new AdminTable() { AdminID = administratorId };
                    dbContext.AdminTable.Attach(administratorToRemove);
                    dbContext.AdminTable.Remove(administratorToRemove);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Logging.LogErrorEvent(null, e);
            }
        }

        /// <summary>
        /// Updates the selected Administrator
        /// </summary>
        /// <param name="admin_dto"></param>
        public void UpdateAdministrator(Administrators_dto admin_dto)
        {
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    var administratorToUpdate = dbContext.AdminTable.SingleOrDefault(i => i.AdminID == admin_dto.AdminID);
                    administratorToUpdate.AdminEmail = admin_dto.AdminEmail;
                    administratorToUpdate.AdminName = admin_dto.AdminName;
                    administratorToUpdate.AdminPinCode = admin_dto.AdminPinCode;
                    dbContext.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Logging.LogErrorEvent(null, e);
            }
        }
    }
}
#endregion


