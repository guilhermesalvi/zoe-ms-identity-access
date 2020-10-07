using System.Collections.Generic;

namespace Zoe.IdentityAccess.Api.Controllers.Responses
{
    public sealed class ResponseBase<TData>
    {
        public bool Succeeded { get; set; }
        public TData Data { get; set; }
        public IEnumerable<ResponseError> Errors { get; set; }
    }
}
