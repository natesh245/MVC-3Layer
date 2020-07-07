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
using DataAccess;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Rotativa;

namespace onlinebanking.Controllers
{
    public class TransactionsController : Controller
    {
        public static long CurrentAccount;
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
                //Twilio
                const string accountSid = "AC79aa0af132e16dd3e10edcdd31f63079";
                const string authToken = "1eabd43fcefa44c134ef8f71b7d0b1d2";

                TwilioClient.Init(accountSid, authToken);

                

                ViewData["Message"] = " ";
                TransactionBusinessLayer tranBL = new TransactionBusinessLayer();
                TransactionModel tranModel = new TransactionModel();
                UpdateModel(tranModel);
                tranBL.SendMoney(Convert.ToInt64(Session["Accountno"]), tranModel.AccountNo, tranModel.Amount);
                ViewData["Message"] = " Transaction Successfull";

                try
                {
                    var message = MessageResource.Create(
                 body: "Transaction of Rs" + tranModel.Amount.ToString() + " To Account No: " + tranModel.AccountNo.ToString() + " is Successfull",
                 from: new Twilio.Types.PhoneNumber("+12058518453"),
                 to: new Twilio.Types.PhoneNumber("+918660069868")   
             );

                }
                catch
                {
                    ViewData["Message"] = "Transaction Successful, Message not sent";
                }
             


                return View();


            }
            catch
            {
                ViewData["Message"] = " Transaction Failed";
                TransactionDataAccess.sqlCon.Close();
                return View();

            }


        }

        public ActionResult Statement()
        {
            TransactionsController.CurrentAccount = Convert.ToInt64(Session["Accountno"]);
            TransactionBusinessLayer sObj = new TransactionBusinessLayer();
            StatementModel sModel = new StatementModel();
           List<StatementModel> tranList= sObj.GetStatement(Convert.ToInt64(Session["Accountno"]));
            sModel.statementList = tranList;
           
            return View(sModel);
        }

        public ActionResult StatementPdf()
        {
            TransactionBusinessLayer stObj = new TransactionBusinessLayer();
            StatementModel stModel = new StatementModel();
            //  List<StatementModel> tranList = stObj.GetStatement(Convert.ToInt64(Session["Accountno"]));
            //List<StatementModel> tranList = stObj.GetStatement(110010001114 );
            List<StatementModel> tranList = stObj.GetStatement(TransactionsController.CurrentAccount);
            stModel.statementList = tranList;

            return View(stModel);
        }



        public ActionResult PrintStatementToPdf()
        {
            var statementPdf = new ActionAsPdf("StatementPdf");
            return statementPdf;
        }

    } 
}

           
        
            

    
