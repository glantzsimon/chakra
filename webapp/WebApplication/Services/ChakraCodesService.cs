using K9.WebApplication.Models;

namespace K9.WebApplication.Services
{
    public class ChakraCodesService : IChakraCodesService
    {
        public ChakraCodesModel CalculateChakraCodes(ChakraCodesModel model)
        {
            return new ChakraCodesModel(new PersonModel());
        }
    }
}