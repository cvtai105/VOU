using Application.Interfaces;
using Application.Services.GameServices.Contract;
using Application.Services.GameServices.QuizzGameService;
using Application.Services.GameServices.ShakeGameServices;
using Microsoft.Extensions.Logging;

namespace Application.Services.GameServices.Factory
{
    public class GameCreatorFactory
    {

        private ILogger<ShakeGameCreator> _shakeLogger;
        private ILogger<QuizzGameCreator> _quizzLogger;
        private IApplicationDbContext _context;

        public GameCreatorFactory(ILogger<ShakeGameCreator> shakeLogger, ILogger<QuizzGameCreator> quizzLogger, IApplicationDbContext context)
        {
            _shakeLogger = shakeLogger;
            _quizzLogger = quizzLogger;
            _context = context;
        }

        public IGameCreator GetGameCreator(string gamePrototypeType)
        {
            return gamePrototypeType switch
            {
                "Shake" => new ShakeGameCreator(_shakeLogger, _context),
                "Quiz" => new QuizzGameCreator(_quizzLogger, _context),
                _ => throw new ArgumentException("Invalid game type")
            };
        }
        
    }
}