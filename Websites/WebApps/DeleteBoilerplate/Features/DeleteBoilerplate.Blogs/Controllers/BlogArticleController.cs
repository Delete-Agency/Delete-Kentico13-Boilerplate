using AutoMapper;
using CMS.DocumentEngine.Types.DeleteBoilerplate;
using DeleteBoilerplate.Blogs.Controllers;
using DeleteBoilerplate.Blogs.Models.BlogArticle;
using DeleteBoilerplate.Infrastructure.Controllers;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterPageRoute(BlogArticle.CLASS_NAME, typeof(BlogArticleController))]

namespace DeleteBoilerplate.Blogs.Controllers
{
    public class BlogArticleController : BaseController
    {
        public BlogArticleController(IMapper mapper, IPageDataContextRetriever pageDataContextRetriever)
      : base(mapper, pageDataContextRetriever)
        {
        }

        public IActionResult Index()
        {
            var blogArticle = GetContextItemViewModel<BlogArticle, BlogArticleViewModel>();
            return View(blogArticle);
        }
    }
}