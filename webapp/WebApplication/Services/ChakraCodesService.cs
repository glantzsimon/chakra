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
            model.BirthYear = CalculateBirthYear(model.PersonModel);
            model.CurrentYear = CalculateCurrentYear(model.PersonModel);

            model.IsProcessed = true;

            return model;
        }

        public ChakraCodeDetails CalculateDominant(DateTime date)
        {
            var result = CalculateNumerology(date.Year + date.Month + date.Day);

            return new ChakraCodeDetails
            {
                ChakraCode = (EChakraCode)result,
                TypeName = "Dominant"
            };
        }

        public ChakraCodeDetails CalculateSubDominant(DateTime date)
        {
            var result = date.Month > 9 ? date.Month - 9 : date.Month;

            return new ChakraCodeDetails
            {
                ChakraCode = (EChakraCode)result,
                IsActive = IsActive(date, 0, 27),
                TypeName = "Sub Dominant"
            };
        }

        public ChakraCodeDetails CalculateGuide(DateTime date)
        {
            var result = CalculateNumerology(date.Day);

            return new ChakraCodeDetails
            {
                ChakraCode = (EChakraCode)result,
                IsActive = IsActive(date, 27, 54),
                TypeName = "Guide"
            };
        }

        public ChakraCodeDetails CalculateGift(DateTime date)
        {
            var result = CalculateNumerology(date.Year);

            return new ChakraCodeDetails
            {
                ChakraCode = (EChakraCode)result,
                IsActive = IsActive(date, 54, 81),
                TypeName = "Gift"
            };
        }

        public ChakraCodeDetails CalculateBirthYear(PersonModel person)
        {
            var result = CalculateDominant(person.DateOfBirth).ChakraCode;

            result = result == EChakraCode.Elder ? EChakraCode.Pioneer : result + 1;

            return new ChakraCodeDetails
            {
                ChakraCode = result,
                TypeName = "CurrentYear"
            };
        }

        public ChakraCodeDetails CalculateCurrentYear(PersonModel person)
        {
            var result = CalculateBirthYear(person).ChakraCode;

            result = (EChakraCode)(((int)result + person.YearsOld + 1) % 9);
            
            return new ChakraCodeDetails
            {
                ChakraCode = result,
                TypeName = "CurrentYear"
            };
        }

        private static int CalculateNumerology(int value)
        {
            var result = 0;
            while (result >= 10 || result == 0)
            {
                if (result == 0)
                {
                    result = value;
                }
                result = result.ToString().Select(e => int.Parse(e.ToString())).Sum();
            }

            return result;
        }

        private static bool IsActive(DateTime dateOfBirth, int activeStartYear, int activeEndYear)
        {
            var person = new PersonModel(dateOfBirth);
            var personYearsOld = person.YearsOld >= 81 ? person.YearsOld - 81 : person.YearsOld;
            return personYearsOld >= activeStartYear && personYearsOld < activeEndYear;
        }
    }
}