﻿using FelicitySecurity.Services.Data.Repository;
using System.Collections.Generic;
using FelicitySecurity.Core.DataTransferObjects;
using System.Web.Services;
using System.ServiceModel;
using System;
using FelicitySecurity.Core.Data.DataModel;
using FelicitySecurity.Services.Helpers;

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
        Repository<StaffTable> staffBaseRepo = new Repository<StaffTable>();
        #endregion

        public FelicitySecurityDataService()
        {

        }
        #region Methods
        [OperationContract]
        [WebMethod]
        /// <summary>
        /// calls the Add Administrator businessLogic method
        /// </summary>
        /// <param name="item">Administrators_dto</param>
        public void AddAdministrator(Administrators_dto item)
        {
            AdminTable entity = EntityMapper.MapEntityFromDto(item);
            administratorBaseRepo.Add(entity);
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// calls the Find All Administrator businessLogic method
        /// </summary>
        /// <param name="item">Administrators_dto</param>
        public List<Administrators_dto> FindAllAdministrators()
        {
            return administratorRepository.FindAllAdministrators();
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// calls the Add Member businessLogic method
        /// </summary>
        /// <param name="item">Members_dto</param>
        public void AddMember(Members_dto item)
        {
            var entity = EntityMapper.MapEntityFromDto(item);
            memberBaseRepo.Add(entity);
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// calls the Find All Members businessLogic method
        /// </summary>
        /// <param name="item">Members_dto</param>
        public List<Members_dto> FindAllMembers()
        {
            return memberRepository.FindAllMembers();
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// calls the Add Staff businessLogic method
        /// </summary>
        /// <param name="item">Staff_dto</param>
        public void AddStaff(Staff_dto item)
        {
            var entity = EntityMapper.MapEntityFromDto(item);
            staffBaseRepo.Add(entity);
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// calls the Find All Staff businessLogic method
        /// </summary>
        /// <param name="item">Staff_dto</param>
        public List<Staff_dto> FindAllStaff()
        {
            return staffRepository.FindAllStaff();
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// Calls the Remove Administrator businessLogic method
        /// </summary>
        /// <param name="administratorId"></param>
        public void RemoveAdministrator(Administrators_dto item)
        {
            AdminTable entity = EntityMapper.MapEntityFromDto(item);
            administratorBaseRepo.Delete(entity);
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// Calls the Update Administrator businessLogic method
        /// </summary>
        /// <param name="item"></param>
        public void UpdateAdministrator(Administrators_dto item)
        {
            AdminTable entity = EntityMapper.MapEntityFromDto(item);
            administratorBaseRepo.Update(entity);
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// Calls the Update Member businessLogic method and passes the member to update with
        /// </summary>
        /// <param name="item"></param>
        public void UpdateMember(Members_dto item)
        {
            var entity = EntityMapper.MapEntityFromDto(item);
            memberBaseRepo.Update(entity);
        }

        [WebMethod]
        [OperationContract]
        /// <summary>
        /// Calls the Delete Member businessLogic method and passes the id to delete with
        /// </summary>
        /// <param name="memberId"></param>
        public void DeleteMember(Members_dto item)
        {
            var entity = EntityMapper.MapEntityFromDto(item);
            memberBaseRepo.Delete(entity);
        }
        #endregion
    }
}
