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
            var username = HttpContext.Session["user"];
            MembershipUser u = Membership.GetUser();
            Guid user = (Guid) u.ProviderUserKey;
           //Guid user = new Guid("83e8a966-e8b8-4f15-a03d-1de51f573c8f");

            int s1q1y = Convert.ToInt32(Request["s1q1y"].ToString());
            int s1q1n = Convert.ToInt32(Request["s1q1n"].ToString());
            int s1q2y = Convert.ToInt32(Request["s1q2y"].ToString());
            int s1q2n = Convert.ToInt32(Request["s1q2n"].ToString());
            int s1q3y = Convert.ToInt32(Request["s1q3y"].ToString());
            int s1q3n = Convert.ToInt32(Request["s1q3n"].ToString());
            int s1q4y = Convert.ToInt32(Request["s1q4y"].ToString());
            int s1q4n = Convert.ToInt32(Request["s1q4n"].ToString());
            int s1q5y = Convert.ToInt32(Request["s1q5y"].ToString());
            int s1q5n = Convert.ToInt32(Request["s1q5n"].ToString());
            int s1q6y = Convert.ToInt32(Request["s1q6y"].ToString());
            int s1q6n = Convert.ToInt32(Request["s1q6n"].ToString());
            int s1q7y = Convert.ToInt32(Request["s1q7y"].ToString());
            int s1q7n = Convert.ToInt32(Request["s1q7n"].ToString());
            int s1q8y = Convert.ToInt32(Request["s1q8y"].ToString());
            int s1q8n = Convert.ToInt32(Request["s1q8n"].ToString());
            int s1q9y = Convert.ToInt32(Request["s1q9y"].ToString());
            int s1q9n = Convert.ToInt32(Request["s1q9n"].ToString());



            int s1q101 = Convert.ToInt32(Request["s1q101"].ToString());
            int s1q102 = Convert.ToInt32(Request["s1q102"].ToString());
            int s1q103 = Convert.ToInt32(Request["s1q103"].ToString());
            int s1q104 = Convert.ToInt32(Request["s1q104"].ToString());
            int s1q105 = Convert.ToInt32(Request["s1q105"].ToString());

            int s1q111 = Convert.ToInt32(Request["s1q111"].ToString());
            int s1q112 = Convert.ToInt32(Request["s1q112"].ToString());
            int s1q113 = Convert.ToInt32(Request["s1q113"].ToString());
            int s1q114 = Convert.ToInt32(Request["s1q114"].ToString());
            int s1q115 = Convert.ToInt32(Request["s1q115"].ToString());

            int s1q121 = Convert.ToInt32(Request["s1q121"].ToString());
            int s1q122 = Convert.ToInt32(Request["s1q122"].ToString());
            int s1q123 = Convert.ToInt32(Request["s1q123"].ToString());
            int s1q124 = Convert.ToInt32(Request["s1q124"].ToString());
            int s1q125 = Convert.ToInt32(Request["s1q125"].ToString());

            int s1q131 = Convert.ToInt32(Request["s1q131"].ToString());
            int s1q132 = Convert.ToInt32(Request["s1q132"].ToString());
            int s1q133 = Convert.ToInt32(Request["s1q133"].ToString());
            int s1q134 = Convert.ToInt32(Request["s1q134"].ToString());
            int s1q135 = Convert.ToInt32(Request["s1q135"].ToString());

            int s1q141 = Convert.ToInt32(Request["s1q141"].ToString());
            int s1q142 = Convert.ToInt32(Request["s1q142"].ToString());
            int s1q143 = Convert.ToInt32(Request["s1q143"].ToString());
            int s1q144 = Convert.ToInt32(Request["s1q144"].ToString());
            int s1q145 = Convert.ToInt32(Request["s1q145"].ToString());

            int s1q151 = Convert.ToInt32(Request["s1q151"].ToString());
            int s1q152 = Convert.ToInt32(Request["s1q152"].ToString());
            int s1q153 = Convert.ToInt32(Request["s1q153"].ToString());
            int s1q154 = Convert.ToInt32(Request["s1q154"].ToString());
            int s1q155 = Convert.ToInt32(Request["s1q155"].ToString());

            int s1q161 = Convert.ToInt32(Request["s1q161"].ToString());
            int s1q162 = Convert.ToInt32(Request["s1q162"].ToString());
            int s1q163 = Convert.ToInt32(Request["s1q163"].ToString());
            int s1q164 = Convert.ToInt32(Request["s1q164"].ToString());
            int s1q165 = Convert.ToInt32(Request["s1q165"].ToString());

            int s1q171 = Convert.ToInt32(Request["s1q171"].ToString());
            int s1q172 = Convert.ToInt32(Request["s1q172"].ToString());
            int s1q173 = Convert.ToInt32(Request["s1q173"].ToString());
            int s1q174 = Convert.ToInt32(Request["s1q174"].ToString());
            int s1q175 = Convert.ToInt32(Request["s1q175"].ToString());

            int s1q181 = Convert.ToInt32(Request["s1q181"].ToString());
            int s1q182 = Convert.ToInt32(Request["s1q182"].ToString());
            int s1q183 = Convert.ToInt32(Request["s1q183"].ToString());
            int s1q184 = Convert.ToInt32(Request["s1q184"].ToString());
            int s1q185 = Convert.ToInt32(Request["s1q185"].ToString());

            int s1q191 = Convert.ToInt32(Request["s1q191"].ToString());
            int s1q192 = Convert.ToInt32(Request["s1q192"].ToString());
            int s1q193 = Convert.ToInt32(Request["s1q193"].ToString());
            int s1q194 = Convert.ToInt32(Request["s1q194"].ToString());
            int s1q195 = Convert.ToInt32(Request["s1q195"].ToString());

            int s1q201 = Convert.ToInt32(Request["s1q201"].ToString());
            int s1q202 = Convert.ToInt32(Request["s1q202"].ToString());
            int s1q203 = Convert.ToInt32(Request["s1q203"].ToString());
            int s1q204 = Convert.ToInt32(Request["s1q204"].ToString());
            int s1q205 = Convert.ToInt32(Request["s1q205"].ToString());

            int s1q211 = Convert.ToInt32(Request["s1q211"].ToString());
            int s1q212 = Convert.ToInt32(Request["s1q212"].ToString());
            int s1q213 = Convert.ToInt32(Request["s1q213"].ToString());
            int s1q214 = Convert.ToInt32(Request["s1q214"].ToString());
            int s1q215 = Convert.ToInt32(Request["s1q215"].ToString());

            int s1q221 = Convert.ToInt32(Request["s1q221"].ToString());
            int s1q222 = Convert.ToInt32(Request["s1q222"].ToString());
            int s1q223 = Convert.ToInt32(Request["s1q223"].ToString());
            int s1q224 = Convert.ToInt32(Request["s1q224"].ToString());
            int s1q225 = Convert.ToInt32(Request["s1q225"].ToString());

            int s1q231 = Convert.ToInt32(Request["s1q231"].ToString());
            int s1q232 = Convert.ToInt32(Request["s1q232"].ToString());
            int s1q233 = Convert.ToInt32(Request["s1q233"].ToString());
            int s1q234 = Convert.ToInt32(Request["s1q234"].ToString());
            int s1q235 = Convert.ToInt32(Request["s1q235"].ToString());

            int s1q241 = Convert.ToInt32(Request["s1q241"].ToString());
            int s1q242 = Convert.ToInt32(Request["s1q242"].ToString());
            int s1q243 = Convert.ToInt32(Request["s1q243"].ToString());
            int s1q244 = Convert.ToInt32(Request["s1q244"].ToString());
            int s1q245 = Convert.ToInt32(Request["s1q245"].ToString());

            int s1q251 = Convert.ToInt32(Request["s1q251"].ToString());
            int s1q252 = Convert.ToInt32(Request["s1q252"].ToString());
            int s1q253 = Convert.ToInt32(Request["s1q253"].ToString());
            int s1q254 = Convert.ToInt32(Request["s1q254"].ToString());
            int s1q255 = Convert.ToInt32(Request["s1q255"].ToString());

            int s1q261 = Convert.ToInt32(Request["s1q261"].ToString());
            int s1q262 = Convert.ToInt32(Request["s1q262"].ToString());
            int s1q263 = Convert.ToInt32(Request["s1q263"].ToString());
            int s1q264 = Convert.ToInt32(Request["s1q264"].ToString());
            int s1q265 = Convert.ToInt32(Request["s1q265"].ToString());

            int s1q271 = Convert.ToInt32(Request["s1q271"].ToString());
            int s1q272 = Convert.ToInt32(Request["s1q272"].ToString());
            int s1q273 = Convert.ToInt32(Request["s1q273"].ToString());
            int s1q274 = Convert.ToInt32(Request["s1q274"].ToString());
            int s1q275 = Convert.ToInt32(Request["s1q275"].ToString());

            int s1q281 = Convert.ToInt32(Request["s1q281"].ToString());
            int s1q282 = Convert.ToInt32(Request["s1q282"].ToString());
            int s1q283 = Convert.ToInt32(Request["s1q283"].ToString());
            int s1q284 = Convert.ToInt32(Request["s1q284"].ToString());
            int s1q285 = Convert.ToInt32(Request["s1q285"].ToString());

            int s1q291 = Convert.ToInt32(Request["s1q291"].ToString());
            int s1q292 = Convert.ToInt32(Request["s1q292"].ToString());
            int s1q293 = Convert.ToInt32(Request["s1q293"].ToString());
            int s1q294 = Convert.ToInt32(Request["s1q294"].ToString());
            int s1q295 = Convert.ToInt32(Request["s1q295"].ToString());

            int s1q301 = Convert.ToInt32(Request["s1q301"].ToString());
            int s1q302 = Convert.ToInt32(Request["s1q302"].ToString());
            int s1q303 = Convert.ToInt32(Request["s1q303"].ToString());
            int s1q304 = Convert.ToInt32(Request["s1q304"].ToString());
            int s1q305 = Convert.ToInt32(Request["s1q305"].ToString());

            int s1q311 = Convert.ToInt32(Request["s1q311"].ToString());
            int s1q312 = Convert.ToInt32(Request["s1q312"].ToString());
            int s1q313 = Convert.ToInt32(Request["s1q313"].ToString());
            int s1q314 = Convert.ToInt32(Request["s1q314"].ToString());
            int s1q315 = Convert.ToInt32(Request["s1q315"].ToString());

            int s1q321 = Convert.ToInt32(Request["s1q321"].ToString());
            int s1q322 = Convert.ToInt32(Request["s1q322"].ToString());
            int s1q323 = Convert.ToInt32(Request["s1q323"].ToString());
            int s1q324 = Convert.ToInt32(Request["s1q324"].ToString());
            int s1q325 = Convert.ToInt32(Request["s1q325"].ToString());

            int s1q331 = Convert.ToInt32(Request["s1q331"].ToString());
            int s1q332 = Convert.ToInt32(Request["s1q332"].ToString());
            int s1q333 = Convert.ToInt32(Request["s1q333"].ToString());
            int s1q334 = Convert.ToInt32(Request["s1q334"].ToString());
            int s1q335 = Convert.ToInt32(Request["s1q335"].ToString());

            int s1q341 = Convert.ToInt32(Request["s1q341"].ToString());
            int s1q342 = Convert.ToInt32(Request["s1q342"].ToString());
            int s1q343 = Convert.ToInt32(Request["s1q343"].ToString());
            int s1q344 = Convert.ToInt32(Request["s1q344"].ToString());
            int s1q345 = Convert.ToInt32(Request["s1q345"].ToString());

            int s1q351 = Convert.ToInt32(Request["s1q351"].ToString());
            int s1q352 = Convert.ToInt32(Request["s1q352"].ToString());
            int s1q353 = Convert.ToInt32(Request["s1q353"].ToString());
            int s1q354 = Convert.ToInt32(Request["s1q354"].ToString());
            int s1q355 = Convert.ToInt32(Request["s1q355"].ToString());

            List<string> s1qc = new List<string>();
            string rawStr = Request["myInputs[]"].ToString();
            string[] str = rawStr.Split(',');
            foreach(string s in str)
            { 
            s1qc.Add(s);
            }



            string connString = ConfigurationManager.ConnectionStrings["SampleMembershipDB"].ConnectionString;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                AnswerSqlHandler(1, "Yes", user, Month, Year, s1q1y, conn);
                AnswerSqlHandler(1, "No", user, Month, Year, s1q1n, conn);
                AnswerSqlHandler(2, "Yes", user, Month, Year, s1q2y, conn);
                AnswerSqlHandler(2, "No", user, Month, Year, s1q2n, conn);
                AnswerSqlHandler(3, "Yes", user, Month, Year, s1q3y, conn);
                AnswerSqlHandler(3, "No", user, Month, Year, s1q3n, conn);
                AnswerSqlHandler(4, "Yes", user, Month, Year, s1q4y, conn);
                AnswerSqlHandler(4, "No", user, Month, Year, s1q4n, conn);
                AnswerSqlHandler(5, "Yes", user, Month, Year, s1q5y, conn);
                AnswerSqlHandler(5, "No", user, Month, Year, s1q5n, conn);
                AnswerSqlHandler(6, "Yes", user, Month, Year, s1q6y, conn);
                AnswerSqlHandler(6, "No", user, Month, Year, s1q6n, conn);
                AnswerSqlHandler(7, "Yes", user, Month, Year, s1q7y, conn);
                AnswerSqlHandler(7, "No", user, Month, Year, s1q7n, conn);
                AnswerSqlHandler(8, "Yes", user, Month, Year, s1q8y, conn);
                AnswerSqlHandler(8, "No", user, Month, Year, s1q8n, conn);
                AnswerSqlHandler(9, "Yes", user, Month, Year, s1q9y, conn);
                AnswerSqlHandler(9, "No", user, Month, Year, s1q9n, conn);

                AnswerSqlHandler(10, "1", user, Month, Year, s1q101, conn);
                AnswerSqlHandler(10, "2", user, Month, Year, s1q102, conn);
                AnswerSqlHandler(10, "3", user, Month, Year, s1q103, conn);
                AnswerSqlHandler(10, "4", user, Month, Year, s1q104, conn);
                AnswerSqlHandler(10, "5", user, Month, Year, s1q105, conn);

                AnswerSqlHandler(11, "1", user, Month, Year, s1q111, conn);
                AnswerSqlHandler(11, "2", user, Month, Year, s1q112, conn);
                AnswerSqlHandler(11, "3", user, Month, Year, s1q113, conn);
                AnswerSqlHandler(11, "4", user, Month, Year, s1q114, conn);
                AnswerSqlHandler(11, "5", user, Month, Year, s1q115, conn);

                AnswerSqlHandler(12, "1", user, Month, Year, s1q121, conn);
                AnswerSqlHandler(12, "2", user, Month, Year, s1q122, conn);
                AnswerSqlHandler(12, "3", user, Month, Year, s1q123, conn);
                AnswerSqlHandler(12, "4", user, Month, Year, s1q124, conn);
                AnswerSqlHandler(12, "5", user, Month, Year, s1q125, conn);

                AnswerSqlHandler(13, "1", user, Month, Year, s1q131, conn);
                AnswerSqlHandler(13, "2", user, Month, Year, s1q132, conn);
                AnswerSqlHandler(13, "3", user, Month, Year, s1q133, conn);
                AnswerSqlHandler(13, "4", user, Month, Year, s1q134, conn);
                AnswerSqlHandler(13, "5", user, Month, Year, s1q135, conn);

                AnswerSqlHandler(14, "1", user, Month, Year, s1q141, conn);
                AnswerSqlHandler(14, "2", user, Month, Year, s1q142, conn);
                AnswerSqlHandler(14, "3", user, Month, Year, s1q143, conn);
                AnswerSqlHandler(14, "4", user, Month, Year, s1q144, conn);
                AnswerSqlHandler(14, "5", user, Month, Year, s1q145, conn);

                AnswerSqlHandler(15, "1", user, Month, Year, s1q151, conn);
                AnswerSqlHandler(15, "2", user, Month, Year, s1q152, conn);
                AnswerSqlHandler(15, "3", user, Month, Year, s1q153, conn);
                AnswerSqlHandler(15, "4", user, Month, Year, s1q154, conn);
                AnswerSqlHandler(15, "5", user, Month, Year, s1q155, conn);

                AnswerSqlHandler(16, "1", user, Month, Year, s1q161, conn);
                AnswerSqlHandler(16, "2", user, Month, Year, s1q162, conn);
                AnswerSqlHandler(16, "3", user, Month, Year, s1q163, conn);
                AnswerSqlHandler(16, "4", user, Month, Year, s1q164, conn);
                AnswerSqlHandler(16, "5", user, Month, Year, s1q165, conn);

                AnswerSqlHandler(17, "1", user, Month, Year, s1q171, conn);
                AnswerSqlHandler(17, "2", user, Month, Year, s1q172, conn);
                AnswerSqlHandler(17, "3", user, Month, Year, s1q173, conn);
                AnswerSqlHandler(17, "4", user, Month, Year, s1q174, conn);
                AnswerSqlHandler(17, "5", user, Month, Year, s1q175, conn);

                AnswerSqlHandler(18, "1", user, Month, Year, s1q181, conn);
                AnswerSqlHandler(18, "2", user, Month, Year, s1q182, conn);
                AnswerSqlHandler(18, "3", user, Month, Year, s1q183, conn);
                AnswerSqlHandler(18, "4", user, Month, Year, s1q184, conn);
                AnswerSqlHandler(18, "5", user, Month, Year, s1q185, conn);

                AnswerSqlHandler(19, "1", user, Month, Year, s1q191, conn);
                AnswerSqlHandler(19, "2", user, Month, Year, s1q192, conn);
                AnswerSqlHandler(19, "3", user, Month, Year, s1q193, conn);
                AnswerSqlHandler(19, "4", user, Month, Year, s1q194, conn);
                AnswerSqlHandler(19, "5", user, Month, Year, s1q195, conn);

                AnswerSqlHandler(20, "1", user, Month, Year, s1q201, conn);
                AnswerSqlHandler(20, "2", user, Month, Year, s1q202, conn);
                AnswerSqlHandler(20, "3", user, Month, Year, s1q203, conn);
                AnswerSqlHandler(20, "4", user, Month, Year, s1q204, conn);
                AnswerSqlHandler(20, "5", user, Month, Year, s1q205, conn);

                AnswerSqlHandler(21, "1", user, Month, Year, s1q211, conn);
                AnswerSqlHandler(21, "2", user, Month, Year, s1q212, conn);
                AnswerSqlHandler(21, "3", user, Month, Year, s1q213, conn);
                AnswerSqlHandler(21, "4", user, Month, Year, s1q214, conn);
                AnswerSqlHandler(21, "5", user, Month, Year, s1q215, conn);

                AnswerSqlHandler(22, "1", user, Month, Year, s1q221, conn);
                AnswerSqlHandler(22, "2", user, Month, Year, s1q222, conn);
                AnswerSqlHandler(22, "3", user, Month, Year, s1q223, conn);
                AnswerSqlHandler(22, "4", user, Month, Year, s1q224, conn);
                AnswerSqlHandler(22, "5", user, Month, Year, s1q225, conn);

                AnswerSqlHandler(23, "1", user, Month, Year, s1q231, conn);
                AnswerSqlHandler(23, "2", user, Month, Year, s1q232, conn);
                AnswerSqlHandler(23, "3", user, Month, Year, s1q233, conn);
                AnswerSqlHandler(23, "4", user, Month, Year, s1q234, conn);
                AnswerSqlHandler(23, "5", user, Month, Year, s1q235, conn);

                AnswerSqlHandler(24, "1", user, Month, Year, s1q241, conn);
                AnswerSqlHandler(24, "2", user, Month, Year, s1q242, conn);
                AnswerSqlHandler(24, "3", user, Month, Year, s1q243, conn);
                AnswerSqlHandler(24, "4", user, Month, Year, s1q244, conn);
                AnswerSqlHandler(24, "5", user, Month, Year, s1q245, conn);

                AnswerSqlHandler(25, "1", user, Month, Year, s1q251, conn);
                AnswerSqlHandler(25, "2", user, Month, Year, s1q252, conn);
                AnswerSqlHandler(25, "3", user, Month, Year, s1q253, conn);
                AnswerSqlHandler(25, "4", user, Month, Year, s1q254, conn);
                AnswerSqlHandler(25, "5", user, Month, Year, s1q255, conn);

                AnswerSqlHandler(26, "1", user, Month, Year, s1q261, conn);
                AnswerSqlHandler(26, "2", user, Month, Year, s1q262, conn);
                AnswerSqlHandler(26, "3", user, Month, Year, s1q263, conn);
                AnswerSqlHandler(26, "4", user, Month, Year, s1q264, conn);
                AnswerSqlHandler(26, "5", user, Month, Year, s1q265, conn);

                AnswerSqlHandler(27, "1", user, Month, Year, s1q271, conn);
                AnswerSqlHandler(27, "2", user, Month, Year, s1q272, conn);
                AnswerSqlHandler(27, "3", user, Month, Year, s1q273, conn);
                AnswerSqlHandler(27, "4", user, Month, Year, s1q274, conn);
                AnswerSqlHandler(27, "5", user, Month, Year, s1q275, conn);

                AnswerSqlHandler(28, "1", user, Month, Year, s1q281, conn);
                AnswerSqlHandler(28, "2", user, Month, Year, s1q282, conn);
                AnswerSqlHandler(28, "3", user, Month, Year, s1q283, conn);
                AnswerSqlHandler(28, "4", user, Month, Year, s1q284, conn);
                AnswerSqlHandler(28, "5", user, Month, Year, s1q285, conn);

                AnswerSqlHandler(29, "1", user, Month, Year, s1q291, conn);
                AnswerSqlHandler(29, "2", user, Month, Year, s1q292, conn);
                AnswerSqlHandler(29, "3", user, Month, Year, s1q293, conn);
                AnswerSqlHandler(29, "4", user, Month, Year, s1q294, conn);
                AnswerSqlHandler(29, "5", user, Month, Year, s1q295, conn);

                AnswerSqlHandler(30, "1", user, Month, Year, s1q301, conn);
                AnswerSqlHandler(30, "2", user, Month, Year, s1q302, conn);
                AnswerSqlHandler(30, "3", user, Month, Year, s1q303, conn);
                AnswerSqlHandler(30, "4", user, Month, Year, s1q304, conn);
                AnswerSqlHandler(30, "5", user, Month, Year, s1q305, conn);

                AnswerSqlHandler(31, "1", user, Month, Year, s1q311, conn);
                AnswerSqlHandler(31, "2", user, Month, Year, s1q312, conn);
                AnswerSqlHandler(31, "3", user, Month, Year, s1q313, conn);
                AnswerSqlHandler(31, "4", user, Month, Year, s1q314, conn);
                AnswerSqlHandler(31, "5", user, Month, Year, s1q315, conn);

                AnswerSqlHandler(32, "1", user, Month, Year, s1q321, conn);
                AnswerSqlHandler(32, "2", user, Month, Year, s1q322, conn);
                AnswerSqlHandler(32, "3", user, Month, Year, s1q323, conn);
                AnswerSqlHandler(32, "4", user, Month, Year, s1q324, conn);
                AnswerSqlHandler(32, "5", user, Month, Year, s1q325, conn);

                AnswerSqlHandler(33, "1", user, Month, Year, s1q331, conn);
                AnswerSqlHandler(33, "2", user, Month, Year, s1q332, conn);
                AnswerSqlHandler(33, "3", user, Month, Year, s1q333, conn);
                AnswerSqlHandler(33, "4", user, Month, Year, s1q334, conn);
                AnswerSqlHandler(33, "5", user, Month, Year, s1q335, conn);

                AnswerSqlHandler(34, "1", user, Month, Year, s1q341, conn);
                AnswerSqlHandler(34, "2", user, Month, Year, s1q342, conn);
                AnswerSqlHandler(34, "3", user, Month, Year, s1q343, conn);
                AnswerSqlHandler(34, "4", user, Month, Year, s1q344, conn);
                AnswerSqlHandler(34, "5", user, Month, Year, s1q345, conn);

                AnswerSqlHandler(35, "1", user, Month, Year, s1q351, conn);
                AnswerSqlHandler(35, "2", user, Month, Year, s1q352, conn);
                AnswerSqlHandler(35, "3", user, Month, Year, s1q353, conn);
                AnswerSqlHandler(35, "4", user, Month, Year, s1q354, conn);
                AnswerSqlHandler(35, "5", user, Month, Year, s1q355, conn);

                foreach(string s in s1qc)
                {
                    AnswerSqlHandler(36, s, user, Month, Year, 1, conn);
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




            return View("Upload");
        }





        public void AnswerSqlHandler (int SXQID, string AnsText, Guid user, int Month, int Year, int Quantity, SqlConnection conn)
        {
            if (Quantity != 0 && AnsText != null)
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