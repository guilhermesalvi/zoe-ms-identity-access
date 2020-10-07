using Microsoft.AspNetCore.Mvc;

namespace Zoe.IdentityAccess.Api.Controllers.Presenters
{
    public interface IPresenterComponent<in TResult>
    {
        IActionResult OnSuccessResult(TResult data = default);
        IActionResult OnErrorResult(TResult data = default);
    }
}
