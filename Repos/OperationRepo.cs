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
    public class OperationRepo : IOperationRepo
    {

        private readonly BankContext _context;
        public OperationRepo(BankContext context)
        {
            _context = context;
        }
        public async Task<List<Operation>> GetAllOperations()
        {
            var operations = await _context.Operations.ToListAsync();
            return operations;
        }

        public async Task<Operation> GetOperationByID(int id)
        {

            var operation = await _context.Operations.
                Where(e => e.ID == id).FirstOrDefaultAsync();
            return operation;
        }
    }
}
