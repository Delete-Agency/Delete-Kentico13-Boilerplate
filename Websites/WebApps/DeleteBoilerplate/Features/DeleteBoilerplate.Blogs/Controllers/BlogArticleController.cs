using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.DocumentEngine.Types.DeleteBoilerplate;
using DeleteBoilerplate.Blogs.Controllers;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterPageRoute(BlogArticle.CLASS_NAME, typeof(BlogArticleController))]

namespace DeleteBoilerplate.Blogs.Controllers
{
    public class BlogArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}