using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Models;

namespace TaskBackEnd.Supervisors
{
    public partial class Supervisor
    {
        public async Task<List<CurrencyModel>> GetAllCurrency()
        {
            var currencies = await _ICurrencyRepo.GetAllCurrencies();
            return _mapper.Map<List<CurrencyModel>>(currencies);
        }
        public async Task<CurrencyModel> GetCurrencyID(int id)
        {

            var currency = await _ICurrencyRepo.GetCurrencyByID(id);
            return _mapper.Map<CurrencyModel>(currency);
        }
    }
}
