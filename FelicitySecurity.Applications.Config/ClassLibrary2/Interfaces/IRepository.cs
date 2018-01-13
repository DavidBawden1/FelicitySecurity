namespace FelicitySecurity.CCTV.Repository.Interfaces
{
    /// <summary>
    /// Generic repository interface for all CRUD operations. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
