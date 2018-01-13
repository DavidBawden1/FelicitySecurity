using Dapper;
using FelicitySecurity.CCTV.Repository.Interfaces;
using System.Data.SqlClient;
using System.Linq;

namespace FelicitySecurity.CCTV.Repository.Repository
{
    /// <summary>
    /// Generic repository for all CRUD operations. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class
    {
        public Repository(string connectionString) :
            base(connectionString)
        {

        }

        public T Add(T entity)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return entity = connection.Query<T>("", entity).First();
            }
        }

        public T Update(T entity)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return entity = connection.Query<T>("", entity).First();
            }
        }

        public void Delete(T entity)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
               connection.Query<T>("", entity);
            }
        }
    }
}
