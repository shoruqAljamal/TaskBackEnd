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
    [Route("api/Currency")]
    public class CurrencyController : Controller
    {
        private readonly Isupervisor _ISupervisor;
        public CurrencyController(Isupervisor ISupervisor)
        {
            _ISupervisor = ISupervisor;
        }
        [HttpGet("GetAllCurrency")]
        public async Task<IActionResult> GetAllCurrency()
        {
            var result = await _ISupervisor.GetAllCurrency();
            return Ok(result);
        }
        [HttpGet("GetCurrencyById/{id}")]
        public async Task<IActionResult> GetCurrencyById(int id)
        {
            var result = await _ISupervisor.GetCurrencyID(id);
            return Ok(result);
        }
    
    }
}
