using FelicitySecurity.Applications.Config.Interfaces;
using FelicitySecurity.Applications.Config.Models;
using FelicitySecurity.Core.BusinessLogic;
using FelicitySecurity.Core.FelicitySecurityDataServiceReference;
using System.Collections.Generic;

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

        /// <summary>
        /// Calls the FindAllMembers method in the business logic class. 
        /// </summary>
        public List<MemberModel> FindAllMembers(MemberModel model)
        {
            List<Members_dto> allMembers = businessLogic.FindAllMembers();
            foreach(Members_dto member in allMembers)
            {
                MemberModel memberModel = new MemberModel();
                memberModel.MemberId = member.MemID;
                memberModel.MemberFirstName = member.MemFirstname;
                memberModel.MemberLastName = member.MemLastname;
                memberModel.MemberDateOfBirth = member.MemDOB;
                memberModel.MemberPostCode = member.MemPostcode;
                memberModel.MemberPhoneNumber = member.MemPhonenumber;
                memberModel.MemberDateOfRegistration = member.MemRegDate;
                memberModel.IsPersonARegisteredMember = member.MemStatus.Value;
                memberModel.IsPersonAStaffMember = member.IsStaff.Value;
                memberModel.MemberFacialImages = member.MemFacialImage;
                model.ListOfMembers.Add(memberModel);
            }
            return model.ListOfMembers;
        }
        #endregion
    }
}
