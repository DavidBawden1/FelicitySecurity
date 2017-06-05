﻿using Emgu.CV;
using Emgu.CV.Structure;
using FelicitySecurity.Applications.Config.Controllers;
using FelicitySecurity.Applications.Config.Interfaces;
using FelicitySecurity.Applications.Config.Models;
using FelicitySecurity.Applications.Config.Resources.ImageProcessing;
using FelicitySecurity.Applications.Config.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace FelicitySecurity.Applications.Config.ViewModels
{
    /// <summary>
    /// The Members ViewModel handles data passed to and from controller and view. 
    /// </summary>
    public class MembersViewModel : IMembersViewModel, INotifyPropertyChanged
    {
        #region Declarations 
        public enum CurrentSortingType { Default, Alphabetical }
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
            Binding memberFacialImages = new Binding(ByteArrayOfImageList.ToString(), viewModel, "MemberFacialImages");
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
        #endregion
    }
}