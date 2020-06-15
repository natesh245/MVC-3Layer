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
            CustomerModel cusModel = new CustomerModel();
           SqlDataReader sdr =cusBl.GetCustomerDetails(id);

            if (sdr.Read())
            {
                cusModel.Name = sdr["customer_name"].ToString();
                cusModel.FatherName = sdr["fathers_name"].ToString();
                cusModel.DateOfBirth = sdr["date_of_birth"].ToString();
                cusModel.Age = Convert.ToInt32(sdr["customer_age"]);
                cusModel.MaritalStatus = sdr["martial_status"].ToString();
                cusModel.Address = sdr["customer_address"].ToString();
                cusModel.City= sdr["customer_city"].ToString();
                cusModel.State = sdr["customer_state"].ToString();
                cusModel.Country = sdr["customer_country"].ToString();
                cusModel.Pincode= Convert.ToInt32(sdr["pincode"]);
                cusModel.Phone = Convert.ToInt64(sdr["phone"]);
                cusModel.EmailId = sdr["email_id"].ToString();
              
            }
            else
            {
                ViewData["Message"] = "User Login Failed";
            }
           CustomerDataAccess.sqlCon.Close();
            return View(cusModel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CustomerBusinessLayer cusBl = new CustomerBusinessLayer();
            CustomerModel cusModel = new CustomerModel();
            SqlDataReader sdr=cusBl.DisplayEditCustomer(id);
            if (sdr.Read())
            {
                ViewData["CustomerMessage"] = "";
                cusModel.Name = sdr["customer_name"].ToString();
                cusModel.FatherName = sdr["fathers_name"].ToString();
                cusModel.DateOfBirth = sdr["date_of_birth"].ToString();
                cusModel.Age = Convert.ToInt32(sdr["customer_age"]);
                cusModel.MaritalStatus = sdr["martial_status"].ToString();
                cusModel.Address = sdr["customer_address"].ToString();
                cusModel.City = sdr["customer_city"].ToString();
                cusModel.State = sdr["customer_state"].ToString();
                cusModel.Country = sdr["customer_country"].ToString();
                cusModel.Pincode = Convert.ToInt32(sdr["pincode"]);
                cusModel.Phone = Convert.ToInt64(sdr["phone"]);
                cusModel.EmailId = sdr["email_id"].ToString();

            }
           
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