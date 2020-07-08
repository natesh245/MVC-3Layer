using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using BussinessLayer;
using BussinessLayer.Models;
using DataAccess;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Rotativa;

using System.Net.Mail;


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
                
                ViewData["Message"] = " ";
                TransactionBusinessLayer tranBL = new TransactionBusinessLayer();
                TransactionModel tranModel = new TransactionModel();
                UpdateModel(tranModel);
                tranBL.SendMoney(Convert.ToInt64(Session["Accountno"]), tranModel.AccountNo, tranModel.Amount);
                ViewData["Message"] = " Transaction Successfull";

                /*
                try
                {
                    //Twilio
                    const string accountSid = "your account sid";
                    const string authToken = "your auth token";

                    TwilioClient.Init(accountSid, authToken);
                    var message = MessageResource.Create(
                 body: "Transaction of Rs" + tranModel.Amount.ToString() + " To Account No: " + tranModel.AccountNo.ToString() + " is Successfull",
                 from: new Twilio.Types.PhoneNumber("your twilio phone no"),
                  to: new Twilio.Types.PhoneNumber("+91yourno")
             );

                }
                catch
                {
                    ViewData["Message"] = "Transaction Successful, Message not sent";
                }
                */

                /*
                try
                {
                    //Transactional Email
                    string userName= WebConfigurationManager.AppSettings["GmailUserName"];
                    string password = WebConfigurationManager.AppSettings["GmailPassword"];
                    MailMessage mail = new MailMessage();
                    mail.To.Add("natesh246@gmail.com");
                    mail.From = new MailAddress("natesh246@gmail.com");
                    mail.Subject = "Transaction Successfull";
                    string Body = "Transaction Successful, Amount of Rs "+tranModel.Amount.ToString()+" is paid to account "+tranModel.AccountNo.ToString() ;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential(userName, password); // Enter seders User name and password  
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    ViewData["Message"] = "Transaction Successful";
                }
                catch
                {
                    ViewData["Message"] = "Transaction Successful, Mail not sent";
                }
                */
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

           
        
            

    
