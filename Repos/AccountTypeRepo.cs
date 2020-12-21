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
    public class AccountTypeRepo :IAccountTypeRepo
    {
        private readonly BankContext _context;
        public AccountTypeRepo(BankContext context)
        {
            _context = context;
        }

  
        public async Task<List<AccountType>> GetAllAccontTypes()
        {
            var accounttypes = await _context.AccountTypes.ToListAsync();
            return accounttypes;
        }

        public async Task<AccountType> GetAccontTypeByID(int id)
        {
            var accounttype = await _context.AccountTypes.Where(e => e.ID == id).FirstOrDefaultAsync();
            return accounttype;
        }
    }
}
