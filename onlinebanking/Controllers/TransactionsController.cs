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
    public class TransactionsController : Controller
    {
        // GET: Transactions
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post()
        {
            try
            {
                ViewData["Message"] = " ";
                TransactionClass tranObj = new TransactionClass();
                UpdateModel(tranObj);
                string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(con);

                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("p_insert_transaction", sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DEBIT_ACCOUNT_NO", Session["Accountno"]);
                sqlCmd.Parameters.AddWithValue("@CREDIT_ACCOUNT_NO", tranObj.AccountNo);
                sqlCmd.Parameters.AddWithValue("@AMOUNT", tranObj.Amount);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                ViewData["Message"] = " Transaction Successfull";
                return View();
               
            }
            catch
            {
                ViewData["Message"] = " Transaction Failed";

                return View();

            }


        }
            

    }
}