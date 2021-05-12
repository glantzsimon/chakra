using System;

namespace K9.WebApplication.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ChakraCodeEnumMetaDataAttribute : Attribute
    {
        public Type ResourceType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Colour { get; set; }
    }

}