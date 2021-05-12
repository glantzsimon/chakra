using K9.SharedLibrary.Extensions;
using K9.WebApplication.Attributes;
using K9.WebApplication.Enums;

namespace K9.WebApplication.Models
{
    public class ChakraCodeDetails
    {
        public EChakraCode ChakraCode { get; set; }

        public bool IsActive { get; set; }

        public string TypeName { get; set; }

        public string Name => Attributes.Name;

        public string Colour => Attributes.Colour;
        
        public int ChakraCodeNumber => (int)ChakraCode;

        private ChakraCodeEnumMetaDataAttribute Attributes => ChakraCode.GetAttribute<ChakraCodeEnumMetaDataAttribute>();

    }
}