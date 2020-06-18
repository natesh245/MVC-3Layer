using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BussinessLayer.Models;
using System.Data.SqlClient;
using System.Security.Authentication;

namespace BussinessLayer
{
    public class LoginBusinessLayer
    {
        public int CustomerId;
        public string EmailId;
        public string Name;
         
        public void LoginUser(string Emailid,string Password)
        {
            
            LoginDataAccess loginDl = new LoginDataAccess();
            
            SqlDataReader sdr= loginDl.Login(Emailid, Password);
            if (sdr.Read())
            {
                 this.CustomerId = Convert.ToInt32(sdr["id"]);
                this.EmailId =sdr["email_id"].ToString();
                this.Name = sdr[1].ToString();
                LoginDataAccess.sqlCon.Close();

            }
            else
            {
                LoginDataAccess.sqlCon.Close();
                throw new Exception("Login Failed");
            }
        
        }

        public void ChangePassword(string email,string password)
        {
            LoginDataAccess ldac = new LoginDataAccess();
            ldac.UpdatePassword(email,password);
        }
    }
}
