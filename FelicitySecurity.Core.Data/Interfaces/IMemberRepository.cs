using FelicitySecurity.Core.DataTransferObjects;
using System.Collections.Generic;

namespace FelicitySecurity.Services.Data.Interfaces
{
    public interface IMemberRepository
    {
        List<Members_dto> FindAllMembers();
    }
}
