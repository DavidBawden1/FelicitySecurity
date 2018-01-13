namespace FelicitySecurity.CCTV.Repository.Repository
{
    /// <summary>
    /// Handles the Connection string for every repository class. 
    /// </summary>
    public abstract class RepositoryBase
    {
        protected readonly string ConnectionString;
        
        /// <summary>
        /// Constructs the RepositoryBase with the supplied connection string. 
        /// </summary>
        /// <param name="connectionString">Connection string passed down from EnvironmentSettings.dev/prod.json</param>
        public RepositoryBase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    }
}
