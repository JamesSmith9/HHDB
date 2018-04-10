using SampleMembership.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleMembership.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {

        private HHDBEntities db = new HHDBEntities();


        public ActionResult Index()
        {
            return View(db.Surveys.ToList());
        }

        public ActionResult Report(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);

            if (survey == null)
            {
                return HttpNotFound();
            }

            // Gets Active and Inactive Survey Questions
            survey.SurveyQuestions = db.SurveyXQuestions.Where(x => x.SurveyID == survey.SurveyID)
                .Select(x => x.Question).ToList();

            return View(survey);
        }

    }
}