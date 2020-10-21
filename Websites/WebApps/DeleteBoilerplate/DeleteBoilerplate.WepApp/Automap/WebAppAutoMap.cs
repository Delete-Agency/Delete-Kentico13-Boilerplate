using AutoMapper;
using CMS.DocumentEngine.Types.DeleteBoilerplate;
using DeleteBoilerplate.WepApp.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeleteBoilerplate.WepApp.Automap
{
    public class WebAppAutoMap : Profile
    {
        public WebAppAutoMap()
        {
            CreateMapNews();
        }

        private void CreateMapNews()
        {
            CreateMap<NewsPage, NewsPageViewModel>(MemberList.None)
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.TitleNews));
        }
    }
}
