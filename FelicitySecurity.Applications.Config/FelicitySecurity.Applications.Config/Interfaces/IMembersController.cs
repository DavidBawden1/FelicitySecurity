using FelicitySecurity.Applications.Config.Models;

namespace FelicitySecurity.Applications.Config.Interfaces
{
    /// <summary>
    /// The Members controller interface
    /// </summary>
    public interface IMembersController
    {
        void AddMember(MemberModel model);
        void UpdateSelectedMember(MemberModel model);
        void DeleteMember(MemberModel model);
    }
}
