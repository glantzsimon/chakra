using K9.Base.DataAccessLayer.Models;
using K9.Base.Globalisation;
using K9.Base.WebApplication.Config;
using K9.Base.WebApplication.Enums;
using K9.Base.WebApplication.Services;
using K9.SharedLibrary.Helpers;
using K9.SharedLibrary.Models;
using K9.WebApplication.Config;
using NLog;
using System.Web.Mvc;

namespace K9.WebApplication.Controllers
{
    public partial class AccountController : BaseChakraController
    {
        private readonly IRepository<User> _userRepository;
        private readonly ILogger _logger;
        private readonly IAccountService _accountService;
        private readonly IAuthentication _authentication;
        private readonly IFacebookService _facebookService;
        private readonly RecaptchaConfiguration _recaptchaConfig;

        public AccountController(IRepository<User> userRepository, ILogger logger, IMailer mailer, IOptions<WebsiteConfiguration> websiteConfig, IDataSetsHelper dataSetsHelper, IRoles roles, IAccountService accountService, IAuthentication authentication, IFileSourceHelper fileSourceHelper, IFacebookService facebookService, IOptions<RecaptchaConfiguration> recaptchaConfig)
            : base(logger, dataSetsHelper, roles, authentication, fileSourceHelper)
        {
            _userRepository = userRepository;
            _logger = logger;
            _accountService = accountService;
            _authentication = authentication;
            _facebookService = facebookService;
            _recaptchaConfig = recaptchaConfig.Value;
        }

        #region Membership
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Login(UserAccount.LoginModel model)
        {
            if (ModelState.IsValid)
            {
                switch (_accountService.Login(model.UserName, model.Password, model.RememberMe))
                {
                    case ELoginResult.Success:
                        return Json("OK");

                    case ELoginResult.AccountLocked:
                        return Json("Locked");
                            
                    default:
                        ModelState.AddModelError("", Dictionary.UsernamePasswordIncorrectError);
                        break;
                }
            }
            else
            {
                ModelState.AddModelError("", Dictionary.UsernamePasswordIncorrectError);
            }

            return Json(model);
        }
        
        #endregion

        #region Helpers

        public override string GetObjectName()
        {
            return typeof(User).Name;
        }

        #endregion

    }
}