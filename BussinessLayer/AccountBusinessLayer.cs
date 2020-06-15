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
        public SqlDataReader GetAccountDetail(int Id)
        {
            AccountDataAccess accObj = new AccountDataAccess();
            AccountModel accModel = new AccountModel();
            SqlDataReader sdr = accObj.ReadDetail( Id);
            return sdr;

        }
        

    }
}
