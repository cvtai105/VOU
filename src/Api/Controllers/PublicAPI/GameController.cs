using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.GamePrototypeServices;
using Application.Services.GameServices;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers.PublicAPI
{
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGamePrototypeServices _gamePrototypeServices;
        private readonly IGameServices _gameServices;

        public GameController(ILogger<GameController> logger, IGamePrototypeServices gamePrototypeServices, IGameServices gameServices)
        {
            _logger = logger;
            _gamePrototypeServices = gamePrototypeServices;
            _gameServices = gameServices;
        }

        [HttpGet]
        [Route("prototypes")]
        // [ResponseCache(Duration = 24*60*60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<IActionResult> GetActiveGamePrototypes()
        {
            var games = await _gamePrototypeServices.GetActiveGamePrototypesAsync();
            return Ok(games);
        }

        [HttpGet]
        [Route("games-by-event")]
        public IActionResult GetEventGames([FromQuery] Guid eventId)
        {
            if (eventId != Guid.Empty)
            {
                var games =  _gameServices.GetEventGamesByEventId(eventId).Result;
                return Ok(games);
            }
            else
            {
                return BadRequest("Need query parameter: eventId");
            }
        }

        [HttpGet]
        [Route("games-by-prototype")]
        public IActionResult GetGameEvents([FromQuery] Guid gamePrototypeId)
        {
            if (gamePrototypeId != Guid.Empty)
            {
                var games = _gameServices.GetEventGamesByGamePrototypeId(gamePrototypeId).Result;
                return Ok(games);
            }
            else
            {
                return BadRequest("Need query parameter: gamePrototypeId");
            }
        }

    }
}