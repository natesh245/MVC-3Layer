using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.Models;
using BussinessLayer;
using DataAccess;

namespace onlinebanking.Controllers
{
    public class AccountController : Controller
    {
        //GET :ID
        public ActionResult Details(int id)
        {
            var accBusObj = new AccountBusinessLayer();
            
            AccountModel accModel=accBusObj.GetAccountDetail(id);
            Session["Accountno"] = accBusObj.AccountNo;
            Session["Balance"] = accBusObj.Balance;

            return View(accModel);
           
        }
        
        
    }
}