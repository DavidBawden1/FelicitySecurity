
namespace FelicitySecurity.Core.DataTransferObjects
{
    /// <summary>
    /// The Administrators dto transfers administrator details 
    /// </summary>
    public class Administrators_dto
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPinCode { get; set; }
    }
}
