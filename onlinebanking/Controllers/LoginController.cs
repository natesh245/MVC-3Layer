using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using BussinessLayer;
using DataAccess;


namespace onlinebanking.Controllers
{

    public class LoginController : Controller
    {
        
        public ActionResult Logout()
        {
            Session["customerid"] = null;
            Session["emailid"] = null;
            Session["Name"] = null;
            Session["Accountno"] = null;
            return RedirectToAction("Index");

        }

        public ActionResult Index()
        {
           
            return View();
        }



        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post()
        {
            LoginBusinessLayer lbObj = new LoginBusinessLayer();
            LoginModel lmObj = new LoginModel();
            UpdateModel(lmObj);
           SqlDataReader sdr =lbObj.LoginUser(lmObj.EmailId,lmObj.Password);
            if (sdr.Read())
            {
                Session["customerid"] = sdr["id"].ToString();
                Session["emailid"] = lmObj.EmailId.ToString();
                Session["Name"] = sdr[1].ToString();
                ViewData["isLoggedIn"] = "true";
                LoginDataAccess.sqlCon.Close();
                return RedirectToRoute(new
                {
                    controller = "Account",
                    action = "Details",
                    id = Session["customerid"]

                });
            }
            else
            {
                ViewData["Message"] = "User Login Failed";
            }

            LoginDataAccess.sqlCon.Close();
            return View();
        }

      

       
    }
}
