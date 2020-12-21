﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBackEnd.Models
{
    public class TransactionActionModel
    {
        public int? FromAccountId { get; set; }
        public int? ToAccountId { get; set; }
        public double Amount { get; set; }
        public int CurrencyId { get; set; }
        public int OperationId { get; set; }
    }
}
