using AutoMapper;
using DeleteBoilerplate.Common.Models.Media;
using DeleteBoilerplate.Domain.Models.BaseModels;

namespace DeleteBoilerplate.Infrastructure.Automap
{
    public class InfrastructureAutoMap : Profile, IProfile
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
