using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;

namespace TaskBackEnd.Context.Configuration
{
    public class AccountConfiguration
    {
        public AccountConfiguration(EntityTypeBuilder<Account> entity)
        {
            //entity.HasKey(e => new { e.CustomerID, e.CurrencyID });
            //entity.HasIndex(e => new { e.Number , e.CurrencyID }).IsUnique();
            entity.HasIndex(e => new { e.Number }).IsUnique();
            entity
                .HasOne<AccountType>(a => a.AccountType)
                .WithMany()
                .HasForeignKey(a => a.AccountTypeId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            //Cascade means delete parent and its children
            //NoAction Deny it from Deletation
            //SetNull Make FK null in children and delete parent

            entity
             .HasOne(a => a.Customer)
             .WithMany(e => e.Accounts)
             .HasForeignKey(a => a.CustomerId)
            .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            entity
            .HasOne(a => a.Currency)
            .WithMany()
            .HasForeignKey(a => a.CurrencyId)
           .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            entity.HasData(
                new Account()
                { 
                    ID =1,
                    AccountTypeId =1 , 
                  CurrencyId =1,
                  Amount=2000.0,
                  CustomerId =1,
                  Number =3588
                },
                  new Account()
                  {
                      ID = 2,
                      AccountTypeId = 2,
                      CurrencyId = 1,
                      Amount = 3000.0,
                      CustomerId = 1,
                      Number = 3589                  },
                    new Account()
                    {
                        ID = 3,
                        AccountTypeId = 3,
                        CurrencyId = 2,
                        Amount = 5000.0,
                        CustomerId = 1,
                        Number = 3590
                    },
                       new Account()
                       {
                           ID = 4,
                           AccountTypeId = 1,
                           CurrencyId = 2,
                           Amount = 5000.0,
                           CustomerId = 2,
                           Number = 3591
                       }


                );
        }

    }
}
