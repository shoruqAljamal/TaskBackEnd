using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;

namespace TaskBackEnd.IRepos
{
    public interface IAccountRepo
    {
        Task<List<Account>> GetAllAccounts();
        Task<Account> GetAccountByID(int id);
        Task<Account> GetAccountByIDWithouInclude(int id);
        Task<int> ReturnLastNumber();
        Task<Account> Add(Account account);
        Task<bool> Update(Account account);
        Task<bool> DeleteByID(int id);
    }
}
