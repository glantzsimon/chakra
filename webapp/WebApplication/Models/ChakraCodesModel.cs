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
    }
}