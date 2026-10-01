using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Services.WaitList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ListaEspera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class WaitListController : Controller
    {
        private readonly IWaitListInterface _waitlistInterface;

        public WaitListController(IWaitListInterface waitListInterface)
        {
            _waitlistInterface = waitListInterface;
        }


        [HttpGet]
        public async Task<IActionResult> getWaitList()
        {
            var waitList = await _waitlistInterface.AllUserModality();
            return Ok(waitList);
        }
        
    }
}