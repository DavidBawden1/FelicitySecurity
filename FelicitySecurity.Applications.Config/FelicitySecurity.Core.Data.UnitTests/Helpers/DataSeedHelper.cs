using FelicitySecurity.Core.Data.Repository;
using FelicitySecurity.Core.DataTransferObjects;
using System;

namespace FelicitySecurity.Core.Data.UnitTests.Helpers
{
    public class DataSeedHelper
    {
        /// <summary>
        /// Creates a mock Administrator. 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="pinCode"></param>
        /// <returns></returns>
        public static Administrators_dto CreateAdministrator(FelicitySecurityRepository repository, string email, string name, string pinCode)
        {
            var dto = new Administrators_dto()
            {
                AdminEmail = email,
                AdminName = name,
                AdminPinCode = pinCode
            };
            return repository.AddAdministrator(dto);
        }

        /// <summary>
        /// Creates a mock Member. 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="pinCode"></param>
        /// <returns></returns>
        public static Members_dto CreateMember(FelicitySecurityRepository repository, string firstName, string lastName, DateTime dateOfBirth, DateTime dateOfRegistration, int responsibleAdministratorsId)
        {
            var dto = new Members_dto()
            {
                MemFirstname = firstName, 
                MemLastname = lastName, 
                MemDOB = dateOfBirth, 
                MemRegDate = dateOfRegistration, 
                MemPostcode = "TA6 3PY",
                MemPhonenumber = "07712728891",
                MemStatus = true  
            };
            return repository.AddMember(dto);
        }
    }
}
