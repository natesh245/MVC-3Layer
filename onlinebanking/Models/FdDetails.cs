using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlinebanking.Models
{
    public class FdDetails
    {
		
		public List<FdDetails> FdDetailList { get; set; }
		[Display(Name ="Account No")]
		public long account_no { get; set; }
		[Display(Name = "Deposit Id")]
		public int deposit_id { get; set; }
		[Display(Name = "Fd Date")]
		public string fd_date { get; set; }
		[Display(Name = "Fd Amount")]
		public decimal fd_amount { get; set; }
		[Display(Name = "Duration")]
		public int duration { get; set; }
		[Display(Name = "Rate of interest(%)")]
		public decimal rate_of_interest { get; set; }
		[Display(Name = "Maturity Date")]
		public string maturity_date { get; set; }
		[Display(Name = "Maturity Amount")]
		public decimal maturity_amount { get; set; }
		[Display(Name = "Nominee")]
		public string nominee { get; set; }
	}
}