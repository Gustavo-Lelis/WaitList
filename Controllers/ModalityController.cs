using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Services.Modality;
using Microsoft.AspNetCore.Mvc;

namespace ListaEspera.Controllers
{
    [ApiController]
    [Route("api/Modality")]
    public class ModalityController : ControllerBase
    {
        private readonly IModalityService _iModality;

        public ModalityController(IModalityService iModality)
        {
            _iModality = iModality;
        }

        [HttpPost("Register")]

        public async Task<IActionResult> CreateModalitys(ModalityDto modalityDto)
        {
            
            try
            {
                var modality = await _iModality.CreateModality(modalityDto);

                if(modality == null)
                {
                    return BadRequest(new {message = "Ocorreu um erro interno ao cadastrar modality."});
                }

                return StatusCode(StatusCodes.Status201Created, new
                {
                    message = "Cadastrado com sucesso",
                    modality
                });
                
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    mensagem = "Ocorreu um erro interno ao cadastrar modalidade.",
                    detalhe = ex.Message // Remova em produção por segurança
                });
            }
            
        }

         [HttpGet]
        public async Task<IActionResult> getModality()
        {
            var modality = await _iModality.ListModality();
            return Ok(modality);
        }

    }
}