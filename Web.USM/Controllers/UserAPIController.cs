using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.Routing;
using Web.USM.Attributes;
using System.Web.Http.Description;
using USM.DAL;
using USM.DAL.Models;
using System.Collections;

namespace Web.USM.Controllers
{
    [USMAuthenticateAsync]
	public class UserAPIController : ApiController
    {
        /*private static Hashtable _Fields = new Hashtable();
        private static GetSortByObject(DbSet)
        {

        }*/
       private USMContext db = new USMContext();

        // GET: api/UserAPI
        [EnableQuery]
       public IQueryable<User> GetUsers()
        {
            System.Threading.Thread.Sleep(1500);
            /*var query = db.Users.OrderBy(sort);
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var results = query
            .Skip(start)
            .Take(pageSize)
            .ToList().AsQueryable();

            return Ok(new
            {
                //TotalCount = totalCount,
                //TotalPages = totalPages,
                Results = db.Users.AsQueryable()
            });*/

            return db.Users.Where(o=>o.IsDeleted==0).Include(o => o.UserRole);
        }

        // GET: api/UserAPI/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/UserAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/UserAPI
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			try
            {
            db.Users.Add(user);
            await db.SaveChangesAsync();

            }
            catch (Exception ex) { return Ok(new { success = false, message = ex.InnerException.Message+ex.InnerException.StackTrace }); }


            return Ok(new { success = true, message = "User created." });
        }

        // DELETE: api/UserAPI/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            try
            {
                User user = await db.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                //db.Users.Remove(user);
                user.IsDeleted = 1;
                await db.SaveChangesAsync();
            }//try
            catch (Exception ex) { return Ok(new { success = false, message = ex.Message }); }
            return Ok(new { success = true, message = "User deleted." });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }
    }
}