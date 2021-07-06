using K9.Globalisation;
using K9.WebApplication.Attributes;

namespace K9.WebApplication.Enums
{
    public enum EChakraCode
    {
        Unspecified,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Pioneer",
            Description = "Pioneer",
            Colour = "#833135",
            Purpose = "To pioneer")]
        Pioneer,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Peacemaker",
            Description = "Peacemaker",
            Colour = "#d68258",
            Purpose = "To bring together and create harmony")]
        Peacemaker,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Warrior",
            Description = "Warrior",
            Colour = "#e3c570",
            Purpose = "To transform")]
        Warrior,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Healer",
            Description = "Heart / Healer",
            Colour = "#496553",
            Purpose = "To heal")]
        Healer,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Akashic",
            Description = "Akashic Generator",
            Colour = "#1e506d",
            Purpose = "To express")]
        Akashic,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Manifestor",
            Description = "Manifestor",
            Colour = "#4a4d69",
            Purpose = "To manifest")]
        Manifestor,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Royal",
            Description = "Royal",
            Colour = "#f2e9e4",
            Purpose = "To teach")]
        Royal,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Mystic",
            Description = "Mystic",
            Colour = "#c6a671",
            Purpose = "To reveal")]
        Mystic,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Elder",
            Description = "Elder / Source",
            Colour = "#e5e5e5",
            Purpose = "To be of service")]
        Elder
    }

}