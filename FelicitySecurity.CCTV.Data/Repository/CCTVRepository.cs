using FelicitySecurity.CCTV.Data.Models;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
namespace FelicitySecurity.CCTV.Data.Repository
{
    public class CCTVRepository : CCTVRepositoryBase
    {
        public CCTVRepository(Configuration configuration, SqlConnection connectionString)
            : base(configuration, connectionString)
        {

        }

        public bool IsAdminAuthorised(AdministratorModel model)
        {
            SqlParameter emailParameter = new SqlParameter("@email", model.EmailAddress);
            SqlParameter pinCodeParameter = new SqlParameter("@pinCode", model.Password);
            var connection = this.ConnectionString;
            connection.Query<AdministratorModel>("select AdminID, AdminName, AdminEmail, AdminPinCode from AdminTable" 
                + "where AdminEmail = @email and AdminPinCode = @pinCode",
                new {email = model.EmailAddress, pinCode = model.Password });

            return false;
        }
    }
}
