using System.IO;

namespace CheeseTracker.Common.Services
{
    public class ImageConverterService : IImageConverterService
    {
        public string Convert(Stream stream)
        {
            return "image";
        }
    }
}
