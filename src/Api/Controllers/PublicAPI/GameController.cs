using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.GameServices;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers.PublicAPI
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameServices _gameServices;

        public GameController(ILogger<GameController> logger, IGameServices gameServices)
        {
            _logger = logger;
            _gameServices = gameServices;
        }

        [HttpGet]
        [Route("gamebases")]
        public IActionResult GetActiveGameBases()
        {
            var games = _gameServices.GetActiveGames();
            return Ok(games);
        }

        [HttpGet]
        [Route("events")]
        public IActionResult GetEventGames([FromQuery] Guid eventId, [FromQuery] Guid gameBaseId)
        {
            if (eventId != Guid.Empty)
            {
                var games = _gameServices.GetEventGamesByEventId(eventId);
                return Ok(games);
            }
            else if (gameBaseId != Guid.Empty)
            {
                var games = _gameServices.GetEventGamesByGameBaseId(gameBaseId);
                return Ok(games);
            }
            else
            {
                return BadRequest("Need one query parameter: eventId or gameBaseId");
            }
            
        }

    }
}