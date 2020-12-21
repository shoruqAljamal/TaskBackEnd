using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskBackEnd.IRepos;
using TaskBackEnd.Models;
using TaskBackEnd.Supervisors;

namespace TaskBackEnd.Controllers
{
    [Route("api/Transaction")]
    public class TransactionController : Controller
    {
        private readonly Isupervisor _ISupervisor;
        public TransactionController(Isupervisor ISupervisor)
        {
            _ISupervisor = ISupervisor;
        }
        [HttpGet("GetAllTransaction")]
        public async Task<IActionResult> GetAllTransaction()
        {
            var result = await _ISupervisor.GetAllTransaction();
            return Ok(result);
        }
        [HttpGet("GetTransactionById/{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            var result = await _ISupervisor.GetTransactionByID(id);
            return Ok(result);
        }

        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody]TransactionActionModel model)
        {
            var result = await _ISupervisor.Withdraw(model);
            return Ok(result);
        }

        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit([FromBody]TransactionActionModel model)
        {
                var result = await _ISupervisor.Deposit(model);
            return Ok(result);
        }
        [HttpPost("Transfer")]
        public async Task<IActionResult> Transfer([FromBody]TransactionActionModel model)
        {
            var result = await _ISupervisor.Transfer(model);
            return Ok(result);
        }



    }
}
