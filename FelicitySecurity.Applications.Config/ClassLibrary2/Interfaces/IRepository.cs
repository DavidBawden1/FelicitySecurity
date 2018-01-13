using FelicitySecurity.CCTV.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FelicitySecurity.CCTV.Repository.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        T Delete(T entity);
        T Update(T entity);
        T Add(T entity);
    }
}
