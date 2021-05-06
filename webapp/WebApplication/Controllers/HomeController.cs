﻿using K9.SharedLibrary.Helpers;
using K9.SharedLibrary.Models;
using NLog;
using System.Web.Mvc;

namespace K9.WebApplication.Controllers
{
    public class HomeController : BaseChakraController
    {
        private readonly IAuthentication _authentication;
       
        public HomeController(ILogger logger, IDataSetsHelper dataSetsHelper, IRoles roles, IAuthentication authentication, IFileSourceHelper fileSourceHelper)
            : base(logger, dataSetsHelper, roles, authentication, fileSourceHelper)
        {
            _authentication = authentication;
        }

        public ActionResult Index()
        {
            //if (_authentication.IsAuthenticated)
            //{
            //    return RedirectToAction("MyProfile", "Chakra");
            //}
            return View();
        }
       
        public override string GetObjectName()
        {
            return string.Empty;
        }
    }
}