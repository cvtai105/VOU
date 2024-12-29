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
        private ILogger<GameServices> _logger;

        public GameServices(
            IApplicationDbContext context,
            GameCreatorFactory gameCreatorFactory,
            ILogger<GameServices> logger)
        {
            _context = context;
            _gameCreatorFactory = gameCreatorFactory;
            _logger = logger;
        }

        public async Task<bool> AddGamesToEventAsync(CreateEventGameRequest request)
        {
            //get event
            var eventEntity = _context.Events.Find(request.EventId)?? throw new NotFoundException("Event not found");

            //get brand id
            var userId = request.UserId;
            var brandId = _context.Brands.Where(x => x.UserId == userId).Select(x => x.Id).FirstOrDefault();

            if (eventEntity.BrandId != brandId)
            {
                throw new ForbiddenAccessException("Brand does not have access to this event");
            }

            //create games
            foreach (var eventGame in request.CreateEventGameParams)
            {
                eventGame.EventId = request.EventId;
                var gameCreator = _gameCreatorFactory.GetGameCreator(eventGame.Type);
                await gameCreator.CreateGameAsync(eventGame);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<Game>> GetEventGamesByEventId(Guid eventId)
        {
            var games = _context.Games.Where(x => x.EventId == eventId).Include(x => x.GamePrototype).ToList();
            return Task.FromResult(games);
        }

        public Task<List<Game>> GetEventGamesByGamePrototypeId(Guid prototypeId)
        {
            var games = _context.Games.Where(x => x.GamePrototypeId == prototypeId).Include(x => x.Event).ToList();
            return Task.FromResult(games);
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