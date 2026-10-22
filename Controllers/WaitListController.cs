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


        [HttpGet]
        public async Task<IActionResult> getWaitList()
        {
            var waitList = await _iWaitList.AllUserModality();
            return Ok(waitList);
        }

        [HttpPost("reservate")]

        public async Task<IActionResult> ReservateList(WaitListDto waitListDto)
        {
            var waitList = await _iWaitList.RegisterUser(waitListDto);
            return Ok(waitList);
        }

        [HttpGet]
        public async Task<IActionResult> getListToClass(int classId, PositionStatus positionStatus)
        {
            var waitList = await _iWaitList.ListOfClassToPosition(classId, positionStatus);
            return Ok(waitList);
        }
        
    }
}