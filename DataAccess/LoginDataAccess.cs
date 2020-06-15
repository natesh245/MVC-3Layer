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
        
        public SqlDataReader Login(string emailId, string Password)
        {
            

        string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(con);
            string sqlQuery = "select id,customer_name, email_id,user_password from CUSTOMER where email_id=@EmailId and user_password=@UserPasssword";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
            sqlCmd.Parameters.AddWithValue("@EmailId",emailId);
            sqlCmd.Parameters.AddWithValue("@UserPasssword", Password);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            return sdr;
        }
      
    }
}
