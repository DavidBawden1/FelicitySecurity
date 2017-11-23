using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelicitySecurity.CCTV.Data.Repository
{
    public class CCTVRepository : CCTVRepositoryBase
    {
        public CCTVRepository(Configuration configuration, string connectionString)
            : base(configuration, connectionString)
        {

        }
    }
}
