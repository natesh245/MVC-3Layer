using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter the email id")]
        [Display(Name = "Email Id")]

        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please enter the Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
