using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBackEnd.Entites
{
    public class Transaction
    {
        public int ID { get; set; }
        public int OperationId { get; set; }
        public double Amount { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; } 
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public Operation Operation { get; set; }
        public DateTime Date { get; set; }
    }
}
