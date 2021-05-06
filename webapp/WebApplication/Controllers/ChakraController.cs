using K9.Base.DataAccessLayer.Models;
using K9.SharedLibrary.Helpers;
using K9.SharedLibrary.Models;
using NLog;
using System.Web.Mvc;

namespace K9.WebApplication.Controllers
{
    public class ChakraController : BaseChakraController
    {
        private readonly IAuthentication _authentication;
        private readonly IRepository<User> _usersRepository;

        public ChakraController(ILogger logger, IDataSetsHelper dataSetsHelper, IRoles roles, IAuthentication authentication, IFileSourceHelper fileSourceHelper, IRepository<User> usersRepository)
            : base(logger, dataSetsHelper, roles, authentication, fileSourceHelper)
        {
            _authentication = authentication;
            _usersRepository = usersRepository;
        }

        [Route("calculate")]
        public ActionResult Index()
        {
            //var dateOfBirth = new DateTime(DateTime.Now.Year - (27), DateTime.Now.Month, DateTime.Now.Day);
            //var personModel = new PersonModel
            //{
            //    DateOfBirth = dateOfBirth,
            //    Gender = Methods.GetRandomGender()
            //};
            //return View(new NineStarKiModel(personModel));
            return View();
        }

        //[Route("calculate")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CalculateCodes(NineStarKiModel model)
        //{
        //    if (model.PersonModel != null)
        //    {
        //        model = _nineStarKiService.CalculateNineStarKiProfile(model.PersonModel);
        //    }
        //    return View("Index", model);
        //}
        
        public override string GetObjectName()
        {
            return string.Empty;
        }
    }
}

