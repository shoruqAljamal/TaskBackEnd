using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;

namespace TaskBackEnd.IRepos
{
    public interface ICurrencyRatioRepo
    {
        Task<List<CurrencyRatio>> GetAllCurrenciesRatios();
        Task<CurrencyRatio> GetCurrencyRatioByID(int id);
        Task<CurrencyRatio> GetRatioByFromAndToID(int fromId, int toId);

    }
}
