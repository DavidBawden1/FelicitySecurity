using FelicitySecurity.Core.BusinessLogic;
using FelicitySecurity.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;

namespace FelicitySecurity.Services
{
    /// <summary>
    /// Summary description for FelicitySecurityDataService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FelicitySecurityDataService : System.Web.Services.WebService
    {
        FelicitySecurityBusinessLogic businessLogic = new FelicitySecurityBusinessLogic();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
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

    }
}
