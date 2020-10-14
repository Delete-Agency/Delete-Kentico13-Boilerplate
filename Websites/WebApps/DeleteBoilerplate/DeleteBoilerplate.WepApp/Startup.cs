using System;
using System.Threading.Tasks;

using CMS.Helpers;

using Kentico.Activities.Web.Mvc;
using Kentico.CampaignLogging.Web.Mvc;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.Forms.Web.Mvc;
using Kentico.Membership;
using Kentico.Newsletters.Web.Mvc;
using Kentico.OnlineMarketing.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Scheduler.Web.Mvc;
using Kentico.Web.Mvc;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DeleteBoilerplate.WepApp
{
    public class Startup
    {        
        /// <summary>
        /// This is a route controller constraint for pages not handled by the content tree-based router.
        /// The constraint limits the match to a list of specified controllers for pages not handled by the content tree-based router.
        /// The constraint ensures that broken URLs lead to a "404 page not found" page and are not handled by a controller dedicated to the component or 
        /// to a page handled by the content tree-based router (which would lead to an exception).
        /// </summary>
        private const string CONSTRAINT_FOR_NON_ROUTER_PAGE_CONTROLLERS = "Account|Consent|Coupon|Checkout|NewsletterSubscriptionWidget|Orders|Search|Subscription";

        // Application authentication cookie name
        private const string AUTHENTICATION_COOKIE_NAME = "identity.authentication";


        public const string DEFAULT_WITHOUT_LANGUAGE_PREFIX_ROUTE_NAME = "DefaultWithoutLanguagePrefix";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Ensures redirect to the administration instance based on URL defined in settings
            //services.AddSingleton<IStartupFilter>(new AdminRedirectStartupFilter(Configuration));

            // This startup filter is required only for evaluation scenarios.
            // Adding it into regular applications may cause issues with system functionality.
            //services.AddSingleton<IStartupFilter>(new AdminLocalhostProxyStartupFilter());

            services.AddKentico(features =>
                {
                    features.UsePreview();
                    features.UsePageBuilder();
                    features.UseActivityTracking();
                    features.UseABTesting();
                    features.UseWebAnalytics();
                    features.UseEmailTracking();
                    features.UseCampaignLogger();
                    features.UseScheduler();
                    features.UsePageRouting(new PageRoutingOptions { EnableAlternativeUrls = true, CultureCodeRouteValuesKey = "culture" });
                })
                .SetAdminCookiesSameSiteNone();

            //services.AddDancingGoatServices();

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.AddLocalization()
                .AddControllersWithViews()
                .AddViewLocalization()
                //.AddDataAnnotationsLocalization(options =>
                //{
                //    options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(SharedResources));
                //})
                ;

            services.Configure<KenticoRequestLocalizationOptions>(options =>
            {
                options.RequestCultureProviders.Add(new RouteDataRequestCultureProvider
                {
                    RouteDataStringKey = "culture",
                    UIRouteDataStringKey = "culture"
                });
            });

            //services.Configure<FormBuilderBundlesOptions>(options =>
            //{
            //    options.JQueryCustomBundleWebRootPath = "Scripts/jquery-3.5.1.min.js";
            //    options.JQueryUnobtrusiveAjaxCustomBundleWebRootPath = "Scripts/jquery.unobtrusive-ajax.min.js";
            //});


            ConfigureMembershipServices(services);
            ConfigurePageBuilderFilters();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseStaticFiles();

            app.UseKentico();

            app.UseCookiePolicy();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Kentico().MapRoutes();

                endpoints.MapControllerRoute(
                    name: "error",
                    pattern: "error/{code}",
                    defaults: new { controller = "HttpErrors", action = "Error" }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: $"{{culture}}/{{controller}}/{{action}}",
                    constraints: new
                    {
                        culture = new SiteCultureConstraint { HideLanguagePrefixForDefaultCulture = true },
                        controller = CONSTRAINT_FOR_NON_ROUTER_PAGE_CONTROLLERS
                    }
                );

                endpoints.MapControllerRoute(
                    name: DEFAULT_WITHOUT_LANGUAGE_PREFIX_ROUTE_NAME,
                    pattern: "{controller}/{action}",
                    constraints: new
                    {
                        controller = CONSTRAINT_FOR_NON_ROUTER_PAGE_CONTROLLERS
                    }
                );
            });
        }

        private static void ConfigureMembershipServices(IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher<ApplicationUser>, Kentico.Membership.PasswordHasher<ApplicationUser>>();
            services.AddScoped<IMessageService, MessageService>();

            services.AddApplicationIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                // Note: These settings are effective only when password policies are turned off in the administration settings.
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;
            })
                    .AddApplicationDefaultTokenProviders()
                    .AddUserStore<ApplicationUserStore<ApplicationUser>>()
                    .AddRoleStore<ApplicationRoleStore<ApplicationRole>>()
                    .AddUserManager<ApplicationUserManager<ApplicationUser>>()
                    .AddSignInManager<SignInManager<ApplicationUser>>();

            services.AddAuthorization();
            services.AddAuthentication();

            services.ConfigureApplicationCookie(c =>
            {
                //c.Events.OnRedirectToLogin = ctx =>
                //{
                //    // Redirects to login page respecting the current culture
                //    var factory = ctx.HttpContext.RequestServices.GetRequiredService<IUrlHelperFactory>();
                //    var urlHelper = factory.GetUrlHelper(new ActionContext(ctx.HttpContext, new RouteData(ctx.HttpContext.Request.RouteValues), new ActionDescriptor()));
                //    var url = urlHelper.Action("Login", "Account");

                //    ctx.Response.Redirect(url);

                //    return Task.CompletedTask;
                //};
                c.ExpireTimeSpan = TimeSpan.FromDays(14);
                c.SlidingExpiration = true;
                c.Cookie.Name = AUTHENTICATION_COOKIE_NAME;
            });

            CookieHelper.RegisterCookie(AUTHENTICATION_COOKIE_NAME, CookieLevel.Essential);
        }


        private static void ConfigurePageBuilderFilters()
        {
            //PageBuilderFilters.PageTemplates.Add(new ArticlePageTemplatesFilter());
        }
    }
}
