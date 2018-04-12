using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SampleMembership.Models;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace SampleMembership.Controllers
{
    [RoutePrefix("api/highcharts")]
    public class HighchartsController : ApiController
	{
		private HHDBEntities db = new HHDBEntities();

		// GET: api/Controller
		[HttpGet]
        [Route("")]
        public JsonResult<List<HighchartsAnswerViewModel>> GetAnswers(int surveyId)
		{
			try
			{
                var surveyQuestions = (db.SurveyXQuestions.Where(s => s.SurveyID == surveyId).ToList());
                var Answers = db.Answers;
                List<Answer> surveyAnswers = new List<Answer>();

                // Match Answer to Survey Question
                foreach (var a in Answers)
                {
                    foreach (var s in surveyQuestions)
                    {
                        if (a.SXQID == s.SXQID)
                        {
                            surveyAnswers.Add(a);
                        }
                    }
                }

				var result = surveyAnswers.Select(f => new HighchartsAnswerViewModel { AnsText = f.AnsText, AnswerID = f.AnswerID, CreatedByUser = f.CreatedByUser, Month = f.Month, Quantity = f.Quantity, SXQID = f.SXQID, Year = f.Year }).ToList();
				return Json(result);

			}
			catch (System.Exception)
			{
				throw;
			}
		}

        //eg: GET api/highcharts?questionId={questionId}
        [HttpGet]
        [Route("")]
        public JsonResult<List<HighchartsAnswerViewModel>> GetAnswers(int surveyId, int questionId)
        {
            try
            {
                var surveyQuestions = (db.SurveyXQuestions.Where(s => s.SurveyID == surveyId && s.QuestionID == questionId).ToList());
                var Answers = db.Answers;
                List<Answer> surveyAnswers = new List<Answer>();

                // Match Answer to Survey Question
                foreach (var a in Answers)
                {
                    foreach (var s in surveyQuestions)
                    {
                        if (a.SXQID == s.SXQID)
                        {
                            surveyAnswers.Add(a);
                        }
                    }
                }

                var result = surveyAnswers.Select(f => new HighchartsAnswerViewModel { AnsText = f.AnsText, AnswerID = f.AnswerID, CreatedByUser = f.CreatedByUser, Month = f.Month, Quantity = f.Quantity, SXQID = f.SXQID, Year = f.Year }).ToList();
                return Json(result);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        // GET: api/Controller
        [HttpGet]
        public JsonResult<List<HighchartsAnswerViewModel>> GetAnswers(int surveyId, int questionId, int month)
        {
            try
            {
                var surveyQuestions = (db.SurveyXQuestions.Where(s => s.SurveyID == surveyId && s.QuestionID == questionId).ToList());
                var Answers = db.Answers.Where(a => a.Month == month);
                List<Answer> surveyAnswers = new List<Answer>();

                // Match Answer to Survey Question
                foreach (var a in Answers)
                {
                    foreach (var s in surveyQuestions)
                    {
                        if (a.SXQID == s.SXQID)
                        {
                            surveyAnswers.Add(a);
                        }
                    }
                }

                var result = surveyAnswers.Select(f => new HighchartsAnswerViewModel { AnsText = f.AnsText, AnswerID = f.AnswerID, CreatedByUser = f.CreatedByUser, Month = f.Month, Quantity = f.Quantity, SXQID = f.SXQID, Year = f.Year }).ToList();
                return Json(result);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public JsonResult<List<HighchartsAnswerViewModel>> GetAnswers(int surveyId, int questionId, int month, int year)
        {
            try
            {
                var surveyQuestions = (db.SurveyXQuestions.Where(s => s.SurveyID == surveyId && s.QuestionID == questionId).ToList());
                var Answers = db.Answers.Where(a => a.Month == month && a.Year == year);
                List<Answer> surveyAnswers = new List<Answer>();

                // Match Answer to Survey Question
                foreach (var a in Answers)
                {
                    foreach (var s in surveyQuestions)
                    {
                        if (a.SXQID == s.SXQID)
                        {
                            surveyAnswers.Add(a);
                        }
                    }
                }

                var result = surveyAnswers.Select(f => new HighchartsAnswerViewModel { AnsText = f.AnsText, AnswerID = f.AnswerID, CreatedByUser = f.CreatedByUser, Month = f.Month, Quantity = f.Quantity, SXQID = f.SXQID, Year = f.Year }).ToList();
                return Json(result);

            }
            catch (System.Exception)
            {
                throw;
            }
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