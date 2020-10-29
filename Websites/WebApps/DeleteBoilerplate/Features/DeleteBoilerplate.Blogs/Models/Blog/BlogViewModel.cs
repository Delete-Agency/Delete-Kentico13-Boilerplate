using DeleteBoilerplate.Domain.Models.BaseModels;
using System;

namespace DeleteBoilerplate.Blogs.Models.Blog
{
    public class BlogViewModel : IViewModel
    {
        public Guid NodeGuid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
