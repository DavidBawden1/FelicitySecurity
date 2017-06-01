using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using FelicitySecurity.Applications.Config.Resources.ImageProcessing.CameraFeeds;
using FelicitySecurity.Applications.Config.Resources.ImageProcessing.FaceRecognition;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FelicitySecurity.Applications.Config.Views
{
    public partial class RegisterMembers_Form : Form
    {
        #region Properties
        SuspectFacialPrediction suspectFacialPrediction = new SuspectFacialPrediction();

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
        /// <summary>
        /// Sets the Suspect object to the details of the detected subject. 
        /// </summary>
        /// <param name="detectedSubject">the detected subject details.</param>
        /// <returns>suspect</returns>
        public delegate Suspect SetSuspectDetails(Suspect detectedSubject);

        /// <summary>
        /// a timer
        /// </summary>
        private Timer _timer = new Timer();
        private Capture defaultCameraInstance;

        public RegisterMembers_Form()
        {
            defaultCameraInstance = CameraFeed.GetCameraCaptureInstance(CaptureInstance);
            InitializeComponent();
        }

        /// <summary>
        /// Specifies the camera feed instance & processes the input  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CameraFeedBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CameraFeed cameraFeed = new CameraFeed();
                cameraFeed.ProcessCameraFeedInput(defaultCameraInstance, this);
               // Application.Idle += RunThreadOverTimer;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        /// <summary>
        /// When the timer ticks the camera feed background worker is called. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunThreadOverTimer(object sender, EventArgs e)
        {
            try
            {
                StartCameraFeedBackgroundWorker();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Loads the form & start timer for threads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterMembers_Form_Load(object sender, EventArgs e)
        {
            Application.Idle += StartTimer;
        }

        /// <summary>
        /// Starts the timer to trigger background worker thread. 
        /// </summary>
        void StartTimer(object sender, EventArgs e)
        {
            _timer.Tick += new EventHandler(RunThreadOverTimer);
            _timer.Interval = 1;
            _timer.Enabled = true;
        }

        /// <summary>
        /// Starts running the CameraFeedBackground worker.
        /// </summary>
        private void StartCameraFeedBackgroundWorker()
        {
            try
            {
                if (!CameraFeed_BackgroundWorker.IsBusy)
                {
                    CameraFeed_BackgroundWorker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Gets the suspect details from the camera feed being run under the background worker thread. 
        /// </summary>
        /// <param name="suspect"></param>
        public Suspect GetSuspectDetails(Suspect suspect)
        {
            SetSuspectDetails suspectDetails = new SetSuspectDetails(GetSuspectDetails);
            Invoke(suspectDetails, new object[] { suspect });
            return suspect;
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

        /// <summary>
        /// Returns the Image of the recognised suspect
        /// </summary>
        /// <param name="imageOfFoundFace"></param>
        /// <returns></returns>
        public IImage GetFoundFace(Image<Gray, Byte> imageOfFoundFace)
        {
            return RecognisedMember_EmguImageBox.Image = imageOfFoundFace;
        }

        /// <summary>
        /// Returns the images of the CameraFeed to the image box controls
        /// </summary>
        private void ReturnCameraFeedsToUI()
        {
            CameraFeed_ImageBox.Image = RawCameraFeedImage;//show feed 
            CroppedDetectedFace_EmguImageBox.Image = GrayscaledCroppedFace;//show new resized feed
        }

        /// <summary>
        /// Displays a broken Circuit image to the UI control to resemble no camera feed activity.
        /// </summary>
        /// <returns>Imagebox</returns>
        private ImageBox DisplaySwitchedOffCameraFeed()
        {
            CameraFeed_ImageBox.BackColor = Color.Black;
            return CameraFeed_ImageBox;
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
                GetSuspectDetails(suspect);
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
            CameraFeed_ImageBox.BackColor = Color.Transparent;
            CameraFeed_ImageBox.BackgroundImage = null;
            return CameraFeed_ImageBox;
        }

        public void ProcessCameraFeedInput()
        {
            try
            {
                using (RawCameraFeedImage = defaultCameraInstance.QueryFrame().ToImage<Bgr, Byte>())
                {
                    if (RawCameraFeedImage != null)
                    {
                        CameraFeed_ImageBox = SetWorkingCameraFeedProperties();
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
    }
}
