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
            var surveyQuestions = db.SurveyXQuestions.Where(p => p.SurveyID == id).ToList();
            List<Question> questions = new List<Question>();
            foreach (var sq in surveyQuestions)
            {
                var q = db.Questions.Where(quest => quest.QuestionID == sq.QuestionID).FirstOrDefault();
                questions.Add(q);
            }


            // Gets Active and Inactive Survey Questions
            survey.Questions = questions.Select(q => new SelectListItem() { Selected = false, Text = q.QText, Value = q.QuestionID.ToString() }).ToList();

            return View(survey);
        }

    }
}