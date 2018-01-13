using FelicitySecurity.CCTV.Repository.Models;
using System.Data.SqlClient;
using Dapper;
using System;
using System.Configuration;
using System.Linq;
using FelicitySecurity.CCTV.Repository.Interfaces;

namespace FelicitySecurity.CCTV.Repository.Repository
{
    public class AdministratorRepository : Repository<AdministratorModel>, IRepository<AdministratorModel>,  IAdministratorRepository
    {
        public AdministratorRepository(string connectionString):
            base(connectionString)
        {

        }
        
        /// <summary>
        /// returns true if credentials return an administrator. 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsAdminAuthorised(string email, string password)
        {
            var authParameters = new
            {
                email = email,
                pinCode = password
            };

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var administrator = connection.Query<AdministratorModel>("select AdminTable.AdminID AS AdminId, AdminTable.AdminName AS Username, AdminTable.AdminEmail AS EmailAddress, AdminTable.AdminPinCode AS Password" +
                        " from AdminTable where AdminEmail = @email and AdminPinCode = @pinCode", authParameters);
                    return administrator.Any();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failure executing query.", ex);
            }
        }
    }
}
