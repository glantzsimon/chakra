using K9.SharedLibrary.Extensions;
using K9.WebApplication.Attributes;
using K9.WebApplication.Enums;

namespace K9.WebApplication.Models
{
    public class ChakraCodeForecast
    {
        public EChakraCode ChartCode { get; set; }

        public int TopNumber { get; set; }

        public int BottomNumber { get; set; }
        
        public int RowNumber { get; set; }

        public string Name => Attributes.Name;

        private ChakraCodeEnumMetaDataAttribute Attributes => ChartCode.GetAttribute<ChakraCodeEnumMetaDataAttribute>();
    }
}