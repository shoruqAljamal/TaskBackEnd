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
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        private readonly Isupervisor _ISupervisor;
        public CustomerController(Isupervisor ISupervisor)
        {
            _ISupervisor = ISupervisor;
        }
        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var result = await _ISupervisor.GetAllCustomer();
            return Ok(result);
        }
        [HttpGet("GetCustomerById/{id}")]
        public async Task<IActionResult>GetCustomerById(int id)
        {
            var result = await _ISupervisor.GetCustomerById(id);
            return Ok(result);
        }
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody]CustomerModel customer)
        {
            var result = await _ISupervisor.AddCustomer(customer);
            return Ok(result);
        }
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody]CustomerModel customer)
        {
            var result = await _ISupervisor.UpdateCustomer(customer);
            return Ok(result);
        }
        [HttpDelete("DeleteCustomerById/{id}")]
        public async Task<IActionResult> DeleteCustomerById(int id)
        {
            var result = await _ISupervisor.DeleteCustomerById(id);
            return Ok(result);
        }
    }
}
