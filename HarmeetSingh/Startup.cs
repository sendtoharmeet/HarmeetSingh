using BusinessApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace HarmeetSingh
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var currentCulture = Configuration["CurrentCulture"] ?? "en";

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<IDataProcessor, DataProcessor>();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo(currentCulture)
                };
                options.DefaultRequestCulture = new RequestCulture(culture: currentCulture, uiCulture: currentCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseStaticFiles();
            loggerFactory.AddLog4Net();
            var currentCulture = Configuration["CurrentCulture"] ?? "en";
            var supportedCulture = new[]
            {
                new CultureInfo(currentCulture),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(currentCulture),
                SupportedCultures = supportedCulture,
                SupportedUICultures = supportedCulture
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

