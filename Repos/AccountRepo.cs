using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Context;
using TaskBackEnd.Entites;
using TaskBackEnd.IRepos;

namespace TaskBackEnd.Repos
{
    public class AccountRepo : IAccountRepo
    {
        private readonly BankContext _context;
        public AccountRepo(BankContext context)
        {
            _context = context; 
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return accounts;
        }
        public async Task<Account> GetAccountByID(int id)
        {
            var account = await _context.Accounts.Where(e =>e.ID == id)
                                                    .Include(e=>e.AccountType)
                                                    .Include(e=>e.Currency)
                                                    .FirstOrDefaultAsync();
            return account;
        }
        public async Task<Account> GetAccountByIDWithouInclude(int id)
        {
            var account = await _context.Accounts.Include(e=>e.Transactions).Where(e => e.ID == id)
                                                    .Select(e=> new Account()
                                                    {
                                                        Number = e.Number, 
                                                         ID = e.ID, 
                                                         AccountTypeId = e.AccountTypeId , 
                                                         Amount = e.Amount,
                                                         CurrencyId = e.CurrencyId,
                                                         CustomerId = e.CustomerId,
                                                        Transactions = e.Transactions.Select(model => new Transaction {
                                                            AccountId = model.AccountId,
                                                            OperationId = model.OperationId,
                                                            Amount = model.Amount,
                                                            Date = model.Date,
                                                            FromAccountId = model.FromAccountId,
                                                            ToAccountId = model.ToAccountId
                                                        }).ToList()
                                                    }).FirstOrDefaultAsync();
            return account;
        }

        public async Task<int> ReturnLastNumber()
        {
            var lastnumber =  await _context.Accounts.MaxAsync(e => e.Number);
            if (lastnumber == 0)
                return 1;
            return lastnumber+1;
        }


        public async Task<Account> Add(Account account)
        {
            // كانت هون بدون الاكاونت بالسطر اللي ورا
            _context.Accounts.Add(account); //Change Tracker : only change the state 
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<bool> Update(Account account)
        {
            _context.Update(account); //Change Tracker : only change the state 
            try
            {
               await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
            return true;
        }
        public async Task<bool> DeleteByID(int id)
        {
            var account = await GetAccountByID(id);
            _context.Remove(account); //Change Tracker : only change the state 
            var success = await _context.SaveChangesAsync();
            if (success == 0)
                return false;
            return true;
        }



    }
}
