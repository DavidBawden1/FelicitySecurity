using Microsoft.VisualStudio.TestTools.UnitTesting;
using FelicitySecurity.Services.Data.Repository;
using FelicitySecurity.Core.DataTransferObjects;
using FelicitySecurity.Core.Data.UnitTests.Helpers;
using FelicitySecurity.Core.Data.UnitTests.DataModel;

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
            var x = repository.FindAllAdministrators();
            Administrators_dto admin = new Administrators_dto();
            foreach(var item in x)
            {
                admin.AdminID = item.AdminID;
                admin.AdminEmail = item.AdminEmail;
                admin.AdminName = item.AdminName;
                admin.AdminPinCode = item.AdminPinCode;
            }

            Assert.AreEqual(1, x.Count);
            Assert.AreEqual("dbawden@outlook.com", admin.AdminEmail);
            Assert.AreEqual("David", admin.AdminName);
            Assert.AreEqual("1234", admin.AdminPinCode);
        }
    }
}



