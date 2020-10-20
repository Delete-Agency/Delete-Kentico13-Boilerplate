using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.SiteProvider;
using DeleteBoilerplate.Domain.Repositories;
using DeleteBoilerplate.GenericComponents.Models.Footer;
using DeleteBoilerplate.GenericComponents.Models.SocialLink;
using Microsoft.AspNetCore.Mvc;

namespace DeleteBoilerplate.GenericComponents.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISocialLinkRepository _socialLinkRepository;

        public FooterViewComponent(ISocialLinkRepository socialLinkRepository)
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
                    Icon = x.Fields.Icon.AttachmentUrl
                })
                .ToList();

            var footerViewModel = new FooterViewModel
            {
                SocialLinks = socialLinks,
                Text = "This is Footer"
            };

            return View("~/Views/Global/Footer.cshtml", footerViewModel);
        }
    }
}
