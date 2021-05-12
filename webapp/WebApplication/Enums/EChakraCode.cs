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
            Colour = "Red")]
        Pioneer,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Creative",
            Description = "Creative",
            Colour = "Orange")]
        Creative,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Warrior",
            Description = "Warrior",
            Colour = "Yellow")]
        Warrior,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Healer",
            Description = "Heart / Healer",
            Colour = "Green")]
        Healer,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Communicator",
            Description = "Communicator / Expression",
            Colour = "Blue")]
        Communicator,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Seer",
            Description = "Seer",
            Colour = "Purple")]
        Seer,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Teacher",
            Description = "Teacher",
            Colour = "Silver")]
        Teacher,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Mystic",
            Description = "Mystic",
            Colour = "Gold")]
        Mystic,
        [ChakraCodeEnumMetaData(ResourceType = typeof(Dictionary),
            Name = "Elder",
            Description = "Elder / Source",
            Colour = "White")]
        Elder
    }

}