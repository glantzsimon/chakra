using K9.WebApplication.Enums;

namespace K9.WebApplication.Models
{
    public class ChakraCodeForecast
    {
        public EChakraCode ChartCode { get; set; }

        public int TopNumber { get; set; }

        public int BottomNumber { get; set; }
        
        public int RowNumber { get; set; }
    }
}