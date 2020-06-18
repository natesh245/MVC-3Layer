using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public class ChangePasswordModel
    {

        [Display(Name = "Email Id")]
        [Required(ErrorMessage = "Email Id is Required")]
        public string EmailId { get; set; }

        [Display(Name ="New Password")]
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
