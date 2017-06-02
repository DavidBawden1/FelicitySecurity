namespace FelicitySecurity.Applications.Config.Resources.ImageProcessing.CameraFeeds
{
    /// <summary>
    /// The predicted Suspects identity.
    /// </summary>
    public class Suspect
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostCode { get; set; }
        public string Face { get; set; }
    }   
}