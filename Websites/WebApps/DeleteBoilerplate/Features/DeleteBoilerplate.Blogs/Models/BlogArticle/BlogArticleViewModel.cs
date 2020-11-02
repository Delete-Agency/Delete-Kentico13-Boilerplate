using DeleteBoilerplate.Common.Models.Media;
using DeleteBoilerplate.Domain.Models.BaseModels;
using System;

namespace DeleteBoilerplate.Blogs.Models.BlogArticle
{
    public class BlogArticleViewModel : IViewModel
    {
        public Guid NodeGuid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ImageViewModel Image { get; set; }
    }
}
