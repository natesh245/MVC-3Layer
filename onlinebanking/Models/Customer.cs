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
        [Required(ErrorMessage ="Name is Required")]
        
        [Display(Name = "Name")]
        public string customer_name { get; set; }
        [Required(ErrorMessage = "Fathers Name is Required")]
        [Display(Name = "Fathers Name")]
        public string fathers_name { get; set; }
        [Required(ErrorMessage = "Date of Birth is Required")]
        [Display(Name = "DOB")]
       
        public  string date_of_birth { get; set; }
        [Required(ErrorMessage = "Age is Required")]
        [Display(Name = "Age")]
       
        public int customer_age { get; set; }
        [Display(Name = "Martial Status")]
        [Required(ErrorMessage = "Martial Status is Required")]
        public string martial_status { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string customer_address { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "City is Required")]
        public string customer_city { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage = "State is Required")]
        public string customer_state { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country is Required")]
        public string customer_country { get ; set; }
        [Required(ErrorMessage = "Pincode is Required")]
        public int pincode { get; set; }
        [Required(ErrorMessage = "Phone no is Required")]
        public long phone { get; set; }
        [Display(Name = "Email Id")]
        [Required(ErrorMessage = "Email Id is Required")]
        public string email_id { get; set; }
        
       
   
    }
}