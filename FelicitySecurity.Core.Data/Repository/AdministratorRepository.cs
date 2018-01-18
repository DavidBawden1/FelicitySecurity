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
    public class AdministratorRepository : Repository<Administrators_dto>,  IAdministratorRepository
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
    }
}



