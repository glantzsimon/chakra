using K9.SharedLibrary.Extensions;
using K9.WebApplication.Attributes;
using K9.WebApplication.Enums;
using K9.WebApplication.Extensions;

namespace K9.WebApplication.Models
{
    public class ChakraCodeForecast
    {
        public EChakraCode ChartCode { get; set; }

        public int TopNumber { get; set; }

        public int BottomNumber { get; set; }
        
        public int? RowNumber { get; set; }

        public string Name => Attributes.Name;
        
        public string Forecast => Attributes.ResourceType.GetValueFromResource(ForecastName) ?? string.Empty;

        public string Title => RowNumber == null ? $"{(int)ChartCode} - {TopNumber}/{BottomNumber}" : $"{(int)ChartCode} - {RowNumber}";

        private int RowNumberCalculated => RowNumber ?? (TopNumber - (int)ChartCode).ToNumerology();

        private string ForecastName => $"_{(int)ChartCode}_{RowNumberCalculated}";

        private ChakraCodeEnumMetaDataAttribute Attributes => ChartCode.GetAttribute<ChakraCodeEnumMetaDataAttribute>();
    }
}