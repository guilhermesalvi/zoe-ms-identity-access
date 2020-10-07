using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Zoe.IdentityAccess.Api.Configurations
{
    public static class MediatRConfig
    {
        public static IServiceCollection AddMediatRConfig(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
