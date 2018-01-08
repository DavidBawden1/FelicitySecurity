using FelicitySecurity.Core.Utils;
using FelicitySecurity.Services.Data.Interfaces;
using System;
using System.Data.Common;
using System.Data.Entity;

namespace FelicitySecurity.Services.Data.Repository
{
    /// <summary>
    /// The commit mode of the Repository
    /// </summary>
    public enum RepositoryCommitMode { Auto, Manual }

    /// <summary>
    /// the base repository layer. implements IDisposable for dud connections. 
    /// </summary>
    public class FelicitySecurityRepositoryBase : IDisposable
    {
        #region Variables
        private DbContext _dbContext;
        private DbConnection _connection;
        private string _connectionString;
        #endregion
        #region Properties

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
        #endregion
        #region Implementations
        /// <summary>
        /// disposes of the Database context. 
        /// </summary>
        public void Dispose()
        {
            ((IDisposable)_dbContext).Dispose();
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Initialises the constructor: accepts a connection.
        /// </summary>
        /// <param name="connection"></param>
        public FelicitySecurityRepositoryBase(DbConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Initialises the constructor: accepts a connectionstring.
        /// </summary>
        /// <param name="connectionString"></param>
        public FelicitySecurityRepositoryBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Initialises the constructor: accepts a connection and commit mode. sets fetch child objects to true
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commitMode"></param>
        public FelicitySecurityRepositoryBase(DbConnection connection, RepositoryCommitMode commitMode)
        {
            _connection = connection;
        }

        public FelicitySecurityRepositoryBase()
        {
        }
        #endregion
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
                var timeoutString = System.Configuration.ConfigurationSettings.AppSettings.Get("EntityTimeout");
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
                if (_connection != null)
                {
                    _dbContext = (DbContext)Activator.CreateInstance(DbContextType, new object[] { _connection });
                }
                else if (!string.IsNullOrEmpty(_connectionString))
                {
                    _dbContext = (DbContext)Activator.CreateInstance(DbContextType, new object[] { _connectionString });
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

