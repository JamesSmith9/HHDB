﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace SampleMembership
{
	using System.Web.Http;

	class WebApiConfig
	{
		public static void Register(HttpConfiguration configuration)
		{
			configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
				new { id = RouteParameter.Optional });
		}
	}
}
