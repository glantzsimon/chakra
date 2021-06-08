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

        public List<DharmaChakraCodeModel> DharmaCodesFoundation => DharmaCodes.Where(e => e.Age < 27).ToList();
        
        public List<DharmaChakraCodeModel> DharmaCodesContribution => DharmaCodes.Where(e => e.Age >= 27 && e.Age < 54).ToList();
        
        public List<DharmaChakraCodeModel> DharmaCodesAscension => DharmaCodes.Where(e => e.Age >= 54 && e.Age < 81).ToList();
        
        public List<DharmaChakraCodeModel> DharmaCodesElders => DharmaCodes.Where(e => e.Age >= 81 && e.Age < 108).ToList();

        public DharmaChakraCodeModel FirstDharmaCode => DharmaCodes.FirstOrDefault();

    }
}