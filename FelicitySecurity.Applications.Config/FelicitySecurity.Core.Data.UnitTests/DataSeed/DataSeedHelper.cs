using FelicitySecurity.Services.Data.Repository;
using FelicitySecurity.Core.DataTransferObjects;
using System;
using FelicitySecurity.Core.Data.DataModel;

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
        public static AdminTable CreateAdministrator(Repository<AdminTable> repository, int id, string email, string name, string pinCode)
        {
            var dto = new AdminTable()
            {
                AdminID = id,
                AdminEmail = email,
                AdminName = name,
                AdminPinCode = pinCode
            };
            return dto;
        }

        /// <summary>
        /// Creates a mock Member. 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="pinCode"></param>
        /// <returns></returns>
        public static MemberTable CreateMember(Repository<MemberTable> repository, string firstName, string lastName, DateTime dateOfBirth, DateTime dateOfRegistration, int responsibleAdministratorsId)
        {
            var dto = new MemberTable()
            {
                MemFirstname = firstName,
                MemLastname = lastName,
                MemDOB = dateOfBirth,
                MemRegDate = dateOfRegistration,
                MemPostcode = "TA6 3PY",
                MemPhonenumber = "07712728891",
                MemStatus = true
            };
            return dto;
        }
    }
}
