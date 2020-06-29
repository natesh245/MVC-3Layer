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
        public void OpenFd(long accountno,int amount,int duration , string nominee, string rel)
        {
             double roi;
             int maturityAmount;
           

            FdDataAccess fdDac = new FdDataAccess();
            if (duration >= 6 && duration <= 7)
            {
                roi = 4;
                
                maturityAmount =Convert.ToInt32( amount+ (amount * roi * duration / 100));
            }
            else if (duration >= 8 && duration <= 12)
            {
               roi = 4.5;

              maturityAmount =Convert.ToInt32( amount + (amount * roi * duration / 100));

            }
            else
            {
                 roi = 5;

                 maturityAmount = Convert.ToInt32(amount + (amount * roi * duration / 100));
            }

            DateTime today = DateTime.Today;
            DateTime dt = new DateTime(today.Year, today.Month, today.Day, 16, 0, 0);

        
            
            fdDac.Create(accountno, amount, duration,roi, maturityAmount, nominee, rel);

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

                fObj.FdDate =Convert.ToDateTime( ds.Tables[0].Rows[i]["fd_date"]);

                fObj.FdAmount = Convert.ToInt64(ds.Tables[0].Rows[i]["fd_amount"].ToString());

                fObj.Duration = Convert.ToInt32(ds.Tables[0].Rows[i]["Duration"].ToString());

                fObj.RateOfInterest = Convert.ToInt64(ds.Tables[0].Rows[i]["rate_of_interest"].ToString());

                fObj.MaturityDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["maturity_date"].ToString());

                fObj.MaturityAmount = Convert.ToInt32(ds.Tables[0].Rows[i]["maturity_amount"].ToString());

                fObj.Nominee = ds.Tables[0].Rows[i]["nominee"].ToString();

                FdDetailList.Add(fObj);
            }
           
            FdDataAccess.sqlCon.Close();
            return FdDetailList;
        }
    }
}
