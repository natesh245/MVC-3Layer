using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public class AccountModel
    {
        public long AccountNo { get; set; }
        public long DebitCardNo { get; set; }
        public string BranchId { get; set; }
        public int AccountTypeId { get; set; }
        public int CustomerId { get; set; }
        public long Balance { get; set; }
        public string CheckBookId { get; set; }
    }
}
