using Application.Interfaces;
using Application.Services.GameServices.Contract;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Services.GameServices.ShakeGameServices
{
    public class ShakeGameCreator : IGameCreator
    {
        private readonly ILogger<ShakeGameCreator> _logger;
        private readonly IApplicationDbContext _context;

        public ShakeGameCreator(ILogger<ShakeGameCreator> logger, IApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Task<bool> CreateGameAsync(CreateGameParamsBase createGameParams)
        {
            if (createGameParams is CreateShakeGameParams shakeGameParams)
            {
                //create the game
                _logger.LogInformation("Creating Shake Game");
                _logger.LogInformation($"Voucher Piece Count: {shakeGameParams.VoucherPieceCount}");

                var newGame = new Game{
                    EventId = shakeGameParams.EventId,
                    GamePrototypeId = shakeGameParams.GamePrototypeId,
                    StartTime = shakeGameParams.StartTime,
                    EndTime = shakeGameParams.EndTime,
                    Status = "Active"
                };

                _context.Games.Add(newGame);

                _context.ShakeGames.Add(new ShakeGame
                {
                    EventGameId = newGame.Id,
                    VoucherPieceCount = shakeGameParams.VoucherPieceCount,
                });

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