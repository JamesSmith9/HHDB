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

        // GET: Import
        public ActionResult Index() => View(db.Surveys.ToList());

        // GET: Import/Form1
        public ActionResult Form1()
        {
            return View();
        }

        public ActionResult ImportForm(int? id)
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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "SXQID,QuestionID,SurveyID")] SurveyXQuestion surveyXQuestion)
		{
			if (ModelState.IsValid)
			{
				db.SurveyXQuestions.Add(surveyXQuestion);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "QText", surveyXQuestion.QuestionID);
			ViewBag.SurveyID = new SelectList(db.Surveys, "SurveyID", "Name", surveyXQuestion.SurveyID);
			return View(surveyXQuestion);
		}


	}
}