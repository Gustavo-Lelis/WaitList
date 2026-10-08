using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Services.WaitList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ListaEspera.Services.Client;
using ListaEspera.Dtos;

namespace ListaEspera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class WaitListController : ControllerBase
    {
        private readonly IWaitListService _iWaitlistService;

        public WaitListController(IWaitListService iWaitListService)
        {
            _iWaitlistService = iWaitListService;
        }


        [HttpGet]
        public async Task<IActionResult> getWaitList()
        {
            var waitList = await _iWaitlistService.AllUserModality();
            return Ok(waitList);
        }

    
        
    }
}