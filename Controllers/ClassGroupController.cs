using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Models.Enums;
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
            
            
            var classGroup = await _iClassGroup.CreateClass(classGroupDto);
            return classGroup.Status switch
            {
                ProcessedResults.Created => CreatedAtAction(
                    nameof(GetClassGroupToId),
                    new{id = classGroup.Data!.Id},
                    classGroup
                ),
                ProcessedResults.NotFound => NotFound(classGroup),
                _ => StatusCode(StatusCodes.Status500InternalServerError, classGroup),
            };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassGroupToId(int id)
        {
            var classGroup = await _iClassGroup.FindClassGroupToId(id);
            return classGroup.Status switch
            {
                ProcessedResults.Ok => Ok(classGroup),
                ProcessedResults.NotFound => NotFound(classGroup),
                _ => StatusCode(StatusCodes.Status500InternalServerError, classGroup),
            };
        }
    }
}