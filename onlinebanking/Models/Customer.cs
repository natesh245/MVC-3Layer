using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace onlinebanking.Models
{
    public class Customer
    {
        
        [Display(Name = "Name")]
        public string customer_name { get; set; }
        [Display(Name = "Fathers Name")]
        public string fathers_name { get; set; }
        [Display(Name = "DOB")]
      
        public  string date_of_birth { get; set; }
        [Display(Name = "Age")]
       
        public int customer_age { get; set; }
        [Display(Name = "Martial Status")]
       
        public string martial_status { get; set; }
        [Display(Name = "Address")]
       
        public string customer_address { get; set; }
        [Display(Name = "City")]
        
        public string customer_city { get; set; }
        [Display(Name = "State")]
       
        public string customer_state { get; set; }
        [Display(Name = "Country")]
        public string customer_country { get; set; }
        public int pincode { get; set; }
        public long phone { get; set; }
        [Display(Name = "Email Id")]
        public string email_id { get; set; }
        
       
   
    }
}