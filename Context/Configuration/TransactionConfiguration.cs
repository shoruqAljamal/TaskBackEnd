using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;

namespace TaskBackEnd.Context.Configuration
{
    public class TransactionConfiguration
    {
        public TransactionConfiguration(EntityTypeBuilder<Transaction> entity)
        {

            entity
              .HasOne(t => t.Account)
              .WithMany(a => a.Transactions)
              .HasForeignKey(t => t.AccountId)
              .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            entity.HasOne(t => t.Operation)
                .WithMany()
                .HasForeignKey(t => t.OperationId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

        }
    }
}
