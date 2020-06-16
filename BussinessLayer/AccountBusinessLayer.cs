using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BussinessLayer.Models;
using System.Data.SqlClient;

namespace BussinessLayer
{
    public class AccountBusinessLayer
    {
        public long AccountNo;
        public long Balance;
        public AccountModel GetAccountDetail(int Id)
        {
            AccountDataAccess accObj = new AccountDataAccess();
            AccountModel accModel = new AccountModel();
            SqlDataReader sdr = accObj.ReadDetail( Id);
           
            if (sdr.Read())
            {
                this.AccountNo = Convert.ToInt64(sdr["account_no"]);
                this.Balance = Convert.ToInt64(sdr["balance"]);
                accModel.AccountNo = Convert.ToInt64(sdr["account_no"]);
                accModel.DebitCardNo = Convert.ToInt64(sdr["debit_card_no"]);
                accModel.BranchId = sdr["branch_id"].ToString();
                accModel.AccountTypeId = Convert.ToInt32(sdr["account_type_id"]);
                accModel.CheckBookId = sdr["check_book_id"].ToString();
                accModel.CustomerId = Convert.ToInt32(sdr["customer_id"]);
                accModel.Balance = Convert.ToInt64(sdr["balance"]);
                AccountDataAccess.sqlCon.Close();
               

            }
            return accModel;

        }
     
    }
}
