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
        
        public int? RowNumber { get; set; }

        public string Name => Attributes.Name;
        
        public string Forecast => Attributes.ResourceType.GetValueFromResource(ForecastName);

        private int RowNumberCalculated => RowNumber ?? TopNumber - (int)ChartCode;

        private string ForecastName => $"_{ChartCode}_{RowNumberCalculated}";

        private ChakraCodeEnumMetaDataAttribute Attributes => ChartCode.GetAttribute<ChakraCodeEnumMetaDataAttribute>();
    }
}