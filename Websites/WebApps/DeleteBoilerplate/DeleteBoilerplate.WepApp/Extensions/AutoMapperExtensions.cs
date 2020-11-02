using AutoMapper;
using DeleteBoilerplate.Domain.Models.BaseModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DeleteBoilerplate.WepApp.Automap
{
    public static class AutoMapperExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var profiles = GetAutoMapProfiles();

            var mapper = new MapperConfiguration(mc =>
            {
                foreach (var profile in profiles)
                {
                    var instanceProfile = Activator.CreateInstance(profile) as Profile;
                    mc.AddProfile(instanceProfile);
                }
            }).CreateMapper();

            services.AddSingleton(mapper);
        }

        private static IEnumerable<TypeInfo> GetAutoMapProfiles()
        {
            var profiles = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.DefinedTypes)
                .Where(type => IsAssignableFromIProfile(type) && type.IsClass);

            return profiles;
        }

        private static bool IsAssignableFromIProfile(Type type) => typeof(IProfile).GetTypeInfo().IsAssignableFrom(type);
    }
}
