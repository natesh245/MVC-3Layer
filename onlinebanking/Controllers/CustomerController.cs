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
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Details(int id)
        {
            CustomerBusinessLayer cusBl = new CustomerBusinessLayer();
           
           CustomerModel cusModel=cusBl.GetCustomerDetails(id);
            CustomerDataAccess.sqlCon.Close();
            return View(cusModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CustomerBusinessLayer cusBl = new CustomerBusinessLayer();
           
            CustomerModel cusModel = cusBl.DisplayEditCustomer(id);
          
            ViewData["CustomerMessage"] = "";
            CustomerDataAccess.sqlCon.Close();
            return View(cusModel);

        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            CustomerBusinessLayer cusBl = new CustomerBusinessLayer();
            CustomerModel cusModel = new CustomerModel();
            UpdateModel(cusModel);
            cusBl.EditCustomerDetails(id,cusModel.Name,cusModel.FatherName,cusModel.DateOfBirth,
                cusModel.Age,cusModel.MaritalStatus,cusModel.Address,cusModel.City,cusModel.State,
                cusModel.Country,cusModel.Pincode,cusModel.Phone,cusModel.EmailId);
            
            ViewData["CustomerMessage"] = "Changes Saved Successfully";
            CustomerDataAccess.sqlCon.Close();
            return View();


        }
    }
}