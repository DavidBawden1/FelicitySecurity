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
            var connection = this.ConnectionString;
            return false;
        }
    }
}
