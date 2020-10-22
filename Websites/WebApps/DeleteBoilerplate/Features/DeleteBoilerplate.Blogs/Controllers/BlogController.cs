using AutoMapper;
using CMS.DocumentEngine.Types.DeleteBoilerplate;
using DeleteBoilerplate.Blogs.Controllers;
using DeleteBoilerplate.Infrastructure.Controllers;
using DeleteBoilerplate.Blogs.Models.Blog;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using CMS.DocumentEngine;

[assembly: RegisterPageRoute(Blog.CLASS_NAME, typeof(BlogController))]

namespace DeleteBoilerplate.Blogs.Controllers
{
    public class BlogController : BaseController
    {
        public BlogController(IMapper mapper, IPageDataContextRetriever pageDataContextRetriever)
            : base(mapper, pageDataContextRetriever)
        {
        }

        public IActionResult Index()
        {
            var node = PageDataContextRetriever.Retrieve<TreeNode>().Page;
            var blog = PageDataContextRetriever.Retrieve<Blog>().Page;

            return View();
        }
    }
}
