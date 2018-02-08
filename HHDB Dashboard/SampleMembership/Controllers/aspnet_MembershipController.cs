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
    public class aspnet_MembershipController : Controller
    {
        private HHDBEntities db = new HHDBEntities();

        // GET: aspnet_Membership
        public ActionResult Index()
        {
            var aspnet_Membership = db.aspnet_Membership.Include(a => a.aspnet_Applications).Include(a => a.aspnet_Applications1).Include(a => a.aspnet_Users).Include(a => a.aspnet_Users1);
            return View(aspnet_Membership.ToList());
        }

        // GET: aspnet_Membership/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aspnet_Membership aspnet_Membership = db.aspnet_Membership.Find(id);
            if (aspnet_Membership == null)
            {
                return HttpNotFound();
            }
            return View(aspnet_Membership);
        }

        // GET: aspnet_Membership/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName");
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName");
            ViewBag.UserId = new SelectList(db.aspnet_Users, "UserId", "UserName");
            ViewBag.UserId = new SelectList(db.aspnet_Users, "UserId", "UserName");
            return View();
        }

        // POST: aspnet_Membership/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationId,UserId,Password,PasswordFormat,PasswordSalt,MobilePIN,Email,LoweredEmail,PasswordQuestion,PasswordAnswer,IsApproved,IsLockedOut,CreateDate,LastLoginDate,LastPasswordChangedDate,LastLockoutDate,FailedPasswordAttemptCount,FailedPasswordAttemptWindowStart,FailedPasswordAnswerAttemptCount,FailedPasswordAnswerAttemptWindowStart,Comment")] aspnet_Membership aspnet_Membership)
        {
            if (ModelState.IsValid)
            {
                aspnet_Membership.UserId = Guid.NewGuid();
                db.aspnet_Membership.Add(aspnet_Membership);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName", aspnet_Membership.ApplicationId);
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName", aspnet_Membership.ApplicationId);
            ViewBag.UserId = new SelectList(db.aspnet_Users, "UserId", "UserName", aspnet_Membership.UserId);
            ViewBag.UserId = new SelectList(db.aspnet_Users, "UserId", "UserName", aspnet_Membership.UserId);
            return View(aspnet_Membership);
        }

        // GET: aspnet_Membership/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aspnet_Membership aspnet_Membership = db.aspnet_Membership.Find(id);
            if (aspnet_Membership == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName", aspnet_Membership.ApplicationId);
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName", aspnet_Membership.ApplicationId);
            ViewBag.UserId = new SelectList(db.aspnet_Users, "UserId", "UserName", aspnet_Membership.UserId);
            ViewBag.UserId = new SelectList(db.aspnet_Users, "UserId", "UserName", aspnet_Membership.UserId);
            return View(aspnet_Membership);
        }

        // POST: aspnet_Membership/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationId,UserId,Password,PasswordFormat,PasswordSalt,MobilePIN,Email,LoweredEmail,PasswordQuestion,PasswordAnswer,IsApproved,IsLockedOut,CreateDate,LastLoginDate,LastPasswordChangedDate,LastLockoutDate,FailedPasswordAttemptCount,FailedPasswordAttemptWindowStart,FailedPasswordAnswerAttemptCount,FailedPasswordAnswerAttemptWindowStart,Comment")] aspnet_Membership aspnet_Membership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspnet_Membership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName", aspnet_Membership.ApplicationId);
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName", aspnet_Membership.ApplicationId);
            ViewBag.UserId = new SelectList(db.aspnet_Users, "UserId", "UserName", aspnet_Membership.UserId);
            ViewBag.UserId = new SelectList(db.aspnet_Users, "UserId", "UserName", aspnet_Membership.UserId);
            return View(aspnet_Membership);
        }

        // GET: aspnet_Membership/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aspnet_Membership aspnet_Membership = db.aspnet_Membership.Find(id);
            if (aspnet_Membership == null)
            {
                return HttpNotFound();
            }
            return View(aspnet_Membership);
        }

        // POST: aspnet_Membership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            aspnet_Membership aspnet_Membership = db.aspnet_Membership.Find(id);
            db.aspnet_Membership.Remove(aspnet_Membership);
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
