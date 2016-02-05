using System;
using System.Data.Linq;
using System.IO;

namespace CheeseTracker.Common.Services
{
    public class ImageConverterService : IImageConverterService
    {
        public string ConvertToBase64(Binary binary)
        {
            return Convert.ToBase64String(binary.ToArray());
        }

        public Binary ConvertToBinary(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
