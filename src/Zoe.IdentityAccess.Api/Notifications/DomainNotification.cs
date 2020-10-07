using MediatR;
using System;

namespace Zoe.IdentityAccess.Api.Notifications
{
    public class DomainNotification : INotification
    {
        public Guid DomainNotificationId { get; }
        public string Key { get; }
        public string Value { get; }
        public int Version { get; }

        public DomainNotification(string key, string value)
        {
            this.DomainNotificationId = Guid.NewGuid();
            this.Version = 1;
            this.Key = key;
            this.Value = value;
        }
    }
}
