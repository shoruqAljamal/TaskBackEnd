using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Models;

namespace TaskBackEnd.Supervisors
{
    public partial class Supervisor
    {
        public async Task<List<AccountTypeModel>> GetAllAccountType()
        {
            var accounttypes = await _IAccountTypeRepo.GetAllAccontTypes();
            return _mapper.Map<List<AccountTypeModel>>(accounttypes);
        }
        public async Task<AccountTypeModel> GetAccountTypeByID(int id)
        {

            var accounttype = await _IAccountTypeRepo.GetAccontTypeByID(id);
            return _mapper.Map<AccountTypeModel>(accounttype);
        }
    }
}
