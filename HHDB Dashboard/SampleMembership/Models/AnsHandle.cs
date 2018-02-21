using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SampleMembership.Models
{
    public class AnsHandle
    {
        int SXQID;
        string AnsText;
        Guid CreatedByUser;
        int Month;
        int Year;
        int Quantity;

        public AnsHandle(int SXQID, string AnsText, Guid CreatedByUser, int Month, int Year, int Quantity)
        {
            this.SXQID = SXQID;
            this.AnsText = AnsText;
            this.CreatedByUser = CreatedByUser;
            this.Month = Month;
            this.Year = Year;
            this.Quantity = Quantity;
        }


        public void Submit()
        {
            string connString = ConfigurationManager.ConnectionStrings["SampleMembershipDB"].ConnectionString;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();


                if (Quantity != 0 && AnsText != null && AnsText != "")
                {


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO Answer (SXQID, AnsText, CreatedByUser, Month, Year, Quantity) VALUES (@SXQID, @AnsText, @User, @Month, @Year, @Quantity)";
                        cmd.Parameters.AddWithValue("@SXQID", SXQID);
                        cmd.Parameters.AddWithValue("@AnsText", AnsText);
                        cmd.Parameters.AddWithValue("@User", CreatedByUser);
                        cmd.Parameters.AddWithValue("@Month", Month);
                        cmd.Parameters.AddWithValue("@Year", Year);
                        cmd.Parameters.AddWithValue("@Quantity", Quantity);
                    }

                }

            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}