using AutoMapper;
using DeleteBoilerplate.Common.Extensions;
using DeleteBoilerplate.Common.Models.Media;

namespace DeleteBoilerplate.Infrastructure.ValueConverters
{
    public class ImageFromUrlValueConverter : IValueConverter<string, ImageViewModel>
    {
        public ImageViewModel Convert(string sourceMember, ResolutionContext context)
        {
            if (!string.IsNullOrWhiteSpace(sourceMember))
            {
                var model = MediaExtensions.GetImageModelByURL(sourceMember);
                if (model != null)
                {
                    return context.Mapper.Map<ImageViewModel>(model);
                }
            }

            return null;
        }
    }
}
