using Microsoft.VisualStudio.TestTools.UnitTesting;
using FelicitySecurity.Services.Data.Repository;
using FelicitySecurity.Core.DataTransferObjects;
using FelicitySecurity.Core.Data.UnitTests.Helpers;
using System.Data.Entity;
using Moq;
using FelicitySecurity.Core.Data.UnitTests.Mockables.Interfaces;
using FelicitySecurity.Core.Data.UnitTests.Mockables;
using FelicitySecurity.Core.Data.UnitTests.DataModel;

namespace FelicitySecurity.Core.Data.UnitTests
{
    [TestClass]
    public class FelicitySecurityEngineRepository_AddAdministratorUnitTests : FelicitySecurityUnitTestingRepository
    {
        [TestMethod]
        public void TestAddAdministrators()
        {
            FelicityTestEntities en = new FelicityTestEntities();
            FelicitySecurityUnitTestingRepository repository = new FelicitySecurityUnitTestingRepository(en);
            repository.DeleteAllAdministrators();
            Administrators_dto administrator = new Administrators_dto();
            administrator = (DataSeedHelper.CreateAdministrator(repository, 1, "dbawden@outlook.com", "David", "1234"));
            repository.AddAdministrator(administrator);
            var x = repository.FindAllAdministrators();
            Assert.AreEqual(1, x.Count);          
        }
    }
}



