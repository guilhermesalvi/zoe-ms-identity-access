using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace Zoe.IdentityAccess.Api.Configurations
{
    public static class ControllersConfig
    {
        public static IServiceCollection AddControllersConfig(this IServiceCollection services)
        {
            services
                .AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressMapClientErrors = true;
                })
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            return services;
        }
    }
}
