using System.IO;

namespace CheeseTracker.Common.Services
{
    public interface IImageConverterService
    {
        string Convert(Stream stream);
    }
}
