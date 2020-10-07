namespace Zoe.IdentityAccess.Api.UseCases.Abstractions
{
    public interface IUseCaseResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
