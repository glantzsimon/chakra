using K9.WebApplication.Enums;
using System;
using System.Globalization;

namespace K9.WebApplication.Models
{
    public class MonthChakraCodeModel
    {
        public int MonthNumber { get; set; }

        public EChakraCode ChakraCode { get; set; }

        public int ChakraCodeNumber => (int)ChakraCode;

        public string Month => new DateTime(2015, MonthNumber, 1).ToString("MMM", CultureInfo.CreateSpecificCulture("en-US"));
    }
}