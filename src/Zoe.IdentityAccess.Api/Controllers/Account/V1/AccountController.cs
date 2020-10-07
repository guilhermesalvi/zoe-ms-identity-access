using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zoe.IdentityAccess.Api.Controllers.Presenters;
using Zoe.IdentityAccess.Api.UseCases.Abstractions;
using Zoe.IdentityAccess.Api.UseCases.CreateUserAccount;

namespace Zoe.IdentityAccess.Api.Controllers.Account.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/account")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Presenter<AccountPresenterComponent, IUseCaseResult> _presenter;

        public AccountController(
            IMediator mediator,
            Presenter<AccountPresenterComponent, IUseCaseResult> presenter)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Register([FromBody] CreateUserAccountCommand command)
        {
            var result = await this._mediator.Send(command);
            this._presenter.Populate(result);

            return this._presenter.Result;
        }
    }
}
