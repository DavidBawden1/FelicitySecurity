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
            MemoryStream fullMemoryStream = new MemoryStream();
            foreach (var facialImage in viewModel.FacialImages)
            {
                MemoryStream individualMemoryStream = new MemoryStream();
                _imageToConvertFromEmguCVToDrawing = facialImage.ToBitmap();
                _imageToConvertFromEmguCVToDrawing.Save(individualMemoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                individualMemoryStream.WriteTo(fullMemoryStream);
            }
            viewModel.ByteArrayOfImageList = fullMemoryStream.ToArray();
        }
    }
}
