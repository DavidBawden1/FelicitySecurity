using FelicitySecurity.Services.Data.Interfaces;
using System.Data.SqlClient;
using System.Linq;
using System;
using System.Collections.Generic;
using FelicitySecurity.Core.Data.DataModel;
using System.Data.Entity;

namespace FelicitySecurity.Services.Data.Repository
{
    /// <summary>
    /// Generic repository for all CRUD operations. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class
    {
        private IDbSet<T> _entities;
        public IDbSet<T> Entities { get => _entities; set => _entities = value; }

        public Repository(string connectionString) :
            base(connectionString)
        {

        }

        public Repository()
        {

        }

        public void Add(T entity)
        {
            if (entity != null)
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    dbContext.Set<T>().Add(entity);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Entity was null");

            }
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    dbContext.Entry(entity).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Entity was null.");
            }
        }

        public void Delete(T entity)
        {
            if (entity != null)
            {
                using (FelicityLiveEntities dbContext = (FelicityLiveEntities)GetDBContext())
                {
                    dbContext.Set<T>().Remove(entity);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                throw new Exception($"Entity was null.");
            }
        }
    }
}
