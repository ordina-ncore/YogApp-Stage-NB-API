using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using System.Security.Claims;

namespace YogApp.API
{

    public class HttpRequestInterceptor : DefaultHttpRequestInterceptor
    {
        public override ValueTask OnCreateAsync(HttpContext context,
        IRequestExecutor requestExecutor, IQueryRequestBuilder requestBuilder,
        CancellationToken cancellationToken)
        {
            var claims = new List<Claim>{};
            var identity = new ClaimsIdentity();
            identity.AddClaims(claims); context.User.AddIdentity(identity); return base.OnCreateAsync(context, requestExecutor, requestBuilder,
            cancellationToken);
        }
    }
}
