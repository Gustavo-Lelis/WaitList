using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Services.ClassGroup;
using Microsoft.AspNetCore.Mvc;

namespace ListaEspera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassGroupController : ControllerBase
    {
        private readonly IClassGroupService _iClassGroup;

        public ClassGroupController(IClassGroupService iClassGroup)
        {
            _iClassGroup = iClassGroup;
        }

        [HttpPost("newClass")]
        public async Task<IActionResult> CreateClassGroup(ClassGroupDto classGroupDto)
        {
            
            try
            {
                var classGroup = await _iClassGroup.CreateClass(classGroupDto);

                if(classGroup == null)
                {
                    return BadRequest(new {message = "Ocorreu um erro interno ao cadastrar turma."});
                }

                return StatusCode(StatusCodes.Status201Created, new
                {
                    message = "Cadastrado com sucesso",
                    classGroup
                });
                
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    mensagem = "Ocorreu um erro interno ao cadastrar turma.",
                    detalhe = ex.Message // Remova em produção por segurança
                });
            }
            
        }
    }
}