using FelicitySecurity.Services.Data.Interfaces;
using System.Data.SqlClient;
using System.Linq;
using System;
using System.Collections.Generic;
using FelicitySecurity.Core.Data.DataModel;

namespace FelicitySecurity.Services.Data.Repository
{
    /// <summary>
    /// Generic repository for all CRUD operations. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository<T> : RepositoryBase, IRepository<T> where T : class
    {
        public Repository(string connectionString) :
            base(connectionString)
        {

        }

        public Repository()
        {

        }

        /// <summary>
        /// gets the dbContext of type FelicityLiveEntities
        /// </summary>
        protected override Type DbContextType
        {
            get
            {
                return typeof(FelicityLiveEntities);
            }
        }

        public List<T> Find()
        {
            try
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    return Find();
                }
            }
            catch (Exception e)
            {

            }
            return new List<T>();
        }

        public T Add(T entity)
        {
            return Add(entity);
        }

        public void Update(T entity)
        {
            Update(entity);
        }

        public void Delete(T entity)
        {
            Delete(entity);
        }
    }
}
