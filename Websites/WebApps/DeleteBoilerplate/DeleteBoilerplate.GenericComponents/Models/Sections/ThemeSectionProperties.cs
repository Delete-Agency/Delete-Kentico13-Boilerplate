using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace DeleteBoilerplate.GenericComponents.Models.Sections
{
    public class ThemeSectionProperties : ISectionProperties
    {
        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "Color scheme", Order = 1)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), ";None\r\nsection-white;White")]
        public string Theme { get; set; }
    }
}
