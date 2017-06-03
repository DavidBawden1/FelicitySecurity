using FelicitySecurity.Applications.Config.Models;
using FelicitySecurity.Core.BusinessLogic;
using FelicitySecurity.Core.FelicitySecurityDataServiceReference;
using System.Collections.Generic;

namespace FelicitySecurity.Applications.Config.Controllers
{
    public class MembersController
    {
        FelicitySecurityBusinessLogic businessLogic = new FelicitySecurityBusinessLogic();
        public List<MemberModel> AllAdministratorsEmail(MemberModel model)
        {
            List<Members_dto> allAdministrators = businessLogic.FindAllMembers();

            foreach(Members_dto memberDto in allAdministrators)
            {
                MemberModel memberModel = new MemberModel();
                memberModel.MemberId = memberDto.MemID;
                memberModel.MemberFirstName = memberDto.MemFirstname;
                memberModel.MemberLastName = memberDto.MemLastname;
                memberModel.MemberDateOfBirth = memberDto.MemDOB.Value.Date;
                memberModel.MemberPostCode = memberDto.MemPostcode;
                memberModel.MemberDateOfRegistration = memberDto.MemRegDate.Value.Date;
                memberModel.MemberPhoneNumber = memberDto.MemPhonenumber;
                memberModel.IsPersonARegisteredMember = memberDto.MemStatus.Value;
                memberModel.IsPersonAStaffMember = memberDto.IsStaff.Value;
                memberModel.MemberFacialImages = memberDto.MemFacialImage;
                model.ListOfMembers.Add(memberModel);
            }
            return model.ListOfMembers;
        }
    }
}
