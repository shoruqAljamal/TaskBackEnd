using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;

namespace TaskBackEnd.IRepos
{
   public interface IOperationRepo
    {
        Task<List<Operation>> GetAllOperations();
        Task<Operation> GetOperationByID(int id);

    }
}
