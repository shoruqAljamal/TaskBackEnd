using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;

namespace TaskBackEnd.Context.Configuration
{
    public class OperationConfiguration
    {
        public OperationConfiguration(EntityTypeBuilder<Operation> entity)
        {


            entity.HasData(

                new Operation() { ID = 1, Name = "Transfer" },
                new Operation() { ID = 2, Name = "Deposite" },
                new Operation() { ID = 3, Name = "Withdraw" }
                );
        }
    }
}
