using K9.WebApplication.Enums;
using K9.WebApplication.Models;
using System;
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
            model.Guide = CalculateGuide(model.PersonModel.DateOfBirth);
            model.Gift = CalculateGift(model.PersonModel.DateOfBirth);

            model.IsProcessed = true;

            return model;
        }

        public ChakraCodeDetails CalculateDominant(DateTime date)
        {
            var result = CalculateNumerology(date.Year + date.Month + date.Day);
            
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
                ChakraCode = (EChakraCode)result,
                IsActive = IsActive(date, 0, 27)
            };
        }

        public ChakraCodeDetails CalculateGuide(DateTime date)
        {
         var   result = CalculateNumerology(date.Year);
            
            return new ChakraCodeDetails
            {
                ChakraCode = (EChakraCode)result,
                IsActive = IsActive(date, 27, 54)
            };
        }

        public ChakraCodeDetails CalculateGift(DateTime date)
        {
            var   result = CalculateNumerology(date.Year);
            
            return new ChakraCodeDetails
            {
                ChakraCode = (EChakraCode)result,
                IsActive = IsActive(date, 54, 81)
            };
        }

        private static int CalculateNumerology(int result)
        {
            while (result >= 10)
            {
                result = result.ToString().Select(e => int.Parse(e.ToString())).Sum();
            }

            return result;
        }

        private static bool IsActive(DateTime dateOfBirth, int activeStartYear, int activeEndYear)
        {
            var person = new PersonModel(dateOfBirth);
            var personYearsOld = person.YearsOld >= 81 ? person.YearsOld - 81  : person.YearsOld;
            return personYearsOld >= activeStartYear && personYearsOld < activeEndYear;
        }
    }
}