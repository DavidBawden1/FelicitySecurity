using FelicitySecurity.CCTV.Repository.Models;
using System.Data.SqlClient;
using Dapper;
using System;
using System.Configuration;

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
            SqlParameter emailParameter = new SqlParameter("@email", email);
            SqlParameter pinCodeParameter = new SqlParameter("@pinCode", password);

            try
            {
                var connection = this.ConnectionString;
                connection.Query<AdministratorModel>("select AdminTable.AdminID, AdminTable.AdminName, AdminTable.AdminEmail, AdminTable.AdminPinCode" +
                    " from AdminTable where AdminEmail = '@email' and AdminPinCode = 'pinCode'",
                    new { email = email, pinCode = password});
            }
            catch (Exception ex)
            {
                throw new Exception("Failure executing query.", ex);
            }
            return false;
        }
    }
}
