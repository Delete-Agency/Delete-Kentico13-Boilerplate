﻿using AutoMapper;
using DeleteBoilerplate.Blogs.Automap;
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
                mc.AddProfile(new BlogsAutoMap());
            }).CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
