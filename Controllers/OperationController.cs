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
    [Route("api/Operation")]
    public class OperationController : Controller
    {
        private readonly Isupervisor _ISupervisor;
        public OperationController(Isupervisor ISupervisor)
        {
            _ISupervisor = ISupervisor;
        }
        [HttpGet("GetAllOperation")]
        public async Task<IActionResult> GetAllOperation()
        {
            var result = await _ISupervisor.GetAllOperation();
            return Ok(result);
        }
        [HttpGet("GetOperationById/{id}")]
        public async Task<IActionResult> GetOperationById(int id)
        {
            var result = await _ISupervisor.GetOperationByID(id);
            return Ok(result);
        }
    
    }
}
