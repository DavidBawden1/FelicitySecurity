using FelicitySecurity.Core.BusinessLogic;
using FelicitySecurity.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace FelicitySecurity.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FelicitySecurityDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FelicitySecurityDataService.svc or FelicitySecurityDataService.svc.cs at the Solution Explorer and start debugging.
    public class FelicitySecurityDataService : IFelicitySecurityDataService
    {
        #region Declarations
        FelicitySecurityBusinessLogic businessLogic = new FelicitySecurityBusinessLogic();
        #endregion

        #region Properties 
        #endregion

        #region Constructors
        #endregion

        #region Methods
        public void DoWork()
        {

        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        [WebMethod]
        /// <summary>
        /// calls the Add Administrator businessLogic method
        /// </summary>
        /// <param name="item">Administrators_dto</param>
        public void AddAdministrator(Administrators_dto item)
        {
            businessLogic.AddAdministrator(item);
        }

        [WebMethod]
        /// <summary>
        /// calls the Find All Administrator businessLogic method
        /// </summary>
        /// <param name="item">Administrators_dto</param>
        public List<Administrators_dto> FindAllAdministrators()
        {
            return businessLogic.FindAllAdministrators();
        }

        [WebMethod]
        /// <summary>
        /// calls the Add Member businessLogic method
        /// </summary>
        /// <param name="item">Members_dto</param>
        public void AddMember(Members_dto item)
        {
            businessLogic.AddMember(item);
        }

        [WebMethod]
        /// <summary>
        /// calls the Find All Members businessLogic method
        /// </summary>
        /// <param name="item">Members_dto</param>
        public List<Members_dto> FindAllMembers()
        {
            return businessLogic.FindAllMembers();
        }

        [WebMethod]
        /// <summary>
        /// calls the Add Faces businessLogic method
        /// </summary>
        /// <param name="item">Faces_dto</param>
        public void AddFaces(Faces_dto item)
        {
            businessLogic.AddFaces(item);
        }

        [WebMethod]
        /// <summary>
        /// calls the Find All Faces businessLogic method
        /// </summary>
        /// <param name="item">Faces_dto</param>
        public List<Faces_dto> FindAllMembersFaces()
        {
            return businessLogic.FindAllMembersFaces();
        }

        [WebMethod]
        /// <summary>
        /// calls the Add Staff businessLogic method
        /// </summary>
        /// <param name="item">Staff_dto</param>
        public void AddStaff(Staff_dto item)
        {
            businessLogic.AddStaff(item);
        }

        [WebMethod]
        /// <summary>
        /// calls the Find All Staff businessLogic method
        /// </summary>
        /// <param name="item">Staff_dto</param>
        public List<Staff_dto> FindALLStaff(Staff_dto item)
        {
            return businessLogic.FindAllStaff(item);
        }

        [WebMethod]
        /// <summary>
        /// Calls the Remove Administrator businessLogic method
        /// </summary>
        /// <param name="administratorId"></param>
        public void RemoveAdministrator(int administratorId)
        {
            businessLogic.RemoveAdministrator(administratorId);
        }

        [WebMethod]
        /// <summary>
        /// Calls the Update Administrator businessLogic method
        /// </summary>
        /// <param name="item"></param>
        public void UpdateAdministrator(Administrators_dto item)
        {
            businessLogic.UpdateAdministrator(item);
        }
        #endregion
    }
}
