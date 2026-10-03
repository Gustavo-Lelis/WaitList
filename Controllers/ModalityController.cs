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
        public readonly IModalityService _iModality;

        public ModalityController(IModalityService iModality)
        {
            _iModality = iModality;
        }

        [HttpPost("Register")]

        public async Task<IActionResult> CreateModalitys(ModalityDto modalityDto)
        {
            var modality = await _iModality.CreateModality(modalityDto);
            return Ok(modality);
        }

    }
}