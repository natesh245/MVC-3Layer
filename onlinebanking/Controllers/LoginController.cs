using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onlinebanking.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace onlinebanking.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
       
   

        [HttpPost]
        public ActionResult Index(LoginClass lcObj)
        {
            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(con);
            string sqlQuery = "select id,customer_name, email_id,user_password from CUSTOMER where email_id=@EmailId and user_password=@UserPasssword";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery,sqlCon);
            sqlCmd.Parameters.AddWithValue("@EmailId", lcObj.email_id);
            sqlCmd.Parameters.AddWithValue("@UserPasssword", lcObj.user_password);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            if (sdr.Read())
            {
                Session["customerid"] = sdr["id"].ToString();
                Session["emailid"] = lcObj.email_id.ToString();
                Session["Name"] = sdr[1].ToString();
                return RedirectToAction("welcome");
            }
            else
            {
                ViewData["Message"] = "User Login Failed";
            }
            sqlCon.Close();

            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}
