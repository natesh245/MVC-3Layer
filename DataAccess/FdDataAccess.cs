using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FdDataAccess
    {
        public static string con = ConfigurationManager.ConnectionStrings["OnlineBanking"].ConnectionString;
        public static SqlConnection sqlCon = new SqlConnection(con);
        public void Create(long AccountNo,int Amount,int duration,string Nominee)
        {
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("fixed_deposit_sp", sqlCon);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@account_no", AccountNo);
            sqlCmd.Parameters.AddWithValue("@amount", Amount);
            sqlCmd.Parameters.AddWithValue("@duration", duration);
            sqlCmd.Parameters.AddWithValue("@nominee", Nominee);

            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        public DataSet ReadDetails(long accountno)
        {
            DataSet ds = new DataSet();
            string sqlQuery = "select * from FIXED_DEPOSIT  where account_no=@account_no ";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);

            sqlCmd.Parameters.AddWithValue("@account_no",accountno );
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(ds);
            return ds;
        }
    }
}
