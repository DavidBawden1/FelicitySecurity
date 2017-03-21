using FelicitySecurity.Applications.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FelicitySecurity.Applications.Config.Views
{
    public partial class AuthenticateAdministrators_Form : Form
    {
        public AuthenticateAdministrators_Form()
        {
            InitializeComponent();
        }

        private void RegisterAdministratorButton_Click(object sender, EventArgs e)
        {
       
        }

        private void Back_MenuItem_Click(object sender, EventArgs e)
        {
            InitialiseRegistrationForm();
            CloseThisForm();
        }

        private void CloseThisForm()
        {
            Hide();
        }

        private void InitialiseRegistrationForm()
        {
            RegisterAdministrators_Form registerForm = new RegisterAdministrators_Form();
            registerForm.Show();
        }
    }
}
