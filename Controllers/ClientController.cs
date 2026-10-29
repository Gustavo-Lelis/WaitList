using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Models.Enums;
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
            
            return client.Status switch
            {
                ProcessedResults.Ok => StatusCode(StatusCodes.Status200OK),
                ProcessedResults.ErroServer => StatusCode(StatusCodes.Status500InternalServerError),
                ProcessedResults.NotFound => StatusCode(StatusCodes.Status404NotFound),
                _ => (IActionResult)client,
            };

                
                
            
        }
    }
}