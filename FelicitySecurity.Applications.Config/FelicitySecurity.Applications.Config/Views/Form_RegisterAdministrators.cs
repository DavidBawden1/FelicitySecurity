using FelicitySecurity.Applications.Config.Controllers;
using FelicitySecurity.Applications.Config.Resources.Controls;
using FelicitySecurity.Applications.Config.Resources.Validation;
using FelicitySecurity.Applications.Config.ViewModels;
using FelicitySecurity.Applications.Config.Views;
using FelicitySecurity.Core.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FelicitySecurity.Applications.Config
{
    public partial class RegisterAdministratorsForm : Form, IDataErrorInfo
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
        /// <summary>
        /// Validate the controls here. if validation fails return the specific error message.  
        /// </summary>
        public string Error
        {
            get
            {
                return _error = BasicFieldValidation();
            }
        }

        /// <summary>
        /// implies specific validation logic for registration. 
        /// </summary>
        /// <returns></returns>
        private string BasicFieldValidation()
        {
            if (string.IsNullOrEmpty(CreateUsername_TextBox.Text) && string.IsNullOrEmpty(EnterEmail_TextBox.Text)
                                && string.IsNullOrEmpty(EnterPin_TextBox.Text) && string.IsNullOrEmpty(ReEnterPin_TextBox.Text))
            {
                return "Please fill in your details!";
            }
            if (string.IsNullOrEmpty(CreateUsername_TextBox.Text))
            {
                return "You must supply a username!";
            }
            if (CreateUsername_TextBox.TextLength > 50)
            {
                return "Your username must be between 0 and 50 characters!";
            }
            if (string.IsNullOrEmpty(EnterEmail_TextBox.Text))
            {
                return "You must supply an email address!";
            }
            if (!validation.IsValidEmail(EnterEmail_TextBox.Text))
            {
                return "Your email address has to be valid! eg. woopiegoldberg@yahoo.co.uk";
            }
            if (string.IsNullOrEmpty(EnterPin_TextBox.Text) || EnterPin_TextBox.TextLength > 4)
            {
                return "You must enter a 4 digit pin!";
            }
            if (EnterPin_TextBox.Text != ReEnterPin_TextBox.Text)
            {
                return "please confirm your pincodes!";
            }
            return string.Empty;
        }

        /// <summary>
        /// The name of the control given and returns its error message. 
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns>an error message</returns>
        public string this[string columnName]
        {
            get
            {
                return Error;
            }
        }

        /// <summary>
        /// set when the user selects an administrator from the list. 
        /// </summary>
        public int SelectedAdministratorId { get; set; }

        #endregion
        #region Constructors

        /// <summary>
        /// Initialises the RegisterAdministratorsForm
        /// </summary>
        public RegisterAdministratorsForm()
        {
            InitializeComponent();
        }
        #endregion

        #region EventHandlers
        /// <summary>
        /// Creates an administrator 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Register_Button_Click(object sender, EventArgs e)
        {
            
            //if error is null then validation has passed so continue otherwise return the error message. 
            if (!ValidateEmail.DoesEmailExist(EnterEmail_TextBox.Text))
            {
                if (string.IsNullOrEmpty(Error.ToString()))
                {
                    viewModel.BindTextboxControls(this, viewModel, _textbox);
                    controller.AddAdministrators(EnterEmail_TextBox.Text, CreateUsername_TextBox.Text, EnterPin_TextBox.Text);
                    MessageBox.Show("Administrator added successfully.", "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    viewModel.DisplayAdministratorEmails(this, controller, model, sortingType);
                }
                else
                {
                    MessageBox.Show(Error, "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(EnterEmail_TextBox.Text + " already exists!", "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Error);
                viewModel.Clear(this);
            }
        }

        /// <summary>
        /// updates the selected Administrator with the new details provided.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateAdministratorButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Error.ToString()))
            {
                viewModel.BindTextboxControls(this, viewModel, _textbox);
                PopulateModelWithSelectedAdminId();
                if (SelectedAdministratorId != 0)
                {
                    controller.UpdateSelectedAdministrator(model);
                    RefreshUIPostUpdatingAdministrator();
                }
                else
                {
                    MessageBox.Show("You must select an Administrator to update!.", "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Error, "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cancels the user input on this form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterCancel_Button_Click(object sender, EventArgs e)
        {
            viewModel.Clear(this);
        }

        /// <summary>
        /// when the form Loads retrieve all administrators and display them to the listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterAdministratorsForm_Load(object sender, EventArgs e)
        {
            viewModel.InitialiseControlDataSources(this);
            viewModel.DisplayAdministratorEmails(this, controller, model, sortingType);
        }

        /// <summary>
        /// Takes the Selected item and returns the parent objects data by querying by that item. 
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
        /// Re-orders the administrators list box depending on the selected sortingType. i.e: Default or Alphabetical
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentSortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(CurrentSortComboBox.SelectedValue.ToString(), out sortingType);
            viewModel.DisplayAdministratorEmails(this, controller, model, sortingType);
        }

        #endregion

        /// <summary>
        /// Removes the selected administrator from the database. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveAdministratorButton_Click(object sender, EventArgs e)
        {
            if (Administrators_ListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an Administrator to remove.", "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PopulateModelWithSelectedAdminId();
                controller.RemoveSelectedAdministrator(model);
                RefreshUIPostDeletionOfAdmin();
            }
        }

        /// <summary>
        /// When the administrator has been deleted, the list is repopulated and the UI controls are cleared. 
        /// </summary>
        private void RefreshUIPostDeletionOfAdmin()
        {
            viewModel.DisplayAdministratorEmails(this, controller, model, sortingType);
            viewModel.Clear(this);
            MessageBox.Show("Administrator removed successfully.", "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// refreshes UI after updating the administrator. 
        /// </summary>
        private void RefreshUIPostUpdatingAdministrator()
        {
            viewModel.DisplayAdministratorEmails(this, controller, model, sortingType);
            EnterPin_TextBox.Clear();
            ReEnterPin_TextBox.Clear();
            MessageBox.Show("Administrator updated successfully.", "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// populates the Administrators Model properties with those of the selected administrator. 
        /// </summary>
        private void PopulateModelWithSelectedAdminId()
        {
            SelectedAdministratorId = (Administrators_ListBox.SelectedItem as ListboxItem).Value;
            model.AdminID = SelectedAdministratorId;
            model.AdminEmail = EnterEmail_TextBox.Text;
            model.AdminName = CreateUsername_TextBox.Text;
            model.AdminPinCode = EnterPin_TextBox.Text;
        }

        /// <summary>
        /// Opens the Authentication form and closes this form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterBack_Button_Click(object sender, EventArgs e)
        {
            InitialiseAuthenticationForm();
            CloseThisForm();
        }

        /// <summary>
        /// Closes this form. 
        /// </summary>
        private void CloseThisForm()
        {
            this.Close();
        }

        /// <summary>
        /// Opens the authentication form. 
        /// </summary>
        private static void InitialiseAuthenticationForm()
        {
            Form_AuthenticateAdministrator authenticationForm = new Form_AuthenticateAdministrator();
            authenticationForm.Show();
        }
    }
}

