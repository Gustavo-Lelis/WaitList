using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Models.Enums;
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
   
            var modality = await _iModality.CreateModality(modalityDto);
             return modality.Status switch
            {
                ProcessedResults.Ok => Ok(modality),
                ProcessedResults.Created => CreatedAtAction(nameof(GetModalityToId), new { id = modality.Data!.Id}, modality),
                ProcessedResults.NotFound => NotFound(modality),
                _ => StatusCode(StatusCodes.Status500InternalServerError, modality),
            };
    
            
        }

        [HttpGet]
        public async Task<IActionResult> GetModality()
        {
            var modality = await _iModality.ListModality();
            return modality.Status switch
            {
                ProcessedResults.Ok => Ok(modality),
                ProcessedResults.NotFound => NotFound(modality),
                _ => StatusCode(StatusCodes.Status500InternalServerError, modality),
            };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModalityToId(int id)
        {
            var modality = await _iModality.FindModalityToId(id);
            return modality.Status switch
            {
                ProcessedResults.Ok => Ok(modality),
                ProcessedResults.NotFound => NotFound(modality),
                _ => StatusCode(StatusCodes.Status500InternalServerError, modality),
            };
        }

    }
}