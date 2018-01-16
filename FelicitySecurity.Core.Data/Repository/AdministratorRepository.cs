using FelicitySecurity.Core.Data.DataModel;
using FelicitySecurity.Core.DataTransferObjects;
using FelicitySecurity.Core.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FelicitySecurity.Services.Data.Interfaces;

namespace FelicitySecurity.Services.Data.Repository
{
    /// <summary>
    /// The Engine repository, responsible for handling database transactions for 
    /// administrators, members, facial image datasets and staff. 
    /// </summary>
    public class AdministratorRepository : Repository<AdminTable>,  IAdministratorRepository
    {
        public AdministratorRepository(string connectionString):
            base(connectionString)
        {

        }

        public AdministratorRepository()
        {

        }

        /// <summary>
        /// returns all of the administrators within the administrators table. 
        /// </summary>
        /// <returns>a result list of all administrators in the system</returns>
        public List<AdminTable> FindAllAdministrators()
        {
            List<AdminTable> administratorsResult = new List<AdminTable>();
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    foreach (var item in dbContext.AdminTable)
                    {
                        AdminTable dto = new AdminTable();
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
        public AdminTable AddAdministrator(AdminTable item)
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
        /// Updates the selected Administrator
        /// </summary>
        /// <param name="adminDto"></param>
        public void UpdateAdministrator(AdminTable adminDto)
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
        /// Takes a specified administratorId and then removes the administrator associated with it.
        /// </summary>
        /// <param name="administratorId">The administrator to remove</param>
        public void DeleteAdministrator(AdminTable adminDto)
        {
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    AdminTable administratorToRemove = dbContext.AdminTable.SingleOrDefault(admin => admin.AdminID == adminDto.AdminID);
                    dbContext.AdminTable.Remove(administratorToRemove);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Logging.LogErrorEvent(this, e);
            }
        }
    }
}



