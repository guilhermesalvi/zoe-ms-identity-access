using Zoe.IdentityAccess.Api.UseCases.Abstractions;

namespace Zoe.IdentityAccess.Api.UseCases.CreateUserAccount
{
    public class CreateUserAccountUseCaseResult : IUseCaseResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public static CreateUserAccountUseCaseResult Ok => new CreateUserAccountUseCaseResult { Succeeded = true };
        public static CreateUserAccountUseCaseResult Fail => new CreateUserAccountUseCaseResult { Succeeded = false };

        public CreateUserAccountUseCaseResult(
            bool succeeded = default,
            string message = default)
        {
            this.Succeeded = succeeded;
            this.Message = message;
        }
    }
}
