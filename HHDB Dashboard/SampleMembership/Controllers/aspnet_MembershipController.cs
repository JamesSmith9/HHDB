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
		public ActionResult Create(int memberId = 0)
		{
			return CreateView(memberId);
		}


		private ActionResult CreateView(int memberId, aspnet_Membership viewModel = null)
		{
			if (viewModel == null)
			{
				viewModel = new aspnet_Membership
				{
					IsApproved = true
				};
			}
			
			var roles = db.aspnet_Roles.ToList();
			viewModel.UserRoles = roles.Select(role => new SelectListItem() { Selected = false, Text = role.RoleName, Value = role.RoleId.ToString() }).ToList();
			viewModel.ApplicationId = db.aspnet_Applications.Where(a => a.ApplicationName == "Hubbard House Survey Analysis System").SingleOrDefault().ApplicationId;

			return View(viewModel);
		}
	

	// POST: aspnet_Membership/Create
	// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
	// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Create([Bind(Include = "UserName,Password,IsLockedOut,Comment,RoleId,ApplicationId")] aspnet_Membership aspnet_Membership)
	{
		if (ModelState.IsValid)
		{
			MembershipUser user = Membership.CreateUser
			(
				aspnet_Membership.UserName,
				aspnet_Membership.Password
			);
			db.SaveChanges();

				var role = db.aspnet_Roles.Where(e => e.RoleId == aspnet_Membership.RoleId).FirstOrDefault();
			Roles.AddUserToRole(user.UserName, role.RoleName.ToString());

			return RedirectToAction("Index");
		}
			var roles = db.aspnet_Roles.ToList();
			aspnet_Membership.UserRoles = roles.Select(role => new SelectListItem() { Selected = false, Text = role.RoleName, Value = role.RoleId.ToString() }).ToList();
			aspnet_Membership.ApplicationId = db.aspnet_Applications.Where(a => a.ApplicationName == "Hubbard House Survey Analysis System").SingleOrDefault().ApplicationId;

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

		var user = db.aspnet_Users.Where(a => a.UserId == aspnet_Membership.UserId).FirstOrDefault();
		aspnet_Membership.UserName = user.UserName;

			var roles = db.aspnet_Roles.ToList();
			aspnet_Membership.UserRoles = roles.Select(role => new SelectListItem() { Selected = false, Text = role.RoleName, Value = role.RoleId.ToString() }).ToList();
			aspnet_Membership.ApplicationId = db.aspnet_Applications.Where(a => a.ApplicationName == "Hubbard House Survey Analysis System").SingleOrDefault().ApplicationId;
			//Users will only have one role
			var userCurrentRoles = db.aspnet_UsersInRoles.Where(e => e.UserId == user.UserId).FirstOrDefault();
			if (userCurrentRoles != null){
				aspnet_Membership.RoleId = userCurrentRoles.RoleId;
			}

			return View(aspnet_Membership);
	}

	// POST: aspnet_Membership/Edit/5
	// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
	// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Edit([Bind(Include = "UserName,Password,PasswordFormat,PasswordSalt,CreateDate,ApplicationId,UserId,LastLoginDate,LoweredEmail,passwordChange,IsApproved,IsLockedOut,Comment,LastLockoutDate,FailedPasswordAttemptCount,FailedPasswordAttemptWindowStart,FailedPasswordAnswerAttemptCount,FailedPasswordAnswerAttemptWindowStart,RoleId")] aspnet_Membership aspnet_Membership)
	{
			if (ModelState.IsValid)
			{

				if (!String.IsNullOrWhiteSpace(aspnet_Membership.passwordChange))
				{
					var member = Membership.GetUser(aspnet_Membership.UserName.ToString());
					if (member != null)
					{
						var passwordReset = Membership.EnablePasswordReset;
						var result = member.ChangePassword(member.ResetPassword(), aspnet_Membership.passwordChange);
						aspnet_Membership.LastPasswordChangedDate = DateTime.Now;
					}
					else
					{
						ModelState.AddModelError(string.Empty, "Error occured updating user password.");
					}
				}
				//If Role changed, delete old one and add new role
				var user = db.aspnet_Users.Where(a => a.UserId == aspnet_Membership.UserId).FirstOrDefault();
				var userCurrentRole = db.aspnet_UsersInRoles.Where(e => e.UserId == user.UserId).FirstOrDefault();
				var addUserRole = db.aspnet_Roles.Where(e => e.RoleId == aspnet_Membership.RoleId).FirstOrDefault();

				if (userCurrentRole != null)
				{
					var userCurrentRoleName = (db.aspnet_Roles.Where(e => e.RoleId == userCurrentRole.RoleId).FirstOrDefault()).RoleName;
					if (userCurrentRole.RoleId != aspnet_Membership.RoleId)
					{
						Roles.RemoveUserFromRole(aspnet_Membership.UserName.ToString(), userCurrentRoleName.ToString());
						Roles.AddUserToRole(aspnet_Membership.UserName.ToString(), addUserRole.RoleName.ToString());
					}
				}
				else
				{
					Roles.AddUserToRole(aspnet_Membership.UserName.ToString(), addUserRole.RoleName.ToString());
				}

				db.Entry(aspnet_Membership).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}


			var roles = db.aspnet_Roles.ToList();
			aspnet_Membership.UserRoles = roles.Select(role => new SelectListItem() { Selected = false, Text = role.RoleName, Value = role.RoleId.ToString() }).ToList();
			aspnet_Membership.ApplicationId = db.aspnet_Applications.Where(a => a.ApplicationName == "Hubbard House Survey Analysis System").SingleOrDefault().ApplicationId;

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
