using System.Collections.Generic;
using FelicitySecurity.Core.FelicitySecurityDataServiceReference;
using System.Linq;

namespace FelicitySecurity.Core.BusinessLogic
{
    /// <summary>
    /// Applies business logic before calling on any Repository data methods. 
    /// </summary>
    public class FelicitySecurityBusinessLogic
    {
        #region Declarations
        FelicitySecurityDataServiceSoapClient client = new FelicitySecurityDataServiceSoapClient("BasicHttpBinding_IFelicityDataService");
        #endregion

        #region Constructors
        #endregion
        #region Methods
        /// <summary>
        /// calls the Add Administrator Repository method
        /// </summary>
        /// <param name="item">Administrators_dto</param>
        public void AddAdministrator(Administrators_dto item)
        {
            client.AddAdministrator(item);
        }

        /// <summary>
        /// calls the Find All Administrator Repository method
        /// </summary>
        /// <param name="item">Administrators_dto</param>
        public List<Administrators_dto> FindAllAdministrators()
        {
            return client.FindAllAdministrators().ToList();
        }

        /// <summary>
        /// calls the Add Member Repository method
        /// </summary>
        /// <param name="item">Members_dto</param>
        public void AddMember(Members_dto item)
        {
            client.AddMember(item);
        }

        /// <summary>
        /// calls the Find All Members Repository method
        /// </summary>
        /// <param name="item">Members_dto</param>
        public List<Members_dto> FindAllMembers()
        {
            return client.FindAllMembers().ToList();
        }

        /// <summary>
        /// calls the Add Staff Repository method
        /// </summary>
        /// <param name="item">Staff_dto</param>
        public void AddStaff(Staff_dto item)
        {
            client.AddStaff(item);
        }

        /// <summary>
        /// calls the Find All Staff Repository method
        /// </summary>
        /// <param name="item">Staff_dto</param>
        public List<Staff_dto> FindAllStaff(Staff_dto item)
        {
            return client.FindAllStaff().ToList();
        }

        /// <summary>
        /// Calls the Remove Administrator Repository method
        /// </summary>
        /// <param name="administratorId"></param>
        public void RemoveAdministrator(int administratorId)
        {
            client.RemoveAdministrator(administratorId);
        }

        /// <summary>
        /// Calls the Update Administrator Repository method
        /// </summary>
        /// <param name="item"></param>
        public void UpdateAdministrator(Administrators_dto item)
        {
            client.UpdateAdministrator(item);
        }
        #endregion
    }
}
