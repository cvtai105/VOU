using Application.DTOs.Game;
using Application.Services.GameServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandAPI
{
    [Route("api/brand/games")]
    [ApiController]
    [Authorize(Roles = "brand")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameServices _gameServices;

        public GameController(ILogger<GameController> logger, IGameServices gameServices)
        {
            _logger = logger;
            _gameServices = gameServices;
        }


        // [HttpDelete]
        // [Route("{gameId}")]
        // public IActionResult StopEventGame(Guid gameId)
        // {
        //     _ = _gameServices.StopEventGame(gameId);
        //     return NoContent();
        // }

        [HttpPost]
        public async Task<IActionResult> AddEventGamesAsync([FromBody] CreateEventGameRequest createEventGameParams)
        {
            var result = await _gameServices.AddGamesToEventAsync(createEventGameParams);
            
            return Ok(result); 
        }
        

    }
}