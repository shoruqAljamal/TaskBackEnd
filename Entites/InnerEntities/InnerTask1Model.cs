using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBackEnd.Entites.InnerEntities
{
    public class InnerTask1Model
    {
        public string CustomerName { get; set; }
        public List<InnerAcountTask1Model> Accounts { get; set; }
    }
}
