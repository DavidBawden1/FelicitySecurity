using FelicitySecurity.Applications.Config.Controllers;
using FelicitySecurity.Applications.Config.Models;

namespace FelicitySecurity.Applications.Config.Interfaces
{
    /// <summary>
    /// The MembersViewModel Interface
    /// </summary>
    public interface IMembersViewModel
    {
        void RegisterMember(MembersController controller, MemberModel model);
        void UpdateSelectedMember(MembersController controller, MemberModel model);
        void DeleteMember(MembersController controller, int memberId);
    }
}
