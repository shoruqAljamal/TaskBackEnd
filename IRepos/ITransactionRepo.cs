using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;

namespace TaskBackEnd.IRepos
{
    public interface ITransactionRepo
    {
        Task<List<Transaction>> GetAllTransactions();
        Task<Transaction> GetTransactionByID(int id);
        Task<List<Transaction>> GetTransactionByAccountID(int accountID);
        Task<Transaction> Add(Transaction transaction);

    }
}
