using K9.WebApplication.Models;

namespace K9.WebApplication.Services
{
    public interface IChakraCodesService
    {
        ChakraCodesModel CalculateChakraCodes(ChakraCodesModel model);
    }
}