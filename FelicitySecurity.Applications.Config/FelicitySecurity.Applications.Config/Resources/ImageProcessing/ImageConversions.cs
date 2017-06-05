using Emgu.CV;
using Emgu.CV.Structure;
using FelicitySecurity.Applications.Config.ViewModels;
using System.IO;

namespace FelicitySecurity.Applications.Config.Resources.ImageProcessing
{
    /// <summary>
    /// Converts images from EmguCV Types to Drawing.Image types
    /// Appends those images to byte arrays.
    /// </summary>
    public class ImageConversions
    {
        private System.Drawing.Image _imageToConvertFromEmguCVToDrawing;

        /// <summary>
        /// Appends each image within FacialImages list to the byte array
        /// </summary>
        public void AppendEachImageToByteArrayOfImageList(MembersViewModel viewModel)
        {
            ImageConversions imageConversion = new ImageConversions();
            foreach (var facialImage in viewModel.FacialImages)
            {
                viewModel.ByteArrayOfImageList = imageConversion.ConvertImageToByteArray(facialImage);
            }
        }

        /// <summary>
        /// Converts the EmguCV.image to an system.drawing.image and then writes it to a byte array.
        /// </summary>
        /// <param name="facialImage"></param>
        /// <returns> byte array of images</returns>
        public byte[] ConvertImageToByteArray(Image<Gray, byte> facialImage)
        {
            MemoryStream memoryStream = new MemoryStream();
            _imageToConvertFromEmguCVToDrawing = facialImage.ToBitmap();
            _imageToConvertFromEmguCVToDrawing.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            return memoryStream.ToArray();
        }
    }
}
