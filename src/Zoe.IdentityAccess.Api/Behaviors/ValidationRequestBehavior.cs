using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Zoe.IdentityAccess.Api.Notifications;

namespace Zoe.IdentityAccess.Api.Behaviors
{
    public class ValidationRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator> _validators;
        private readonly IMediator _mediator;

        public ValidationRequestBehavior(
            IEnumerable<IValidator<TRequest>> validators,
            IMediator mediator)
        {
            this._validators = validators ?? throw new ArgumentNullException(nameof(validators));
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var failures = new List<ValidationFailure>();

            foreach (var validator in this._validators)
            {
                var validation = await validator.ValidateAsync(new ValidationContext<object>(request));

                if (validation.Errors != null)
                {
                    failures.AddRange(validation.Errors);
                }
            }

            if (failures.Count > 0)
            {
                await this.NotifyErrorsAsync(failures);

                return default;
            }

            return await next();
        }

        private async Task NotifyErrorsAsync(IEnumerable<ValidationFailure> failures)
        {
            foreach (var failure in failures)
            {
                await this._mediator.Publish(new DomainNotification(failure.ErrorCode, failure.ErrorMessage));
            }
        }
    }
}
