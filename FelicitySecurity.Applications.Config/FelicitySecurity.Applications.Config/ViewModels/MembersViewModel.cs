using Emgu.CV;
using Emgu.CV.Structure;
using FelicitySecurity.Applications.Config.Controllers;
using FelicitySecurity.Applications.Config.Interfaces;
using FelicitySecurity.Applications.Config.Models;
using FelicitySecurity.Applications.Config.Resources.Controls;
using FelicitySecurity.Applications.Config.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace FelicitySecurity.Applications.Config.ViewModels
{

    /// <summary>
    /// The Members ViewModel handles data passed to and from controller and view. 
    /// </summary>
    public class MembersViewModel : IMembersViewModel, INotifyPropertyChanged
    {
        #region Declarations 
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
        #region Properties
        public int MemberId { get; set; }

        private string _memberFirstName;
        public string MemberFirstName
        {
            get
            {
                return _memberFirstName;
            }
            set
            {
                OnPropertyChanged("MemberFirstName");
            }
        }

        private string _memberLastName;
        public string MemberLastName
        {
            get
            {
                return _memberLastName;
            }
            set
            {
                OnPropertyChanged("MemberLastName");
            }
        }

        private DateTime _memberDateOfBirth;
        public DateTime MemberDateOfBirth
        {
            get
            {
                return _memberDateOfBirth;
            }
            set
            {
                OnPropertyChanged("MemberDateOfBirth");
            }
        }

        private string _memberPostCode;
        public string MemberPostCode
        {
            get
            {
                return _memberPostCode;
            }
            set
            {
                OnPropertyChanged("MemberPostCode");
            }
        }

        private DateTime _memberDateOfRegistration;
        public DateTime MemberDateOfRegistration
        {
            get
            {
                return _memberDateOfRegistration;
            }
            set
            {
                OnPropertyChanged("MemberRegistrationDate");
            }
        }

        private string _memberPhoneNumber;
        public string MemberPhoneNumber
        {
            get
            {
                return _memberPhoneNumber;
            }
            set
            {
                OnPropertyChanged("MemberPhoneNumber");
            }
        }

        private bool _isPersonARegisteredMember;
        public bool IsPersonARegisteredMember
        {
            get
            {
                return _isPersonARegisteredMember;
            }
            set
            {
                OnPropertyChanged("IsPersonARegisteredMember");
            }
        }

        private bool _isPersonAStaffMember;
        public bool IsPersonAStaffMember
        {
            get
            {
                return _isPersonAStaffMember;
            }
            set
            {
                OnPropertyChanged("IsPersonAStaffMember");
            }
        }

        public List<Image<Gray, byte>> FacialImages = new List<Image<Gray, byte>>();

        private byte[] _memberFacialImages;
        public byte[] MemberFacialImages
        {
            get
            {
                return _memberFacialImages;
            }
            set
            {
                OnPropertyChanged("MemberFacialImages");
            }
        }

        public byte[] ByteArrayOfImageList
        {
            get;
            set;
        }


        #endregion
        #region Constructors
        #endregion
        #region Methods
        public void RegisterMember(MembersController controller, MemberModel model)
        {
            controller.AddMember(model);
        }

        /// <summary>
        /// Passes the new member model to the controller so it can update the old dto
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="model"></param>
        public void UpdateSelectedMember(MembersController controller, MemberModel model)
        {
            controller.UpdateSelectedMember(model);
        }

        /// <summary>
        /// Binds the properties of the viewModel to the controls in 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="viewModel"></param>
        public void BindControls(RegisterMembers_Form form, MembersViewModel viewModel)
        {
            Binding memberFirstNameBinding = new Binding(form.FirstName_Textbox.Text, viewModel, "MemberFirstName");
            Binding memberLastNameBinding = new Binding(form.LastName_Textbox.Text, viewModel, "MemberLastName");
            Binding memberDateOfBirthBinding = new Binding(form.DateOfBirth_DatePicker.Value.ToString(), viewModel, "MemberDateOfBirth");
            Binding memberPostCode = new Binding(form.PostCode_Textbox.Text, viewModel, "MemberPostCode");
            Binding memberDateOfRegistrationBinding = new Binding(form.DateOfRegistration_DatePicker.Value.ToString(), viewModel, "MemberDateOfBirth");
            Binding memberPhoneNumber = new Binding(form.PhoneNumber_Textbox.Text, viewModel, "MemberPhoneNumber");
            Binding isPersonARegisteredMember = new Binding(form.MembershipStatus_Checkbox.Text, viewModel, "IsPersonARegisteredMember");
            Binding isPersonAStaffMember = new Binding(form.StaffStatus_Checkbox.Text, viewModel, "IsPersonAStaffMember");
            MemberFacialImages = ByteArrayOfImageList;
        }

        /// <summary>
        /// checks that the property isnt null then applies the property changed event handler to the property. 
        /// </summary>
        /// <param name="propertyName">the name of the supplied property</param>
        public void OnPropertyChanged(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Populates the Member model with data contained in relevant UI controls
        /// </summary>
        public void PopulateMemberModel(RegisterMembers_Form form, MemberModel model)
        {
            model.MemberFirstName = form.FirstName_Textbox.Text;
            model.MemberLastName = form.LastName_Textbox.Text;
            model.MemberPostCode = form.PostCode_Textbox.Text;
            model.MemberDateOfBirth = form.DateOfBirth_DatePicker.Value;
            model.MemberPhoneNumber = form.PhoneNumber_Textbox.Text;
            model.MemberDateOfRegistration = form.DateOfRegistration_DatePicker.Value;
            model.IsPersonARegisteredMember = form.MembershipStatus_Checkbox.Checked;
            model.IsPersonAStaffMember = form.StaffStatus_Checkbox.Checked;
            model.MemberFacialImages = ByteArrayOfImageList;
        }

        /// <summary>
        /// Returns every members firstname to Listbox
        /// </summary>
        public void DisplayMemberDetailsToListbox(RegisterMembers_Form form, MembersController controller, MemberModel model, CurrentSortingType sortingType)
        {
            form.ExistingMembers_ListBox.Items.Clear();
            model.ListOfMembers.Clear();
            MemberSorting(controller, model, sortingType);
            if (model.ListOfMembers.Count != 0)
            {
                foreach (var member in model.ListOfMembers)
                {
                    ListboxItem memberItem = new ListboxItem();
                    memberItem.Value = member.MemberId;
                    memberItem.ItemText = string.Format(member.MemberFirstName + " " + member.MemberLastName + " " + member.MemberPostCode.ToUpper());
                    form.ExistingMembers_ListBox.Items.Add(memberItem);
                }
            }
            else
            {
                form.ExistingMembers_ListBox.Items.Add("Add a Member");
            }
        }

        /// <summary>
        /// Returns the selected members details to their relevant form fields.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="controller"></param>
        /// <param name="model"></param>
        public void DisplayMemberDetailsToFormControls(RegisterMembers_Form form, MembersController controller, MemberModel model)
        {
            if (model.MemberId > 0)
            {
                var selectedMemberModel = controller.FindAllMembers(model).Where(x => x.MemberId == model.MemberId).FirstOrDefault();
                form.FirstName_Textbox.Text = selectedMemberModel.MemberFirstName;
                form.LastName_Textbox.Text = selectedMemberModel.MemberLastName;
                form.DateOfBirth_DatePicker.Value = selectedMemberModel.MemberDateOfBirth.Date;
                form.PostCode_Textbox.Text = selectedMemberModel.MemberPostCode;
                form.DateOfRegistration_DatePicker.Value = selectedMemberModel.MemberDateOfRegistration.Date;
                form.PhoneNumber_Textbox.Text = selectedMemberModel.MemberPhoneNumber;
                form.MembershipStatus_Checkbox.Checked = selectedMemberModel.IsPersonARegisteredMember;
                form.StaffStatus_Checkbox.Checked = selectedMemberModel.IsPersonAStaffMember;
                MemberFacialImages = selectedMemberModel.MemberFacialImages;
            }
        }

        /// <summary>
        /// Depending on the CurrentSortingType, the list of Members will be sorted with either: Default or Alphabetical. 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="model"></param>
        /// <param name="sortingType">default or alphabetical</param>
        private static void MemberSorting(MembersController controller, MemberModel model, CurrentSortingType sortingType)
        {
            switch (sortingType)
            {
                case CurrentSortingType.Default:
                    controller.FindAllMembers(model);
                    break;
                case CurrentSortingType.Alphabetical:
                    controller.FindAllMembers(model).Sort((x, y) => string.Compare(x.MemberLastName, y.MemberLastName));
                    break;
                default:
                    controller.FindAllMembers(model);
                    break;
            }
        }

        public void DeleteMember(MembersController controller, int memberId)
        {
            if (memberId > 0)
            {
                controller.DeleteMember(memberId);
            }
        }
        #endregion
    }
}
