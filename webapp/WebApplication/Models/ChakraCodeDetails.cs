using K9.SharedLibrary.Extensions;
using K9.WebApplication.Attributes;
using K9.WebApplication.Enums;
using System;

namespace K9.WebApplication.Models
{
    public class ChakraCodeDetails
    {
        public EChakraCode ChakraCode { get; set; }

        public bool IsActive { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool ShowDates { get; set; }

        public string Title { get; set; }

        public bool IsCurrent => DateTime.Now.IsBetween(StartDate, EndDate);

        public string IsCurrentCssClass => IsCurrent ? "current" : "";

        public string Name => Attributes?.Name;

        public string Colour => Attributes?.Colour;

        public string Purpose => Attributes?.Purpose;

        public string Description => Attributes?.DescriptionText;

        public int ChakraCodeNumber => (int)ChakraCode;

        private ChakraCodeEnumMetaDataAttribute Attributes => ChakraCode.GetAttribute<ChakraCodeEnumMetaDataAttribute>();

    }
}