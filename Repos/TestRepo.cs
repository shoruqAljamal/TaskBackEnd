using System;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Context;
using TaskBackEnd.Entites;
using TaskBackEnd.IRepos;
using TaskBackEnd.Entites.InnerEntities;

namespace TaskBackEnd.Repos
{
    public class TestRepo : ITestRepo
    {
        private readonly BankContext _context;
        public TestRepo(BankContext context)
        {
            _context = context;
        }
        public async Task<List<InnerTask1Model>> Test()
        {
            //var result = await _context.Customers.Include(e => e.Accounts).Include(e => e.Currency)
            //                    .Select(e => new Customer
            //                    {
            //                        ID = e.ID,
            //                        Name = e.Name,
            //                        CurrencyID = e.CurrencyID,
            //                        Currency = e.Currency,
            //                        Totalmony = e.Totalmony,
            //                        Accounts = e.Accounts.Select(a => new Account
            //                        {
            //                            Number = a.Number
            //                        }).ToList()
            //                    }).ToListAsync();
            /// return customer with account who has the biigest amount of many 
            //var maxAmount = await _context.Accounts.MaxAsync(e => e.Amount);
            //var result = await _context.Customers.Include(e => e.Accounts).Include(e => e.Currency)
            //                    .Select(e => new Customer
            //                    {
            //                        ID = e.ID,
            //                        Name = e.Name,
            //                        CurrencyID = e.CurrencyID,
            //                        Currency = e.Currency,
            //                        Totalmony = e.Totalmony,
            //                        Accounts = e.Accounts.Where(e => e.Amount == _context.Accounts.Max(e => e.Amount)).Select(a => new Account
            //                        {
            //                            Number = a.Number,
            //                            Amount = a.Amount
            //                        }).ToList()
            //                    }).ToListAsync();

            //return result;
            // InnerCustomerAccountModel for account who has the bigest amount of many 
            //var maxAmount = await _context.Accounts.MaxAsync(e => e.Amount);
            //var result = await _context.Customers.Include(e => e.Accounts)
            //                                                .ThenInclude(e => e.AccountType)
            //                                      .Include(e => e.Accounts)
            //                                                .ThenInclude(e => e.Currency)
            //                                      .Include(e => e.Currency)
            //                    .Select(e => new InnerCustomerAccountModel
            //                    {
            //                        CustomerName = e.Name,
            //                        CustomerCurrencyName = e.Currency.Name,
            //                        Amount = e.Accounts.Where(a => a.Amount == maxAmount).FirstOrDefault().Amount,
            //                        AccountNumber = e.Accounts.Where(a => a.Amount == maxAmount).FirstOrDefault().Number,
            //                        AccountCurrencyName = e.Accounts.Where(a => a.Amount == maxAmount).FirstOrDefault().Currency.Name,
            //                        AccountTypeName = e.Accounts.Where(a => a.Amount == maxAmount).FirstOrDefault().AccountType.Name

            //                    }).ToListAsync();
            // tsk one 

            var result = await _context.Customers.Include(e => e.Accounts)
                                                            .ThenInclude(e => e.AccountType)

                                .Select(e => new InnerTask1Model
                                {
                                    CustomerName = e.Name,
                                    Accounts = e.Accounts.Where(c=> c.AccountTypeId == 2)
                                                .Select(a => new InnerAcountTask1Model { 
                                                    accountTypeName = a.AccountType.Name
                                                }).ToList()

                                }).ToListAsync();

            //Tsk 2


            //var result = await _context.Customers.Where(e=>e.ID ==1)
            //                                      .Include(e => e.Accounts)                              
            //                    .Select(e => new InnerTask2Model
            //                    {
            //                        CustomerName = e.Name,
            //                        SumOfMoney = e.Accounts.Sum(c=>c.Amount),
            //                        NumberOfAccounts = e.Accounts.Count()
            //                    }).FirstOrDefaultAsync();

            return result;
        }
    }
}
