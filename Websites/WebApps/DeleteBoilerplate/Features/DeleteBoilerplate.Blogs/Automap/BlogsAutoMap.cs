using CMS.DocumentEngine.Types.DeleteBoilerplate;
using DeleteBoilerplate.Blogs.Models.Blog;
using AutoMapper;

namespace DeleteBoilerplate.Blogs.Automap
{
    public class BlogsAutoMap : Profile
    {
        public BlogsAutoMap()
        {
            CreateMapBlog();
        }

        private void CreateMapBlog()
        {
            CreateMap<Blog, BlogViewModel>(MemberList.None)
                .ForMember(dst => dst.NodeGuid, opt => opt.MapFrom(src => src.NodeGUID))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
