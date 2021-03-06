﻿using FelicitySecurity.Core.Data.Repository;
using FelicitySecurity.Core.DataTransferObjects;
using FelicitySecurity.Services.Interfaces;
using System.Collections.Generic;

namespace FelicitySecurity.Data.Services
{
    /// <summary>
    /// Web Service for all data going to and from the Configuration application and Database. 
    /// </summary>
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
        /// <summary>
        /// calls the Add Administrator Repository method
        /// </summary>
        /// <param name="item">Administrators_dto</param>
        public void AddAdministrator(Administrators_dto item)
        {
            repository.AddAdministrator(item); 
        }

        /// <summary>
        /// calls the Find All Administrator Repository method
        /// </summary>
        /// <param name="item">Administrators_dto</param>
        public List<Administrators_dto> FindAllAdministrators()
        {
            return repository.FindAllAdministrators();
        }

        /// <summary>
        /// calls the Add Member Repository method
        /// </summary>
        /// <param name="item">Members_dto</param>
        public void AddMember(Members_dto item)
        {
            repository.AddMember(item);
        }

        /// <summary>
        /// calls the Find All Members Repository method
        /// </summary>
        /// <param name="item">Members_dto</param>
        public List<Members_dto> FindAllMembers()
        {
            return repository.FindAllMembers();
        }

        /// <summary>
        /// calls the Add Faces Repository method
        /// </summary>
        /// <param name="item">Faces_dto</param>
        public void AddFaces(Faces_dto item)
        {
            repository.AddFaces(item);
        }

        /// <summary>
        /// calls the Find All Faces Repository method
        /// </summary>
        /// <param name="item">Faces_dto</param>
        public List<Faces_dto> FindAllMembersFaces()
        {
            return repository.FindAllMembersFaces();
        }

        /// <summary>
        /// calls the Add Staff Repository method
        /// </summary>
        /// <param name="item">Staff_dto</param>
        public void AddStaff(Staff_dto item)
        {
            repository.AddStaff(item);
        }

        /// <summary>
        /// calls the Find All Staff Repository method
        /// </summary>
        /// <param name="item">Staff_dto</param>
        public List<Staff_dto> FindALLStaff(Staff_dto item)
        {
            return repository.FindALLStaff();
        }

       /// <summary>
       /// Calls the Remove Administrator Repository method
       /// </summary>
       /// <param name="administratorId"></param>
        public void RemoveAdministrator(int administratorId)
        {
            repository.RemoveAdministrator(administratorId);
        }

        /// <summary>
        /// Calls the Update Administrator Repository method
        /// </summary>
        /// <param name="item"></param>
        public void UpdateAdministrator(Administrators_dto item)
        {
            repository.UpdateAdministrator(item);
        }
        #endregion
    }
}
