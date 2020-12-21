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
    public class CurrencyRepo : ICurrencyRepo
    {

        private readonly BankContext _context;
        public CurrencyRepo(BankContext context)
        {
            _context = context; 
        }
        public async Task<List<Currency>> GetAllCurrencies()
        {
            var curruncies = await _context.Currencies.ToListAsync();
            return curruncies;
        }

        public async Task<Currency> GetCurrencyByID(int id)
        {
            var currency = await _context.Currencies
                .Where(e => e.ID == id).FirstOrDefaultAsync();
            return currency;

        }
    }
}
