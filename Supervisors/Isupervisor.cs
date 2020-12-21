using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Models;

namespace TaskBackEnd.Supervisors
{
    public interface Isupervisor
    {
        #region Customer
        Task<List<CustomerModel>> GetAllCustomer();
        Task<CustomerModel> GetCustomerById(int id);
        Task<CustomerModel> AddCustomer(CustomerModel customerModel);
        Task<bool> UpdateCustomer(CustomerModel customerModel);
        Task<bool> DeleteCustomerById(int id);
        #endregion

        #region Account

        Task<List<AccountModel>> GetAllAccount();
        Task<AccountModel> GetAccountByID(int id);
        Task<AccountModel> AddAccount(AccountModel accountModel);
        Task<bool> UpdateAccount(AccountModel accountModel);
        Task<bool> DeleteAccountById(int id);
        #endregion

        #region AccountType
        Task<List<AccountTypeModel>> GetAllAccountType();
        Task<AccountTypeModel> GetAccountTypeByID(int id);
        #endregion

        #region Currencye
        Task<List<CurrencyModel>> GetAllCurrency();
        Task<CurrencyModel> GetCurrencyID(int id);
        #endregion

        #region CurrencyRatio
        Task<List<CurrencyRatioModel>> GetAllCurrencyRatio();
        Task<CurrencyRatioModel> GetCurrencyRatioID(int id);
        Task<CurrencyRatioModel> GetRatioByFromAndToID(int fromId, int toId);

        #endregion

        #region Operation
        Task<List<OperationModel>> GetAllOperation();
        Task<OperationModel> GetOperationByID(int id);

        #endregion

        #region Transaction
        Task<List<TransactionModel>> GetAllTransaction();
        Task<TransactionModel> GetTransactionByID(int id);
        Task<TransactionModel> GetTransactionByAccountID(int accountId);
        Task<bool> Withdraw(TransactionActionModel model);
        Task<bool> Deposit(TransactionActionModel model);
        Task<bool> Transfer(TransactionActionModel model);


        #endregion


    }
}
