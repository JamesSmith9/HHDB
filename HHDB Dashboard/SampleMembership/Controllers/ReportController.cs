using SampleMembership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleMembership.Controllers
{
    public class ReportController : Controller
    {
        private HHDBEntities db = new HHDBEntities();

        // GET: Report
        public ActionResult Index() => View(db.Surveys.ToList());



        public ActionResult ReportForm(int? id)
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