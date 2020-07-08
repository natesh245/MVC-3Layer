using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BussinessLayer.Models;
using System.Data;
using System.Net.Mail;


namespace BussinessLayer
{
    public class TransactionBusinessLayer
    {
        public void SendMoney(long debit,long credit,int amount)
        {
            TransactionDataAccess tranDA = new TransactionDataAccess();
            
                tranDA.InsertDetails(debit, credit, amount);
          
        }
        public List<StatementModel> GetStatement(long Accountno)
        {
            TransactionDataAccess tranDac = new TransactionDataAccess();
            DataSet ds=tranDac.Read(Accountno);
            List<StatementModel> Transactionlist = new List<StatementModel>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                StatementModel uobj = new StatementModel();
                uobj.TransactionId = Convert.ToInt32(ds.Tables[0].Rows[i]["transaction_id"].ToString());
                uobj.DebitAccount = Convert.ToInt64(ds.Tables[0].Rows[i]["debit_account_no"].ToString());
                uobj.CreditAccount = Convert.ToInt64(ds.Tables[0].Rows[i]["credit_account_no"].ToString());
                uobj.DebitAccountBalance = Convert.ToInt64(ds.Tables[0].Rows[i]["debit_account_balance"].ToString());
                uobj.CreditAccountBalance = Convert.ToInt64(ds.Tables[0].Rows[i]["credit_account_balance"].ToString());
                uobj.Amount = Convert.ToInt32(ds.Tables[0].Rows[i]["amount"].ToString());
          
                uobj.TransactionDate = ds.Tables[0].Rows[i]["transaction_date_time"].ToString();
              

                Transactionlist.Add(uobj);
            }
            
            TransactionDataAccess.sqlCon.Close();
            return Transactionlist;
        }

        public void SendTransactionEmail()
        {
            /*
            string userName = WebConfigurationManager.AppSettings["GmailUserName"];
            string password = WebConfigurationManager.AppSettings["GmailPassword"];
            MailMessage mail = new MailMessage();
            mail.To.Add("natesh246@gmail.com");
            mail.From = new MailAddress("natesh246@gmail.com");
            mail.Subject = "Transaction Successfull";
            string Body = "Transaction Successful, Amount of Rs " + tranModel.Amount.ToString() + " iss paid to account " + tranModel.AccountNo.ToString();
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(userName, password); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mail);
            */
        }
        
    }
}
