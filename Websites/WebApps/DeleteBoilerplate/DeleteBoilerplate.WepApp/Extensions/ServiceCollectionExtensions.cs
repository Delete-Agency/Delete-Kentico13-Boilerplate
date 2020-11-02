using DeleteBoilerplate.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DeleteBoilerplate.WepApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDeleteBoilerplateDependencies(this IServiceCollection services)
        {
            services.AddViewComponentServices();
            services.AddRepositories();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ISocialLinkRepository, SocialLinkRepository>();
        }

        private static void AddViewComponentServices(this IServiceCollection services)
        {
            //For page templates and other one
        }
    }
}
