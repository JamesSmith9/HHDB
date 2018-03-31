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
    public class AnswersController : Controller
    {
        private HHDBEntities db = new HHDBEntities();

       
        // GET: Answers
        public ActionResult Index(string sortOrder, int? search, int? month, int? question)
        {

            

            //Sorting Anwers
            //Year
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Year_desc" : "";
            //Month
            ViewBag.MonthSortParm = sortOrder == "Month" ? "month_desc" : "Month";
            //Create by user
            ViewBag.CreateSortParm = sortOrder == "Create" ? "create_desc" : "Create";
            var answers = db.Answers
                .Include(a => a.SurveyXQuestion)
                .Include(a => a.aspnet_Users);

            foreach (Answer a in answers)
            {
                a.Q = db.SurveyXQuestions.Where(x => x.SXQID == a.SXQID)
                    .Select(x => x.Question).ToList();
            }

            //search year
            if(search != null)
            {
                answers = answers.Where(a => a.Year ==(search));
            }

            //search month
            if (month != null)
            {
                answers = answers.Where(a => a.Month == (month));
            }

            //search question
            if (question != null)
            {
                answers = answers.Where(a => a.SXQID == (question));
            }

            //Sort by Month, Year, User
            switch (sortOrder)
            {
                case "Year_desc":
                    answers = answers.OrderByDescending(a => a.Year);
                    break;

                case "Month":
                    answers = answers.OrderBy(a => a.Month);
                    break;

              case "create_desc":
                    answers = answers.OrderByDescending(a => a.CreatedByUser);
                    break;

                case "Create":
                    answers = answers.OrderBy(a => a.CreatedByUser);
                    break;

                case "month_desc":
                    answers = answers.OrderByDescending(a => a.Month);
                    break;
                default:
                    answers = answers.OrderBy(a => a.Year);
                    break;

            }

            

            return View(answers.ToList());
        }

        // GET: Answers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // GET: Answers/Create
        public ActionResult Create()
        {
            ViewBag.SXQID = new SelectList(db.SurveyXQuestions, "SXQID", "SXQID");
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SXQID,AnsText,CreatedByUser,AnswerID,Month,Year,Quantity")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Answers.Add(answer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SXQID = new SelectList(db.SurveyXQuestions, "SXQID", "SXQID", answer.SXQID);
            return View(answer);
        }

        // GET: Answers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.SXQID = new SelectList(db.SurveyXQuestions, "SXQID", "SXQID", answer.SXQID);
            return View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SXQID,AnsText,CreatedByUser,AnswerID,Month,Year,Quantity")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SXQID = new SelectList(db.SurveyXQuestions, "SXQID", "SXQID", answer.SXQID);
            return View(answer);
        }

        // GET: Answers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Answer answer = db.Answers.Find(id);
            db.Answers.Remove(answer);
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
