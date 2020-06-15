using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlinebanking.Models
{
    public class FixedDepositClass
    {
        [Required(ErrorMessage = "Please enter the Amount")]
        [Display(Name = "Fixed Deposit Amount")]
        [Range(5000, 50000,
        ErrorMessage = "Amount  must be between {1} and {2}.")]
        public long fd_amount { get; set; }

        [Required(ErrorMessage = "Please enter the Duration")]
        [Display(Name = "Fixed deposit Duration(in months)")]
        public int duration { get; set; }

        [Required(ErrorMessage = "Please enter the Nominee")]
        [Display(Name = "Name of the Nominee")]
        public string nominee { get; set; }
    }
}