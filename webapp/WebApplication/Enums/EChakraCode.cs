using System;
using K9.Globalisation;
using K9.WebApplication.Attributes;

namespace K9.WebApplication.Enums
{
    public enum EChakraCode
    {
        Unspecified,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Pioneer",
            Colour = "Red")]
        Pioneer,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Creative",
            Colour = "Orange")]
        Creative,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Warrior",
            Colour = "Yellow")]
        Warrior,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Heart / Healer",
            Colour = "Green")]
        Healer,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Expression",
            Colour = "Blue")]
        Communicator,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Pioneer",
            Colour = "Red")]
        Seer,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Teacher",
            Colour = "Silver")]
        Teacher,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Mystic",
            Colour = "Gold")]
        Mystic,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Elder / Source",
            Colour = "White")]
        Elder
    }

}