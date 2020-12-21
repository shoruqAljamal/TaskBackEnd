using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBackEnd.Models
{
    public class TransactionModel
    {
        public int ID { get; set; }
        public int OperationId { get; set; }
        public double Amount { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public int AccountId { get; set; }
        public OperationModel Operation { get; set; }
        public DateTime Date { get; set; }
    }
}
