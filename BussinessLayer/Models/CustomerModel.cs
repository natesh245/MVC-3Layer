using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public class CustomerModel
    {
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fathers Name is Required")]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
       
        [Display(Name = "DOB")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        
        [Display(Name = "Age")]
        public int Age { get; set; }

      
        public string Gender { get; set; }

        [Display(Name = "Marital Status")]
        [Required(ErrorMessage = "Martial Status is Required")]
        public string MaritalStatus { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is Required")]
        public string State { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country is Required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Pincode is Required")]
        public int Pincode { get; set; }

        [Required(ErrorMessage = "Phone no is Required")]
        public long Phone { get; set; }

        [Display(Name = "Email Id")]
        [Required(ErrorMessage = "Email Id is Required")]
        public string EmailId { get; set; }

    }
}
