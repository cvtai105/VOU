using Application.Services.GameServices.Contract;
using Application.Services.GameServices.QuizzGame;
using Microsoft.Extensions.Logging;

namespace Application.Services.GameServices.ShakeGame
{
    public class ShakeGameCreator : IGameCreator
    {
        private readonly ILogger<ShakeGameCreator> _logger;

        public ShakeGameCreator(ILogger<ShakeGameCreator> logger)
        {
            _logger = logger;
        }

        public Task<bool> CreateGameAsync(CreateGameParamsAbstract createGameParams)
        {
            if (createGameParams is CreateShakeGameParams shakeGameParams)
            {
                //create the game
                _logger.LogInformation("Creating Shake Game");
                return Task.FromResult(true);
            }
            else
            {
                _logger.LogInformation("shakeGameParams is not of the correct type");
                throw new ArgumentException("Invalid createGameParams type");
            }
        }
    }
}