using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleMembership.Models;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SampleMembership.Controllers
{
    public class ReportsController : Controller
    {

        private HHDBEntities db = new HHDBEntities();

        public static DataTable GetQuestionSummary()
        {
            DataTable dt = new DataTable("ChartSummary");
            string query = "Select QuestionAns From [dbo].[Answers_int]";
            string connString = ConfigurationManager.ConnectionStrings["SampleMembershipDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            //con.ConnectionString = "Data Source=.;" + "Initial Catalog=Transport;" + "Persist Security Info=True;";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            //cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public class Summary
        {
            public double Item { get; set; }
            public string Value { get; set; }
        }

        public JsonResult ChartSummary()
        {
            List<Summary> lstSummary = new List<Summary>();

            foreach (DataRow dr in GetQuestionSummary().Rows)
            {
                Summary summary = new Summary();
                summary.Value = dr[0].ToString().Trim();
                summary.Item = Convert.ToDouble(dr[1]);
                lstSummary.Add(summary);

            }
            return Json(lstSummary.ToList(), JsonRequestBehavior.AllowGet);
        }
        // GET: Reports
        public ActionResult Index()
        {

            var exemploList = new SelectList(new[] { "Exemplo1:", "Exemplo2", "Exemplo3" });
            ViewBag.ExemploList = exemploList;

            return View();
        }
        public ActionResult PieChart()
        {
            return View();
        }

        public ActionResult LineGraph()
        {
            return View();
        }
        public class DropDownListController : Controller
        {
            //  
            // GET: /DropDownList/  
            public ActionResult Index()
            {
                return View();
            }
        }
    }

}
