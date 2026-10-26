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
            
            try
            {
                var client = await _iClientService.CreateClient(clientDto);

                if(client == null)
                {
                    return BadRequest(new {message = "Ocorreu um erro interno ao cadastrar cliente."});
                }

                return StatusCode(StatusCodes.Status201Created, new
                {
                    message = "Cadastrado com sucesso",
                    client
                });
                
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    mensagem = "Ocorreu um erro interno ao cadastrar cliente.",
                    detalhe = ex.Message // Remova em produção por segurança
                });
            }
            
        }
    }
}