using Emgu.CV;
using Emgu.CV.Structure;
using FelicitySecurity.Applications.Config.Resources.ImageProcessing.CameraFeeds;
using FelicitySecurity.Applications.Config.Resources.ImageProcessing.FaceRecognition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace FelicitySecurity.Applications.Config.Views
{
    public partial class RegisterMembers_Form : Form
    {
        #region Properties
        private bool _isEnabled = false;
        private int _captureInstance = 0;

        /// <summary>
        /// Specifies the index of the targeted camera feed to operate.
        /// </summary>
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

        public List<Image<Gray, byte>> FacialImages = new List<Image<Gray, byte>>();
        private Image<Gray, byte> facialImageComparison;
        private int _facialImagesListPosition = 0;
        public int FacialImagesListPosition
        {
            get
            {
                return _facialImagesListPosition;
            }
            set
            {

            }
        }

        private int _maximumNumberOfFaces = 20;
        public int MaximumNumberOfFaces
        {
            get
            {
                return _maximumNumberOfFaces;
            }
            set
            {

            }
        }

        private bool _IsAbleToRecord = false;
        public bool IsAbleToRecord
        {
            get
            {
                return _IsAbleToRecord;
            }
            set
            {

            }
        }

        System.Drawing.Image _imageToConvertFromEmguCVtoDrawing;

        public byte[] ByteArrayOfImageList
        {
            get;
            set;
        }

        #endregion
        #region Declarations
        CameraFeed cameraFeed = new CameraFeed();
        SuspectFacialPrediction suspectFacialPrediction = new SuspectFacialPrediction();
        /// <summary>
        /// Sets the Suspect object to the details of the detected subject. 
        /// </summary>
        /// <param name="detectedSubject">the detected subject details.</param>
        /// <returns>suspect</returns>
        public delegate Suspect SetSuspectDetails(Suspect detectedSubject);

        /// <summary>
        /// a timer
        /// </summary>
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        private Capture defaultCameraInstance;
        #endregion

        public RegisterMembers_Form()
        {
            defaultCameraInstance = InstantiateCameraFeed.GetCameraCaptureInstance(CaptureInstance);
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
                cameraFeed.ProcessCameraFeedInput(defaultCameraInstance, this);
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

        private void RecordImages_Button_Click(object sender, EventArgs e)
        {
            if (!IsAbleToRecord && FacialImages.Count < MaximumNumberOfFaces)
            {
                if (cameraFeed.GrayscaledCroppedFace != null && cameraFeed.GrayscaledCroppedFace != facialImageComparison)
                {
                    CreateTemporaryListOfFacialImages();
                }
            }
            else
            {
                NotifyUserOfCompleteListOfFacialImages();
            }
        }

        private void NotifyUserOfCompleteListOfFacialImages()
        {
            _isEnabled = false;
            SetRecordImagesButtonAccessibility(_isEnabled);
            MessageBox.Show(string.Format("Successfully recorded {0} facial images", FacialImages.Count.ToString()), "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateTemporaryListOfFacialImages()
        {
            FacialImages.Add(cameraFeed.GrayscaledCroppedFace);
            AcquiredImages_Label.Text = "Acquired Images: " + FacialImages.Count.ToString();
            facialImageComparison = cameraFeed.GrayscaledCroppedFace;
        }

        private byte[] ConvertImageToByteArray(Image<Gray, byte> facialImage)
        {
            MemoryStream memoryStream = new MemoryStream();
            _imageToConvertFromEmguCVtoDrawing = facialImage.ToBitmap();
            _imageToConvertFromEmguCVtoDrawing.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            return memoryStream.ToArray();
        }

        private void SetRecordImagesButtonAccessibility(bool isEnabled)
        {
            RecordImages_Button.Enabled = isEnabled;
        }

        public List<Image<Gray, byte>> GetFacialImageList()
        {
            var x = FacialImages;
            return x;
        }

        private void ClearImageList_Button_Click(object sender, EventArgs e)
        {
            ClearFacialImageList();
        }

        private void ClearFacialImageList()
        {
            _isEnabled = true;
            FacialImages.Clear();
            AcquiredImages_Label.Text = "Acquired Images:";
            SetRecordImagesButtonAccessibility(_isEnabled);
        }

        private void AddMember_Button_Click(object sender, EventArgs e)
        {
            foreach (var facialImage in FacialImages)
            {
                ByteArrayOfImageList = ConvertImageToByteArray(facialImage);
            }
        }
    }
}
