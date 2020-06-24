using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerDataAccess
    {
        public static string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        public static SqlConnection sqlCon = new SqlConnection(con);

        public SqlDataReader ReadDetails(int Id)
        {
           
            string sqlQuery = "select * from CUSTOMER where id=" + Id.ToString();
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            return sdr;

        }

        public SqlDataReader UpdateDetails(int id)
        { 
            string sqlQuery = "select * from CUSTOMER where id=" + id.ToString();
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            return sdr;
        }

        public void EditDetails(int Id,string Name,string FatherName,DateTime DOB,int Age,string status,string Address,string City,string State,string Country,int Pincode,long Phone,string EmailId,string gender)
        {
            
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("p_update_customer_details", sqlCon);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID", Id);
            sqlCmd.Parameters.AddWithValue("@Name", Name);
            sqlCmd.Parameters.AddWithValue("@FATHERS_NAME", FatherName);
            sqlCmd.Parameters.AddWithValue("@GENDER", gender);
            sqlCmd.Parameters.AddWithValue("@DOB", DOB);
            sqlCmd.Parameters.AddWithValue("@AGE", Age);
            sqlCmd.Parameters.AddWithValue("@MARTIAL_STATUS", status);
            sqlCmd.Parameters.AddWithValue("@ADDRESS", Address);
            sqlCmd.Parameters.AddWithValue("@CITY", City);
            sqlCmd.Parameters.AddWithValue("@STATE", State);
            sqlCmd.Parameters.AddWithValue("@COUNTRY", Country);
            sqlCmd.Parameters.AddWithValue("@PINCODE", Pincode);
            sqlCmd.Parameters.AddWithValue("@PHONE", Phone);
            sqlCmd.Parameters.AddWithValue("@EMAIL_ID", EmailId);

            sqlCmd.ExecuteNonQuery();

        }

    }
}
