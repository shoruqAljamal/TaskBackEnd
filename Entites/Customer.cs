using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBackEnd.Entites
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Totalmony { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
