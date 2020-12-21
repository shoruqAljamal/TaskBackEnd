using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;

namespace TaskBackEnd.IRepos
{
   public interface ICustomerRepo
    {

        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerByID(int id);
        Task<Customer> Add(Customer customer);
        Task<bool> Update(Customer customer);
        Task<bool> DeleteByID(int id);

    }
}
