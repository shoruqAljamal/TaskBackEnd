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
    [Route("api/CurrencyRatio")]
    public class CurrencyRatioController : Controller
    {
        private readonly Isupervisor _ISupervisor;
        public CurrencyRatioController(Isupervisor ISupervisor)
        {
            _ISupervisor = ISupervisor;
        }
        [HttpGet("GetAllCurrencyRatio")]
        public async Task<IActionResult> GetAllCurrencyRatio()
        {
            var result = await _ISupervisor.GetAllCurrencyRatio();
            return Ok(result);
        }
        [HttpGet("GetCurrencyRatioById/{id}")]
        public async Task<IActionResult> GetCurrencyRatioById(int id)
        {
            var result = await _ISupervisor.GetCurrencyRatioID(id);
            return Ok(result);
        }
    
    }
}
