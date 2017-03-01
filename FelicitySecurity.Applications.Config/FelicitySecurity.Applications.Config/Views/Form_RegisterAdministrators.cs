﻿using FelicitySecurity.Applications.Config.Controllers;
using FelicitySecurity.Applications.Config.Resources.Controls;
using FelicitySecurity.Applications.Config.Resources.Validation;
using FelicitySecurity.Applications.Config.ViewModels;
using FelicitySecurity.Core.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FelicitySecurity.Applications.Config
{
    public partial class RegisterAdministratorsForm : Form, IDataErrorInfo
    {
        #region Properties 
        private TextBox _textbox;
        AdministratorsController controller = new AdministratorsController();
        AdministratorsModel model = new AdministratorsModel();
        AdministratorsViewModel viewModel = new AdministratorsViewModel();
        ValidationBase validation = new ValidationBase();
        ValidateExistingEmail ValidateEmail = new ValidateExistingEmail();
        /// <summary>
        /// Validate the controls here. if validation fails return the specific error message.  
        /// </summary>
        public string Error
        {
            get
            {
                if(string.IsNullOrEmpty(CreateUsername_TextBox.Text) && string.IsNullOrEmpty(EnterEmail_TextBox.Text)
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
                if (ValidateEmail.DoesEmailExist(EnterEmail_TextBox.Text))
                {
                    return EnterEmail_TextBox.Text + " already exists!";
                }

                return string.Empty;
            }
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
            try
            {
                //if error is null then validation has passed so continue otherwise return the error message. 
                if (string.IsNullOrEmpty(Error.ToString()))
                {
                    viewModel.BindTextboxControls(this, viewModel, _textbox);
                    controller.AddAdministrators(EnterEmail_TextBox.Text, CreateUsername_TextBox.Text, EnterPin_TextBox.Text);
                    MessageBox.Show("Administrator added successfully.", "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    viewModel.DisplayAdministratorEmails(this, controller, model);
                }
                else
                {
                    MessageBox.Show(Error, "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Felicity Security", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
            viewModel.DisplayAdministratorEmails(this, controller, model);
        }

        /// <summary>
        /// Takes the Selected item and returns the parent objects data by querying by that item. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Administrators_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string administratorsEmail = (Administrators_ListBox.SelectedItem as ListboxItem).ItemText;
            viewModel.DisplayAdministratorsDetails(this, administratorsEmail, controller, model);
        }
        #endregion


    }
}