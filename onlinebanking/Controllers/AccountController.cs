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
    public class AccountController : Controller
    {
        //GET :ID
        public ActionResult Details(int id)
        {
            Account accountObj = new Account();

            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(con);

            string sqlQuery = "select * from ACCOUNT where customer_id="+id.ToString();
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);

            SqlDataReader sdr = sqlCmd.ExecuteReader();
            if (sdr.Read())
            {
                accountObj.account_no = Convert.ToInt64(sdr["account_no"]);
                accountObj.debit_card_no = Convert.ToInt64(sdr["debit_card_no"]);
                accountObj.branch_id = sdr["branch_id"].ToString();
                accountObj.account_type_id = Convert.ToInt32(sdr["account_type_id"]);
                accountObj.check_book_id = sdr["check_book_id"].ToString();
                accountObj.customer_id = Convert.ToInt32(sdr["customer_id"]);
                accountObj.balance = Convert.ToInt64(sdr["balance"]);

            }
            else
            {
                ViewData["Error"] = "Error";
            }

            sqlCon.Close();


            return View(accountObj);
           
        }
        
        
    }
}