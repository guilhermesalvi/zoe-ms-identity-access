using Microsoft.Extensions.DependencyInjection;
using Zoe.IdentityAccess.Api.Controllers.Account.V1;
using Zoe.IdentityAccess.Api.Controllers.Presenters;
using Zoe.IdentityAccess.Api.UseCases.Abstractions;

namespace Zoe.IdentityAccess.Api.Configurations
{
    public static class PresentersConfig
    {
        public static IServiceCollection AddPresentersConfig(this IServiceCollection services)
        {
            // Account
            services.AddTransient<AccountPresenterComponent>();
            services.AddTransient<Presenter<AccountPresenterComponent, IUseCaseResult>>();

            return services;
        }
    }
}
