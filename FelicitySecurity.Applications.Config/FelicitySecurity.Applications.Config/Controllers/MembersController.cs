using FelicitySecurity.Applications.Config.Models;
using FelicitySecurity.Core.BusinessLogic;
using FelicitySecurity.Core.FelicitySecurityDataServiceReference;
using System.Collections.Generic;

namespace FelicitySecurity.Applications.Config.Controllers
{
    public class MembersController
    {
        FelicitySecurityBusinessLogic businessLogic = new FelicitySecurityBusinessLogic();
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
    }
}
