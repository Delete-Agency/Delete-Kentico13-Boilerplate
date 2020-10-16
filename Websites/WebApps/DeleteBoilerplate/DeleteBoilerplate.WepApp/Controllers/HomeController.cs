using DeleteBoilerplate.WepApp.Controllers;

using CMS.DocumentEngine.Types.DeleteBoilerplate;

using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;

using Microsoft.AspNetCore.Mvc;

[assembly: RegisterPageRoute(HomePage.CLASS_NAME, typeof(HomeController))]

namespace DeleteBoilerplate.WepApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}