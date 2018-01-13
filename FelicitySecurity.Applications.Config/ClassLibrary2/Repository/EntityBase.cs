namespace FelicitySecurity.CCTV.Repository.Repository
{
    public abstract class EntityBase
    {
        protected readonly string ConnectionString;
        public EntityBase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public int Id { get; protected set; }
    }
}
