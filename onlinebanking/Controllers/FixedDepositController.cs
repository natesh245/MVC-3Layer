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

namespace onlinebanking.Controllers
{
    public class FixedDepositController : Controller
    {
        // GET: FixedDeposit
        // GET: FixedDeposit
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post(OpenFdModel oFdModel)
        {
            try
            {
                ViewData["Message"] = " ";
                FdBusinessLayer fdBl = new FdBusinessLayer();
                fdBl.OpenFd(Convert.ToInt64(Session["Accountno"]),oFdModel.fdAmount,oFdModel.Duration,oFdModel.RateOfInterest,oFdModel.MaturityAmount,oFdModel.MaturityDate,oFdModel.Nominee,oFdModel.NomineeRelation);
                ViewData["Message"] = "Fixed deposit created Successfully";
                FdDataAccess.sqlCon.Close();
                return View();

            }
            catch
            {
                ViewData["Message"] = " Fixed deposit Failed";

                return View();

            }

        }
        public ActionResult FdDetail()
        {
            FdBusinessLayer fdBL = new FdBusinessLayer();
            FdDetailsModel fdModel = new FdDetailsModel();
            List<FdDetailsModel> fdModelList=fdBL.GetFdDetails(Convert.ToInt64(Session["Accountno"]));
            fdModel.FdDetailList = fdModelList;
            FdDataAccess.sqlCon.Close();
            return View(fdModel);

        }

    }
}