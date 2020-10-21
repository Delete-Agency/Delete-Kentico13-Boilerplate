using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace DeleteBoilerplate.WepApp.Automap
{
    public static class AutoMapperExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new WebAppAutoMap());
            }).CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
