using CMS.DocumentEngine;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace DeleteBoilerplate.Infrastructure.Controllers
{
    public class BaseController : Controller
    {
        private readonly IPageDataContextRetriever PageDataContextRetriever;

        public BaseController(IPageDataContextRetriever pageDataContextRetriever)
        {
            this.PageDataContextRetriever = pageDataContextRetriever;
        }

        protected virtual T GetContextItem<T>() where T : TreeNode, new()
        {
            return PageDataContextRetriever.Retrieve<T>().Page;
        }
    }
}
