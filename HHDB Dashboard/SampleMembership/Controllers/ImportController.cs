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
    public class ImportController : Controller
    {
        private HHDBEntities db = new HHDBEntities();

        //GET: Import/InputForm
        public ActionResult InputForm() => View(db.Questions.ToList());

        // GET: Import
        public ActionResult Index() => View(db.Surveys.ToList());


        // GET: Import/Form1
        public ActionResult Form1()
        {
            return View();
        }



    }
}