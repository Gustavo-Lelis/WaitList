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
using ListaEspera.Models.Enums;
using ListaEspera.Dtos.WaitList;

namespace ListaEspera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WaitListController : ControllerBase
    {
        private readonly IWaitListService _iWaitList;

        public WaitListController(IWaitListService iWaitList)
        {
            _iWaitList = iWaitList;
        }


        [HttpGet("ListaCompleta")]
        public async Task<IActionResult> GetWaitList()
        {
            try
            {
                var waitList = await _iWaitList.AllUserModality();

                // Cenário 1: Os dados não foram encontrados ou a lista está vazia
                // Retorna HTTP 404 (Not Found) ou HTTP 204 (No Content)
                if (waitList == null)
                {
                    return NotFound(new { mensagem = "Nenhum registro encontrado na lista de espera." });
                    // Dica: return NoContent(); também é uma excelente prática para listas vazias.
                }

                // Cenário 2: Sucesso. Retorna HTTP 200 (OK) com os dados
                return Ok(waitList);
            }
            catch (Exception ex)
            {
                // Cenário 3: Erro inesperado no banco ou na aplicação
                // Retorna HTTP 500 (Internal Server Error)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    mensagem = "Ocorreu um erro interno ao buscar a lista.",
                    detalhe = ex.Message // Remova em produção por segurança
                });
            }
        }

        [HttpPost("reservate")]

        public async Task<IActionResult> ReservateList(WaitListDto waitListDto)
        {
           try
            {
                var waitList = await _iWaitList.RegisterUser(waitListDto);

                if(waitList == null)
                {
                    return BadRequest(new {message = "Ocorreu um erro interno ao cadastrar na lista."});
                }

                return StatusCode(StatusCodes.Status201Created, new
                {
                    message = "Cadastrado com sucesso",
                    waitList
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

        [HttpGet("ListaDeTurmas")]
        public async Task<IActionResult> getListToClass(int classId, PositionStatus positionStatus)
        {
            try
            {
                var waitList = await _iWaitList.ListOfClassToPosition(classId, positionStatus);

                if(waitList == null)
                {
                    return NotFound(new { mensagem = "Nenhum registro encontrado na lista de espera." });
                }

                return Ok(waitList);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    mensagem = "Ocorreu um erro interno ao buscar a lista.",
                    detalhe = ex.Message // Remova em produção por segurança
                });

            }
        }

        [HttpPatch("UpdateStatus")]
        public async Task<IActionResult> PositionStatusUpdate(WaitListEditStatusDto waitListEditStatusDto)
        {
            try
            {
                var waitList = await _iWaitList.UpdatePositionStatus(waitListEditStatusDto);

                if(waitList == null)
                {
                    return BadRequest(new {message = "Ocorreu um erro a atualizar a positionstatus."});
                }

                return Ok(waitList);
                
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