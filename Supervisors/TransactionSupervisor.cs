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
        public async Task<List<TransactionModel>> GetAllTransaction()
        {
            var transactions = await _ITransactionRepo.GetAllTransactions();
            return _mapper.Map<List<TransactionModel>>(transactions);
        }
        public async Task<TransactionModel> GetTransactionByID(int id)
        {

            var transaction = await _ITransactionRepo.GetTransactionByID(id);
            return _mapper.Map<TransactionModel>(transaction);
        }

        public async Task<TransactionModel> GetTransactionByAccountID(int accountId)
        {
            var transaction = await _ITransactionRepo.GetTransactionByAccountID(accountId);
            return _mapper.Map<TransactionModel>(transaction);

        }
        public async Task<bool> Withdraw(TransactionActionModel model)
        {
            Transaction transaction = new Transaction()
            {
                AccountId = (int)model.FromAccountId,
                OperationId = model.OperationId,
                Amount = model.Amount,
                Date = DateTime.Now,
                FromAccountId = (int)model.FromAccountId
            };
            await _ITransactionRepo.Add(transaction);
            var account = await _IAccountRepo.GetAccountByIDWithouInclude((int)model.FromAccountId);
            if (account.CurrencyId == model.CurrencyId)
            {
                account.Amount += model.Amount;
            }
            else
            {
                var ratio = await GetRatioByFromAndToID(model.CurrencyId, account.Currency.ID);
                account.Amount -= model.Amount * ratio.Ratio;
            }
            
            
            return await _IAccountRepo.Update(account);
        }

        public async Task<bool> Deposit(TransactionActionModel model)
        {
            Transaction transaction = new Transaction()
            {
                AccountId = (int)model.ToAccountId,
                OperationId = model.OperationId,
                Amount = model.Amount,
                Date = DateTime.Now,
                ToAccountId = (int)model.ToAccountId
            };
            await _ITransactionRepo.Add(transaction);
            var account = await _IAccountRepo.GetAccountByIDWithouInclude((int)model.ToAccountId);
            if (account.CurrencyId == model.CurrencyId)
            {
                account.Amount = account.Amount + model.Amount;
            }
            else
            {
                var ratio = await GetRatioByFromAndToID(model.CurrencyId, account.CurrencyId);
                account.Amount += model.Amount * ratio.Ratio;
            }
            return await _IAccountRepo.Update(account);
        }
        public async Task<bool> Transfer(TransactionActionModel model)

        {
            Transaction transaction = new Transaction()
            {
                AccountId = (int)model.FromAccountId,
                OperationId = model.OperationId,
                Amount = model.Amount,
                Date = DateTime.Now,
                FromAccountId = (int)model.FromAccountId,
                ToAccountId = (int)model.ToAccountId

            };
            Transaction transaction2 = new Transaction()
            {
                AccountId = (int)model.ToAccountId,
                OperationId = model.OperationId,
                Amount = model.Amount,
                Date = DateTime.Now,
                FromAccountId = (int)model.FromAccountId,
                ToAccountId = (int)model.ToAccountId

            };
            await _ITransactionRepo.Add(transaction);
            await _ITransactionRepo.Add(transaction2);
            var fromAccount = await _IAccountRepo.GetAccountByIDWithouInclude((int)model.FromAccountId);
            var toAccount = await _IAccountRepo.GetAccountByIDWithouInclude((int)model.ToAccountId);
            if (fromAccount.CurrencyId == toAccount.CurrencyId)
            {
                toAccount.Amount = toAccount.Amount + model.Amount;
                fromAccount.Amount = fromAccount.Amount - model.Amount;
            }
            else
            {
                var ratio = await GetRatioByFromAndToID(model.CurrencyId, fromAccount.CurrencyId);
                fromAccount.Amount -= model.Amount * ratio.Ratio;
                toAccount.Amount += model.Amount * ratio.Ratio;
            }
          
            var from= await _IAccountRepo.Update(fromAccount);
            var to= await _IAccountRepo.Update(toAccount);
             if(from && to)
                 return true;
             return false;
        }

    }
}
