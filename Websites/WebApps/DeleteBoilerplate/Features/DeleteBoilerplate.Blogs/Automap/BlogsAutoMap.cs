using CMS.DocumentEngine.Types.DeleteBoilerplate;
using DeleteBoilerplate.Blogs.Models.Blog;
using AutoMapper;
using DeleteBoilerplate.Blogs.Models.BlogArticle;
using DeleteBoilerplate.Infrastructure.ValueConverters;

namespace DeleteBoilerplate.Blogs.Automap
{
    public class BlogsAutoMap : Profile
    {
        public BlogsAutoMap()
        {
            CreateMapBlog();
            CreateMapBlogArticle();
        }

        private void CreateMapBlog()
        {
            CreateMap<Blog, BlogViewModel>(MemberList.None)
                .ForMember(dst => dst.NodeGuid, opt => opt.MapFrom(src => src.NodeGUID))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description));
        }

        private void CreateMapBlogArticle()
        {
            CreateMap<BlogArticle, BlogArticleViewModel>(MemberList.None)
                .ForMember(dst => dst.NodeGuid, opt => opt.MapFrom(src => src.NodeGUID))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.Image, opt => opt.ConvertUsing(new ImageFromUrlValueConverter(), src => src.Image));
        }
    }
}
