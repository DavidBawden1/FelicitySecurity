using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FelicitySecurity.CCTV.Data
{
    public class CCTVRepositoryBase
    {
        private DbConnection _connectionString;
        private Configuration configuration;
        public CCTVRepositoryBase(Configuration configuration, DbConnection connectionString)
        {
            connectionString = _connectionString;
        }
    }
}
