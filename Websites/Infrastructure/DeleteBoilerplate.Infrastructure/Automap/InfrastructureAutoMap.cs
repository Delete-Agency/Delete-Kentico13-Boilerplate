using AutoMapper;
using DeleteBoilerplate.Common.Models.Media;

namespace DeleteBoilerplate.Infrastructure.Automap
{
    public class InfrastructureAutoMap : Profile
    {
        public InfrastructureAutoMap()
        {
            CreateMapImage();
        }

        private void CreateMapImage()
        {
            CreateMap<ImageModel, ImageViewModel>();
        }
    }
}
