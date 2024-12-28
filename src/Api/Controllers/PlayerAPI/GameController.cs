using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers.PlayerAPI
{
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("gamebases")]
        public IActionResult GetActive()
        {
            return Ok("gamebases");
        }

        [HttpGet]
        [Route("event/{eventId}")]
        public IActionResult GetByEvent(Guid eventId)
        {
            return Ok("Games by event");
        }

        [HttpPost]
        [Route("reward/game/{gameId}")]
        public IActionResult Reward(Guid gameId)
        {
            return Ok("Game rewarded");
        }

       
    }
}