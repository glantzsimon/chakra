using K9.Base.DataAccessLayer.Models;
using K9.SharedLibrary.Helpers;
using K9.SharedLibrary.Models;
using K9.WebApplication.Models;
using K9.WebApplication.Services;
using NLog;
using System;
using System.Web.Mvc;
using K9.WebApplication.Constants;
using K9.WebApplication.Enums;
using K9.WebApplication.Helpers;

namespace K9.WebApplication.Controllers
{
    public class ChakraController : BaseChakraController
    {
        private readonly IAuthentication _authentication;
        private readonly IChakraCodesService _chakraCodesService;

        public ChakraController(ILogger logger, IDataSetsHelper dataSetsHelper, IRoles roles, IAuthentication authentication, IFileSourceHelper fileSourceHelper, IRepository<User> usersRepository, IChakraCodesService chakraCodesService)
            : base(logger, dataSetsHelper, roles, authentication, fileSourceHelper)
        {
            _authentication = authentication;
            _chakraCodesService = chakraCodesService;
        }

        public ActionResult Index()
        {
            var dateOfBirth = new DateTime(DateTime.Now.Year - (27), DateTime.Now.Month, DateTime.Now.Day);
            var personModel = new PersonModel
            {
                DateOfBirth = dateOfBirth
            };
            return View(new ChakraCodesModel(personModel));
        }

        [Route("calculate")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(ChakraCodesModel model)
        {
            if (model.PersonModel != null)
            {
                model = _chakraCodesService.CalculateChakraCodes(model);
            }
            return View("Index", model);
        }

        [Route("calculate-forecast")]
        public JsonResult CalculateForecast(EForecastType forecastType, int offset)
        {
            ChakraCodeForecast result;
            var storedDateOfBirth = SessionHelper.GetDateTimeValue(SessionConstants.DateOfBirth);
            var personModel = new PersonModel(storedDateOfBirth.Value);

            switch (forecastType)
            {
                case EForecastType.Monthly:
                    result = _chakraCodesService.GetMonthlyForecast(personModel, offset);
                    break;

                case EForecastType.Daily:
                    result = _chakraCodesService.GetDailyForecast(personModel, offset);
                    break;

                default:
                    result = _chakraCodesService.GetYearlyForecast(personModel, offset);
                    break;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public override string GetObjectName()
        {
            return string.Empty;
        }
    }
}

