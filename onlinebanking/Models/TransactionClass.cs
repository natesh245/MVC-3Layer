using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace onlinebanking.Models
{
    public class TransactionClass
    {

        [Required(ErrorMessage = "Please enter the Payee Account No")]
        [Display(Name = "Payee Account No")]
        public long AccountNo { get; set; }
        [Required(ErrorMessage = "Please enter the Amount")]
        [Display(Name = "Amount")]
        public int Amount { get; set; }

    }
}