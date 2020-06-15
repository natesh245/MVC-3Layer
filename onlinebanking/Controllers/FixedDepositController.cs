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
    public class FixedDepositController : Controller
    {
        // GET: FixedDeposit
        // GET: FixedDeposit
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
                FixedDepositClass fdc = new FixedDepositClass();
                UpdateModel(fdc);
                string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(con);

                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("fixed_deposit_sp", sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@account_no", Session["Accountno"]);
                sqlCmd.Parameters.AddWithValue("@amount", fdc.fd_amount);
                sqlCmd.Parameters.AddWithValue("@duration", fdc.duration);
                sqlCmd.Parameters.AddWithValue("@nominee", fdc.nominee);


                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                ViewData["Message"] = "Fixed deposit created Successfully";
                return View();

            }
            catch
            {
                ViewData["Message"] = " Fixed deposit Failed";

                return View();

            }

        }
        public ActionResult FdDetail()
        {
            FdDetails fdd = new FdDetails();

            DataSet ds = new DataSet();

            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(con);
            string sqlQuery = "select * from FIXED_DEPOSIT  where account_no=@account_no ";
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
           
            sqlCmd.Parameters.AddWithValue("@account_no", Session["Accountno"]);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(ds);
            List<FdDetails> FdDetailList = new List<FdDetails>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                FdDetails fObj = new FdDetails();
                fObj.account_no = Convert.ToInt64(ds.Tables[0].Rows[i]["account_no"].ToString());

                fObj.deposit_id = Convert.ToInt32(ds.Tables[0].Rows[i]["deposit_id"].ToString());

                fObj.fd_date = ds.Tables[0].Rows[i]["fd_date"].ToString();

                fObj.fd_amount = Convert.ToInt64(ds.Tables[0].Rows[i]["fd_amount"].ToString());

                fObj.duration = Convert.ToInt32(ds.Tables[0].Rows[i]["Duration"].ToString());

                fObj.rate_of_interest = Convert.ToInt64(ds.Tables[0].Rows[i]["rate_of_interest"].ToString());

                fObj.maturity_date = ds.Tables[0].Rows[i]["maturity_date"].ToString();

                fObj.maturity_amount = Convert.ToInt32(ds.Tables[0].Rows[i]["maturity_amount"].ToString());

                fObj.nominee = ds.Tables[0].Rows[i]["nominee"].ToString();

                FdDetailList.Add(fObj);
            }
            fdd.FdDetailList = FdDetailList;
            sqlCon.Close();
            return View(fdd);

        }

    }
}