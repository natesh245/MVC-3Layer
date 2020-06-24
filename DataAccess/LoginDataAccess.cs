using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class LoginDataAccess
    {
         public static string con = ConfigurationManager.ConnectionStrings["OnlineBanking"].ConnectionString;
        public static SqlConnection sqlCon = new SqlConnection(con);

        public SqlDataReader Login(string emailId, string Password)
        {

            string sqlQuery = "select id,customer_first_name,customer_last_name, email_id,customer_password from CUSTOMER where email_id=@EmailId and customer_password=@UserPasssword";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
            sqlCmd.Parameters.AddWithValue("@EmailId",emailId);
            sqlCmd.Parameters.AddWithValue("@UserPasssword", Password);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            return sdr;
        }

        public void  UpdatePassword(string emailid,string password)
        {
            string sqlQuery = "UPDATE CUSTOMER SET customer_password=@password where email_id=@EmailId";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
            sqlCmd.Parameters.AddWithValue("@EmailId", emailid);
            sqlCmd.Parameters.AddWithValue("@password", password);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

        }
      
    }
}
