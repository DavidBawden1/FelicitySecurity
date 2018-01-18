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
        //string connectionString = @"metadata=res://*/DataModel.FelicitySecurity.csdl|res://*/DataModel.FelicitySecurity.ssdl|res://*/DataModel.FelicitySecurity.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-T69TDHC\MSSQLSERVER1;initial catalog=FelicityLive;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework&quot;"+" providerName="+"System.Data.EntityClient";
        Repository<AdminTable> adminBaseRepository = new Repository<AdminTable>();
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
            AdminTable administrator = (DataSeedHelper.CreateAdministrator(adminBaseRepository, "dbawden@outlook.com", "David", "1234"));
            adminBaseRepository.Add(administrator);
            int adminId = adminRepo.FindAllAdministrators().Select(iD => iD.AdminID).First();
            administrator = (DataSeedHelper.CreateAdministrator(adminBaseRepository, "dbawden@outlook.com", "Paul", "5565"));
            adminBaseRepository.Update(administrator);
            var administrators = adminRepo.FindAllAdministrators();
            Administrators_dto admin = new Administrators_dto();
            foreach (var item in administrators)
            {
                admin.AdminID = item.AdminID;
                admin.AdminEmail = item.AdminEmail;
                admin.AdminName = item.AdminName;
                admin.AdminPinCode = item.AdminPinCode;
            }

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
            AdminTable administrator = (DataSeedHelper.CreateAdministrator(adminBaseRepository, "dbawden@outlook.com", "David", "1234"));
            adminBaseRepository.Add(administrator);
            int adminId = adminRepo.FindAllAdministrators().Select(iD => iD.AdminID).First();
            administrator = (DataSeedHelper.CreateAdministrator(adminBaseRepository, "dbawden@outlook.com", "Paul", "5565"));
            adminBaseRepository.Delete(administrator);
            var administrators = adminRepo.FindAllAdministrators();
            Assert.AreEqual(0, administrators.Count);
        }
    }
}



