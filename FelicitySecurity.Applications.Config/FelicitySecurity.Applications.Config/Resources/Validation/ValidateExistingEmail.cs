using FelicitySecurity.Core.Data.Repository;
using FelicitySecurity.Core.DataTransferObjects;

namespace FelicitySecurity.Applications.Config.Resources.Validation
{
    /// <summary>
    /// Ensures any email can only be registered once
    /// </summary>
    public class ValidateExistingEmail
    {
        /// <summary>
        /// Checks to see if the supplied email already exists. 
        /// </summary>
        /// <param name="email">the supplied email address used for registration.</param>
        /// <returns> true if the email exists. False if it doesnt.</returns>
        public bool DoesEmailExist(string email)
        {
            bool isValid = false;
            FelicitySecurityRepository repository = new FelicitySecurityRepository();
            Administrators_dto adminDto = new Administrators_dto();
            var emailList = repository.FindAllAdministrators();
            foreach (var item in emailList)
            {
                if (email != item.AdminEmail)
                {
                    return isValid;
                }
                else
                {
                    return isValid = true;
                }
            }
            return isValid;
        }
    }
}

