using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
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
        public delegate Suspect SetSuspectDetails(Suspect recognisedSuspect);
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
        public Capture ChannelFeed
        {
            get
            {
                Capture channelFeedInstance = new Capture(CaptureInstance);
                return channelFeedInstance;
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
            ProcessCameraFeedInput();
            return cameraFeed;
        }
        #endregion

        #region Methods
        public Emgu.CV.IImage GetFoundFace(Image<Gray, Byte> ImgFound, string NameOfMember, string lastname, string postcode, int MatchValue)
        {
            return registerMembersForm.RecognisedMember_EmguImageBox.Image = ImgFound;
        }
        public void DisplayFoundFace(Emgu.CV.UI.ImageBox imageBox, Image<Gray, Byte> ImgFound, string NameOfMember, string lastname, string postcode, int MatchValue)
        {
            imageBox.Image = ImgFound;
        }
        public Suspect GetSuspectDetails(Suspect suspect)
        {
            SetSuspectDetails suspectDetails = new SetSuspectDetails(GetSuspectDetails);
            //Invoke(suspectDetails, new List<Suspect> { suspect });
            return suspect;
        }
        #endregion

        /// <summary>
        /// Processes the camera feed input with facial detection & recognition. 
        /// </summary>
        public void ProcessCameraFeedInput()
        {
            try
            {
                using (RawCameraFeedImage = ChannelFeed.QueryFrame().ToImage<Bgr, Byte>())
                {
                    if (RawCameraFeedImage != null)
                    {
                        registerMembersForm.CameraFeed_ImageBox.BackColor = Color.Transparent;
                        registerMembersForm.CameraFeed_ImageBox.BackgroundImage = null;
                        var grayscaleFrameImage = RawCameraFeedImage.Convert<Gray, Byte>();
                        Rectangle[] Faces =
                        Cascade.DetectMultiScale(grayscaleFrameImage, 8.0, 1, new Size(100, 100), new Size(800, 800)); //run cascade file over gray image with precision of three as 1.2 is very fast but inaccurate, 3.0 is slower but accurate and 0 min next neighbours rather than 10 because of accuracy too. 

                        //if i is less than the length of data within the faces array remove it from image 
                        for (int i = 0; i < Faces.Length; i++)
                        {
                            Faces[i].X += (int)(Faces[i].Height * 0.20);// enlarge image of face
                            Faces[i].Y += (int)(Faces[i].Width * 0.30);//enlarge image of face 
                            Faces[i].Height -= (int)(Faces[i].Height * 0.3);//remove anything that isnt a face
                            Faces[i].Width -= (int)(Faces[i].Width * 0.35);//remove anything that isnt a face

                            GrayscaledCroppedFace = RawCameraFeedImage.Copy(Faces[i]).Convert<Gray, Byte>().Resize(100, 100, Inter.Cubic);
                            GrayscaledCroppedFace._EqualizeHist();
                            //draw face detected in usersface imagebox 
                            RawCameraFeedImage.Draw(Faces[i], new Bgr(Color.Orange), 1);
                            //if faces are recognised then display to the user

                            if (suspectFacialPrediction.IsDataSetPopulated)
                            {
                                Thread.Sleep(20);
                                string name = suspectFacialPrediction.GetPositiveMatchOnFacialRecognition(GrayscaledCroppedFace);
                                string lastname = suspectFacialPrediction.GetPositiveMatchOnFacialRecognition(GrayscaledCroppedFace);
                                string postcode = suspectFacialPrediction.GetPositiveMatchOnFacialRecognition(GrayscaledCroppedFace);
                                int MatchValue = (int)suspectFacialPrediction.NeighbourDistance;

                                GetFoundFace(GrayscaledCroppedFace, name, lastname, postcode, MatchValue);
                                Suspect suspect = new Suspect();
                                suspect.FirstName = name;
                                GetSuspectDetails(suspect);
                            }
                        }
                    }
                    else
                    {
                        //UsersFace.back
                        registerMembersForm.CameraFeed_ImageBox.BackColor = Color.Black;
                    }
                    registerMembersForm.CameraFeed_ImageBox.Image = RawCameraFeedImage;//show feed 
                    registerMembersForm.CroppedDetectedFace_EmguImageBox.Image = GrayscaledCroppedFace;//show new resized feed
                }

            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
