using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using USM.DAL;
using USM.DAL.Models;
using Web.USM.Attributes;

namespace Web.USM.Controllers
{
    
    [USMAuthenticate]
    public class UsersAdminController : Controller
    {
        private USMContext db = new USMContext();

        // GET: UsersAdmin
        public async Task<ActionResult> Index()
        {
            var users = db.Users.Include(u => u.UserRole);
            return View(await users.ToListAsync());
        }

        // GET: UsersAdmin/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            //string _s = ControllerContext.HttpContext.User.Identity.Name;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: UsersAdmin/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.UserRoles, "ID", "Name");
            return View();
        }

        // POST: UsersAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserID,Username,Password,FullName,Email,MobileNumber,UserIsDisabled,RoleID,IsDeleted,CreateDate,LastUpdateDate")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.UserRoles, "ID", "Name", user.RoleID);
            return View(user);
        }

        // GET: UsersAdmin/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.UserRoles, "ID", "Name", user.RoleID);
            return View(user);
        }

        // POST: UsersAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserID,Username,Password,FullName,Email,MobileNumber,UserIsDisabled,RoleID,IsDeleted,CreateDate,LastUpdateDate")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.UserRoles, "ID", "Name", user.RoleID);
            return View(user);
        }

        // GET: UsersAdmin/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: UsersAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

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
