using DeleteBoilerplate.WepApp.Controllers;

using CMS.DocumentEngine.Types.DeleteBoilerplate;

using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;

using Microsoft.AspNetCore.Mvc;
using DeleteBoilerplate.Infrastructure.Controllers;
using AutoMapper;

[assembly: RegisterPageRoute(Home.CLASS_NAME, typeof(HomeController), ActionName = "IndexHome")]

namespace DeleteBoilerplate.WepApp.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IMapper mapper, IPageDataContextRetriever pageDataContextRetriever)
            : base(mapper, pageDataContextRetriever)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexHome()
        {
            return View();
        }
    }
}