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
            var classGroup = await _iClassGroup.CreateClass(classGroupDto);
            return Ok(classGroup);
        }
    }
}