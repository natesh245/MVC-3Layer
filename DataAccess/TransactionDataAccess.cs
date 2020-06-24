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
    public class TransactionDataAccess
    {
        public static string con = ConfigurationManager.ConnectionStrings["OnlineBanking"].ConnectionString;
      public static SqlConnection sqlCon = new SqlConnection(con);
        public void InsertDetails(long DebitNo,long CreditNo,int Amount)
        {
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("p_insert_transaction", sqlCon);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@DEBIT_ACCOUNT_NO", DebitNo);
            sqlCmd.Parameters.AddWithValue("@CREDIT_ACCOUNT_NO", CreditNo);
            sqlCmd.Parameters.AddWithValue("@AMOUNT", Amount);

            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        public DataSet Read(long AccountNo)
        {
            DataSet ds = new DataSet();
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("p_transaction_details", sqlCon);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ACCOUNT", AccountNo);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
             da.Fill(ds);
            return ds;
           
        }
    }
}
