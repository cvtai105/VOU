using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.GameDTOs;
using Application.Interfaces;
using Application.Interfaces.GameBehaviors;
using Application.Services.GameServices.QuizzGameServices;
using Domain.Entities;

namespace Infrastructure.Services.GameServices.QuizGameServices
{
    public class QuizGameBehaviorsProvider : IGameBehaviorsProvider
    {
        
        public Task<bool> CreateGameAsync(CreateGameParamsBase createGameParams, IApplicationDbContext _context)
        {
            if (createGameParams is CreateQuizzGameParams quizzGameParams)
            {
                //create the game
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
                throw new ArgumentException("Invalid createGameParams type");
            }
        }

        public Task<List<GameRewardBase>> GetPlayerRewardByGame(Guid gameId, Guid playerId, IApplicationDbContext context)
        {
            throw new NotImplementedException();
        }

        public Task<GameRewardBase> RewardPrizesAsync(Guid playerId, Guid gameId, IApplicationDbContext context)
        {
            throw new NotImplementedException();
        }
    }
}