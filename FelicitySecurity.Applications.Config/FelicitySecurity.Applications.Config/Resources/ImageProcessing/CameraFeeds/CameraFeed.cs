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
        private int _captureInstance = 0;
        public Capture ChannelFeed
        {
            get;
            set;
        }
        public CascadeClassifier Cascade
        {
            get;
            set;
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
        #region Properties
        #endregion
        #region Constructors
        public CameraFeed SpecifyCameraInstance(int cameraInstance)
        {
            CameraFeed cameraFeed = new CameraFeed();
            Capture SelectedCaptureInstance = new Capture(cameraInstance);
            cameraFeed.ChannelFeed = SelectedCaptureInstance;
            return cameraFeed;
        }
        #endregion
        #region Methods
        public void DisplayFoundFace(Image<Gray, Byte> ImgFound, string NameOfMember, string lastname, string postcode, int MatchValue)
        {
            registerMembersForm.RecognisedMember_EmguImageBox.Image = ImgFound;//display img found in the found image imagebox
        }
        public void DisplayFoundFace(Emgu.CV.UI.ImageBox imageBox, Image<Gray, Byte> ImgFound, string NameOfMember, string lastname, string postcode, int MatchValue)
        {
            registerMembersForm.RecognisedMember_EmguImageBox.Image = ImgFound;//display img found in the found image imagebox
        }
        #endregion
        public void RunCameraFeed()
        {
            try
            {
                using (RawCameraFeedImage = ChannelFeed.QueryFrame().ToImage<Bgr, Byte>())
                {
                    //if imageoriginal isnt empty run detect faces 
                    if (RawCameraFeedImage != null)
                    {
                        registerMembersForm.CameraFeed_ImageBox.BackColor = Color.Transparent;
                        registerMembersForm.CameraFeed_ImageBox.BackgroundImage = null;
                        //CONVERT FROM COLOUR TO GRAY 
                        var grayframe = RawCameraFeedImage.Convert<Gray, Byte>();
                        Rectangle[] Faces =
                        Cascade.DetectMultiScale(grayframe, 8.0, 1, new Size(100, 100), new Size(800, 800)); //run cascade file over gray image with precision of three as 1.2 is very fast but inaccurate, 3.0 is slower but accurate and 0 min next neighbours rather than 10 because of accuracy too. 

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

                                /*DisplayFoundFace(FaceCrop, name, MatchValue, Lastname, Postcode);*/
                                //DisplayFoundFace(GrayscaledCroppedFace, name, lastname, postcode, MatchValue);

                                //RecognisedPersonGB.Text = ("Recognised Person: " + ""  );
                                //groupboxdatarecieved(registerMembersForm.RecognisedMember_GroupBox.Text.ToString());

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
