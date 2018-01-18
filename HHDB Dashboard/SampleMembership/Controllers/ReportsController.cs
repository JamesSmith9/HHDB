using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMembership.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PieChart()
        {
            return View();
        }

        public ActionResult LineGraph()
        {
            return View();
        }

        public ActionResult Import()
        {
            return View("~/Views/import/Index.cshtml");
        }

        public ActionResult CreateGraph()
        {
            return View();
        }
    }
}