using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Context;
using TaskBackEnd.Entites;
using TaskBackEnd.IRepos;

namespace TaskBackEnd.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly BankContext _context; 
        public CustomerRepo(BankContext context)
        {
            _context = context;
        }
        public async Task<List<Customer>> GetAllCustomers()
        {
           var customers = await _context.Customers.ToListAsync();
            return customers; 
        }

        public async Task<Customer> GetCustomerByID(int id)
        {
            var customer = await _context.Customers.Where(e => e.ID == id)
                                            .Include(e=>e.Currency)
                                            .Include(e=>e.Accounts)
                                                .ThenInclude(e=>e.AccountType)
                                            .Include(e => e.Accounts)
                                                .ThenInclude(e => e.Currency)
                                            .FirstOrDefaultAsync();
            return customer; 
           
        }

        public async Task<Customer> Add(Customer customer)
        {
            _context.Add(customer); //Change Tracker : only change the state 
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> Update(Customer customer)
        {
            _context.Update(customer); //Change Tracker : only change the state 
            var success = await _context.SaveChangesAsync();
            if(success == 0)
                return false;
            return true;
        }
        public async Task<bool> DeleteByID(int id)
        {
            var customer = await GetCustomerByID(id);
            _context.Remove(customer); //Change Tracker : only change the state 
            var success = await _context.SaveChangesAsync();
            if (success == 0)
                return false;
            return true;
        }

    }
}
