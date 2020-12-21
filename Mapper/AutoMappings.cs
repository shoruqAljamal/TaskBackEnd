using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;
using TaskBackEnd.Models;

namespace TaskBackEnd
{
    public class AutoMappings :Profile
    {
        public AutoMappings()
        {
            CreateMap<Customer, CustomerModel>().ReverseMap(); // means you want to map from User to UserDTO
            CreateMap<AccountModel, Account>().ReverseMap();
            CreateMap<AccountTypeModel, AccountType>().ReverseMap();
            CreateMap<CurrencyModel, Currency>().ReverseMap();
            CreateMap<CurrencyRatioModel, CurrencyRatio>().ReverseMap();
            CreateMap<OperationModel, Operation>().ReverseMap();
            CreateMap<TransactionModel, Transaction>().ReverseMap();
        }
    }
}
