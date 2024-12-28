using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.GameServices.Contract;
using Microsoft.Extensions.Logging;

namespace Application.Services.GameServices.QuizzGame
{
    public class QuizzGameCreator : IGameCreator
    {
        private ILogger<QuizzGameCreator> _logger;

        public QuizzGameCreator(ILogger<QuizzGameCreator> logger)
        {
            _logger = logger;
        }


        public Task<bool> CreateGameAsync(CreateGameParamsAbstract createGameParams)
        {
            //check if the createGameParams is of the correct type
            if (createGameParams is CreateQuizzGameParams quizzGameParams)
            {
                //create the game
                _logger.LogInformation("Creating Quizz Game");
                return Task.FromResult(true);
            }
            else
            {
                _logger.LogInformation("quizzGameParams is not of the correct type");
                throw new ArgumentException("Invalid createGameParams type");
            }
            
        }
    }
}