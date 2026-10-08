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
        private readonly IClientService _iClientService;

        public WaitListController(IWaitListService iWaitListService, IClientService iClientService)
        {
            _iWaitlistService = iWaitListService;
            _iClientService = iClientService;
        }


        [HttpGet]
        public async Task<IActionResult> getWaitList()
        {
            var waitList = await _iWaitlistService.AllUserModality();
            return Ok(waitList);
        }

        [HttpPost("newClient")]
        public async Task<IActionResult> RegisterClient(ClientDto clientDto)
        {
            var client = await _iClientService.CreateClient(clientDto);
            return Ok(client);
        }
        
    }
}