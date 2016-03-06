using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net.Http.Headers;
using System.Web.Security;
using System.Threading;
using System.Threading.Tasks;

namespace Web.USM.Attributes
{
    public class USMAuthenticateAsyncAttribute : ActionFilterAttribute, IAuthenticationFilter
    {

        public System.Threading.Tasks.Task AuthenticateAsync(HttpAuthenticationContext context, System.Threading.CancellationToken cancellationToken)
        {
            if (HttpContext.Current.Request.Cookies["UserID"] == null || HttpContext.Current.Request.Cookies["UserID"].Value.Length == 0)
            {
                context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
            }//if
            return Task.FromResult(0);
        }

        public System.Threading.Tasks.Task ChallengeAsync(HttpAuthenticationChallengeContext context, System.Threading.CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}