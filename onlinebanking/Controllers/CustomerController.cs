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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customer cusObj = new Customer();
            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(con);
            string sqlQuery = "select * from CUSTOMER where id=" + id.ToString();
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
                cusObj.customer_city = sdr["customer_city"].ToString();
                cusObj.customer_state = sdr["customer_state"].ToString();
                cusObj.customer_country = sdr["customer_country"].ToString();
                cusObj.pincode = Convert.ToInt32(sdr["pincode"]);
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

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            Customer cusObj = new Customer();
            UpdateModel(cusObj);
            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(con);
            
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("p_update_customer_details", sqlCon);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID", id);
            sqlCmd.Parameters.AddWithValue("@Name", cusObj.customer_name);
            sqlCmd.Parameters.AddWithValue("@FATHERS_NAME", cusObj.fathers_name);
            sqlCmd.Parameters.AddWithValue("@DOB", cusObj.date_of_birth);
            sqlCmd.Parameters.AddWithValue("@AGE", cusObj.customer_age);
            sqlCmd.Parameters.AddWithValue("@MARTIAL_STATUS", cusObj.martial_status);
            sqlCmd.Parameters.AddWithValue("@ADDRESS", cusObj.customer_address);
            sqlCmd.Parameters.AddWithValue("@CITY", cusObj.customer_city);
            sqlCmd.Parameters.AddWithValue("@STATE", cusObj.customer_state);
            sqlCmd.Parameters.AddWithValue("@COUNTRY", cusObj.customer_country);
            sqlCmd.Parameters.AddWithValue("@PINCODE", cusObj.pincode);
            sqlCmd.Parameters.AddWithValue("@PHONE", cusObj.phone);
            sqlCmd.Parameters.AddWithValue("@EMAIL_ID", cusObj.email_id);

            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            return RedirectToRoute(new
            {
                controller = "Customer",
                action = "Details",
                id = id
            });


        }
    }
}