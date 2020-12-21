using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.IRepos;

namespace TaskBackEnd.Supervisors
{
    public partial class Supervisor : Isupervisor
    {
        //Inject All Repository And mapper
        private readonly IMapper _mapper;
        private readonly ICurrencyRepo _ICurrencyRepo;
        private readonly ICustomerRepo _ICustomerRepo;
        private readonly IAccountRepo _IAccountRepo;
        private readonly IAccountTypeRepo _IAccountTypeRepo;
        private readonly ICurrencyRatioRepo _ICurrencyRatioRepo;
        private readonly IOperationRepo _IOperationRepo;
        private readonly ITransactionRepo _ITransactionRepo;



        public Supervisor(IMapper mapper, ICustomerRepo ICustomerRepo,
                         IAccountRepo IAccountRepo, ICurrencyRepo ICurrencyRepo,
                         IAccountTypeRepo IAccountTypeRepo, ICurrencyRatioRepo ICurrencyRatioRepo,
                         IOperationRepo IOperationRepo, ITransactionRepo ITransactionRepo
                               )
        {
            _mapper = mapper;
            _ICustomerRepo = ICustomerRepo;
            _IAccountRepo = IAccountRepo;
            _ICurrencyRepo = ICurrencyRepo;
            _IAccountTypeRepo = IAccountTypeRepo;
            _ICurrencyRatioRepo = ICurrencyRatioRepo;
            _IOperationRepo = IOperationRepo;
            _ITransactionRepo = ITransactionRepo;
        }
    }
}
