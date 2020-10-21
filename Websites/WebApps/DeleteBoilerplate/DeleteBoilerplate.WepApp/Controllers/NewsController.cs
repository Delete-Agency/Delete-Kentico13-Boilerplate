using AutoMapper;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DeleteBoilerplate;
using DeleteBoilerplate.Infrastructure.Controllers;
using DeleteBoilerplate.WepApp.Controllers;
using DeleteBoilerplate.WepApp.Models.News;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterPageRoute(NewsPage.CLASS_NAME, typeof(NewsController))]

namespace DeleteBoilerplate.WepApp.Controllers
{
    public class NewsController : BaseController
    {
    

        public NewsController(IPageDataContextRetriever pageDataContextRetriever, IMapper mapper)
            :base(pageDataContextRetriever, mapper)
        {
        }

        public IActionResult Index()
        {
            var model = GetContextItemViewModel<NewsPage, NewsPageViewModel>();
            return View("Index", model);
        }
    }
}