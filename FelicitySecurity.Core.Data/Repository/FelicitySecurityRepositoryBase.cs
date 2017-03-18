using FelicitySecurity.Core.Data.Interfaces;
using FelicitySecurity.Core.Utils;
using System;
using System.Data.Common;
using System.Data.Entity;
using FelicitySecurity.Core.DataTransferObjects;

namespace FelicitySecurity.Core.Data.Repository
{
    /// <summary>
    /// The commit mode of the Repository
    /// </summary>
    public enum RepositoryCommitMode { Auto, Manual }

    /// <summary>
    /// the base repository layer. implements IDisposable for dud connections. 
    /// </summary>
    public class FelicitySecurityRepositoryBase : IDisposable, IFelicitySecurityRepositoryBase
    {
        #region Variables
        private DbContext _dbContext;
        private DbConnection _connection;
        private string _connectionString;
        #endregion
        #region Properties
        /// <summary>
        /// fetches child objects 
        /// </summary>
        public bool FetchChildObjects { get; private set; }

        /// <summary>
        /// gets the repository commit mode: auto or manual
        /// </summary>
        public RepositoryCommitMode CommitMode { get; set; }

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
        /// empty constructor: initialises the repository base sets fetch child objects to true and the commit mode to auto
        /// </summary>

        /// <summary>
        /// Initialises the constructor: accepts a Commit mode, either auto or manual. sets fetch child objects to true 
        /// </summary>
        /// <param name="commitMode"> auto or manual</param>
        public FelicitySecurityRepositoryBase(RepositoryCommitMode commitMode)
        {
            FetchChildObjects = true;
            CommitMode = commitMode;
        }

        /// <summary>
        /// Initialises the constructor: accepts a connection. sets fetch child objects to true and mode to auto
        /// </summary>
        /// <param name="connection"></param>
        public FelicitySecurityRepositoryBase(DbConnection connection)
        {
            FetchChildObjects = true;
            CommitMode = RepositoryCommitMode.Auto;
            _connection = connection;
        }

        /// <summary>
        /// Initialises the constructor: accepts a connectionstring. sets fetch child objects to true and mode to auto
        /// </summary>
        /// <param name="connectionString"></param>
        public FelicitySecurityRepositoryBase(string connectionString)
        {
            FetchChildObjects = true;
            CommitMode = RepositoryCommitMode.Auto;
            _connectionString = connectionString;
        }

        /// <summary>
        /// Initialises the constructor: accepts a connection and commit mode. sets fetch child objects to true
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commitMode"></param>
        public FelicitySecurityRepositoryBase(DbConnection connection, RepositoryCommitMode commitMode)
        {
            FetchChildObjects = true;
            CommitMode = commitMode;
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
                throw new InvalidOperationException(string.Format("{0} needs to derive from type 'DbContext'", DbContextType.Name));
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
            }

            if(CommitMode == RepositoryCommitMode.Auto)
            {
                DbContext context = null;
                if (_connection != null)
                {
                    context = (DbContext)Activator.CreateInstance(DbContextType, new object[] { _connection });
                }
                else if (!string.IsNullOrEmpty(_connectionString))
                {
                    context = (DbContext)Activator.CreateInstance(DbContextType, new object[] { _connectionString });
                }
                else
                {
                    context = (DbContext)Activator.CreateInstance(DbContextType);
                }
                context.Database.CommandTimeout = timeout;
                return context;
            }
            else
            {
                if(_dbContext == null)
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

        /// <summary>
        /// tries to save the changes of the Entity using the given dbContext. 
        /// if successful, return true. Otherwise false. 
        /// failures need to be logged. 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public bool TrySaveChanges(DbContext dbContext)
        {
           try
            {
                if (CommitMode == RepositoryCommitMode.Auto)
                {
                    return SaveChanges(dbContext);
                }
                return false;
            }
            catch(Exception e)
            {
                Logging.LogErrorEvent(this, e);
                throw e;
            }
        }

        /// <summary>
        /// returns either true or false after trying to save the changes with the given dbContext.
        /// </summary>
        /// <returns>SaveChanges either true or false</returns>
        public bool SaveChanges()
        {
            return SaveChanges(_dbContext);
        }

        /// <summary>
        /// Given the dbContext is adequate and not null, the changes will be saved. 
        /// if there are any errors, an exception is thrown. 
        /// Changes need to be logged. 
        /// </summary>
        /// <param name="dbContext">the database context for the Felicity entities</param>
        /// <returns></returns>
        protected bool SaveChanges(DbContext dbContext)
        {
           try
            {
                if(dbContext != null)
                {
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                Logging.LogErrorEvent(this, e);
                throw e;
            }
        }

        void IFelicitySecurityRepositoryBase.FelicitySecurityRepositoryBase()
        {
            FetchChildObjects = true;
            CommitMode = RepositoryCommitMode.Auto;
        }

        void IFelicitySecurityRepositoryBase.FelicitySecurityRepositoryBase(RepositoryCommitMode commitMode)
        {
            FetchChildObjects = true;
            CommitMode = commitMode;
        }

        void IFelicitySecurityRepositoryBase.FelicitySecurityRepositoryBase(DbConnection connection)
        {
            FetchChildObjects = true;
            CommitMode = RepositoryCommitMode.Auto;
            _connection = connection;
        }

        void IFelicitySecurityRepositoryBase.FelicitySecurityRepositoryBase(string connectionString)
        {
            FetchChildObjects = true;
            CommitMode = RepositoryCommitMode.Auto;
            _connectionString = connectionString;
        }

        DbContext IFelicitySecurityRepositoryBase.GetDBContext()
        {
            if (DbContextType == null)
            {
                throw new InvalidOperationException(string.Format("DbContextType cannot be null"));
            }
            if (!DbContextType.IsSubclassOf(typeof(DbContext)))
            {
                throw new InvalidOperationException(string.Format("{0} needs to derive from type 'DbContext'", DbContextType.Name));
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
            }

            if (CommitMode == RepositoryCommitMode.Auto)
            {
                DbContext context = null;
                if (_connection != null)
                {
                    context = (DbContext)Activator.CreateInstance(DbContextType, new object[] { _connection });
                }
                else if (!string.IsNullOrEmpty(_connectionString))
                {
                    context = (DbContext)Activator.CreateInstance(DbContextType, new object[] { _connectionString });
                }
                else
                {
                    context = (DbContext)Activator.CreateInstance(DbContextType);
                }
                context.Database.CommandTimeout = timeout;
                return context;
            }
            else
            {
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

        bool IFelicitySecurityRepositoryBase.TrySaveChanges(DbContext dbContext)
        {
            try
            {
                if (CommitMode == RepositoryCommitMode.Auto)
                {
                    return SaveChanges(dbContext);
                }
                return false;
            }
            catch (Exception e)
            {
                Logging.LogErrorEvent(this, e);
                throw e;
            }
        }

        bool IFelicitySecurityRepositoryBase.SaveChanges()
        {
            return SaveChanges(_dbContext);
        }

        bool IFelicitySecurityRepositoryBase.SaveChanges(DbContext dbContext)
        {
            try
            {
                if (dbContext != null)
                {
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Logging.LogErrorEvent(this, e);
                throw e;
            }
        }
    }
}

