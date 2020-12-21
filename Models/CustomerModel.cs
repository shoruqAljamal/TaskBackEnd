using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBackEnd.Models
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Totalmony { get; set; }
        public int CurrencyId { get; set; }
        public CurrencyModel Currency { get; set; }
        public List<AccountModel> Accounts { get; set; }
    }
}
