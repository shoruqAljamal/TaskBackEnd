using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBackEnd.Entites
{
    public class Account
    {
        [Key]
        public int ID { get; set; }
        public int Number { get; set; }
        public int AccountTypeId { get; set; }
        public int CurrencyId { get; set; }
        public double Amount { get; set; }
        public int CustomerId { get; set; }
        public Currency Currency { get; set; }
        public AccountType AccountType { get; set; }     
        public Customer Customer { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
