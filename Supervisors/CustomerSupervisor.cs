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
        public async Task<List<CustomerModel>> GetAllCustomer()
        {
            var customers = await _ICustomerRepo.GetAllCustomers();
            return _mapper.Map<List<CustomerModel>>(customers);
        }
        public async Task<CustomerModel> GetCustomerById(int id)
        {
            var customer = await _ICustomerRepo.GetCustomerByID(id);
            return _mapper.Map<CustomerModel>(customer);
        }
        public async Task<CustomerModel> AddCustomer(CustomerModel customerModel)
        {
            var customerEntity = _mapper.Map<Customer>(customerModel);
            var lastnumber = await _IAccountRepo.ReturnLastNumber();
            foreach (var account in customerEntity.Accounts)
            {
                account.Number = lastnumber;
                account.Customer = null;
                lastnumber++;
            }

            return _mapper.Map<CustomerModel>(await _ICustomerRepo.Add(customerEntity));
        }
        public async Task<bool> UpdateCustomer(CustomerModel customerModel)
        {
            var customerEntity = _mapper.Map<Customer>(customerModel);
            return await _ICustomerRepo.Update(customerEntity);
        }

        public async Task<bool> DeleteCustomerById(int id)
        {
            try
            {
                await _ICustomerRepo.DeleteByID(id);
            }catch(Exception ex)
            {
                throw ex;
            }

            return true;
        }

    }
}
