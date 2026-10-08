using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Services.Client;
using Microsoft.AspNetCore.Mvc;

namespace ListaEspera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _iClientService;

        public ClientController(IClientService iClientService)
        {
            _iClientService = iClientService;
        }

         [HttpPost("newClient")]
        public async Task<IActionResult> RegisterClient(ClientDto clientDto)
        {
            var client = await _iClientService.CreateClient(clientDto);
            return Ok(client);
        }
    }
}