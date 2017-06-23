using Emgu.CV;
using Emgu.CV.Structure;
using FelicitySecurity.Applications.Config.Controllers;
using FelicitySecurity.Applications.Config.Models;
using FelicitySecurity.Applications.Config.Resources.ImageProcessing;
using FelicitySecurity.Applications.Config.Resources.ImageProcessing.CameraFeeds;
using FelicitySecurity.Applications.Config.Resources.ImageProcessing.FaceRecognition;
using FelicitySecurity.Applications.Config.ViewModels;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FelicitySecurity.Applications.Config.Views
{
    /// <summary>
    /// The Register Members View
    /// </summary>
    public partial class RegisterMembers_Form : Form, IDataErrorInfo
    {
        #region Declarations 
        MembersViewModel viewModel = new MembersViewModel();
        MembersController controller = new MembersController();
        MemberModel model = new MemberModel();
        #endregion
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

        public string Error
        {
            get
            {
                return RegisterMembersFieldValidation();
            }
        }

        public string this[string columnName]
        {
            get
            {
                return Error;
            }
        }

        /// <summary>
        /// Validates all fields that can be validated for the register members form 
        /// </summary>
        /// <returns>a validation error string</returns>
        private string RegisterMembersFieldValidation()
        {
            if (string.IsNullOrEmpty(FirstName_Textbox.Text) && string.IsNullOrEmpty(LastName_Textbox.Text) &&
                DateOfBirth_DatePicker.Value == null && string.IsNullOrEmpty(PostCode_Textbox.Text) &&
                DateOfRegistration_DatePicker.Value == null && string.IsNullOrEmpty(PhoneNumber_Textbox.Text))
            {
                return "Please fill in the details!";
            }
            if (string.IsNullOrEmpty(FirstName_Textbox.Text))
            {
                return "You must supply a firstname!";
            }
            if (string.IsNullOrEmpty(LastName_Textbox.Text))
            {
                return "You must supply a lastname!";
            }
            if (string.IsNullOrEmpty(PostCode_Textbox.Text))
            {
                return "You must supply a postcode!";
            }
            if (string.IsNullOrEmpty(PhoneNumber_Textbox.Text))
            {
                return "You must supply a phone number!";
            }
            if (DateOfBirth_DatePicker.Value == null)
            {
                return "You must supply a date of birth!";
            }
            if (DateOfRegistration_DatePicker.Value == null)
            {
                return "You must supply a date of registration!";
            }
            if (viewModel.FacialImages.Count != MaximumNumberOfFaces)
            {
                return string.Format("You must supply {0} facial images of the member!", MaximumNumberOfFaces);
            }
            return string.Empty;
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
        private Timer _timer = new Timer();
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
            viewModel.DisplayMemberNames(this, controller, model);
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
        /// records a set of different facial images of the member or subject
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecordImages_Button_Click(object sender, EventArgs e)
        {
            if (!IsAbleToRecord && viewModel.FacialImages.Count < MaximumNumberOfFaces)
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

        /// <summary>
        /// Notifies the user that they cannot take any more photos
        /// </summary>
        private void NotifyUserOfCompleteListOfFacialImages()
        {
            _isEnabled = false;
            SetRecordImagesButtonAccessibility(_isEnabled);
            MessageBox.Show(string.Format("Successfully recorded {0} facial images", viewModel.FacialImages.Count.ToString()), "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Creates an image list of facial images of the subject.
        /// </summary>
        public void CreateTemporaryListOfFacialImages()
        {
            viewModel.FacialImages.Add(cameraFeed.GrayscaledCroppedFace);
            AcquiredImages_Label.Text = "Acquired Images: " + viewModel.FacialImages.Count.ToString();
            facialImageComparison = cameraFeed.GrayscaledCroppedFace;
        }

        /// <summary>
        /// Sets the RecordImages button to enabled or disabled
        /// </summary>
        /// <param name="isEnabled"></param>
        private void SetRecordImagesButtonAccessibility(bool isEnabled)
        {
            RecordImages_Button.Enabled = isEnabled;
        }

        /// <summary>
        /// Calls the method to clear the image list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearImageList_Button_Click(object sender, EventArgs e)
        {
            ClearFacialImageList();
        }

        /// <summary>
        /// Clears the facial images list and updates the UI appropriately
        /// </summary>
        private void ClearFacialImageList()
        {
            _isEnabled = true;
            viewModel.FacialImages.Clear();
            AcquiredImages_Label.Text = "Acquired Images:";
            SetRecordImagesButtonAccessibility(_isEnabled);
        }

        /// <summary>
        /// Validates the member information is sufficient and registers the member to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMember_Button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Error))
            {
                ImageConversions imageConversions = new ImageConversions();
                imageConversions.AppendEachImageToByteArrayOfImageList(viewModel);
                viewModel.PopulateMemberModel(this, model);
                viewModel.RegisterMember(controller, model);
                MessageBox.Show(string.Format("{0} {1} registered successfully", FirstName_Textbox.Text, LastName_Textbox.Text), "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Error, "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
