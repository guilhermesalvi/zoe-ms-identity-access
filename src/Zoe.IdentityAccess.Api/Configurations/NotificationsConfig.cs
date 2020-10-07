using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Zoe.IdentityAccess.Api.Notifications;

namespace Zoe.IdentityAccess.Api.Configurations
{
    public static class NotificationsConfig
    {
        public static IServiceCollection AddNotificationsConfig(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            return services;
        }
    }
}
