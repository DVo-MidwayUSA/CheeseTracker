using System.Data.Linq;
using System.IO;

namespace CheeseTracker.Common.Services
{
    public class ImageConverterService : IImageConverterService
    {
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
