using Emgu.CV;
using Emgu.CV.Structure;
using FelicitySecurity.Applications.Config.Controllers;
using FelicitySecurity.Applications.Config.Models;
using FelicitySecurity.Applications.Config.Resources.Controls;
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
        CurrentSortingType sortingType;
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
        /// Set when the user selects a member from the list.
        /// </summary>
        public int SelectedMemberId { get; set; }

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
        public delegate void SetSuspectDetails(Suspect detectedSubject, Image<Gray, byte> detectedFace);

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
            InitialiseControlDataSources(this);
            viewModel.DisplayMemberDetailsToListbox(this, controller, model, sortingType);
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
        public void GetSuspectDetails(Suspect suspect, Image<Gray, byte> detectedFace)
        {
            if (InvokeRequired)
            {
                SetSuspectDetails suspectDetails = new SetSuspectDetails(GetSuspectDetails);
                Invoke(suspectDetails, new object[] { suspect, detectedFace });
            }
            else
            {
                RecognisedMember_EmguImageBox.Image = suspect.Face;
                FirstName_Textbox.Text = suspect.FirstName;
                LastName_Textbox.Text = suspect.LastName;
                PostCode_Textbox.Text = suspect.PostCode;
            }
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

        /// <summary>
        /// Validates the form data entry and updates the selected members information. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateMember_Button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Error))
            {
                if (ExistingMembers_ListBox.SelectedItem != null)
                {
                    UpdateSelectedMember();
                    MessageBox.Show(string.Format("{0} {1} updated successfully", FirstName_Textbox.Text, LastName_Textbox.Text), "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a member to update.", "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Error, "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Updates the selected member with the details in the form fields & images in the ByteArray. 
        /// </summary>
        private void UpdateSelectedMember()
        {
            ImageConversions imageConversions = new ImageConversions();
            imageConversions.AppendEachImageToByteArrayOfImageList(viewModel);
            viewModel.BindControls(this, viewModel);
            PopulateModelWithSelectedMemberId();
            viewModel.UpdateSelectedMember(controller, model);
            RefreshUIPostUpdatingMember();
        }

        /// <summary>
        /// Resets the form fields and refreshes the Existing Members Listbox. 
        /// </summary>
        private void RefreshUIPostUpdatingMember()
        {
            FirstName_Textbox.Clear();
            LastName_Textbox.Clear();
            PostCode_Textbox.Clear();
            PhoneNumber_Textbox.Clear();
            DateOfBirth_DatePicker.Value = DateTime.Today;
            DateOfRegistration_DatePicker.Value = DateTime.Today;
            MembershipStatus_Checkbox.Checked = false;
            StaffStatus_Checkbox.Checked = false;
            viewModel.DisplayMemberDetailsToListbox(this, controller, model, sortingType);
        }

        /// <summary>
        /// Populates the member model the properties of the selected member. 
        /// </summary>
        private void PopulateModelWithSelectedMemberId()
        {
            SelectedMemberId = (ExistingMembers_ListBox.SelectedItem as ListboxItem).Value;
            model.MemberId = SelectedMemberId;
            model.MemberFirstName = FirstName_Textbox.Text;
            model.MemberLastName = LastName_Textbox.Text;
            model.MemberPhoneNumber = PhoneNumber_Textbox.Text;
            model.MemberDateOfBirth = DateOfBirth_DatePicker.Value;
            model.MemberPostCode = PostCode_Textbox.Text;
            model.IsPersonARegisteredMember = MembershipStatus_Checkbox.Checked;
            model.MemberDateOfRegistration = DateOfRegistration_DatePicker.Value;
            model.IsPersonAStaffMember = StaffStatus_Checkbox.Checked;
            model.MemberFacialImages = viewModel.ByteArrayOfImageList;
        }

        /// <summary>
        /// Populates the MemberId with that of the selected member. 
        /// Updates the form fields with the details of the selected member. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExistingMembers_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                model.MemberId = (ExistingMembers_ListBox.SelectedItem as ListboxItem).Value;
                viewModel.DisplayMemberDetailsToFormControls(this, controller, model);
            }
            catch(Exception)
            {
                MessageBox.Show("Please select a Member.", "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Selects the way in which the members list is sorted. i.e. default or alphabetical. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentSort_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(CurrentSort_ComboBox.SelectedValue.ToString(), out sortingType);
            viewModel.DisplayMemberDetailsToListbox(this, controller, model, sortingType);
        }

        /// <summary>
        /// populates the combobox with the sortying types.  
        /// </summary>
        /// <param name="form"></param>
        public void InitialiseControlDataSources(RegisterMembers_Form form)
        {
            form.CurrentSort_ComboBox.DataSource = Enum.GetValues(typeof(CurrentSortingType));
        }
    }
}
