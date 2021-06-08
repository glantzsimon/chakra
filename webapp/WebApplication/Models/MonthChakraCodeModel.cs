using K9.WebApplication.Enums;
using System;
using System.Globalization;
using K9.SharedLibrary.Extensions;
using K9.WebApplication.Extensions;

namespace K9.WebApplication.Models
{
    public class MonthChakraCodeModel
    {
        public int MonthNumber { get; set; }

        public EChakraCode ChakraCode { get; set; }

        public int ChakraCodeNumber => (int)ChakraCode;

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public bool IsCurrent => DateTime.Now.IsBetween(StartDate, EndDate);

        public string IsCurrentCssClass => IsCurrent ? "current" : "";

        public string Month => new DateTime(2015, MonthNumber, 1).ToString("MMM", CultureInfo.CreateSpecificCulture("en-US"));
        
        public string PreviousMonth => new DateTime(2015, MonthNumber.Decrement(), 1).ToString("MMM", CultureInfo.CreateSpecificCulture("en-US"));
    }
}