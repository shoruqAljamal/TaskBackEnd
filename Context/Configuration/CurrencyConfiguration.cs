using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;

namespace TaskBackEnd.Context.Configuration
{
    public class CurrencyConfiguration
    {
        public CurrencyConfiguration(EntityTypeBuilder<Currency> entity)
        {
            entity.HasData(
                new Currency()
                {
                    ID =1,
                    Name ="USD"
                },
                new Currency()
                {
                    ID = 2,
                    Name = "NIS"
                },
                new Currency()
                {
                    ID = 3,
                    Name = "EUR"
                }
                );
        }
    }
}
