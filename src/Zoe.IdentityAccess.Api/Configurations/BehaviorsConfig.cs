using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Zoe.IdentityAccess.Api.Behaviors;

namespace Zoe.IdentityAccess.Api.Configurations
{
    public static class BehaviorsConfig
    {
        public static IServiceCollection AddBehaviorsConfig(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationRequestBehavior<,>));

            AssemblyScanner
                .FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(x => services.AddScoped(x.InterfaceType, x.ValidatorType));

            return services;
        }
    }
}
