using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
                return RedirectToRoute(new
                {
                    controller = "Transactions",
                    action = "Statement"
                   
                });


            }
            catch
            {
                ViewData["Message"] = " Transaction Failed";

                return View();

            }


        }

        public ActionResult Statement()
        {
            Statements sObj = new Statements();
            DataSet ds = new DataSet();

            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(con);

            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("p_transaction_details", sqlCon);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ACCOUNT", Session["Accountno"]);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(ds);
            List<Statements> Transactionlist = new List<Statements>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Statements uobj = new Statements();
                uobj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                uobj.IdCredit = Convert.ToInt32(ds.Tables[0].Rows[i]["id_debit"].ToString());
               
                uobj.DebitAccount = Convert.ToInt64(ds.Tables[0].Rows[i]["debit_account_no"].ToString());
                uobj.CreditAccount = Convert.ToInt64(ds.Tables[0].Rows[i]["credit_account_no"].ToString());
                uobj.DebitAccountBalance = Convert.ToInt64(ds.Tables[0].Rows[i]["debit_account_balance"].ToString());
                uobj.CreditAccountBalance = Convert.ToInt64(ds.Tables[0].Rows[i]["credit_account_balance"].ToString());
                uobj.DebitAmount = Convert.ToInt32(ds.Tables[0].Rows[i]["debit_amount"].ToString());
                uobj.CreditAmount = Convert.ToInt32(ds.Tables[0].Rows[i]["credit_amount"].ToString());
                uobj.DebitDate = ds.Tables[0].Rows[i]["debit_date_time"].ToString();
                uobj.CreditDate = ds.Tables[0].Rows[i]["credit_date_time"].ToString();

                Transactionlist.Add(uobj);
            }
            sObj.statementList = Transactionlist;
            sqlCon.Close();
            return View(sObj);
        }
       

    } 
}

           
        
            

    
