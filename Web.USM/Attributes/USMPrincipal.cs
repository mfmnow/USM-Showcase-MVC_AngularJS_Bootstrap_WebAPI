using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace Web.USM.Attributes
{
    public class USMPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            if (roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public USMPrincipal(string Username)
        {
            this.Identity = new GenericIdentity(Username);
        }
 
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string[] roles { get; set; }
    }
}