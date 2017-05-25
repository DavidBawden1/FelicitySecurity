using Microsoft.VisualStudio.TestTools.UnitTesting;
using FelicitySecurity.Services.Data.Repository;
using FelicitySecurity.Core.DataTransferObjects;
using FelicitySecurity.Core.Data.UnitTests.Helpers;
using System.Linq;

namespace FelicitySecurity.Core.Data.UnitTests
{
    [TestClass]
    public class FelicitySecurityEngineRepository_AddAdministratorUnitTests : FelicitySecurityUnitTestingRepository
    {
        /// <summary>
        /// Tests that an Administrator can be added to the database
        /// </summary>
        [TestMethod]
        public void TestAddAdministrators()
        {
            FelicitySecurityUnitTestingRepository repository = new FelicitySecurityUnitTestingRepository();
            repository.ClearFelicityTestDatabase();
            Administrators_dto administrator = new Administrators_dto();
            administrator = (DataSeedHelper.CreateAdministrator(repository, 1, "dbawden@outlook.com", "David", "1234"));
            repository.AddAdministrator(administrator);
            var administrators = repository.FindAllAdministrators();
            Administrators_dto admin = new Administrators_dto();
            foreach(var item in administrators)
            {
                admin.AdminID = item.AdminID;
                admin.AdminEmail = item.AdminEmail;
                admin.AdminName = item.AdminName;
                admin.AdminPinCode = item.AdminPinCode;
            }

            Assert.AreEqual(1, administrators.Count);
            Assert.AreEqual("dbawden@outlook.com", admin.AdminEmail);
            Assert.AreEqual("David", admin.AdminName);
            Assert.AreEqual("1234", admin.AdminPinCode);
        }

        /// <summary>
        /// Tests that an Administrator can be updated
        /// </summary>
        [TestMethod]
        public void TestUpdateAdministrator()
        {
            FelicitySecurityUnitTestingRepository repository = PrepareDatabase();
            Administrators_dto administrator = new Administrators_dto();
            administrator = (DataSeedHelper.CreateAdministrator(repository, 1, "dbawden@outlook.com", "David", "1234"));
            repository.AddAdministrator(administrator);
            int adminId = repository.FindAllAdministrators().Select(iD => iD.AdminID).First();
            administrator = (DataSeedHelper.CreateAdministrator(repository, adminId, "dbawden@outlook.com", "Paul", "5565"));
            repository.UpdateAdministrator(administrator);
            var administrators = repository.FindAllAdministrators();
            Administrators_dto admin = new Administrators_dto();
            foreach (var item in administrators)
            {
                admin.AdminID = item.AdminID;
                admin.AdminEmail = item.AdminEmail;
                admin.AdminName = item.AdminName;
                admin.AdminPinCode = item.AdminPinCode;
            }

            Assert.AreEqual(1, administrators.Count);
            Assert.AreEqual("dbawden@outlook.com", admin.AdminEmail);
            Assert.AreEqual("Paul", admin.AdminName);
            Assert.AreEqual("5565", admin.AdminPinCode);
        }

        /// <summary>
        /// Tests that an Administrator can be removed from the database
        /// </summary>
        [TestMethod]
        public void TestRemoveAdministrator()
        {
            FelicitySecurityUnitTestingRepository repository = PrepareDatabase();
            Administrators_dto administrator = new Administrators_dto();
            administrator = (DataSeedHelper.CreateAdministrator(repository, 1, "dbawden@outlook.com", "David", "1234"));
            repository.AddAdministrator(administrator);
            int adminId = repository.FindAllAdministrators().Select(iD => iD.AdminID).First();
            administrator = (DataSeedHelper.CreateAdministrator(repository, adminId, "dbawden@outlook.com", "Paul", "5565"));
            repository.RemoveAdministrator(adminId);
            var administrators = repository.FindAllAdministrators();
            Assert.AreEqual(0, administrators.Count);
        }
        [TestInitialize]
        private static FelicitySecurityUnitTestingRepository PrepareDatabase()
        {
            FelicitySecurityUnitTestingRepository repository = new FelicitySecurityUnitTestingRepository();
            repository.ClearFelicityTestDatabase();
            return repository;
        }
    }
}



