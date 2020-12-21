using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;

namespace TaskBackEnd.Context.Configuration
{
    public class CurrencyRatioConfiguration
    {
        public CurrencyRatioConfiguration(EntityTypeBuilder<CurrencyRatio> entity)
        {
            entity.HasData(
                new CurrencyRatio()
                {
                    ID =1 ,
                    FromCurrencyId =1 , 
                    ToCurrencyId = 2, 
                    Ratio = 3.5
                },
                   new CurrencyRatio()
                      {
                          ID = 2,
                          FromCurrencyId = 2,
                          ToCurrencyId = 1,
                          Ratio = 0.286
                      },
                      new CurrencyRatio()
                      {
                          ID = 3,
                          FromCurrencyId = 1,
                          ToCurrencyId = 3,
                          Ratio = 1.19
                      },
                         new CurrencyRatio()
                         {
                             ID = 4,
                             FromCurrencyId = 3,
                             ToCurrencyId = 1,
                             Ratio = 0.84
                         }
                         ,
                            new CurrencyRatio()
                            {
                                ID = 5,
                                FromCurrencyId = 2,
                                ToCurrencyId = 3,
                                Ratio = 3.97671
                            },
                               new CurrencyRatio()
                               {
                                   ID = 6,
                                   FromCurrencyId = 3,
                                   ToCurrencyId = 2,
                                   Ratio = 0.251464
                               }
                );
        }
    }
}
