using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;

namespace TaskBackEnd.IRepos
{
   public interface IAccountTypeRepo
    {
        Task<List<AccountType>> GetAllAccontTypes();
        Task<AccountType> GetAccontTypeByID(int id);

    }
}
