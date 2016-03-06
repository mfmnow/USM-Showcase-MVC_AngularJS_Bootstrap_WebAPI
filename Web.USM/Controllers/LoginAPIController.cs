using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using USM.DAL;
using USM.DAL.Models;
using System.Web;
using Web.USM.Attributes;
using System.Net.Http.Headers;

namespace Web.USM.Controllers
{
    [RoutePrefix("api/authenticate")]
    public class LoginAPIController : ApiController
    {
        private USMContext db = new USMContext();

        // POST: api/LoginAPI
        [Route("")]
        [HttpPost]
        public IHttpActionResult Authenticate(User user)
        {
            List<User> outhUser;
            try
            {
                outhUser = db.Users.Where(x => x.Username == user.Username && x.Password == user.Password).ToList();

                if (outhUser.Count == 0)
                {
                    return Ok(new { success = false, message = "User code or password is incorrect" });
                }


                var cookie = new HttpCookie("UserID", outhUser.FirstOrDefault().UserID.ToString());
                cookie.Expires = DateTime.Now.AddDays(1);
                cookie.Domain = null;
                cookie.Path = "/";
                HttpContext.Current.Response.SetCookie(cookie);

                var cookieUsername = new HttpCookie("Username", outhUser.FirstOrDefault().Username);
                cookieUsername.Expires = DateTime.Now.AddDays(1);
                cookieUsername.Domain = null;
                cookieUsername.Path = "/";
                HttpContext.Current.Response.SetCookie(cookieUsername);

                return Ok(new { success = true });
            }//try
            catch (Exception ex) { return Ok(new { success = false, message = ex.Message }); }
        }//Authenticate

        // POST: api/LoginAPI
        [Route("signout")]
        [HttpGet]
        public IHttpActionResult Signout()
        {
            try
            {
                var cookie = new HttpCookie("UserID");
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
                HttpContext.Current.Response.SetCookie(cookie);

                return Ok(new { success = true });
            }//try
            catch (Exception ex) { return Ok(new { success = false, message = ex.Message }); }
        }//Authenticate

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}