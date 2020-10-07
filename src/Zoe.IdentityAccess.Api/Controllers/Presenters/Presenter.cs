using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using Zoe.IdentityAccess.Api.Notifications;

namespace Zoe.IdentityAccess.Api.Controllers.Presenters
{
    public sealed class Presenter<TComponent, TData>
        where TComponent : IPresenterComponent<TData>
    {
        private readonly DomainNotificationHandler _notificationHandler;
        private readonly TComponent _component;

        private bool IsValidOperation => !this._notificationHandler.HasNotifications;

        public IActionResult Result { get; private set; }

        public Presenter(
            TComponent component,
            INotificationHandler<DomainNotification> notificationHandler)
        {
            this._component = component ?? throw new ArgumentNullException(nameof(component));
            this._notificationHandler = (DomainNotificationHandler)notificationHandler ?? throw new ArgumentNullException(nameof(notificationHandler));
        }

        public void Populate(TData data = default)
        {
            this.Result = this.IsValidOperation
                ? this._component.OnSuccessResult(data)
                : this._component.OnErrorResult(data);
        }
    }
}
