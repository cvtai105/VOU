using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.GameServices.Contract;
using Application.Services.GameServices.QuizzGame;
using Application.Services.GameServices.ShakeGame;
using Microsoft.Extensions.Logging;

namespace Application.Services.GameServices.Factory
{
    public class GameCreatorFactory
    {

        private ILogger<ShakeGameCreator> _shakeLogger;
        private ILogger<QuizzGameCreator> _quizzLogger;

        public GameCreatorFactory(ILogger<ShakeGameCreator> shakeLogger, ILogger<QuizzGameCreator> quizzLogger)
        {
            _shakeLogger = shakeLogger;
            _quizzLogger = quizzLogger;
        }

        public IGameCreator GetGameCreator(string gamePrototypeType)
        {
            return gamePrototypeType switch
            {
                "Shake" => new ShakeGameCreator(_shakeLogger),
                "Quizz" => new QuizzGameCreator(_quizzLogger),
                _ => throw new ArgumentException("Invalid game type")
            };
        }
        
    }
}