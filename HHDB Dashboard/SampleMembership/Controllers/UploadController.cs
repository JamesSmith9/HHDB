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

namespace SampleMembership.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Upload()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Form1(object sender, EventArgs e)
        {
                
            int Month = Convert.ToInt32(Request["month"].ToString());
            int Year = Convert.ToInt32(Request["year"].ToString());


            int s1q1y = Convert.ToInt32(Request["s1q1y"].ToString());
            int s1q1n = Convert.ToInt32(Request["s1q1n"].ToString());





            string connString = ConfigurationManager.ConnectionStrings["SampleMembershipDB"].ConnectionString;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                AnswerSqlHandler(1, "Yes", Month, Year, s1q1y, conn);
                AnswerSqlHandler(1, "No", Month, Year, s1q1n, conn);

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




            return View("Upload");
        }





        public void AnswerSqlHandler (int SXQID, string AnsText, int Month, int Year, int Quantity, SqlConnection conn)
        {
            if (Quantity != 0)
            {


                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO dbo.Answer (SXQID, AnsText, CreatedByUser, Month, Year, Quantity) VALUES (@SXQID, @AnsText, @User, @Month, @Year, @Quantity)";
                    cmd.Parameters.AddWithValue("@SXQID", SXQID);
                    cmd.Parameters.AddWithValue("@AnsText", AnsText);
                    cmd.Parameters.AddWithValue("@User", User);
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