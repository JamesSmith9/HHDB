using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace SampleMembership.Controllers
{
    public class ImportController : Controller
    {
        // GET: Import
        public ActionResult Index()
        {
            return View();
        }

        // GET: Import/Form1
        public ActionResult Form1()
        {
            return View();
        }

       

    }
}