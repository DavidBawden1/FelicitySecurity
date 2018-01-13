namespace FelicitySecurity.CCTV.Repository.Interfaces
{
    /// <summary>
    /// Administrator Repository interface for Administration CRUD operations. 
    /// </summary>
    public interface IAdministratorRepository
    {
        bool IsAdminAuthorised(string email, string pinCode);
    }
}
