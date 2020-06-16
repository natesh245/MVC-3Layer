using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public class OpenFdModel
    {
        [Required(ErrorMessage = "Please enter the Amount")]
        [Display(Name = "Fixed Deposit Amount")]
        [Range(5000, 50000,
        ErrorMessage = "Amount  must be between {1} and {2}.")]
        public int fdAmount { get; set; }

        [Required(ErrorMessage = "Please enter the Duration")]
        [Display(Name = "Fixed deposit Duration(in months)")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Please enter the Nominee")]
        [Display(Name = "Name of the Nominee")]
        public string Nominee { get; set; }
    }
}
