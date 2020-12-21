using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Models;

namespace TaskBackEnd.Supervisors
{
    public partial class Supervisor
    {
        public async Task<List<OperationModel>> GetAllOperation()
        {
            var currencies = await _IOperationRepo.GetAllOperations();
            return _mapper.Map<List<OperationModel>>(currencies);
        }
        public async Task<OperationModel> GetOperationByID(int id)
        {

            var operation = await _IOperationRepo.GetOperationByID(id);
            return _mapper.Map<OperationModel>(operation);
        }
    }
}
