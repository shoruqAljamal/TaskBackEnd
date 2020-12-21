using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;

namespace TaskBackEnd.Context.Configuration
{
    public class AccountTypeConfiguration
    {
        public AccountTypeConfiguration(EntityTypeBuilder<AccountType> entity)
        {
            entity.HasData(
                new AccountType()
                {
                  ID =1,
                 Name="Savings Accounts"  },


                new AccountType()
                    { 
                ID = 2,
                 Name = "Current Accounts"

                     }
                ,

                new AccountType()
                {
                    ID = 3,
                    Name = "Certificates of Deposites"
                }


                );
        }
    }
}
