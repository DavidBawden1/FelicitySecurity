using FelicitySecurity.Core.Data.DataModel;
using FelicitySecurity.Core.DataTransferObjects;

namespace FelicitySecurity.Services.Helpers
{
    public static class EntityMapper
    {
        public static AdminTable MapEntityFromDto(Administrators_dto item)
        {
            return new AdminTable
            {
                AdminID = item.AdminID,
                AdminEmail = item.AdminEmail,
                AdminName = item.AdminName,
                AdminPinCode = item.AdminPinCode
            };
        }

        public static MemberTable MapEntityFromDto(Members_dto item)
        {
            return new MemberTable
            {
                MemID = item.MemID,
                MemFirstname = item.MemFirstname,
                MemLastname = item.MemLastname,
                MemDOB = item.MemDOB,
                MemPostcode = item.MemPostcode,
                MemPhonenumber = item.MemPhonenumber,
                MemStatus = item.MemStatus.Value,
                MemFacialImage = item.MemFacialImage,
                MemRegDate = item.MemRegDate
            };
        }

        public static StaffTable MapEntityFromDto(Staff_dto item)
        {
            return new StaffTable
            {
                StaffID = item.StaffID,
                BadgeNo = item.BadgeNo.Value,
                MemID = item.MemID
            };
        }
    }
}