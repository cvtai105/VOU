using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTOs.GameDTOs;
using Application.Services.GameServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers.PlayerAPI
{
    [Route("api/player/games")]
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameServices _gameServices;

        public GameController(ILogger<GameController> logger, IGameServices gameServices)
        {
            _logger = logger;
            _gameServices = gameServices;
        }

        [HttpPost]
        [Route("win")]
        public async Task<IActionResult> RewardAsync([FromBody] GetRewardRequest req)
        {
            var playerId = User.FindFirstValue("userId");
            if(playerId == null)
            {
                return Unauthorized();
            }
            req.PlayerId = Guid.Parse(playerId);

            return Ok(await _gameServices.RewardPlayer(req));
        }

        [HttpGet]
        [Route("reward")]
        public async Task<IActionResult> GetRewardsAsync([FromQuery] Guid gameId, [FromQuery] string gameType)
        {
            var playerId = User.FindFirstValue("userId");
            if(playerId == null)
            {
                return Unauthorized();
            }

            var param = new GetRewardRequest
            {
                GameId = gameId,
                GameType = gameType,
                PlayerId = Guid.Parse(playerId)
            };

            return Ok(await _gameServices.GetPlayerRewardByGame(param));

        }
        
    }
}