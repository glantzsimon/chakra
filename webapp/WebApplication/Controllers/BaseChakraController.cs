using K9.Base.WebApplication.Controllers;
using K9.SharedLibrary.Helpers;
using K9.SharedLibrary.Models;
using NLog;

namespace K9.WebApplication.Controllers
{
    public class BaseChakraController : BaseController
    {

        public BaseChakraController(ILogger logger, IDataSetsHelper dataSetsHelper, IRoles roles,
            IAuthentication authentication, IFileSourceHelper fileSourceHelper)
            : base(logger, dataSetsHelper, roles, authentication, fileSourceHelper)
        {
        }

        public override string GetObjectName()
        {
            return string.Empty;
        }

    }
}
