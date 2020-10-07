using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zoe.IdentityAccess.Api.Describers;
using Zoe.IdentityAccess.Api.Models;
using Zoe.IdentityAccess.Api.Notifications;

namespace Zoe.IdentityAccess.Api.UseCases.CreateUserAccount
{
    public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, CreateUserAccountUseCaseResult>
    {
        private readonly IMediator _mediator;
        private readonly UserManager<User> _manager;

        public CreateUserAccountCommandHandler(
            IMediator mediator,
            UserManager<User> manager)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        public async Task<CreateUserAccountUseCaseResult> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Email = request.Email,
                UserName = request.Email,
                FullName = request.FullName,
                PreferredName = request.PreferredName,
                EmailConfirmed = true
            };

            var result = await this._manager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                await this.NotifyErrorsAsync(result);
                return CreateUserAccountUseCaseResult.Fail;
            }

            return new CreateUserAccountUseCaseResult(succeeded: true, message: AccountMessageDescriber.ACCOUNT_USER_CREATED_SUCCESSFULLY.Description);
        }

        private async Task NotifyErrorsAsync(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                await this._mediator.Publish(new DomainNotification(error.Code, error.Description));
            }
        }
    }
}
