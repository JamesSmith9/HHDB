using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SampleMembership.Models;

namespace SampleMembership.Controllers
{
    public class aspnet_MembershipController : Controller
    {
        private HHDBEntities db = new HHDBEntities();

        // GET: aspnet_Membership
        public ActionResult Index()
        {
            var aspnet_Membership = db.aspnet_Membership.ToList();
            return View(aspnet_Membership);
        }

        // GET: aspnet_Membership/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationId = new SelectList(db.aspnet_Applications, "ApplicationId", "ApplicationName");
            ViewBag.UserId = new SelectList(db.aspnet_Users, "UserId", "UserName");
            return View();
        }

        // POST: aspnet_Membership/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,Password,Email,IsLockedOut,Comment")] aspnet_Membership aspnet_Membership)
        {
            if (ModelState.IsValid)
            {
				var hubbardHouseApplication = db.aspnet_Applications.Where(a => a.ApplicationName == "Hubbard House Survey Analysis System").SingleOrDefault();
				aspnet_Users user = new aspnet_Users();
                user.UserName = aspnet_Membership.UserName;
                user.LoweredUserName = aspnet_Membership.UserName.ToLower();
                user.UserId = Guid.NewGuid();
				user.ApplicationId = hubbardHouseApplication.ApplicationId;
				db.aspnet_Users.Add(user);
                db.SaveChanges();

                aspnet_Membership.CreateDate = DateTime.Now;
                aspnet_Membership.PasswordFormat = 1;
                aspnet_Membership.PasswordSalt = DateTime.Now.ToString();
                aspnet_Membership.CreateDate = DateTime.Now;
                aspnet_Membership.UserId = user.UserId;
				aspnet_Membership.aspnet_Applications = db.aspnet_Applications.Where(a => a.ApplicationName == "Hubbard House Survey Analysis System");

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
