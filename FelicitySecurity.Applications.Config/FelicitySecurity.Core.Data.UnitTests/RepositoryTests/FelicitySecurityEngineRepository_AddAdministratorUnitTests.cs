using Microsoft.VisualStudio.TestTools.UnitTesting;
using FelicitySecurity.Core.Data.Repository;
using FelicitySecurity.Core.DataTransferObjects;
using System.Collections.Generic;
using FelicitySecurity.Core.Data.UnitTests.Helpers;
using System.Data.Entity;
using FelicitySecurity.Core.Data.DataModel;
using Moq;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using FelicitySecurity.Core.Data.UnitTests.Mockables.Interfaces;
using FelicitySecurity.Core.Data.UnitTests.Mockables;

namespace FelicitySecurity.Core.Data.UnitTests
{
    [TestClass]
    public class FelicitySecurityEngineRepository_AddAdministratorUnitTests : FelicitySecurityRepository
    {
        [TestMethod]
        public void TestAddAdministrators()
        {
            FelicitySecurityRepository repository = new FelicitySecurityRepository();
            Administrators_dto administrator = new Administrators_dto();
            administrator = (DataSeedHelper.CreateAdministrator(repository, "dbawden@outlook.com", "David", "1234"));
            var mockSet = new Mock<DbSet<Administrators_dto>>();
            var mockContext = new Mock<IDbContext>();
            mockContext.Setup(m => m.Set<Administrators_dto>()).Returns(new FakeDbSet<Administrators_dto>
            {
                administrator
            }
            );
        }
    }
}



