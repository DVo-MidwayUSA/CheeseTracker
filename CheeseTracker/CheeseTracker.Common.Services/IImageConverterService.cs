using System.Data.Linq;
using System.IO;

namespace CheeseTracker.Common.Services
{
    public interface IImageConverterService
    {
        Binary ConvertToBinary(Stream stream);
    }
}
