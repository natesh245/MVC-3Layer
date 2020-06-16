using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer;
using BussinessLayer.Models;

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
                TransactionBusinessLayer tranBL = new TransactionBusinessLayer();
                TransactionModel tranModel = new TransactionModel();
                UpdateModel(tranModel);
                tranBL.SendMoney(Convert.ToInt64(Session["Accountno"]), tranModel.AccountNo, tranModel.Amount);
                ViewData["Message"] = " Transaction Successfull";
                return View();


            }
            catch
            {
                ViewData["Message"] = " Transaction Failed";

                return View();

            }


        }

        public ActionResult Statement()
        {
            TransactionBusinessLayer sObj = new TransactionBusinessLayer();
            StatementModel sModel = new StatementModel();
           List<StatementModel> tranList= sObj.GetStatement(Convert.ToInt64(Session["Accountno"]));
            sModel.statementList = tranList;

            return View(sModel);
        }
       

    } 
}

           
        
            

    
