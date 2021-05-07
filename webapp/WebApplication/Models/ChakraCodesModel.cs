namespace K9.WebApplication.Models
{
    public class ChakraCodesModel
    {
        public ChakraCodesModel()
        {
        }

        public ChakraCodesModel(PersonModel personModel)
        {
            PersonModel = personModel;
        }

        public PersonModel PersonModel { get; set; }

        public ChakraCodeDetails Dominant { get; set; }
        
        public ChakraCodeDetails SubDominant { get; set; }

        public bool IsProcessed { get; set; }
    }
}