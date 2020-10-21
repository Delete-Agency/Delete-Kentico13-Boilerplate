﻿using DeleteBoilerplate.WepApp.Controllers;

using CMS.DocumentEngine.Types.DeleteBoilerplate;

using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;

using Microsoft.AspNetCore.Mvc;
using DeleteBoilerplate.Infrastructure.Controllers;

[assembly: RegisterPageRoute(Home.CLASS_NAME, typeof(HomeController))]

namespace DeleteBoilerplate.WepApp.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IPageDataContextRetriever pageDataContextRetriever)
            :base (pageDataContextRetriever)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}