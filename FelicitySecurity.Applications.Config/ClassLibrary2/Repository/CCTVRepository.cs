using FelicitySecurity.CCTV.Repository.Models;
using System.Data.SqlClient;
using Dapper;
using System;
using System.Configuration;
using System.Linq;

namespace FelicitySecurity.CCTV.Repository.Repository
{
    public class CCTVRepository : CCTVRepositoryBase
    {
        public CCTVRepository(Configuration configuration, SqlConnection connectionString)
            : base(configuration, connectionString)
        {

        }

        public CCTVRepository()
          : base()
        {

        }
        public bool IsAdminAuthorised(string email, string password)
        {
            var authParameters = new
            {
                email = email,
                pinCode = password
            };

            try
            {
                using (var connection = this.ConnectionString)
                {   
                    var administrator = connection.Query<AdministratorModel>("select AdminTable.AdminID AS AdminId, AdminTable.AdminName AS Username, AdminTable.AdminEmail AS EmailAddress, AdminTable.AdminPinCode AS Password" +
                        " from AdminTable where AdminEmail = '@email' and AdminPinCode = '@pinCode'", authParameters);
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
