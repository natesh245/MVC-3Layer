using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onlinebanking.Models;

namespace onlinebanking.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Details(int id)
        {

            Customer cusObj = new Customer();
            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(con);
            string sqlQuery = "select * from CUSTOMER where id="+id.ToString();
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            if (sdr.Read())
            {
                cusObj.customer_name = sdr["customer_name"].ToString();
                cusObj.fathers_name = sdr["fathers_name"].ToString();
                cusObj.date_of_birth = sdr["date_of_birth"].ToString();
                cusObj.customer_age = Convert.ToInt32(sdr["customer_age"]);
                cusObj.martial_status = sdr["martial_status"].ToString();
                cusObj.customer_address = sdr["customer_address"].ToString();
                cusObj.customer_city= sdr["customer_city"].ToString();
                cusObj.customer_state = sdr["customer_state"].ToString();
                cusObj.customer_country = sdr["customer_country"].ToString();
                cusObj.pincode= Convert.ToInt32(sdr["pincode"]);
                cusObj.phone = Convert.ToInt64(sdr["phone"]);
                cusObj.email_id = sdr["email_id"].ToString();
              
            }
            else
            {
                ViewData["Message"] = "User Login Failed";
            }
            sqlCon.Close();
            return View(cusObj);
        }
    }
}