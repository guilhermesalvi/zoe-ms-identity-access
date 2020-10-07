using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Reflection;
using Zoe.IdentityAccess.Api.Controllers.Presenters;
using Zoe.IdentityAccess.Api.Controllers.Responses;
using Zoe.IdentityAccess.Api.LocalizationResources;
using Zoe.IdentityAccess.Api.Notifications;
using Zoe.IdentityAccess.Api.UseCases.Abstractions;
using Zoe.IdentityAccess.Api.UseCases.CreateUserAccount;

namespace Zoe.IdentityAccess.Api.Controllers.Account.V1
{
    public class AccountPresenterComponent : IPresenterComponent<IUseCaseResult>
    {
        private readonly DomainNotificationHandler _notificationHandler;
        private readonly IStringLocalizer _localizer;

        public AccountPresenterComponent(
            INotificationHandler<DomainNotification> notificationHandler,
            IStringLocalizerFactory factory)
        {
            this._notificationHandler = (DomainNotificationHandler)notificationHandler ?? throw new ArgumentNullException(nameof(notificationHandler));

            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);

            this._localizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public IActionResult OnSuccessResult(IUseCaseResult data = default)
        {
            return new CreatedAtRouteResult(string.Empty, new ResponseBase<object>
            {
                Succeeded = true,
                Data = this._localizer[(data as CreateUserAccountUseCaseResult)?.Message].Value,
                Errors = null
            });
        }

        public IActionResult OnErrorResult(IUseCaseResult data = default)
        {
            return new UnprocessableEntityObjectResult(new ResponseBase<object>
            {
                Succeeded = false,
                Data = null,
                Errors = this.RenderErrorsWithLocalizer()
            });
        }

        private IEnumerable<ResponseError> RenderErrorsWithLocalizer()
        {
            foreach (var notification in this._notificationHandler.Notifications)
            {
                yield return new ResponseError
                {
                    Code = notification.Key,
                    Description = this._localizer[notification.Value].Value
                };
            }
        }
    }
}
