using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.GamePrototypeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers.AdminAPI
{
    [Route("api/admin/games")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGamePrototypeServices _gamePrototypeServices;

        public GameController(ILogger<GameController> logger, IGamePrototypeServices gamePrototypeServices)
        {
            _logger = logger;
            _gamePrototypeServices = gamePrototypeServices;
        }

        [HttpGet]
        [Route("prototypes")]
        public IActionResult GetGamePrototypes()
        {
            var gamePrototypes = _gamePrototypeServices.GetGamePrototypesAsync();
            return Ok(gamePrototypes);
        }

        [HttpPatch]
        [Route("prototype/{gamePrototypeId}")]
        public IActionResult UpdateGamePrototypeStatus(Guid gamePrototypeId, string status)
        {
            _ = _gamePrototypeServices.UpdateGamePrototypeStatusAsync(gamePrototypeId, status);
            return NoContent();
        }

    }
}