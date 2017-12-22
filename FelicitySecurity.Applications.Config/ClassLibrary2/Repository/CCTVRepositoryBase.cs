using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FelicitySecurity.CCTV.Repository.Repository
{
    public class CCTVRepositoryBase
    {
        public CCTVRepositoryBase(Configuration configuration, IDbConnection connectionString)
        {
            connectionString = ConnectionString;
        }

        public CCTVRepositoryBase()
        {

        }

        protected IDbConnection ConnectionString
        {
            get
            {
                return new SqlConnection(@"Data Source=DESKTOP-T69TDHC\MSSQLSERVER1;Initial Catalog=FelicityLive;Integrated Security=True;");
            }
        }
    }
}
