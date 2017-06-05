using FelicitySecurity.Applications.Config.Interfaces;
using FelicitySecurity.Applications.Config.Models;
using FelicitySecurity.Core.BusinessLogic;
using FelicitySecurity.Core.FelicitySecurityDataServiceReference;

namespace FelicitySecurity.Applications.Config.Controllers
{
    /// <summary>
    /// The Members Controller, handles data to and from the repository and ViewModel
    /// </summary>
    public class MembersController : IMembersController
    {
        #region Declarations
        FelicitySecurityBusinessLogic businessLogic = new FelicitySecurityBusinessLogic();
        #endregion
        #region Methods

        /// <summary>
        /// Passes the new Member object to the repository
        /// </summary>
        /// <param name="model"></param>
        public void AddMember(MemberModel model)
        {
            Members_dto memberDto = new Members_dto();
            memberDto.MemFirstname = model.MemberFirstName;
            memberDto.MemLastname = model.MemberLastName;
            memberDto.MemDOB = model.MemberDateOfBirth;
            memberDto.MemPostcode = model.MemberPostCode;
            memberDto.MemRegDate = model.MemberDateOfRegistration;
            memberDto.MemPhonenumber = model.MemberPhoneNumber;
            memberDto.MemStatus = model.IsPersonARegisteredMember;
            memberDto.IsStaff = model.IsPersonAStaffMember;
            memberDto.MemFacialImage = model.MemberFacialImages;
            businessLogic.AddMember(memberDto);
        }
        #endregion
    }
}
