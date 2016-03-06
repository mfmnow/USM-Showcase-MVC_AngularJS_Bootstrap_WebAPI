using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Security;

namespace Web.USM.Attributes
{
    public class USMAuthenticateAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            /*if (!filterContext.Principal.Identity.IsAuthenticated)
                filterContext.Result = new HttpUnauthorizedResult();*/
            if (HttpContext.Current.Request.Cookies["UserID"] == null || HttpContext.Current.Request.Cookies["UserID"].Value.Length == 0)
                filterContext.Result = new HttpUnauthorizedResult();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}