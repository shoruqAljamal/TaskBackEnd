using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBackEnd.Entites.InnerEntities
{
    public class InnerCustomerAccountModel
    {
        public string CustomerName { get; set; }
        public int AccountNumber { get; set; }
        public double Amount { get; set; }
        public string AccountTypeName { get; set; }
        public string AccountCurrencyName { get; set; }
        public string CustomerCurrencyName { get; set; }
    }
}
