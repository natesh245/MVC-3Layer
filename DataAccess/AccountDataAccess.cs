using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDataAccess
    {
       public static string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        public static SqlConnection sqlCon = new SqlConnection(con);
        public SqlDataReader ReadDetail(int Id)
        {
           
            string sqlQuery = "select * from ACCOUNT where customer_id=" + Id.ToString();
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);

            SqlDataReader sdr = sqlCmd.ExecuteReader();
            return sdr;

        }

        
    }
}
