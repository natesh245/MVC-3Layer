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
            try
            {
                LoginBusinessLayer lbObj = new LoginBusinessLayer();
                LoginModel lmObj = new LoginModel();
                UpdateModel(lmObj);
                lbObj.LoginUser(lmObj.EmailId, lmObj.Password);
                Session["customerid"] = lbObj.CustomerId;
                Session["Name"] = lbObj.Name;
                Session["EmailId"] = lbObj.EmailId;
                return RedirectToRoute(new
                {
                    controller = "Account",
                    action = "Details",
                    id = Session["customerid"]

                });

            }
            catch
            {
                ViewData["Message"] = "Login Failed";
                return View();
            }
            
        }

        public ActionResult ChangePassword()
        {
            ViewData["Message"] = "";
            return View();
        }

        [HttpPost]
        [ActionName("ChangePassword")]
        public ActionResult Change_Password()
        {
            LoginBusinessLayer lbObj = new LoginBusinessLayer();
            LoginModel lmObj = new LoginModel();
            UpdateModel(lmObj);
            lbObj.ChangePassword(lmObj.EmailId, lmObj.Password);
            ViewData["Message"] = "Password Changed Successfully";
            return View();
        }

    }
}
