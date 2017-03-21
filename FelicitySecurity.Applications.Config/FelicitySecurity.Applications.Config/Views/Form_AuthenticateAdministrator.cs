using System;
using System.Windows.Forms;

namespace FelicitySecurity.Applications.Config.Views
{
    /// <summary>
    /// The Authentication Form requires a user to log in. 
    /// </summary>
    public partial class AuthenticateAdministrators_Form : Form
    {
        #region Declarations 
        #endregion
        #region Properties
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
        #endregion
    }
}
