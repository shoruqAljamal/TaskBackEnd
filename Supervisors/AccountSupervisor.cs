using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;
using TaskBackEnd.Models;

namespace TaskBackEnd.Supervisors
{
    public partial class Supervisor
    {
        public async Task<List<AccountModel>> GetAllAccount()
        {
            var accounts = await _IAccountRepo.GetAllAccounts();
            return _mapper.Map<List<AccountModel>>(accounts);
        }
        public async Task<AccountModel> GetAccountByID(int id)
        {

            var account = await _IAccountRepo.GetAccountByID(id);
            return _mapper.Map<AccountModel>(account);
        }

        public async Task<AccountModel> AddAccount(AccountModel accountModel)
        {
            var lastnumber = await _IAccountRepo.ReturnLastNumber();
            accountModel.Number = lastnumber;
            var accountEntity = _mapper.Map<Account>(accountModel);
            return _mapper.Map<AccountModel>(await _IAccountRepo.Add(accountEntity));
        }
        public async Task<bool> UpdateAccount(AccountModel accountModel)
        {
            var accountEntity = _mapper.Map<Account>(accountModel);
            return await _IAccountRepo.Update(accountEntity);
        }

        public async Task<bool> DeleteAccountById(int id)
        {
            try
            {
                await _IAccountRepo.DeleteByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }



    }
}
