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
        public ActionResult Index(LoginModel lMObj)
        {
            LoginBusinessLayer lbObj = new LoginBusinessLayer();
            LoginModel lmObj = new LoginModel();
           SqlDataReader sdr =lbObj.LoginUser(lmObj.EmailId,lmObj.Password);
            if (sdr.Read())
            {
                Session["customerid"] = sdr["id"].ToString();
                Session["emailid"] = lMObj.EmailId.ToString();
                Session["Name"] = sdr[1].ToString();
                ViewData["isLoggedIn"] = "true";
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
            
           
            return View();
        }

      

       
    }
}
