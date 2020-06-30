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

                var message = MessageResource.Create(
                    body: "Transaction of Rs" +tranModel.Amount.ToString() + " To Account No: "+tranModel.AccountNo.ToString()+" is Successfull",
                    from: new Twilio.Types.PhoneNumber("+12058518453"),
                    to: new Twilio.Types.PhoneNumber("+91" + Session["PhoneNo"].ToString())
                );


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
            TransactionBusinessLayer sObj = new TransactionBusinessLayer();
            StatementModel sModel = new StatementModel();
           List<StatementModel> tranList= sObj.GetStatement(Convert.ToInt64(Session["Accountno"]));
            sModel.statementList = tranList;
           
            return View(sModel);
        }
       

    } 
}

           
        
            

    
