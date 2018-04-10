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
	public class HighchartsController : ApiController
	{
		private HHDBEntities db = new HHDBEntities();

		// GET: api/Controller
		[HttpGet]
		public JsonResult<List<HighchartsAnswerViewModel>> GetAnswers()
		{
			try
			{
				var chartAnswers = db.Answers.ToList();
				var result = chartAnswers.Select(f => new HighchartsAnswerViewModel { AnsText = f.AnsText, AnswerID = f.AnswerID, CreatedByUser = f.CreatedByUser, Month = f.Month, Quantity = f.Quantity, SXQID = f.SXQID, Year = f.Year }).ToList();
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