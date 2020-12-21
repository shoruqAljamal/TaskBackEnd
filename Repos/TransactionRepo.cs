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
    public class TransactionRepo : ITransactionRepo
    {
        private readonly BankContext _context;
        public TransactionRepo(BankContext context)
        {
            _context = context;
        }
        public async Task<List<Transaction>> GetAllTransactions()
        {
            var transfers = await _context.Transactions.ToListAsync();
            return transfers;
        }

        public async Task<Transaction> GetTransactionByID(int id)
        {

            var transfer = await _context.Transactions.
                Where(e => e.ID == id).FirstOrDefaultAsync();
            return transfer;
        }
        public async Task<List<Transaction>> GetTransactionByAccountID(int accountID)
        {

            var transfers = await _context.Transactions.
                Where(e => e.AccountId == accountID).Include(e=>e.Operation).ToListAsync();
            return transfers;
        }
        public async Task<Transaction> Add(Transaction transaction)
        {
            _context.Add(transaction); //Change Tracker : only change the state 
            await _context.SaveChangesAsync();
            return transaction;
        }

    }
}
