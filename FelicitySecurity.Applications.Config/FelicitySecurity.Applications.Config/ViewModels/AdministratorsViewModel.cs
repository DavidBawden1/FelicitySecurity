using FelicitySecurity.Applications.Config.Controllers;
using FelicitySecurity.Applications.Config.Interfaces;
using System.ComponentModel;
using System.Windows.Forms;
using FelicitySecurity.Applications.Config.Resources.Controls;
using FelicitySecurity.Core.Models;
using System;
using FelicitySecurity.Applications.Config.Views;

namespace FelicitySecurity.Applications.Config.ViewModels
{
    public enum CurrentSortingType { Default, Alphabetical }

    /// <summary>
    /// The View Model for Administrator related views. Implements INotifyPropertyChanged 
    /// </summary>
    public class AdministratorsViewModel : IAdministratorsViewModel, INotifyPropertyChanged
    {
        #region Declarations
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

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
        public void Clear(RegisterAdministrators_Form form)
        {
            form.EnterEmail_TextBox.Clear();
            form.CreateUsername_TextBox.Clear();
            form.EnterPin_TextBox.Clear();
            form.ReEnterPin_TextBox.Clear();
        }

        public void Clear(AuthenticateAdministrators_Form form)
        {
            form.EnterEmail_TextBox.Clear();
            form.EnterPinCode_TextBox.Clear();
        }

        /// <summary>
        /// Binds the textbox values to their relevant properties in the administrators viewmodel. 
        /// </summary>
        /// <param name="form"> The view</param>
        /// <param name="viewModel">The Administrators ViewModel</param>
        /// <param name="textbox"> The Textbox Controls</param>
        public void BindTextboxControls(RegisterAdministrators_Form form, AdministratorsViewModel viewModel, TextBox textbox)
        {
            Binding _emailBinding = new Binding(form.EnterEmail_TextBox.Text, viewModel, "Email");
            Binding _usernameBinding = new Binding(form.CreateUsername_TextBox.Text, viewModel, "Username");
            Binding _pinCodeBinding = new Binding(form.EnterPin_TextBox.Text, viewModel, "PinCode");
            Binding _reEnterPinCodeBinding = new Binding(form.ReEnterPin_TextBox.Text, viewModel, "PinCodeConfirmed");
        }

        /// <summary>
        /// Returns all of the administrators
        /// </summary>
        public void DisplayAdministratorEmails(RegisterAdministrators_Form form, AdministratorsController controller, AdministratorsModel model, CurrentSortingType sortingType)
        {
            //clear the items and the listbox after its been populated to prevent duplicate lists. 
            form.Administrators_ListBox.Items.Clear();
            AdministratorSorting(controller, model, sortingType);
            if (model.ListOfAdministrators.Count != 0)
            {
                foreach (var item in model.ListOfAdministrators)
                {
                    ListboxItem administratorItem = new ListboxItem();
                    administratorItem.Value = item.AdminID;
                    administratorItem.ItemText = item.AdminEmail;
                    form.Administrators_ListBox.Items.Add(administratorItem);
                }
            }
            else
            {
                form.Administrators_ListBox.Items.Add("Add an Administrator");
            }
            model.ListOfAdministrators.Clear();
        }

        /// <summary>
        /// Returns all of the administrators
        /// </summary>
        public void DisplayAdministratorEmails(AuthenticateAdministrators_Form form, AdministratorsController controller, AdministratorsModel model, CurrentSortingType sortingType)
        {
            //clear the items and the listbox after its been populated to prevent duplicate lists. 
            form.Administrators_ListBox.Items.Clear();
            AdministratorSorting(controller, model, sortingType);
            if (model.ListOfAdministrators.Count != 0)
            {
                foreach (var item in model.ListOfAdministrators)
                {
                    ListboxItem administratorItem = new ListboxItem();
                    administratorItem.Value = item.AdminID;
                    administratorItem.ItemText = item.AdminEmail;
                    form.Administrators_ListBox.Items.Add(administratorItem);
                }
            }
            else
            {
                form.Administrators_ListBox.Items.Add("Add an Administrator");
            }
            model.ListOfAdministrators.Clear();
        }

        /// <summary>
        /// Depending on the CurrentSortingType, the list of administrators will be sorted with either: Default or Alphabetical. 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="model"></param>
        /// <param name="sortingType">default or alphabetical</param>
        private static void AdministratorSorting(AdministratorsController controller, AdministratorsModel model, CurrentSortingType sortingType)
        {
            switch (sortingType)
            {
                case CurrentSortingType.Default:
                    controller.AllAdministratorsEmail(model);
                    break;
                case CurrentSortingType.Alphabetical:
                    controller.AllAdministratorsEmail(model).Sort((x, y) => string.Compare(x.AdminEmail, y.AdminEmail));
                    break;
                default:
                    controller.AllAdministratorsEmail(model);
                    break;
            }
        }

        /// <summary>
        /// Displays the Administrators details when an email is selected. 
        /// </summary>
        /// <param name="form">The Register Administrators form. </param>
        /// <param name="email"> The selected Email</param>
        /// <param name="controller">The Administrators controller</param>
        /// <param name="model">The Admininstrators viewModel </param>
        public void DisplayAdministratorsDetails(RegisterAdministrators_Form form, string email, AdministratorsController controller, AdministratorsModel model)
        {
            var administratorsDetails = controller.ReturnAdministratorByEmail(email);
            form.CreateUsername_TextBox.Text = administratorsDetails.AdminName.ToString();
            form.EnterEmail_TextBox.Text = administratorsDetails.AdminEmail.ToString();
        }
        /// <summary>
        /// Displays the Administrators details when an email is selected. 
        /// </summary>
        /// <param name="form">The Register Administrators form. </param>
        /// <param name="email"> The selected Email</param>
        /// <param name="controller">The Administrators controller</param>
        /// <param name="model">The Admininstrators viewModel </param>
        public void DisplayAdministratorsDetails(AuthenticateAdministrators_Form form, string email, AdministratorsController controller, AdministratorsModel model)
        {
            var administratorsEmail = controller.ReturnAdministratorByEmail(email);
            form.EnterEmail_TextBox.Text = administratorsEmail.AdminEmail.ToString();
        }

        /// <summary>
        /// Validates that the supplied credentials are an administrators. 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="email"></param>
        /// <param name="pinCode"></param>
        /// <param name="controller"></param>
        /// <param name="model"></param>
        /// <returns>true if the credentials match. False if not authorized</returns>
        public bool IsPersonAuthorised(AuthenticateAdministrators_Form form, string email, string pinCode, AdministratorsController controller, AdministratorsModel model)
        {
            var authorisedAdministrators = controller.ReturnAdministratorByEmail(email, pinCode);
            if(authorisedAdministrators != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// populates the combobox with the sortying types.  
        /// </summary>
        /// <param name="form"></param>
        public void InitialiseControlDataSources(RegisterAdministrators_Form form)
        {
            form.CurrentSort_ComboBox.DataSource = Enum.GetValues(typeof(CurrentSortingType));
        }

        /// <summary>
        /// populates the combobox with the sortying types.  
        /// </summary>
        /// <param name="form"></param>
        public void InitialiseControlDataSources(AuthenticateAdministrators_Form form)
        {
            form.CurrentSort_ComboBox.DataSource = Enum.GetValues(typeof(CurrentSortingType));
        }
    }
}
