using FelicitySecurity.Core.Data.DataModel;
using System;
using System.Configuration;
using System.Data.Entity;

namespace FelicitySecurity.Core.Data.UnitTests
{
    /// <summary>
    /// Handles the Connection string for every repository class. 
    /// </summary>
    public abstract class RepositoryUnitTestBase
    {
        protected readonly string ConnectionString;
        private DbContext _dbContext;
        /// <summary>
        /// gets the DbContext Type
        /// </summary>
        protected virtual Type DbContextType
        {
            get
            {
                return typeof(FelicityLiveEntities);
            }
        }

        /// <summary>
        /// Constructs the RepositoryBase with the supplied connection string. 
        /// </summary>
        /// <param name="connectionString">Connection string passed down from EnvironmentSettings.dev/prod.json</param>
        public RepositoryUnitTestBase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public RepositoryUnitTestBase(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public RepositoryUnitTestBase()
        {
                
        }

        protected DbContext GetDBContext()
        {
            if (_dbContext == null)
            {
                if (!string.IsNullOrEmpty(ConnectionString))
                {
                    _dbContext = (DbContext)Activator.CreateInstance(DbContextType, new object[] { ConnectionString });
                }
                else
                {
                    _dbContext = (DbContext)Activator.CreateInstance(DbContextType);
                }
                return _dbContext;
            }
            return _dbContext;
        }
    }
}
