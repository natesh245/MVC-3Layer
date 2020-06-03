using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onlinebanking.Models
{
    public class Account
    {
        public long account_no { get; set; }
        public long debit_card_no { get; set; }
        public string branch_id { get; set; }
        public int account_type_id { get; set; }
        public int customer_id { get; set; }
        public long balance { get; set; }
        public string check_book_id{ get; set; }
    }
}