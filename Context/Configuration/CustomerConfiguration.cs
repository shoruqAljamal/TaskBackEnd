using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;

namespace TaskBackEnd.Context.Configuration
{
    public class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<Customer> entity)
        {
            entity.HasOne<Currency>(s => s.Currency)
               .WithMany()
               .HasForeignKey(s => s.CurrencyId)
               .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction); 
            entity.HasData(
                new Customer()
                {
                    ID = 1,
                    Name = "Anas",
                    Totalmony = 9430.0,
                    CurrencyId = 1
                },
                     new Customer()
                     {
                         ID = 2,
                         Name = "Shorouq",
                         Totalmony = 245.388,
                         CurrencyId = 1
                     }

                );
        }
    }
}
