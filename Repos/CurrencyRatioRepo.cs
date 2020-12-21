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
    public class CurrencyRatioRepo : ICurrencyRatioRepo
    {
        private readonly BankContext _context;
        public CurrencyRatioRepo(BankContext context)
        {
            _context = context;
        }
        public async Task<List<CurrencyRatio>> GetAllCurrenciesRatios()
        {
            var currunciesratios = await _context.CurrenciesRatio.ToListAsync();
            return currunciesratios;
        }

        public async Task<CurrencyRatio> GetCurrencyRatioByID(int id)
        {
            var currencyratio = await _context.CurrenciesRatio
                .Where(e => e.ID == id).FirstOrDefaultAsync();
            return currencyratio;
        }
        public async Task<CurrencyRatio> GetRatioByFromAndToID(int fromId,int toId)
        {
            var currencyratio = await _context.CurrenciesRatio
                .Where(e => e.FromCurrencyId == fromId && e.ToCurrencyId == toId).FirstOrDefaultAsync();
            return currencyratio;
        }
    }
}
