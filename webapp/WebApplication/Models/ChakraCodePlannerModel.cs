using K9.SharedLibrary.Extensions;
using K9.WebApplication.Enums;
using System;

namespace K9.WebApplication.Models
{
    public class ChakraCodePlannerModel
    {
        public EChakraCode ChakraCode { get; set; }

        public int ChakraCodeNumber => (int)ChakraCode;

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public bool IsCurrent => DateTime.Now.IsBetween(StartDate, EndDate);

        public string Title => $"{StartDate.Year - EndDate.Year}";

        public string IsCurrentCssClass => IsCurrent ? "current" : "";
    }
}