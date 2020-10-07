using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;

namespace Zoe.IdentityAccess.Api.Configurations
{
    public static class LocalizationConfig
    {
        public static IServiceCollection AddLocalizationConfig(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "LocalizationResources");

            return services;
        }

        public static IApplicationBuilder UseLocalizationConfig(this IApplicationBuilder app)
        {
            var cultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("pt-BR")
            };

            app.UseRequestLocalization(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });

            return app;
        }
    }
}
