namespace FelicitySecurity.CCTV.Repository.Repository
{
    public class CCTVRepositoryBase
    {
        protected readonly string ConnectionString;

        /// <summary>
        /// Constructs the CCTVRepositoryBase with the supplied connection string. 
        /// </summary>
        /// <param name="connectionString">Connection string passed down from EnvironmentSettings.dev/prod.json</param>
        public CCTVRepositoryBase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    }
}
