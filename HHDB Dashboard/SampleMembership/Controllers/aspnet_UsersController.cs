using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SampleMembership.Models;

namespace SampleMembership.Controllers
{
    public class aspnet_UsersController : Controller
    {
        private HHDBEntities db = new HHDBEntities();

        // GET: aspnet_Users
        public ActionResult Index()
        {
            var aspnet_Users = db.aspnet_Users.Include(a => a.aspnet_Applications).Include(a => a.aspnet_Applications1).Include(a => a.aspnet_Membership).Include(a => a.aspnet_Membership1);
            return View(aspnet_Users.ToList());
        }


        // GET: aspnet_Users/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName");
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName");
            ViewBag.UserId = new SelectList(db.aspnet_Membership, "UserId", "Password");
            ViewBag.UserId = new SelectList(db.aspnet_Membership, "UserId", "Password");
            return View();
        }

        // POST: aspnet_Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationId,UserId,UserName,LoweredUserName,MobileAlias,IsAnonymous,LastActivityDate")] aspnet_Users aspnet_Users)
        {
            if (ModelState.IsValid)
            {
                aspnet_Users.UserId = Guid.NewGuid();
                db.aspnet_Users.Add(aspnet_Users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName", aspnet_Users.ApplicationId);
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName", aspnet_Users.ApplicationId);
            ViewBag.UserId = new SelectList(db.aspnet_Membership, "UserId", "Password", aspnet_Users.UserId);
            ViewBag.UserId = new SelectList(db.aspnet_Membership, "UserId", "Password", aspnet_Users.UserId);
            return View(aspnet_Users);
        }

        // GET: aspnet_Users/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aspnet_Users aspnet_Users = db.aspnet_Users.Find(id);
            if (aspnet_Users == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName", aspnet_Users.ApplicationId);
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName", aspnet_Users.ApplicationId);
            ViewBag.UserId = new SelectList(db.aspnet_Membership, "UserId", "Password", aspnet_Users.UserId);
            ViewBag.UserId = new SelectList(db.aspnet_Membership, "UserId", "Password", aspnet_Users.UserId);
            return View(aspnet_Users);
        }

        // POST: aspnet_Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationId,UserId,UserName,LoweredUserName,MobileAlias,IsAnonymous,LastActivityDate")] aspnet_Users aspnet_Users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspnet_Users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName", aspnet_Users.ApplicationId);
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName", aspnet_Users.ApplicationId);
            ViewBag.UserId = new SelectList(db.aspnet_Membership, "UserId", "Password", aspnet_Users.UserId);
            ViewBag.UserId = new SelectList(db.aspnet_Membership, "UserId", "Password", aspnet_Users.UserId);
            return View(aspnet_Users);
        }

        // GET: aspnet_Users/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aspnet_Users aspnet_Users = db.aspnet_Users.Find(id);
            if (aspnet_Users == null)
            {
                return HttpNotFound();
            }
            return View(aspnet_Users);
        }

        // POST: aspnet_Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            aspnet_Users aspnet_Users = db.aspnet_Users.Find(id);
            db.aspnet_Users.Remove(aspnet_Users);
            db.SaveChanges();
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
