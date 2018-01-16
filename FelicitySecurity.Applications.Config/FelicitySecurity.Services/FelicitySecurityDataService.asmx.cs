using FelicitySecurity.Services.Data.Repository;
using System.Collections.Generic;
using System.Web.Services;
using System.ServiceModel;
using System;
using FelicitySecurity.Core.Data.DataModel;

namespace FelicitySecurity.Services
{
    /// <summary>
    /// Handles all data operations between the configuration Client and the Server. 
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class FelicitySecurityDataService : WebService, IFelicitySecurityDataService
    {
        #region Decalarations
        AdministratorRepository administratorRepository = new AdministratorRepository();
        MemberRepository memberRepository = new MemberRepository();
        StaffRepository staffRepository = new StaffRepository();
        Repository<AdminTable> administratorBaseRepo = new Repository<AdminTable>();
        Repository<MemberTable> memberBaseRepo = new Repository<MemberTable>();
        #endregion

        #region Methods
        [OperationContract]
        [WebMethod]
        /// <summary>
        /// calls the Add Administrator businessLogic method
        /// </summary>
        /// <param name="item">AdminTable</param>
        public void AddAdministrator(AdminTable item)
        {
            administratorBaseRepo.Add(item);
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// calls the Find All Administrator businessLogic method
        /// </summary>
        /// <param name="item">AdminTable</param>
        public List<AdminTable> FindAllAdministrators()
        {
            return administratorRepository.FindAllAdministrators();
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// calls the Add Member businessLogic method
        /// </summary>
        /// <param name="item">MemberTable</param>
        public void AddMember(MemberTable item)
        {
            memberBaseRepo.Add(item);
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// calls the Find All Members businessLogic method
        /// </summary>
        /// <param name="item">MemberTable</param>
        public List<MemberTable> FindAllMembers()
        {
            return memberRepository.FindAllMembers();
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// calls the Add Staff businessLogic method
        /// </summary>
        /// <param name="item">StaffTable</param>
        public void AddStaff(StaffTable item)
        {
            staffRepository.AddStaff(item);
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// calls the Find All Staff businessLogic method
        /// </summary>
        /// <param name="item">StaffTable</param>
        public List<StaffTable> FindAllStaff()
        {
            return staffRepository.FindAllStaff();
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// Calls the Remove Administrator businessLogic method
        /// </summary>
        /// <param name="administratorId"></param>
        public void RemoveAdministrator(AdminTable item)
        {
            administratorBaseRepo.Delete(item);
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// Calls the Update Administrator businessLogic method
        /// </summary>
        /// <param name="item"></param>
        public void UpdateAdministrator(AdminTable item)
        {
            administratorBaseRepo.Update(item);
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// Calls the Update Member businessLogic method and passes the member to update with
        /// </summary>
        /// <param name="item"></param>
        public void UpdateMember(MemberTable item)
        {
            memberBaseRepo.Update(item);
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// Calls the Delete Member businessLogic method and passes the id to delete with
        /// </summary>
        /// <param name="memberId"></param>
        public void DeleteMember(MemberTable item)
        {
            memberBaseRepo.Delete(item);
        }
        #endregion
    }
}
