using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.GameBehaviors;
using Domain.Constants;
using Domain.Entities;
using Infrastructure.Services.GameServices.QuizGameServices;
using Infrastructure.Services.GameServicesShakeGameServices;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.GameServices
{
    public class GameBehaviorsProviderFactory : IGameBehaviorsProviderFactory
    {
        private ShakeGameBehaviorsProvider _shakeGameBehaviorsProvider = new();
        private QuizGameBehaviorsProvider _quizGameBehaviorsProvider = new();
        public IGameBehaviorsProvider GetGameBehavior(string gameType)
        {
            return gameType switch
            {
                GameType.Shake => _shakeGameBehaviorsProvider,
                GameType.Quiz => _quizGameBehaviorsProvider,
                _ => throw new ArgumentException("Invalid game type"),
            };
        }
    }
}