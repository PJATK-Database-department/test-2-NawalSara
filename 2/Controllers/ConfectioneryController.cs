using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_Tutorial13.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Tutorial13.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class ConfectioneryController : ControllerBase
    {
        private readonly IConfectioneryDbService _dbService;

        public ConfectioneryController(IConfectioneryDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult getOrders(int? id)
        {
            if(id == null) { id = 0; }
            return _dbService.GetAllOrders((int)id) == null ? NotFound("There are no orders") : (IActionResult)Ok(_dbService.GetAllOrders((int)id));
        }

    }
}