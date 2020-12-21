using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBackEnd.Entites
{
    public class CurrencyRatio
    {
        public int ID { get; set; }

        public int FromCurrencyId { get; set; }

        public int ToCurrencyId { get; set; }

        public double Ratio { get; set; }
    }
}
