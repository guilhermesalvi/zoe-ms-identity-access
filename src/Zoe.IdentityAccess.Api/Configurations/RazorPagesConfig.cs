using Microsoft.Extensions.DependencyInjection;

namespace Zoe.IdentityAccess.Api.Configurations
{
    public static class RazorPagesConfig
    {
        public static IServiceCollection AddRazorPagesConfig(this IServiceCollection services)
        {
            services.AddRazorPages();

            return services;
        }
    }
}
