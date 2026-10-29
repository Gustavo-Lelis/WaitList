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
           
            var waitList = await _iWaitList.AllUserModality();
            return waitList.Status switch
            {
                ProcessedResults.Ok => Ok(waitList),
                ProcessedResults.NotFound => NotFound(waitList),
                _ => StatusCode(StatusCodes.Status500InternalServerError, waitList),
            };
        }

        [HttpPost("reservate")]

        public async Task<IActionResult> ReservateList(WaitListDto waitListDto)
        {
           
            var waitList = await _iWaitList.RegisterUser(waitListDto);
            return waitList.Status switch
            {
                ProcessedResults.Ok => CreatedAtAction(
                    nameof(GetRegisterToId),
                    new {id = waitList.Data!.Id},
                    waitList
                ),
                ProcessedResults.NotFound => NotFound(waitList),
                ProcessedResults.Conflict => Conflict(waitList),
                _ => StatusCode(StatusCodes.Status500InternalServerError, waitList),
            };
  
        }   
          

        [HttpGet("ListaDeTurmas")]
        public async Task<IActionResult> GetListToClass(int classId, PositionStatus positionStatus)
        {
        
            var waitList = await _iWaitList.ListOfClassToPosition(classId, positionStatus);
            return waitList.Status switch
            {
                ProcessedResults.Ok => Ok(waitList),
                ProcessedResults.NotFound => NotFound(waitList),
                _ => StatusCode(StatusCodes.Status500InternalServerError, waitList),
            };
            
        }

        [HttpPatch("UpdateStatus")]
        public async Task<IActionResult> PositionStatusUpdate(WaitListEditStatusDto waitListEditStatusDto)
        {
            var waitList = await _iWaitList.UpdatePositionStatus(waitListEditStatusDto);

             return waitList.Status switch
            {
                ProcessedResults.Ok => Ok(waitList),
                ProcessedResults.NotFound => NotFound(waitList),
                _ => StatusCode(StatusCodes.Status500InternalServerError, waitList),
            };
                
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegisterToId(int id)
        {
            var waitList = await _iWaitList.FindRegisterToId(id);
            return waitList.Status switch
            {
                ProcessedResults.Ok => Ok(waitList),
                ProcessedResults.NotFound => NotFound(waitList),
                _ => StatusCode(StatusCodes.Status500InternalServerError, waitList),
            };
        }

    }
}