using AutoMapper;
using CMS.DocumentEngine;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace DeleteBoilerplate.Infrastructure.Controllers
{
    public class BaseController : Controller
    {
        private readonly IMapper Mapper;

        private readonly IPageDataContextRetriever PageDataContextRetriever;

        public BaseController(IPageDataContextRetriever pageDataContextRetriever, IMapper mapper)
        {
            this.PageDataContextRetriever = pageDataContextRetriever;
            this.Mapper = mapper;
        }

        protected virtual TPageType GetContextItem<TPageType>() where TPageType : TreeNode, new()
        {
            return PageDataContextRetriever.Retrieve<TPageType>().Page;
        }

        protected virtual TViewModel GetContextItemViewModel<TPageType, TViewModel>() where TPageType : TreeNode, new()
        {
            var contentItem = GetContextItem<TPageType>();
            var model = Mapper.Map<TViewModel>(contentItem);
            return model;
        }

    }
}
