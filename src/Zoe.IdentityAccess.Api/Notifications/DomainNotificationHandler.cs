using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Zoe.IdentityAccess.Api.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private readonly List<DomainNotification> _notifications;

        public IReadOnlyCollection<DomainNotification> Notifications => this._notifications.AsReadOnly();
        public bool HasNotifications => this._notifications.Any();

        public DomainNotificationHandler()
        {
            this._notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            if (notification != null)
            {
                this._notifications.Add(notification);
            }

            return Task.CompletedTask;
        }
    }
}
