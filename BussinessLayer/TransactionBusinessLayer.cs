﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BussinessLayer.Models;
using System.Data;

namespace BussinessLayer
{
    public class TransactionBusinessLayer
    {
        public void SendMoney(long debit,long credit,int amount)
        {
            TransactionDataAccess tranDA = new TransactionDataAccess();
            if(debit!=credit && amount > 0)
            {
                tranDA.InsertDetails(debit, credit, amount);
            }
            else
            {
                throw new Exception("Transaction Failed");
            }
            

        }
        public List<StatementModel> GetStatement(long Accountno)
        {
            TransactionDataAccess tranDac = new TransactionDataAccess();
            DataSet ds=tranDac.Read(Accountno);
            List<StatementModel> Transactionlist = new List<StatementModel>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                StatementModel uobj = new StatementModel();
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
            
            TransactionDataAccess.sqlCon.Close();
            return Transactionlist;
        }
        
    }
}
