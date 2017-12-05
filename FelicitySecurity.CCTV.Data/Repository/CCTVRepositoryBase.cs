using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FelicitySecurity.CCTV.Data.Repository
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
                return new SqlConnection(ConfigurationManager.ConnectionStrings["FelicitySecurityEntities"].ConnectionString);
                
            }
        }
    }
}
