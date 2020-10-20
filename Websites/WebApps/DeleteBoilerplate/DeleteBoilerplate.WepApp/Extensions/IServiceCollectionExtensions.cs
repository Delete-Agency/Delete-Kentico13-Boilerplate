using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeleteBoilerplate.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DeleteBoilerplate.WepApp.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDeleteBoilerplateDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ISocialLinkRepository, SocialLinkRepository>();
        }
    }
}
