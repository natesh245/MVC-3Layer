using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public class FdDetailsModel
    {
		public List<FdDetailsModel> FdDetailList { get; set; }
		[Display(Name = "Account No")]
		public long AccountNo { get; set; }
		[Display(Name = "Deposit Id")]
		public int DepositId { get; set; }
		[Display(Name = "Fd Date")]
		[DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime FdDate { get; set; }
		[Display(Name = "Fd Amount")]
		public decimal FdAmount { get; set; }
		[Display(Name = "Duration")]
		public int Duration { get; set; }
		[Display(Name = "Rate of interest(%)")]
		public decimal RateOfInterest { get; set; }
		[Display(Name = "Maturity Date")]
		[DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime MaturityDate { get; set; }
		[Display(Name = "Maturity Amount")]
		public decimal MaturityAmount { get; set; }
		[Display(Name = "Nominee")]
		public string Nominee { get; set; }
	}
}
