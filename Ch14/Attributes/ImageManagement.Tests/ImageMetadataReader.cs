// Fake test subject to enable Example 1 to compile.
using System;

namespace ImageManagement
{
    public class ImageMetadataReader
    {
        public ImageMetadataReader(string cameraModel)
        {
            if (string.IsNullOrWhiteSpace(cameraModel))
            {
                throw new ArgumentException("Model required", nameof(cameraModel));
            }
            CameraModel = cameraModel;
        }

        public string CameraManufacturer => "Fabrikam";
        public string CameraModel { get; }
    }
}