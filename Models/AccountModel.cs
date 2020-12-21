using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TaskBackEnd.Models
{
    public class AccountModel
    {
    
        public int ID { get; set; }
        public int Number { get; set; }
        public int AccountTypeId { get; set; }
        public int CurrencyId { get; set; }
        public double Amount { get; set; }
        public int CustomerId { get; set; }
        public CurrencyModel Currency { get; set; }
        public AccountTypeModel AccountType { get; set; }
        public List<TransactionModel> Transfers { get; set; }
    }
}
