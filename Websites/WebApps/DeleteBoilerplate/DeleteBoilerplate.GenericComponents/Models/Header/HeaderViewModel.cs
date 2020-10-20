using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeleteBoilerplate.GenericComponents.Models.SocialLink;

namespace DeleteBoilerplate.GenericComponents.Models.Header
{
    public class HeaderViewModel
    {
        public string Text { get; set; }
        public IEnumerable<SocialLinkViewModel> SocialLinks { get; set; }
    }
}
