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
            Colour = "#833135")]
        Pioneer,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Peacemaker",
            Description = "Peacemaker",
            Colour = "#d68258")]
        Peacemaker,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Warrior",
            Description = "Warrior",
            Colour = "#e3c570")]
        Warrior,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Healer",
            Description = "Heart / Healer",
            Colour = "#496553")]
        Healer,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Akashic",
            Description = "Akashic Generator",
            Colour = "#1e506d")]
        Akashic,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Manifestor",
            Description = "Manifestor",
            Colour = "#4a4d69")]
        Manifestor,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Royal",
            Description = "Royal",
            Colour = "#f2e9e4")]
        Royal,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Mystic",
            Description = "Mystic",
            Colour = "#c6a671")]
        Mystic,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Elder",
            Description = "Elder / Source",
            Colour = "#e5e5e5")]
        Elder
    }

}