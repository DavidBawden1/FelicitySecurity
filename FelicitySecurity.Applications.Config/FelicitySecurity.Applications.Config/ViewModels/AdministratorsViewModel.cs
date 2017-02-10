using FelicitySecurity.Applications.Config.Controllers;
using FelicitySecurity.Applications.Config.Interfaces;
using System.ComponentModel;
using System.Windows.Forms;
using FelicitySecurity.Applications.Config.Resources.Controls;
using FelicitySecurity.Core.Models;

namespace FelicitySecurity.Applications.Config.ViewModels
{
    /// <summary>
    /// The View Model for Administrator related views. Implements INotifyPropertyChanged 
    /// </summary>
    public class AdministratorsViewModel : IAdministratorsViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Properties 
        private int _adminId;
        public int AdminID { get; set; }
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
               
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        private string _pinCode;
        public string PinCode
        {
            get
            {
                return _pinCode;
            }
            set
            {
                _pinCode = value;
                OnPropertyChanged("PinCode");
            }
        }
        private string _pinCodeConfirmed;
        public string PinCodeConfirmed
        {
            get
            {
                return _pinCodeConfirmed;
            }
            set
            {
                _pinCodeConfirmed = value;
                OnPropertyChanged("PinCodeConfirmed");
            }
        }

        #endregion
        /// <summary>
        /// checks that the property isnt null then applies the property changed event handler to the property. 
        /// </summary>
        /// <param name="propertyName">the name of the supplied property</param>
        public void OnPropertyChanged(string propertyName)
        {
            if(string.IsNullOrEmpty(propertyName))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Clears the Textboxes of all data entered by the user. 
        /// </summary>
        public void Clear(RegisterAdministratorsForm form)
        {
            form.EnterEmail_TextBox.Clear();
            form.CreateUsername_TextBox.Clear();
            form.EnterPin_TextBox.Clear();
            form.ReEnterPin_TextBox.Clear();
        }

        /// <summary>
        /// Binds the textbox values to their relevant properties in the administrators viewmodel. 
        /// </summary>
        /// <param name="form"> The view</param>
        /// <param name="viewModel">The Administrators ViewModel</param>
        /// <param name="textbox"> The Textbox Controls</param>
        public void BindTextboxControls(RegisterAdministratorsForm form, AdministratorsViewModel viewModel, TextBox textbox)
        {
            Binding _emailBinding = new Binding(form.EnterEmail_TextBox.Text, viewModel, "Email");
            Binding _usernameBinding = new Binding(form.CreateUsername_TextBox.Text, viewModel, "Username");
            Binding _pinCodeBinding = new Binding(form.EnterPin_TextBox.Text, viewModel, "PinCode");
            Binding _reEnterPinCodeBinding = new Binding(form.ReEnterPin_TextBox.Text, viewModel, "PinCodeConfirmed");
        }

        /// <summary>
        /// Returns all of the administrators
        /// </summary>
        public void DisplayAdministratorEmails(RegisterAdministratorsForm form, AdministratorsController controller, AdministratorsModel model)
        {
            //clear the items and the listbox after its been populated to prevent duplicate lists. 
            form.Administrators_ListBox.Items.Clear();
            controller.AllAdministratorsEmail(model);

            foreach (var item in model.ListOfAdministrators)
            {
                ListboxItem administratorItem = new ListboxItem();
                administratorItem.Value = item.AdminID;
                administratorItem.ItemText = item.AdminEmail;
                form.Administrators_ListBox.Items.Add(administratorItem);
            }
            model.ListOfAdministrators.Clear();
        }

        /// <summary>
        /// Displays the Administrators details when an email is selected. 
        /// </summary>
        /// <param name="form">The Register Administrators form. </param>
        /// <param name="email"> The selected Email</param>
        /// <param name="controller">The Administrators controller</param>
        /// <param name="model">The Admininstrators viewModel </param>
        public void DisplayAdministratorsDetails(RegisterAdministratorsForm form, string email, AdministratorsController controller, AdministratorsModel model)
        {
            var administratorsDetails = controller.ReturnAdministratorByEmail(email);
            form.CreateUsername_TextBox.Text = administratorsDetails.AdminName.ToString();
            form.EnterEmail_TextBox.Text = administratorsDetails.AdminEmail.ToString();
        }
    }
}
