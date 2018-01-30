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

namespace SampleMembership.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Import"), fileName);
                file.SaveAs(path);



                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] { new DataColumn("SXQID", typeof(int)),
                                                        new DataColumn("AnsText", typeof(string)),
                                                        new DataColumn("Month",typeof(int)),
                                                        new DataColumn("Year", typeof(int)),
                                                        new DataColumn("Quantity", typeof(int))   });


                string csvData = System.IO.File.ReadAllText(path);
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach (string cell in row.Split(','))
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell;
                            i++;
                        }
                    }
                }

                string consString = ConfigurationManager.ConnectionStrings["SampleMembershipDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.Answer_Staging";
                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }





            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return View();
        }
    }
}