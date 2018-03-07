using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMembership.Models;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace SampleMembership.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {

		private HHDBEntities db = new HHDBEntities();


		// GET: Upload
		public ActionResult Upload()
        {

            return View();
        }




		[HttpPost]
		public ActionResult ImportForm([Bind(Include = "SurveyID")]Survey model)
        {

			model.SurveyQuestions = db.SurveyXQuestions.Where(x => x.SurveyID == model.SurveyID)
				.Select(x => x.Question).ToList();
			/*
            int Month = Convert.ToInt32(Request["month"].ToString());
            int Year = Convert.ToInt32(Request["year"].ToString());
            MembershipUser u = Membership.GetUser();
            Guid user = (Guid)u.ProviderUserKey;
            List<AnsHandle> answer = new List<AnsHandle>();
            int sxqCount = 0;

			List<int> sxqArray = new List<int>();
            foreach (var item in sxqid)
            {
                sxqArray.Add(item);
            }
                        

            for (int i = 0; i < yes.Length; i++)
            {
                AnsHandle AnsY = new AnsHandle(sxqArray[sxqCount], "Yes", user, Month, Year, yes[i]);
                AnsHandle AnsN = new AnsHandle(sxqArray[sxqCount], "No", user, Month, Year, no[i]);
                answer.Add(AnsY);
                answer.Add(AnsN);
                sxqCount++;
            }

            for (int i = 0; i < one.Length; i++)
            {
                AnsHandle AnsOne = new AnsHandle(sxqArray[sxqCount], "1", user, Month, Year, one[i]);
                AnsHandle AnsTwo = new AnsHandle(sxqArray[sxqCount], "2", user, Month, Year, two[i]);
                AnsHandle AnsThree = new AnsHandle(sxqArray[sxqCount], "3", user, Month, Year, three[i]);
                AnsHandle AnsFour = new AnsHandle(sxqArray[sxqCount], "4", user, Month, Year, four[i]);
                AnsHandle AnsFive = new AnsHandle(sxqArray[sxqCount], "5", user, Month, Year, five[i]);
                answer.Add(AnsOne);
                answer.Add(AnsTwo);
                answer.Add(AnsThree);
                answer.Add(AnsFour);
                answer.Add(AnsFive);
                sxqCount++;
            }

            string connString = ConfigurationManager.ConnectionStrings["SampleMembershipDB"].ConnectionString;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                foreach (AnsHandle a in answer)
                {
                    AnswerSqlHandler(a.SXQID, a.AnsText, a.CreatedByUser, a.Month, a.Year, a.Quantity, conn);
                }

                
                List<string> s1qc = new List<string>();
                string rawStr = Request["myInputs[]"].ToString();
                string[] str = rawStr.Split(',');
                foreach (string s in str)
                {
                    if (s != null)
                    {
                        s1qc.Add(s);
                    }
                }

                foreach (string s in s1qc)
                {
                    if (s != null)
                    {
                        AnswerSqlHandler(36, s, user, Month, Year, 1, conn);
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

	*/
			return View("Upload");
		
        }


        public void AnswerSqlHandler(int SXQID, string AnsText, Guid user, int Month, int Year, int Quantity, SqlConnection conn)
        {
            if (Quantity != 0 && AnsText != null && AnsText != "")
            {


                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Answer (SXQID, AnsText, CreatedByUser, Month, Year, Quantity) VALUES (@SXQID, @AnsText, @User, @Month, @Year, @Quantity)";
                    cmd.Parameters.AddWithValue("@SXQID", SXQID);
                    cmd.Parameters.AddWithValue("@AnsText", AnsText);
                    cmd.Parameters.AddWithValue("@User", user);
                    cmd.Parameters.AddWithValue("@Month", Month);
                    cmd.Parameters.AddWithValue("@Year", Year);
                    cmd.Parameters.AddWithValue("@Quantity", Quantity);
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
        }
    }
}