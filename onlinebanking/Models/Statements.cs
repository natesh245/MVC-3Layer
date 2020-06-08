using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onlinebanking.Models
{
    public class Statements
    {
        public List<Statements> statementList { get; set; }
        public int Id { get; set; }
        public int IdCredit { get; set; }
        public long DebitAccount { get; set; }
        public long CreditAccount { get; set; }
        public long DebitAccountBalance{ get; set; }
        public long CreditAccountBalance { get; set; }
        public  int DebitAmount { get; set; }
        public int CreditAmount { get; set; }
        public string DebitDate { get; set; }
        public string CreditDate { get; set; }
        



    }
}