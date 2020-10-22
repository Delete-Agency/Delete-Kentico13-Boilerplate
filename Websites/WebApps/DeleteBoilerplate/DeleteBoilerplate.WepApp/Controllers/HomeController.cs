using DeleteBoilerplate.WepApp.Controllers;

using CMS.DocumentEngine.Types.DeleteBoilerplate;

using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;

using Microsoft.AspNetCore.Mvc;
using DeleteBoilerplate.Infrastructure.Controllers;
using CMS.DocumentEngine;
using AutoMapper;

[assembly: RegisterPageRoute(Home.CLASS_NAME, typeof(HomeController))]

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

        //public IActionResult IndexBlog()
        //{

        //    var node = PageDataContextRetriever.Retrieve<TreeNode>().Page;
        //    var blog = PageDataContextRetriever.Retrieve<Blog>().Page;

        //    return View("Index");
        //}
    }
}