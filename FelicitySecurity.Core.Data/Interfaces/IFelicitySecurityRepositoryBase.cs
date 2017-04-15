using FelicitySecurity.Services.Data.Repository;
using System.Data.Common;
using System.Data.Entity;

namespace FelicitySecurity.Services.Data.Interfaces
{
    public interface IFelicitySecurityRepositoryBase
    {
        void FelicitySecurityRepositoryBase();
        void FelicitySecurityRepositoryBase(RepositoryCommitMode commitMode);
        void FelicitySecurityRepositoryBase(DbConnection connection);
        void FelicitySecurityRepositoryBase(string connectionString);
        DbContext GetDBContext();
        bool TrySaveChanges(DbContext dbContext);
        bool SaveChanges();
        bool SaveChanges(DbContext dbContext);
    }
}
