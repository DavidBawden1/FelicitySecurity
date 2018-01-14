using System.Collections.Generic;

namespace FelicitySecurity.Services.Data.Interfaces
{
    /// <summary>
    /// Generic repository interface for all CRUD operations. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        List<T> Find();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
