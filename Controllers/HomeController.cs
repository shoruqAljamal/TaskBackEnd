﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskBackEnd.IRepos;
using TaskBackEnd.Models;

namespace TaskBackEnd.Controllers
{
    [Route("api/Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestRepo _ITestRepo;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, ITestRepo iTestRepo, IMapper mapper)
        {
            _logger = logger;
            _ITestRepo = iTestRepo;
            _mapper = mapper;
        }
        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            var result = await _ITestRepo.Test();
            return Ok(result);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
