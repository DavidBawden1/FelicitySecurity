using Emgu.CV;

namespace FelicitySecurity.Applications.Config.Resources.ImageProcessing.CameraFeeds
{
    /// <summary>
    /// Instantiates the Camera's Capture Instance 
    /// </summary>
    public abstract class InstantiateCameraFeed
    {
        /// <summary>
        /// Returns the Camera's Capture Instance for the specified camera index
        /// </summary>
        /// <param name="captureInstance"></param>
        /// <returns>capture object</returns>
        public static Capture GetCameraCaptureInstance(int captureInstance)
        {
            Capture cameraCaptureInstance = new Capture(captureInstance);
            return cameraCaptureInstance;
        }
    }
}
