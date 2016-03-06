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
using Web.USM.Attributes;

namespace Web.USM.Controllers
{
    [USMAuthenticateAsync]
	public class UserRoleAPIController : ApiController
    {
        private USMContext db = new USMContext();

        // GET: api/UserRoleAPI
        public IQueryable<UserRole> GetUserRoles()
        {
            return db.UserRoles;
        }

        // GET: api/UserRoleAPI/5
        [ResponseType(typeof(UserRole))]
        public async Task<IHttpActionResult> GetUserRole(int id)
        {
            UserRole userRole = await db.UserRoles.FindAsync(id);
            if (userRole == null)
            {
                return NotFound();
            }

            return Ok(userRole);
        }

        // PUT: api/UserRoleAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserRole(int id, UserRole userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userRole.ID)
            {
                return BadRequest();
            }

            db.Entry(userRole).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserRoleAPI
        [ResponseType(typeof(UserRole))]
        public async Task<IHttpActionResult> PostUserRole(UserRole userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			try
            {
            db.UserRoles.Add(userRole);
            await db.SaveChangesAsync();

            }
            catch (Exception ex) { return Ok(new { success = false, message = ex.Message }); }


            return Ok(new { success = true, message = "UserRole created." });
        }

        // DELETE: api/UserRoleAPI/5
        [ResponseType(typeof(UserRole))]
        public async Task<IHttpActionResult> DeleteUserRole(int id)
        {
            UserRole userRole = await db.UserRoles.FindAsync(id);
            if (userRole == null)
            {
                return NotFound();
            }

            db.UserRoles.Remove(userRole);
            await db.SaveChangesAsync();

            return Ok(userRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserRoleExists(int id)
        {
            return db.UserRoles.Count(e => e.ID == id) > 0;
        }
    }
}