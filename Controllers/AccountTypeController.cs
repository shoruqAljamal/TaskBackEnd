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
    [Route("api/AccountType")]
    public class AccountTypeController : Controller
    {
        private readonly Isupervisor _ISupervisor;
        public AccountTypeController(Isupervisor ISupervisor)
        {
            _ISupervisor = ISupervisor;
        }
        [HttpGet("GetAllAccountType")]
        public async Task<IActionResult> GetAllAccountType()
        {
            var result = await _ISupervisor.GetAllAccountType();
            return Ok(result);
        }
        [HttpGet("GetAccountTypeById/{id}")]
        public async Task<IActionResult> GetAccountTypeById(int id)
        {
            var result = await _ISupervisor.GetAccountTypeByID(id);
            return Ok(result);
        }
    
   
    }
}
