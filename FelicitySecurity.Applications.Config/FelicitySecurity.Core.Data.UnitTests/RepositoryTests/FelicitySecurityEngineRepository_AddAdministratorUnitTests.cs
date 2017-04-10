using Microsoft.VisualStudio.TestTools.UnitTesting;
using FelicitySecurity.Core.Data.Repository;
using FelicitySecurity.Core.DataTransferObjects;
using System.Collections.Generic;
using FelicitySecurity.Core.Data.UnitTests.Helpers;

namespace FelicitySecurity.Core.Data.UnitTests
{
    [TestClass]
    public class FelicitySecurityEngineRepository_AddAdministratorUnitTests
    {
        [TestMethod]
        public void TestAddAdministrators()
        {
            FelicitySecurityRepository repository = new FelicitySecurityRepository();
            List<Administrators_dto> listOfAdministrators = new List<Administrators_dto>();
            listOfAdministrators.Add(DataSeedHelper.CreateAdministrator(repository, "dbawden@outlook.com", "David", "Bawden"));
            Assert.AreEqual(1, listOfAdministrators.Count);
            Assert.AreNotEqual(0, listOfAdministrators.Count);
        }
    }
}
