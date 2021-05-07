using System;
using K9.WebApplication.Enums;
using K9.WebApplication.Models;
using System.Linq;

namespace K9.WebApplication.Services
{
    public class ChakraCodesService : IChakraCodesService
    {
        public ChakraCodesModel CalculateChakraCodes(ChakraCodesModel model)
        {
            if (model.PersonModel == null)
            {
                return model;
            }

            model.Dominant = CalculateDominant(model.PersonModel.DateOfBirth);
            model.SubDominant = CalculateSubDominant(model.PersonModel.DateOfBirth);

            model.IsProcessed = true;

            return model;
        }

        public ChakraCodeDetails CalculateDominant(DateTime date)
        {
            var result = date.Year + date.Month + date.Day;
            
            while (result >= 10)
            {
                result = result.ToString().Select(e => int.Parse(e.ToString())).Sum();
            }

            return new ChakraCodeDetails
            {
                ChakraCode = (EChakraCode)result
            };
        }

        public ChakraCodeDetails CalculateSubDominant(DateTime date)
        {
            var result = date.Month > 9 ? date.Month - 9 : date.Month;

            return new ChakraCodeDetails
            {
                ChakraCode = (EChakraCode)result
            };
        }
    }
}