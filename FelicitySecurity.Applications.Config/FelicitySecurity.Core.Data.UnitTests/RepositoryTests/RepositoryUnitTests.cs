using Microsoft.VisualStudio.TestTools.UnitTesting;
using FelicitySecurity.Services.Data.Repository;
using FelicitySecurity.Core.DataTransferObjects;
using FelicitySecurity.Core.Data.UnitTests.Helpers;
using System.Linq;
using FelicitySecurity.Core.Data.DataModel;

namespace FelicitySecurity.Core.Data.UnitTests
{
    [TestClass]
    public class RepositoryUnitTests : RepositoryUnitTestBase
    {

        Repository<MemberTable> memberBaseRepository = new Repository<MemberTable>();
        Repository<StaffTable> staffBaseRepository = new Repository<StaffTable>();
        AdministratorRepository adminRepo = new AdministratorRepository();
        MemberRepository memberRepo = new MemberRepository();
        /// <summary>
        /// Tests that an Administrator can be added to the database
        /// </summary>
        [TestMethod]
        public void TestAddAdministrators()
        {
            Repository<AdminTable> adminBaseRepository = new Repository<AdminTable>();
            AdminTable administrator = (DataSeedHelper.CreateAdministrator(adminBaseRepository, "testEmail", "testName", "1234"));
            adminBaseRepository.Add(administrator);
            var administrators = adminRepo.FindAllAdministrators();
            var admin = administrators.Where(x => x.AdminEmail == "testEmail" && x.AdminName == "testName" && x.AdminPinCode == "1234").FirstOrDefault();
            Assert.AreEqual("testEmail", admin.AdminEmail);
            Assert.AreEqual("testName", admin.AdminName);
            Assert.AreEqual("1234", admin.AdminPinCode);
        }

        /// <summary>
        /// Tests that an Administrator can be updated
        /// </summary>
        [TestMethod]
        public void TestUpdateAdministrator()
        {
            Repository<AdminTable> adminBaseRepository = new Repository<AdminTable>();
            AdminTable administrator = (DataSeedHelper.CreateAdministrator(adminBaseRepository, "testEmail", "testName", "1234"));
            adminBaseRepository.Add(administrator);
            administrator = (DataSeedHelper.CreateAdministrator(adminBaseRepository, "testEmail", "testName2", "5565"));

            Repository<AdminTable> adminBaseRepository2 = new Repository<AdminTable>();
            adminBaseRepository2.Update(administrator);
            var administators = adminRepo.FindAllAdministrators().Where(x => x.AdminEmail == "testEmail" && x.AdminName == "testName2" && x.AdminPinCode == "5565").FirstOrDefault();

            Assert.AreEqual("testEmail", administators.AdminEmail);
            Assert.AreEqual("testName2", administators.AdminName);
            Assert.AreEqual("5565", administators.AdminPinCode);
        }

        /// <summary>
        /// Tests that an Administrator can be removed from the database
        /// </summary>
        [TestMethod]
        public void TestRemoveAdministrator()
        {
            Repository<AdminTable> adminBaseRepository = new Repository<AdminTable>();
            AdminTable administrator = (DataSeedHelper.CreateAdministrator(adminBaseRepository, "dbawden@outlook.com", "David", "1234"));
            adminBaseRepository.Add(administrator);
            administrator = (DataSeedHelper.CreateAdministrator(adminBaseRepository, "dbawden@outlook.com", "Paul", "5565"));
            adminBaseRepository.Delete(administrator);
            var administrators = adminRepo.FindAllAdministrators();
        }
    }
}



