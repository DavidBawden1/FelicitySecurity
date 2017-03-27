using FelicitySecurity.Core.Data.Repository;
using FelicitySecurity.Core.DataTransferObjects;
using FelicitySecurity.Services.Interfaces;
using System.Collections.Generic;

namespace FelicitySecurity.Data.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FelicitySecurityDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FelicitySecurityDataService.svc or FelicitySecurityDataService.svc.cs at the Solution Explorer and start debugging.
    public class FelicitySecurityDataService : IFelicitySecurityDataService
    {
        #region Declarations
        FelicitySecurityRepository repository = new FelicitySecurityRepository();
        #endregion

        #region Properties 
        #endregion

        #region Constructors
        #endregion

        #region Methods
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

       
        public void AddAdministrator(Administrators_dto item)
        {
            repository.AddAdministrator(item); 
        } 
        public List<Administrators_dto> FindAllAdministrators()
        {
            return repository.FindAllAdministrators();
        }
        public void AddMember(Members_dto item)
        {
            repository.AddMember(item);
        }
        public List<Members_dto> FindAllMembers()
        {
            return repository.FindAllMembers();
        }
        public void AddFaces(Faces_dto item)
        {
            repository.AddFaces(item);
        }
        public List<Faces_dto> FindAllMembersFaces()
        {
            return repository.FindAllMembersFaces();
        }
        public void AddStaff(Staff_dto item)
        {
            repository.AddStaff(item);
        }
        public List<Staff_dto> FindALLStaff(Staff_dto item)
        {
            return repository.FindALLStaff();
        }
        public void RemoveAdministrator(int administratorId)
        {
            repository.RemoveAdministrator(administratorId);
        }
        public void UpdateAdministrator(Administrators_dto item)
        {
            repository.UpdateAdministrator(item);
        }
        #endregion
    }
}
