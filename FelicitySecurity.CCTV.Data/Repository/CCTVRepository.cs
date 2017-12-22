using FelicitySecurity.CCTV.Data.Models;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System;

namespace FelicitySecurity.CCTV.Data.Repository
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
                connection.Query<AdministratorModel>("select AdminID, AdminName, AdminEmail, AdminPinCode from AdminTable"
                    + "where AdminEmail = @email and AdminPinCode = @pinCode",
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
