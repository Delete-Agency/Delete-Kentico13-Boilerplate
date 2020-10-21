using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DeleteBoilerplate;
using DeleteBoilerplate.WepApp.Controllers;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterPageRoute(NewsPage.CLASS_NAME, typeof(NewsController))]

namespace DeleteBoilerplate.WepApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly IPageDataContextRetriever PageDataContextRetriever;

        public NewsController(IPageDataContextRetriever pageDataContextRetriever)
        {
            PageDataContextRetriever = pageDataContextRetriever;
        }

        public IActionResult Index()
        {
            var contentItem = PageDataContextRetriever.Retrieve<TreeNode>().Page;

            var contentNews = PageDataContextRetriever.Retrieve<NewsPage>().Page;

            return View();
        }
    }
}