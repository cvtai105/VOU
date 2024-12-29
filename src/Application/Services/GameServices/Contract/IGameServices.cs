using Application.DTOs.Game;
using Domain.Entities;

namespace Application.Services.GameServices
{
    public interface IGameServices
    {
        //no authentication required
        Task<List<Game>> GetEventGamesByGamePrototypeId(Guid id);
        Task<List<Game>> GetEventGamesByEventId(Guid eventId);

        // brand authentication required
        Task GetGameDetail(Guid gameId);
        Task<bool> AddGamesToEventAsync(CreateEventGameRequest param);
        Task<bool> StopEventGame(Guid gameId);

        // admin authentication required
    }
}
