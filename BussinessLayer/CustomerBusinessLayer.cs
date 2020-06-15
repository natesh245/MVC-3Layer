using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BussinessLayer.Models;
using System.Data.SqlClient;

namespace BussinessLayer
{
 public class CustomerBusinessLayer
    {
        public CustomerModel GetCustomerDetails(int ID)
        {
            CustomerDataAccess cusDL = new CustomerDataAccess();
           SqlDataReader sdr= cusDL.ReadDetails(ID);
            CustomerModel cusModel = new CustomerModel();
            if (sdr.Read())
            {
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
            return cusModel;

        }

        public CustomerModel DisplayEditCustomer(int Id)
        {
            CustomerDataAccess cusDL = new CustomerDataAccess();
            CustomerModel cusModel = new CustomerModel();
           SqlDataReader sdr =cusDL.UpdateDetails(Id);
            if (sdr.Read())
            {

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
            return cusModel;
        }

        public void EditCustomerDetails(int id,string name,string fn,string dob,int age,string Ms,
            string address,string city,string state ,string country,int pincode,long phone,string emailid)
        {
            CustomerDataAccess cusDl = new CustomerDataAccess();
            cusDl.EditDetails(id,name,fn,dob,age,Ms,address,city,state,country,pincode,
                phone,emailid);
            CustomerDataAccess.sqlCon.Close();
        }
    }
}
