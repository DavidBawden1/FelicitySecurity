using Microsoft.VisualStudio.TestTools.UnitTesting;
using FelicitySecurity.Core.Data.Repository;
using FelicitySecurity.Core.DataTransferObjects;

namespace FelicitySecurity.Core.Data.UnitTests
{
    [TestClass]
    public class FelicitySecurityEngineRepository_AddAdministratorUnitTests
    {
        private string _adminEmail;
        public string AdminEmail
        {

            get
            {
                return _adminEmail;
            }
            set
            {
                _adminEmail = @"dbawden@outlook.com";
            }
        }

        private string _adminName;
        public string AdminName
        {
            get
            {
                return _adminName;
            }
            set
            {
                _adminName = "David";
            }
        }
        private string _adminPinCode;

        public string AdminPinCode
        {
            get
            {
                return _adminPinCode;
            }
            set
            {
                _adminPinCode = "12345";
            }
        }
        [TestMethod]
        public void TestAddAdministrators()
        {
            FelicitySecurityRepository repository = new FelicitySecurityRepository();
            var dto = new Administrators_dto()
            {
                AdminEmail = AdminEmail,
                AdminName = AdminName,
                AdminPinCode = AdminPinCode
            };
            repository.AddAdministrator(dto);
        }
            
    }
}
