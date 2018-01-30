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
    public class SurveyXQuestionsController : Controller
    {
        private HHDBEntities db = new HHDBEntities();

        // GET: SurveyXQuestions
        public ActionResult Index()
        {
            var surveyXQuestions = db.SurveyXQuestions.Include(s => s.Question).Include(s => s.Survey);
            return View(surveyXQuestions.ToList());
        }

        // GET: SurveyXQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyXQuestion surveyXQuestion = db.SurveyXQuestions.Find(id);
            if (surveyXQuestion == null)
            {
                return HttpNotFound();
            }
            return View(surveyXQuestion);
        }

        // GET: SurveyXQuestions/Create
        public ActionResult Create()
        {
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "QText");
            ViewBag.SurveyID = new SelectList(db.Surveys, "SurveyID", "Name");
            return View();
        }

        // POST: SurveyXQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: SurveyXQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyXQuestion surveyXQuestion = db.SurveyXQuestions.Find(id);
            if (surveyXQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "QText", surveyXQuestion.QuestionID);
            ViewBag.SurveyID = new SelectList(db.Surveys, "SurveyID", "Name", surveyXQuestion.SurveyID);
            return View(surveyXQuestion);
        }

        // POST: SurveyXQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SXQID,QuestionID,SurveyID")] SurveyXQuestion surveyXQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surveyXQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "QText", surveyXQuestion.QuestionID);
            ViewBag.SurveyID = new SelectList(db.Surveys, "SurveyID", "Name", surveyXQuestion.SurveyID);
            return View(surveyXQuestion);
        }

        // GET: SurveyXQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyXQuestion surveyXQuestion = db.SurveyXQuestions.Find(id);
            if (surveyXQuestion == null)
            {
                return HttpNotFound();
            }
            return View(surveyXQuestion);
        }

        // POST: SurveyXQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SurveyXQuestion surveyXQuestion = db.SurveyXQuestions.Find(id);
            db.SurveyXQuestions.Remove(surveyXQuestion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
