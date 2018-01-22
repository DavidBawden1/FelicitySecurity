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
        public void ListOfImagesToByteArray()
        {
            ImageConversions imageConversions = new ImageConversions();
            Applications.Config.ViewModels.MembersViewModel viewModel = new Applications.Config.ViewModels.MembersViewModel();
            System.Collections.Generic.List<Image<Gray, byte>> testImageList = new System.Collections.Generic.List<Image<Gray, byte>>();
            for (int i = 0; i < 20; i++)
            {
                Image<Gray, byte> imageToSave;
                testImageList.Add(imageToSave);
            }
            viewModel.FacialImages = testImageList;
            imageConversions.AppendEachImageToByteArrayOfImageList(viewModel);
        }
    }
}
