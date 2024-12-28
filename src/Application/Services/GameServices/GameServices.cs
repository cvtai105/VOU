using Application.DTOs.Game;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services.GameServices.Contract;
using Application.Services.GameServices.Factory;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services.GameServices
{
    public class GameServices : IGameServices
    {
        private readonly IApplicationDbContext _context;
        private readonly GameCreatorFactory _gameCreatorFactory;
        private Logger<GameServices> _logger;

        public GameServices(
            IApplicationDbContext context,
            GameCreatorFactory gameCreatorFactory,
            Logger<GameServices> logger)
        {
            _context = context;
            _gameCreatorFactory = gameCreatorFactory;
            _logger = logger;
        }

        public async Task<bool> AddGamesToEventAsync(CreateEventGameRequest request)
        {
            //get event
            var eventEntity = _context.Events.Find(request.EventId)?? throw new NotFoundException("Event not found");
            if (eventEntity.BrandId != request.BrandId)
            {
                throw new ForbiddenAccessException("Brand does not have access to this event");
            }

            //create games
            foreach (var eventGame in request.CreateEventGameParams)
            {
                var gameCreator = _gameCreatorFactory.GetGameCreator(eventGame.GameType);
                await gameCreator.CreateGameAsync(eventGame);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<GamePrototype>> GetActiveGames()
        {
            throw new NotImplementedException();
        }

        public Task<List<Game>> GetEventGamesByEventId(Guid eventId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Game>> GetEventGamesByGameBaseId(Guid gameBaseId)
        {
            throw new NotImplementedException();
        }

        public Task GetGameDetail(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> StopEventGame(Guid gameId)
        {
            throw new NotImplementedException();
        }
    }
}