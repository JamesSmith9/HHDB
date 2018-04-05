using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Security;
using System.Security.Principal;
using SampleMembership.Models;

namespace SampleMembership
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private HHDBEntities db = new HHDBEntities();

        protected void Application_Start()
        {
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
			.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			GlobalConfiguration.Configuration.Formatters
			.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
		}

        protected void Application_AuthorizeRequest(Object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(User.Identity.Name))
            {
                return;
            }
            //Go find User Roles
            var currentUser = db.aspnet_Users.Where(p => p.UserName == User.Identity.Name).FirstOrDefault();
            var userinRoles = db.aspnet_UsersInRoles.Where(r => r.UserId == currentUser.UserId).ToList();
            string[] roles = new string[1];

            if (userinRoles != null)
            {
                foreach (var role in userinRoles)
                {
                    var userRole = (db.aspnet_Roles.Where(u => u.RoleId == role.RoleId).FirstOrDefault()).RoleName;
                    roles[0] = userRole;
                }
            }

            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                GenericPrincipal userPrincipal = new GenericPrincipal(new GenericIdentity(authTicket.Name), roles);
                HttpContext.Current.User = userPrincipal;
            }

        }

    }
}
