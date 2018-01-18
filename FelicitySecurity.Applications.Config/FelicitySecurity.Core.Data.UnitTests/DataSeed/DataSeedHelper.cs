using FelicitySecurity.Services.Data.Repository;
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
        public static AdminTable CreateAdministrator(Repository<AdminTable> repository, string email, string name, string pinCode)
        {
            var entity = new AdminTable()
            {
                AdminEmail = email,
                AdminName = name,
                AdminPinCode = pinCode
            };
            return entity;
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
            var entity = new MemberTable()
            {
                MemFirstname = firstName,
                MemLastname = lastName,
                MemDOB = dateOfBirth,
                MemRegDate = dateOfRegistration,
                MemPostcode = "TA6 3PY",
                MemPhonenumber = "07712728891",
                MemStatus = true
            };
            return entity;
        }
    }
}
