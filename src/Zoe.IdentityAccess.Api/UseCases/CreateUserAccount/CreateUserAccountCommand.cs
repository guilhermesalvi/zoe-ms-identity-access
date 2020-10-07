using MediatR;

namespace Zoe.IdentityAccess.Api.UseCases.CreateUserAccount
{
    public class CreateUserAccountCommand : IRequest<CreateUserAccountUseCaseResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FullName { get; set; }
        public string PreferredName { get; set; }
    }
}
