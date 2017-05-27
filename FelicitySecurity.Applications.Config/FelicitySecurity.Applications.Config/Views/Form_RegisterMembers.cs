using FelicitySecurity.Applications.Config.Resources.ImageProcessing.CameraFeeds;
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
    public partial class RegisterMembers_Form : Form
    {
        public RegisterMembers_Form()
        {
            InitializeComponent();
        }

        private void CameraFeed_BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CameraFeed cameraFeed = new CameraFeed();
            cameraFeed.RunCameraFeed();
        }

        private void RegisterMembers_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
