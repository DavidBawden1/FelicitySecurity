using FelicitySecurity.Core.DataTransferObjects;
using System.Collections.Generic;

namespace FelicitySecurity.Services.Data.Interfaces
{
    public interface IMemberRepository
    {
        List<Members_dto> FindAllMembers();
        Members_dto AddMember(Members_dto item);
        void UpdateMember(Members_dto member);
        void DeleteMember(int memberId);

    }
}
