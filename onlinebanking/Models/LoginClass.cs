using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace onlinebanking.Models
{
    public class LoginClass
    {
        [Required(ErrorMessage ="Please enter the email id")]
        [Display(Name ="Email Id")]
        public string email_id{ get; set; }

        [Required(ErrorMessage ="Please enter the Password")]
        [Display(Name ="Password")]
        public string user_password { get; set; }
    }
}