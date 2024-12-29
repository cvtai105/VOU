using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services.GameServices.Contract;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Services.GameServices.QuizzGameService
{
    public class QuizzGameCreator : IGameCreator
    {
        private ILogger<QuizzGameCreator> _logger;
        private IApplicationDbContext _context;

        public QuizzGameCreator(ILogger<QuizzGameCreator> logger, IApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Task<bool> CreateGameAsync(CreateGameParamsBase createGameParams)
        {
            //check if the createGameParams is of the correct type
            if (createGameParams is CreateQuizzGameParams quizzGameParams)
            {
                //create the game
                _logger.LogInformation("Creating Quizz Game");

                _logger.LogInformation($"QuestionSetId: {quizzGameParams.QuestionSetId}");
                _logger.LogInformation($"WiningScore: {quizzGameParams.WiningScore}");
                var newGame = new Game{
                    EventId = quizzGameParams.EventId,
                    GamePrototypeId = quizzGameParams.GamePrototypeId,
                    StartTime = quizzGameParams.StartTime,
                    EndTime = quizzGameParams.EndTime,
                    Status = "Active"
                };

                _context.QuizzGames.Add(new QuizzGame
                {
                    EventGameId = newGame.Id,
                    QuestionSetId = quizzGameParams.QuestionSetId,
                    WiningScore = quizzGameParams.WiningScore
                });


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