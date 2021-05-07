using K9.Base.DataAccessLayer.Models;
using K9.SharedLibrary.Helpers;
using K9.SharedLibrary.Models;
using K9.WebApplication.Models;
using K9.WebApplication.Services;
using NLog;
using System;
using System.Web.Mvc;

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

        [Route("calculate")]
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

        public override string GetObjectName()
        {
            return string.Empty;
        }
    }
}

