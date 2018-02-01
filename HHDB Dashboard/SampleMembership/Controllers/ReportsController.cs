using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleMembership.Models;
using System.Web.Mvc;

namespace SampleMembership.Controllers
{
    public class ReportsController : Controller
    {

        private HHDBEntities db = new HHDBEntities();

        public class Summary
        {
            public double Item { get; set; }
            public string Value { get; set; }
        }

        public JsonResult QuestionSummary()
        {
            List<Summary> lstSummary = new List<Summary>();
            Summary summary = new Summary();
            
            return Json(lstSummary.ToList(), JsonRequestBehavior.AllowGet);
        }

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


    }
}