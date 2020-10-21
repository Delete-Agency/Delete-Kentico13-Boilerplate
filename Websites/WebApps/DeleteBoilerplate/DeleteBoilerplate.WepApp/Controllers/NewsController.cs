using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DeleteBoilerplate;
using DeleteBoilerplate.Infrastructure.Controllers;
using DeleteBoilerplate.WepApp.Controllers;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterPageRoute(NewsPage.CLASS_NAME, typeof(NewsController))]

namespace DeleteBoilerplate.WepApp.Controllers
{
    public class NewsController : BaseController
    {
        private readonly IPageDataContextRetriever PageDataContextRetriever;

        public NewsController(IPageDataContextRetriever pageDataContextRetriever)
            :base(pageDataContextRetriever)
        {
            PageDataContextRetriever = pageDataContextRetriever;
        }

        public IActionResult Index()
        {
            var contentItem = GetContextItem<NewsPage>();
            string title = contentItem.TitleNews;

            return View("Index", title);
        }
    }
}