using FelicitySecurity.Core.Data.DataModel;
using System.Collections.Generic;

namespace FelicitySecurity.Services.Data.Interfaces
{
    public interface IMemberRepository
    {
        List<MemberTable> FindAllMembers();
        MemberTable AddMember(MemberTable item);
        void UpdateMember(MemberTable item);
        void DeleteMember(MemberTable item);

    }
}
