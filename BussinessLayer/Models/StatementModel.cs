using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public class StatementModel
    {
        public List<StatementModel> statementList { get; set; }
        public int TransactionId { get; set; }
        
        public long DebitAccount { get; set; }
        public long CreditAccount { get; set; }
        public long DebitAccountBalance { get; set; }
        public long CreditAccountBalance { get; set; }
        public int Amount { get; set; }
       
        public string TransactionDate { get; set; }
        

       

    }
}
