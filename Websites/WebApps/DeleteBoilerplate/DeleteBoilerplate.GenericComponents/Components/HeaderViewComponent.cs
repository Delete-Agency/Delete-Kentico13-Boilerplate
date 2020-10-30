using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.SiteProvider;
using DeleteBoilerplate.Domain.Repositories;
using DeleteBoilerplate.GenericComponents.Models.Header;
using DeleteBoilerplate.GenericComponents.Models.SocialLink;
using Microsoft.AspNetCore.Mvc;

namespace DeleteBoilerplate.GenericComponents.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ISocialLinkRepository _socialLinkRepository;

        public HeaderViewComponent(ISocialLinkRepository socialLinkRepository)
        {
            _socialLinkRepository = socialLinkRepository;
        }

        public IViewComponentResult Invoke()
        {
            var socialLinks = _socialLinkRepository.GetSocialLinks(SiteContext.CurrentSiteName)
                .OrderBy(x => x.NodeOrder)
                .Select(x => new SocialLinkViewModel
                {
                    Name = x.Name,
                    Title = x.Title,
                    Url = x.Url,
                    Icon = x.Fields.SocialIcon.AttachmentName
                })
                .ToList();

            var headerViewModel = new HeaderViewModel
            {
                SocialLinks = socialLinks,
                Text = "Header Section"
            };

            return View("~/Views/Global/Header.cshtml", headerViewModel);
        }
    }
}
