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
            var attendant = await _iAttendant.CreateAttendant(attendantDto);
            return Ok(attendant);
        }
    }
}