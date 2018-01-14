using System;
using System.Configuration;
using System.Data.Entity;

namespace FelicitySecurity.Services.Data.Repository
{
    /// <summary>
    /// Handles the Connection string for every repository class. 
    /// </summary>
    public abstract class RepositoryBase
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
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Constructs the RepositoryBase with the supplied connection string. 
        /// </summary>
        /// <param name="connectionString">Connection string passed down from EnvironmentSettings.dev/prod.json</param>
        public RepositoryBase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public RepositoryBase(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public RepositoryBase()
        {
                
        }

        protected DbContext GetDBContext()
        {
            if (DbContextType == null)
            {
                throw new InvalidOperationException(string.Format("DbContextType cannot be null"));
            }
            if (!DbContextType.IsSubclassOf(typeof(DbContext)))
            {
                throw new InvalidOperationException($"{DbContextType.Name} needs to derive from type 'DbContext'");
            }

            int timeout = 60;
            try
            {
                var timeoutString = ConfigurationManager.AppSettings.Get("EntityTimeout");
                if (!string.IsNullOrWhiteSpace(timeoutString))
                {
                    int.TryParse(timeoutString, out timeout);
                }
            }
            catch (Exception e)
            {
                //implement utility logs. 
                Console.WriteLine(e.Message);
            }

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
                _dbContext.Database.CommandTimeout = timeout;
                return _dbContext;
            }
            return _dbContext;
        }
    }
}
