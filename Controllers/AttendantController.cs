using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Services.Attendant;
using Microsoft.AspNetCore.Mvc;

namespace ListaEspera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendantController : ControllerBase
    {
        private readonly IAttendantService _iAttendant;

        public AttendantController(IAttendantService iAttendant)
        {
            _iAttendant = iAttendant;
        }

        [HttpPost("newAttendant")]
        public async Task<IActionResult> RegisterAttendant(AttendantDto attendantDto)
        {
            
            try
            {
                var attendant = await _iAttendant.CreateAttendant(attendantDto);

                if(attendant == null)
                {
                    return BadRequest(new {message = "Ocorreu um erro interno ao cadastrar na lista."});
                }

                return StatusCode(StatusCodes.Status201Created, new
                {
                    message = "Cadastrado com sucesso",
                    attendant
                });
                
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    mensagem = "Ocorreu um erro interno ao cadastrar na lista.",
                    detalhe = ex.Message // Remova em produção por segurança
                });
            }
            
        }
    }
}