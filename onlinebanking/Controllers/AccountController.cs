using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.Models;
using BussinessLayer;
using DataAccess;

namespace onlinebanking.Controllers
{
    public class AccountController : Controller
    {
        //GET :ID
        public ActionResult Details(int id)
        {
            var accBusObj = new AccountBusinessLayer();
            var accModel = new AccountModel();
            SqlDataReader sdr=accBusObj.GetAccountDetail(id);

            if (sdr.Read())
            {
               Session["Accountno"]= Convert.ToInt64(sdr["account_no"]);
               Session["Balance"] = Convert.ToInt64(sdr["balance"]);
                accModel.AccountNo = Convert.ToInt64(sdr["account_no"]);
                accModel.DebitCardNo = Convert.ToInt64(sdr["debit_card_no"]);
                accModel.BranchId = sdr["branch_id"].ToString();
                accModel.AccountTypeId = Convert.ToInt32(sdr["account_type_id"]);
                accModel.CheckBookId = sdr["check_book_id"].ToString();
                accModel.CustomerId = Convert.ToInt32(sdr["customer_id"]);
                accModel.Balance = Convert.ToInt64(sdr["balance"]);

            }
            else
            {
                ViewData["Error"] = "Error";
            }
            AccountDataAccess.sqlCon.Close();
            return View(accModel);
           
        }
        
        
    }
}