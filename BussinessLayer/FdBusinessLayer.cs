using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BussinessLayer.Models;

namespace BussinessLayer
{
    public class FdBusinessLayer
    {
        public void OpenFd(long accountno,int amount,int duration ,string nominee)
        {
            FdDataAccess fdDac = new FdDataAccess();
            fdDac.Create(accountno, amount, duration, nominee);

        }

        public List<FdDetailsModel> GetFdDetails(long Accountno)
        {
            FdDataAccess fdDac = new FdDataAccess();
            FdDetailsModel fdModel = new FdDetailsModel();
            DataSet ds=fdDac.ReadDetails(Accountno);
            List<FdDetailsModel> FdDetailList = new List<FdDetailsModel>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                FdDetailsModel fObj = new FdDetailsModel();
                fObj.AccountNo = Convert.ToInt64(ds.Tables[0].Rows[i]["account_no"].ToString());

                fObj.DepositId = Convert.ToInt32(ds.Tables[0].Rows[i]["deposit_id"].ToString());

                fObj.FdDate = ds.Tables[0].Rows[i]["fd_date"].ToString();

                fObj.FdAmount = Convert.ToInt64(ds.Tables[0].Rows[i]["fd_amount"].ToString());

                fObj.Duration = Convert.ToInt32(ds.Tables[0].Rows[i]["Duration"].ToString());

                fObj.RateOfInterest = Convert.ToInt64(ds.Tables[0].Rows[i]["rate_of_interest"].ToString());

                fObj.MaturityDate = ds.Tables[0].Rows[i]["maturity_date"].ToString();

                fObj.MaturityAmount = Convert.ToInt32(ds.Tables[0].Rows[i]["maturity_amount"].ToString());

                fObj.Nominee = ds.Tables[0].Rows[i]["nominee"].ToString();

                FdDetailList.Add(fObj);
            }
           
            FdDataAccess.sqlCon.Close();
            return FdDetailList;
        }
    }
}
