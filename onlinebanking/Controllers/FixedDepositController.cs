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
        public ActionResult Index_Post()
        {
            try
            {
                ViewData["Message"] = " ";
                OpenFdModel oFdModel = new OpenFdModel ();
                
                UpdateModel(oFdModel);
                FdBusinessLayer fdBl = new FdBusinessLayer();
                fdBl.OpenFd(Convert.ToInt64(Session["Accountno"]),oFdModel.fdAmount,oFdModel.Duration,oFdModel.Nominee);
                ViewData["Message"] = "Fixed deposit created Successfully";
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
            return View(fdModel);

        }

    }
}