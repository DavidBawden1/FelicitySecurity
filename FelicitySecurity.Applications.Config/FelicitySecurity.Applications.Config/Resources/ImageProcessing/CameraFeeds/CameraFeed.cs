using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using FelicitySecurity.Applications.Config.Resources.ImageProcessing.FaceRecognition;
using FelicitySecurity.Applications.Config.Views;
using System;
using System.Drawing;
using System.Threading;

namespace FelicitySecurity.Applications.Config.Resources.ImageProcessing.CameraFeeds
{
    public class CameraFeed
    {
        #region Declarations
        RegisterMembers_Form registerMembersForm = new RegisterMembers_Form();
        SuspectFacialPrediction suspectFacialPrediction = new SuspectFacialPrediction();

        #endregion
        #region Properties
        private int _captureInstance = 0;
        public int CaptureInstance
        {
            get
            {
                return _captureInstance;
            }
            set
            {

            }
        }
        private Capture _channelFeed;
        public Capture ChannelFeed
        {
            get
            {
                _channelFeed = new Capture(CaptureInstance);
                return _channelFeed;
            }
            set
            {

            }
        }
        public CascadeClassifier Cascade
        {
            get
            {
                return Cascade = new CascadeClassifier("FaceDetection\\lbpcascade_frontalface.xml");
            }
            set
            {

            }
        }

        public Image<Bgr, Byte> RawCameraFeedImage
        {
            get;
            set;
        }

        public Image<Gray, Byte> GrayscaledCroppedFace
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public CameraFeed SpecifyCameraInstance(int captureInstance)
        {
            _captureInstance = captureInstance;
            CameraFeed cameraFeed = new CameraFeed();
            Capture SelectedCaptureInstance = new Capture(CaptureInstance);
            cameraFeed.ChannelFeed = SelectedCaptureInstance;
            return cameraFeed;
        }
        #endregion

        #region Methods
        public Emgu.CV.IImage GetFoundFace(Image<Gray, Byte> imageOfFoundFace)
        {
            return registerMembersForm.RecognisedMember_EmguImageBox.Image = imageOfFoundFace;
        }

        /// <summary>
        /// Returns the the found face to the image box
        /// </summary>
        /// <param name="imageBoxToDisplayFoundFace"></param>
        /// <param name="imageOfFoundFace"></param>
        /// <param name="suspectFirstName"></param>
        /// <param name="suspectLastName"></param>
        /// <param name="suspectPostCode"></param>
        /// <param name="matchValue"></param>
        public ImageBox DisplayFoundFace(ImageBox imageBoxToDisplayFoundFace, Image<Gray, Byte> imageOfFoundFace)
        {
            imageBoxToDisplayFoundFace.Image = imageOfFoundFace;
            return imageBoxToDisplayFoundFace;
        }

        #endregion

        /// <summary>
        /// Processes the camera feed input with facial detection & recognition. 
        /// </summary>
        public void ProcessCameraFeedInput(CameraFeed selectedCaptureInstance)
        {
            try
            {
                using (RawCameraFeedImage = ChannelFeed.QueryFrame().ToImage<Bgr, Byte>())
                {
                    if (RawCameraFeedImage != null)
                    {
                        registerMembersForm.CameraFeed_ImageBox = SetWorkingCameraFeedProperties();
                        Rectangle[] detectedFace = GetDetectedFace();
                        GetCroppedDetectedFace(detectedFace);
                        RecogniseDetectedFace();
                    }
                    else
                    {
                        DisplaySwitchedOffCameraFeed();
                    }
                    ReturnCameraFeedsToUI();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        /// <summary>
        /// Displays the camera feed to the UI controls on the form. 
        /// </summary>
        private void ReturnCameraFeedsToUI()
        {
            registerMembersForm.CameraFeed_ImageBox.Image = RawCameraFeedImage;//show feed 
            registerMembersForm.CroppedDetectedFace_EmguImageBox.Image = GrayscaledCroppedFace;//show new resized feed
        }

        /// <summary>
        /// Displays a broken Circuit image to the UI control to resemble no camera feed activity.
        /// </summary>
        /// <returns>Imagebox</returns>
        private ImageBox DisplaySwitchedOffCameraFeed()
        {
            registerMembersForm.CameraFeed_ImageBox.BackColor = Color.Black;
            return registerMembersForm.CameraFeed_ImageBox;
        }

        /// <summary>
        /// When a face is detected, the face is cropped & enlarged. Then a square is drawn over it.
        /// </summary>
        /// <param name="detectedFaces"></param>
        private void GetCroppedDetectedFace(Rectangle[] detectedFaces)
        {
            for (int i = 0; i < detectedFaces.Length; i++)
            {
                detectedFaces[i].X += (int)(detectedFaces[i].Height * 0.20);// enlarge image of face
                detectedFaces[i].Y += (int)(detectedFaces[i].Width * 0.30);//enlarge image of face 
                detectedFaces[i].Height -= (int)(detectedFaces[i].Height * 0.3);//remove anything that isnt a face
                detectedFaces[i].Width -= (int)(detectedFaces[i].Width * 0.35);//remove anything that isnt a face
                GrayscaledCroppedFace = RawCameraFeedImage.Copy(detectedFaces[i]).Convert<Gray, Byte>().Resize(100, 100, Inter.Cubic);
                GrayscaledCroppedFace._EqualizeHist();
                RawCameraFeedImage.Draw(detectedFaces[i], new Bgr(Color.Orange), 1);
            }
        }

        /// <summary>
        /// Recognises the details of the detected subject
        /// </summary>
        private void RecogniseDetectedFace()
        {
            if (suspectFacialPrediction.IsDataSetPopulated)
            {
                Suspect suspect = new Suspect();
                suspect.FirstName = suspectFacialPrediction.GetPositiveMatchOnFacialRecognition(GrayscaledCroppedFace);
                suspect.LastName = suspectFacialPrediction.GetPositiveMatchOnFacialRecognition(GrayscaledCroppedFace);
                suspect.PostCode = suspectFacialPrediction.GetPositiveMatchOnFacialRecognition(GrayscaledCroppedFace);
                int matchValue = (int)suspectFacialPrediction.NeighbourDistance;
                GetFoundFace(GrayscaledCroppedFace);
                registerMembersForm.GetSuspectDetails(suspect);
            }
        }

        /// <summary>
        /// Returns a detected face
        /// </summary>
        /// <returns>a rectangle array containing a face within the camerafeed</returns>
        private Rectangle[] GetDetectedFace()
        {
            var grayscaleFrameImage = RawCameraFeedImage.Convert<Gray, Byte>();
            Rectangle[] detectedFace =
            Cascade.DetectMultiScale(grayscaleFrameImage, 8.0, 1, new Size(100, 100), new Size(800, 800));
            return detectedFace;
        }

        /// <summary>
        /// Configures the camera feeds Image box properties to that of an operational camera. 
        /// </summary>
        /// <returns>an image box</returns>
        private ImageBox SetWorkingCameraFeedProperties()
        {
            registerMembersForm.CameraFeed_ImageBox.BackColor = Color.Transparent;
            registerMembersForm.CameraFeed_ImageBox.BackgroundImage = null;
            return registerMembersForm.CameraFeed_ImageBox;
        }
    }
}
