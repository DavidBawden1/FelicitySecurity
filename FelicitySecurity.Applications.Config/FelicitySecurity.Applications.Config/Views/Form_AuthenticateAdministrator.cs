using FelicitySecurity.Applications.Config.Controllers;
using FelicitySecurity.Applications.Config.Resources.Controls;
using FelicitySecurity.Applications.Config.Resources.Validation;
using FelicitySecurity.Applications.Config.ViewModels;
using FelicitySecurity.Core.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FelicitySecurity.Applications.Config.Views
{
    /// <summary>
    /// The Authentication Form requires a user to log in. 
    /// </summary>
    public partial class AuthenticateAdministrators_Form : Form, IDataErrorInfo
    {
        #region Declarations 
        private TextBox _textbox;
        AdministratorsController controller = new AdministratorsController();
        AdministratorsModel model = new AdministratorsModel();
        AdministratorsViewModel viewModel = new AdministratorsViewModel();
        ValidationBase validation = new ValidationBase();
        ValidateExistingEmail ValidateEmail = new ValidateExistingEmail();
        CurrentSortingType sortingType;
        #endregion
        #region Properties
        private string _error;
        public string Error
        {
            get
            {
                if(string.IsNullOrEmpty(EnterEmail_TextBox.Text) && string.IsNullOrEmpty(EnterPinCode_TextBox.Text))
                {
                    return "Please enter your details.";
                }
                if(!validation.IsValidEmail(EnterEmail_TextBox.Text))
                {
                    return "Your email address has to be valid! eg. woopiegoldberg@yahoo.co.uk";
                }
                if (string.IsNullOrEmpty(EnterPinCode_TextBox.Text) || EnterPinCode_TextBox.TextLength > 4 || EnterPinCode_TextBox.Text.Length < 4)
                {
                    return "You must enter a 4 digit pin!";
                }
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                return Error;
            }
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Constructs the Authentication Form. 
        /// </summary>
        public AuthenticateAdministrators_Form()
        {
            InitializeComponent();
        }
        #endregion
        #region Methods

        /// <summary>
        /// Hides this Form
        /// </summary>
        private void HideThisForm()
        {
            Hide();
        }

        /// <summary>
        /// Initialises the Registration Form
        /// </summary>
        private void InitialiseRegistrationForm()
        {
            RegisterAdministrators_Form registerForm = new RegisterAdministrators_Form();
            registerForm.Show();
        }

        /// <summary>
        /// Closes the entire application
        /// </summary>
        private void CloseThisForm()
        {
            Application.Exit();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Calls the CloseThisForm method. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_MenuItem_Click(object sender, EventArgs e)
        {
            CloseThisForm();
        }

        /// <summary>
        /// Initiates the Registration Form and Hides this Form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Registration_MenuItem_Click(object sender, EventArgs e)
        {
            InitialiseRegistrationForm();
            HideThisForm();
        }

        /// <summary>
        /// Loads the form 
        /// populates the ComboBox and ListBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthenticateAdministrators_Form_Load(object sender, EventArgs e)
        {
            viewModel.InitialiseControlDataSources(this);
            viewModel.DisplayAdministratorEmails(this, controller, model, sortingType);
        }

        /// <summary>
        /// Authenticates the Credentials provided
        /// if authorised, proceeds to the next form 
        /// otherwise an error is returned
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignIn_Button_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Error))
            {
                if(viewModel.IsPersonAuthorised(this, EnterEmail_TextBox.Text, EnterPinCode_TextBox.Text, controller, model))
                {
                    MessageBox.Show(EnterEmail_TextBox.Text + " logged in successfully.","Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(EnterEmail_TextBox.Text + " is not authorised", "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Error, "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Clears the forms Textbox controls. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Button_Click(object sender, EventArgs e)
        {
            viewModel.Clear(this);
        }

        /// <summary>
        /// Populates the Email textbox with the selected administrator when selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Administrators_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string administratorsEmail = (Administrators_ListBox.SelectedItem as ListboxItem).ItemText;
                viewModel.DisplayAdministratorsDetails(this, administratorsEmail, controller, model);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nYou must select an Administrator.", "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Orders the list by default or alphabetical sort. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentSort_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(CurrentSort_ComboBox.SelectedValue.ToString(), out sortingType);
            viewModel.DisplayAdministratorEmails(this, controller, model, sortingType);
        }
        #endregion

    }
}
