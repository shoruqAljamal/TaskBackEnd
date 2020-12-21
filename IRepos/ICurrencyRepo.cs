using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;

namespace TaskBackEnd.IRepos
{
   public interface ICurrencyRepo 
    {

        Task<List<Currency>> GetAllCurrencies();
        Task<Currency> GetCurrencyByID(int id);

    }
}
