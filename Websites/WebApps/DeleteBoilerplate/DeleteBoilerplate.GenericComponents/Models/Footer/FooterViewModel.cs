using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeleteBoilerplate.GenericComponents.Models.SocialLink;

namespace DeleteBoilerplate.GenericComponents.Models.Footer
{
    public class FooterViewModel
    {
        public string Text { get; set; }
        public IEnumerable<SocialLinkViewModel> SocialLinks { get; set; }
    }
}
