using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public class TransactionModel
    {
        [Required(ErrorMessage = "Please enter the Payee Account No")]
        [Display(Name = "Payee Account No")]
        public long AccountNo { get; set; }
        [Required(ErrorMessage = "Please enter the Amount")]
        [Display(Name = "Amount")]
        [Range(1, int.MaxValue, ErrorMessage = "Amount Should be greater than 0")]
        public int Amount { get; set; }
    }
}
