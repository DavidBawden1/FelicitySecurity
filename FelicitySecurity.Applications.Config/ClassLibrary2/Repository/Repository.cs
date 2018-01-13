using Dapper;
using FelicitySecurity.CCTV.Repository.Interfaces;
using System.Data.SqlClient;
using System.Linq;

namespace FelicitySecurity.CCTV.Repository.Repository
{
    public class Repository<T> : EntityBase, IRepository<T> where T : EntityBase
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
            return entity;
        }

        public T Delete(T entity)
        {
            return entity;
        }
    }
}
