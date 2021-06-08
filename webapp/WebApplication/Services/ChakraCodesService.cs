using K9.WebApplication.Enums;
using K9.WebApplication.Extensions;
using K9.WebApplication.Models;
using System;
using System.Collections.Generic;
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
            model.CurrentYearMonthCodes = CalculateMonthChakraCodes(model.PersonModel);
            model.DharmaCodes = CalculateDharmaCodes(model.PersonModel);

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
                TypeName = "Birth Year"
            };
        }

        public ChakraCodeDetails CalculateCurrentYear(PersonModel person)
        {
            var result = CalculateBirthYear(person).ChakraCode;

            result = (EChakraCode)(((int)result + person.YearsOld) % 9);

            if (result == 0)
            {
                result++;
            }

            var yearEndDate = GetYearEndDate(result);
            if (yearEndDate < DateTime.Today)
            {
                result = result.Increment();
            }

            return new ChakraCodeDetails
            {
                ChakraCode = result,
                TypeName = "Current Year",
                StartDate = GetYearStartDate(result),
                EndDate = GetYearEndDate(result),
                ShowDates = true
            };
        }

        public List<MonthChakraCodeModel> CalculateMonthChakraCodes(PersonModel person)
        {
            var items = new List<MonthChakraCodeModel>();
            var yearEnergy = CalculateCurrentYear(person);
            var monthEnergy = yearEnergy.ChakraCodeNumber - 6;

            monthEnergy = monthEnergy < 1 ? (9 + monthEnergy) : monthEnergy;

            for (int i = 0; i < 12; i++)
            {
                var monthNumber = i + 1;

                items.Add(new MonthChakraCodeModel
                {
                    ChakraCode = (EChakraCode)monthEnergy,
                    MonthNumber = monthNumber,
                    StartDate = GetMonthStartDate((EChakraCode)monthEnergy, monthNumber),
                    EndDate = GetMonthEndDate((EChakraCode)monthEnergy, monthNumber)
                });

                monthEnergy = monthEnergy.Increment();
            }

            return items;
        }

        public List<DharmaChakraCodeModel> CalculateDharmaCodes(PersonModel person)
        {
            var items = new List<DharmaChakraCodeModel>();
            var age = 0;
            var year = person.DateOfBirth.Year;
            var yearEnergy = CalculateBirthYear(person).ChakraCodeNumber;

            for (int i = 0; i < 100; i++)
            {
                items.Add(new DharmaChakraCodeModel
                {
                    Age = age,
                    Year = year,
                    ChakraCode = (EChakraCode)yearEnergy
                });

                age++;
                year++;
                yearEnergy = yearEnergy.Increment();
            }

            // Get first 9
            var skip = 0;
            var dharmaBaseCode = 9;
            var code = items.First(e => e.ChakraCodeNumber == 9);

            age = code.Age;

            while (age >= 0)
            {
                code = items.First(e => e.Age == age);
                code.DharmaChakraBaseCode = (EChakraCode)dharmaBaseCode;

                if (skip >= 1)
                {
                    dharmaBaseCode = dharmaBaseCode.Decrement();
                    skip = 0;
                }
                else
                {
                    skip++;
                }

                age--;
            }

            // Get those after 9 
            code = items.First(e => e.ChakraCodeNumber == 9);
            age = code.Age + 1;
            dharmaBaseCode = 1;
            skip = 0;

            while (age < 100)
            {
                code = items.First(e => e.Age == age);
                code.DharmaChakraBaseCode = (EChakraCode)dharmaBaseCode;

                if (skip >= 1)
                {
                    dharmaBaseCode = dharmaBaseCode.Increment();
                    skip = 0;
                }
                else
                {
                    skip++;
                }

                age++;
            }

            // Calculate Dharma Codes
            var birthCode = items.First(e => e.Age == 0);
            var groupCode = birthCode.DharmaChakraBaseCode.Decrement();
            var dharmaCode = (int)groupCode;

            code = items.First(e => e.ChakraCodeNumber == 9);
            age = code.Age;

            while (age >= 0)
            {
                code = items.First(e => e.Age == age);
                code.DharmaChakraCode = (EChakraCode)dharmaCode;
                code.DharmaGroupChakraCode = groupCode;

                if (skip >= 1)
                {
                    dharmaCode = dharmaCode.Decrement();
                    skip = 0;
                }
                else
                {
                    skip++;
                }

                age--;
            }

            // Get remaining dharma codes
            code = items.First(e => e.ChakraCodeNumber == 9);
            var y = 1;
            while (code != null)
            {
                code = items.First(e => e.ChakraCodeNumber == 9);
                groupCode = groupCode.Increment();
                dharmaCode = (int)groupCode;
                age = code.Age + (18 * y);
                skip = 0;

                for (int i = 0; i < 18; i++)
                {
                    code = items.FirstOrDefault(e => e.Age == age - i);
                    if (code != null)
                    {
                        code.DharmaChakraCode = (EChakraCode)dharmaCode;
                        code.DharmaGroupChakraCode = groupCode;
                    }

                    if (skip >= 1)
                    {
                        dharmaCode = dharmaCode.Decrement();
                        skip = 0;
                    }
                    else
                    {
                        skip++;
                    }
                }

                y++;
            }

            return items;
        }

        private DateTime GetMonthStartDate(EChakraCode energy, int month)
        {
            var firstOfMonth = new DateTime(DateTime.Now.Year, month, 1);
            var previousMonth = firstOfMonth.AddMonths(-1);

            switch (energy)
            {
                case EChakraCode.Pioneer:
                case EChakraCode.Akashic:
                    return new DateTime(previousMonth.Year, previousMonth.Month, 27);

                case EChakraCode.Peacemaker:
                case EChakraCode.Manifestor:
                case EChakraCode.Royal:
                case EChakraCode.Elder:
                    return new DateTime(previousMonth.Year, previousMonth.Month, 28).AddDays(1);

                case EChakraCode.Warrior:
                    return new DateTime(previousMonth.Year, previousMonth.Month, 23);

                case EChakraCode.Healer:
                    return new DateTime(previousMonth.Year, previousMonth.Month, 17);

                case EChakraCode.Mystic:
                    return new DateTime(previousMonth.Year, previousMonth.Month, 18);

                default:
                    return firstOfMonth;
            }
        }

        private DateTime GetMonthEndDate(EChakraCode energy, int month)
        {
            var firstOfMonth = new DateTime(DateTime.Now.Year, month, 1);
            var previousMonth = firstOfMonth.AddMonths(-1);

            switch (energy)
            {
                case EChakraCode.Pioneer:
                case EChakraCode.Akashic:
                case EChakraCode.Manifestor:
                case EChakraCode.Mystic:
                    return new DateTime(firstOfMonth.Year, firstOfMonth.Month, 28).AddDays(1);

                case EChakraCode.Peacemaker:
                    return new DateTime(firstOfMonth.Year, firstOfMonth.Month, 23);

                case EChakraCode.Warrior:
                    return new DateTime(firstOfMonth.Year, firstOfMonth.Month, 17);

                case EChakraCode.Healer:
                case EChakraCode.Elder:
                    return new DateTime(firstOfMonth.Year, firstOfMonth.Month, 27);

                case EChakraCode.Royal:
                    return new DateTime(firstOfMonth.Year, firstOfMonth.Month, 18);

                default:
                    return firstOfMonth;
            }
        }

        private DateTime GetYearStartDate(EChakraCode energy)
        {
            var firstOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            var previousYear = firstOfYear.AddYears(-1);

            switch (energy)
            {
                case EChakraCode.Pioneer:
                case EChakraCode.Akashic:
                    return new DateTime(previousYear.Year, 11, 15);

                case EChakraCode.Peacemaker:
                case EChakraCode.Manifestor:
                case EChakraCode.Royal:
                case EChakraCode.Elder:
                    return new DateTime(previousYear.Year, 12, 15);

                case EChakraCode.Warrior:
                    return new DateTime(previousYear.Year, 10, 1);

                case EChakraCode.Healer:
                    return new DateTime(previousYear.Year, 07, 18);

                case EChakraCode.Mystic:
                    return new DateTime(previousYear.Year, 07, 22);
                
                default:
                    return firstOfYear;
            }
        }

        private DateTime GetYearEndDate(EChakraCode energy)
        {
            var firstOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            
            switch (energy)
            {
                
                case EChakraCode.Pioneer:
                case EChakraCode.Akashic:
                case EChakraCode.Manifestor:
                case EChakraCode.Mystic:
                    return new DateTime(firstOfYear.Year, 12, 15);

                case EChakraCode.Peacemaker:
                    return new DateTime(firstOfYear.Year, 10, 1);

                case EChakraCode.Warrior:
                    return new DateTime(firstOfYear.Year, 07, 18);

                case EChakraCode.Royal:
                    return new DateTime(firstOfYear.Year, 07, 22);

                case EChakraCode.Healer:
                case EChakraCode.Elder:
                    return new DateTime(firstOfYear.Year, 11, 15);
                
                default:
                    return firstOfYear;
            }
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