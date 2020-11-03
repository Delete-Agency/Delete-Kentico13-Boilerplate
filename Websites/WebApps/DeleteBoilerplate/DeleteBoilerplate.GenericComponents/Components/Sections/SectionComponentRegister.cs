using DeleteBoilerplate.GenericComponents.Models.Sections;
using DeleteBoilerplate.Infrastructure.Constants;
using Kentico.PageBuilder.Web.Mvc;

[assembly: RegisterSection(SectionIdentifiers.ONE_COLUMN_SECTION, "One column section", typeof(ThemeSectionProperties),
    "~/Views/Sections/_OneColumnSection.cshtml",
    Description = "One column section with one zone.", IconClass = "icon-square")]

[assembly: RegisterSection(SectionIdentifiers.TWO_COLUMN_SECTION, "Two column section", typeof(ThemeSectionProperties),
    "~/Views/Sections/_TwoColumnSection.cshtml",
    Description = "Two column section with one zone.", IconClass = "icon-l-cols-2")]
