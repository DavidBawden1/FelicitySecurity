using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FelicitySecurity.Applications.Config.Resources.ImageProcessing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FelicitySecurity.ImageProcessing.UnitTests
{
    [TestClass]
    public class ImageProcessingUnitTests
    {
        [TestMethod]
        public void CameraTakesUniqueImages()
        {
            ImageConversions imageConversions = new ImageConversions();
            Applications.Config.ViewModels.MembersViewModel viewModel = new Applications.Config.ViewModels.MembersViewModel();
            System.Collections.Generic.List<Image<Gray, byte>> testImageList = new System.Collections.Generic.List<Image<Gray, byte>>();

            viewModel.FacialImages = testImageList;
            imageConversions.AppendEachImageToByteArrayOfImageList(viewModel);
        }
    }
}
