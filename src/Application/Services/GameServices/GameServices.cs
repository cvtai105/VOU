using Application.DTOs.GameDTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.GameBehaviors;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services.GameServices
{
    public class GameServices : IGameServices
    {
        private readonly IApplicationDbContext _context;
        private readonly IGameBehaviorsProviderFactory _gameBehaveiorsProviderFactory;
        private ILogger<GameServices> _logger;

        public GameServices(
            IApplicationDbContext context,
            IGameBehaviorsProviderFactory gameCreatorFactory,
            ILogger<GameServices> logger)
        {
            _context = context;
            _gameBehaveiorsProviderFactory = gameCreatorFactory;
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
                var gameCreator = _gameBehaveiorsProviderFactory.GetGameBehavior(eventGame.Type);
                await gameCreator.CreateGameAsync(eventGame, _context);
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

        public Task<List<GameRewardBase>> GetPlayerRewardByGame(GetRewardRequest request)
        {
            var result = new GameRewardBase
            {
                PlayerId = request.PlayerId,
                GameId = request.GameId
            };

            var gameBehavior = _gameBehaveiorsProviderFactory.GetGameBehavior(request.GameType);

            return gameBehavior.GetPlayerRewardByGame(request.GameId, request.PlayerId, _context);
        }

        public Task<GameRewardBase> RewardPlayer(GetRewardRequest request)
        {
            //get game
            var game = _context.Games.Include(x => x.GamePrototype).FirstOrDefault(x => x.Id == request.GameId);
            if (game == null)
            {
                throw new NotFoundException("Game not found");
            }

            //get game behavior
            var gameBehavior = _gameBehaveiorsProviderFactory.GetGameBehavior(game?.GamePrototype?.Type??string.Empty);

            //reward player
            return gameBehavior.RewardPrizesAsync(request.PlayerId, request.GameId, _context);
        }

        public Task<bool> StopEventGame(Guid gameId)
        {
            throw new NotImplementedException();
        }
    }
}