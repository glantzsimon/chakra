using K9.Base.DataAccessLayer.Enums;
using K9.Base.DataAccessLayer.Extensions;
using K9.Base.Globalisation;
using System;
using System.ComponentModel.DataAnnotations;

namespace K9.WebApplication.Models
{
    public class PersonModel
    {
        public PersonModel()
        {
        }

        public PersonModel(DateTime dateOfBifth)
        {
            DateOfBirth = dateOfBifth;
        }

        [UIHint("Gender")]
        [Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
        public EGender Gender { get; set; }

        [Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.BirthDateLabel)]
        public DateTime DateOfBirth { get; set; }

        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.NameLabel)]
        public string Name { get; set; }
        
        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.LanguageLabel)]
        public string GenderName => Gender.GetLocalisedLanguageName();

        public string GenderPossessivePronoun => Gender == EGender.Male ? "his" : "her";

        public string GenderPronoun => Gender == EGender.Male ? "he" : "she";

        public int YearsOld => GetYearsOld();

        public bool IsAdult() => YearsOld >= 18;
        
        public bool IsSixteenOrOver() => YearsOld >= 16;

        private int GetYearsOld()
        {
            return (DateTime.Now.Year - DateOfBirth.Year) - (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
        }
    }
}