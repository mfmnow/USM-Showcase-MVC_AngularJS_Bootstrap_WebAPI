using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;

namespace Web.USM.Attributes
{
    public class USMAuthorizeAttribute : AuthorizeAttribute
    {
        // Custom property
        public string AccessArea { get; set; }
        public string AccessLevel { get; set; }

        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    //CookieHeaderValue cookie = httpContext.Request.Headers.GetCookies("session-id").FirstOrDefault();
        //    /*USMPrincipal CurrentUser = httpContext.User as USMPrincipal;
        //    USMPrincipal user2 = System.Web.HttpContext.Current.User as USMPrincipal;
        //    if (CurrentUser!=null)
        //        return true;
        //    return false;*/
        //    return true;
        //}
    }
}