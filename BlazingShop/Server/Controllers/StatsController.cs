using BlazingShop.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService _statsService;

        public StatsController(IStatsService statsService)
        {
            _statsService = statsService;
        }

        [HttpGet]
        public async Task<ActionResult<int>> GetVisitsAsync()
        {
            return await _statsService.GetVisitsAsync();
        }

        [HttpPost]
        public async Task IncrementVisitsAsync()
        {
            await _statsService.ImplementVisitsAsync();
        }
    }
}
