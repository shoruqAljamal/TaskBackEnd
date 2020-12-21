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
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly Isupervisor _ISupervisor;
        public AccountController(Isupervisor ISupervisor)
        {
            _ISupervisor = ISupervisor;
        }
        [HttpGet("GetAllAccount")]
        public async Task<IActionResult> GetAllAccount()
        {
            var result = await _ISupervisor.GetAllAccount();
            return Ok(result);
        }
        [HttpGet("GetAccountById/{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var result = await _ISupervisor.GetAccountByID(id);
            return Ok(result);
        }
        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddAccount([FromBody]AccountModel account)
        {
            var result = await _ISupervisor.AddAccount(account);
            return Ok(result);
        }
        [HttpPut("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody]AccountModel account)
        {
            var result = await _ISupervisor.UpdateAccount(account);
            return Ok(result);
        }
        [HttpDelete("DeleteAccountById/{id}")]
        public async Task<IActionResult> DeleteAccountById(int id)
        {
            var result = await _ISupervisor.DeleteAccountById(id);
            return Ok(result);
        }
    }
}
