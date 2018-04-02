using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SampleMembership.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace SampleMembership.Controllers
{
    public class SurveysController : Controller
    {
        private HHDBEntities db = new HHDBEntities();

        // GET: Surveys
        public ActionResult Index()
        {
            return View(db.Surveys.ToList());
        }

        // GET: Surveys/Details/5
        public ActionResult Details(int? id)
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

        // GET: Surveys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Surveys/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SurveyID,Name,Active")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(survey);
        }

        // GET: Surveys/Edit/5
        public ActionResult Edit(int? id)
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
            return View(survey);
        }

        // POST: Surveys/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SurveyID,Name,Active")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public ActionResult Delete(int? id)
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
            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey survey = db.Surveys.Find(id);
            db.Surveys.Remove(survey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SXQEdit(int? id)
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

            survey.SurveyQuestions = db.SurveyXQuestions.Where(x => x.SurveyID == survey.SurveyID)
                .Select(x => x.Question).ToList();

            survey.AllQuestions = db.Questions.ToList();


            return View(survey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult SXQAdd([Bind(Include = "SurveyID")]Survey survey, string QuestionToAdd)
        {
            survey.SurveyQuestions = db.SurveyXQuestions.Where(x => x.SurveyID == survey.SurveyID)
                .Select(x => x.Question).ToList();

            int QID = Int32.Parse(QuestionToAdd);


            if (QID != -1)
            {
                string connString = ConfigurationManager.ConnectionStrings["SampleMembershipDB"].ConnectionString;
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(connString);
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO SurveyXQuestion (QuestionID, SurveyID) VALUES (@QuestionID, @SurveyID)";
                        cmd.Parameters.AddWithValue("QuestionID", QID);
                        cmd.Parameters.AddWithValue("@SurveyID", survey.SurveyID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                        {
                            //Success notification
                        }
                        else
                        {
                            //Error notification
                        }
                    }
                }
                catch (Exception ex)
                {
                    string a = ex.ToString();
                    //log error 
                    //display friendly error to user
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }

            }

            return View("Details", survey);
        }

        public ActionResult SXQRemove([Bind(Include = "SurveyID")]Survey survey, string QuestionToAdd)
        {
            survey.SurveyQuestions = db.SurveyXQuestions.Where(x => x.SurveyID == survey.SurveyID)
                .Select(x => x.Question).ToList();

            int QID = Int32.Parse(QuestionToAdd);


            if (QID != -1)
            {
                string connString = ConfigurationManager.ConnectionStrings["SampleMembershipDB"].ConnectionString;
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(connString);
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE FROM SurveyXQuestion WHERE QuestionID = '@QuestionID' AND SurveyID = '@SurveyID')";
                        cmd.Parameters.AddWithValue("QuestionID", QID);
                        cmd.Parameters.AddWithValue("@SurveyID", survey.SurveyID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                        {
                            //Success notification
                        }
                        else
                        {
                            //Error notification
                        }
                    }
                }
                catch (Exception ex)
                {
                    string a = ex.ToString();
                    //log error 
                    //display friendly error to user
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }

            }

            return View("Details", survey);
        }
    }
}
