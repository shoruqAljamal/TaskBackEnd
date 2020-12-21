using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Models;

namespace TaskBackEnd.Supervisors
{
    public partial class Supervisor
    {
        public async Task<List<CurrencyRatioModel>> GetAllCurrencyRatio()
        {
            var currencyratios = await _ICurrencyRatioRepo.GetAllCurrenciesRatios();
            return _mapper.Map<List<CurrencyRatioModel>>(currencyratios);
        }
        public async Task<CurrencyRatioModel> GetCurrencyRatioID(int id)
        {

            var currencyRatio = await _ICurrencyRatioRepo.GetCurrencyRatioByID(id);
            return _mapper.Map<CurrencyRatioModel>(currencyRatio);
        }
        public async Task<CurrencyRatioModel> GetRatioByFromAndToID(int fromId, int toId)
        {
            var currencyRatio = await _ICurrencyRatioRepo.GetRatioByFromAndToID(fromId,  toId);
            return _mapper.Map<CurrencyRatioModel>(currencyRatio);
        }
    }
}
