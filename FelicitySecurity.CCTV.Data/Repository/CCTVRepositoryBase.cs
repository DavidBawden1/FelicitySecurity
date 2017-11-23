using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelicitySecurity.CCTV.Data.Repository
{
    public class CCTVRepositoryBase
    {
        public CCTVRepositoryBase(Configuration configuration, string connectionString)
        {
            connectionString = ConnectionString;
        }

        protected string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["FelicitySecurityEntities"].ConnectionString;
            }
        }
    }
}
