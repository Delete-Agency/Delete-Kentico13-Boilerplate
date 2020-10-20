using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeleteBoilerplate.GenericComponents.Models.Header;
using Microsoft.AspNetCore.Mvc;

namespace DeleteBoilerplate.GenericComponents.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var headerViewModel = new HeaderViewModel
            {
                Text = "This is Header"
            };

            return View("~/Views/Global/Header.cshtml", headerViewModel);
        }
    }
}
