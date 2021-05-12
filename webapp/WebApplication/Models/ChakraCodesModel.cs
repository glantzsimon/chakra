using System.Collections.Generic;
using System.Linq;
using K9.WebApplication.Enums;

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
        
        public ChakraCodeDetails Guide { get; set; }
        
        public ChakraCodeDetails Gift { get; set; }

        public ChakraCodeDetails BirthYear { get; set; }

        public ChakraCodeDetails CurrentYear { get; set; }

        public List<MonthChakraCodeModel> CurrentYearMonthCodes { get; set; }
        
        public List<DharmaChakraCodeModel> DharmaCodes { get; set; }
        
        public bool IsProcessed { get; set; }

        public DharmaChakraCodeModel FirstDharmaCode => DharmaCodes.FirstOrDefault();

    }
}