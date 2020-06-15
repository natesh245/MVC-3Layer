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
        public SqlDataReader GetCustomerDetails(int ID)
        {
            CustomerDataAccess cusDL = new CustomerDataAccess();
           return cusDL.ReadDetails(ID);

        }

        public SqlDataReader DisplayEditCustomer(int Id)
        {
            CustomerDataAccess cusDL = new CustomerDataAccess();
            return cusDL.UpdateDetails(Id);
        }

        public void EditCustomerDetails(int id,string name,string fn,string dob,int age,string Ms,
            string address,string city,string state ,string country,int pincode,long phone,string emailid)
        {
            CustomerDataAccess cusDl = new CustomerDataAccess();
            cusDl.EditDetails(id,name,fn,dob,age,Ms,address,city,state,country,pincode,
                phone,emailid);

        }
    }
}
